
export class AtscadaGoogleMapController {
    constructor(model, view, markers) {
        this.model = model;
        this.view = view;
        this.markers = markers;
    }

    initialize() {
        this.view.dispatcher.on('historyButtonClicked', async () => await this.actionHistoryButtonClicked());
        for (var marker of this.markers) {
            marker.dispatcher.on('fitBounds', async () => await this.actionFitBoundsGoogleMap());
        }
    }

    async actionHistoryButtonClicked() {       
        var result = await this.model.loadDatabase();
        await this.view.initHistory(result);
    }

    async actionFitBoundsGoogleMap() {
        await this.view.showRealtimeLayers();
    }

    dispose() { }
}
