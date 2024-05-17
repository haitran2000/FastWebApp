
// Nhan thong bao tu View
// Cap nhat Model
export class AtscadaAppController {
    constructor(model, view) {
        this.model = model;
        this.view = view;
        this.locatiton = undefined;
    }

    initialize() {
        // Khi view co thay doi ve Location (Click button menu)
        // Thong bao cho Model.
        this.view.dispatcher.on('locationChanged', async (data) => await this.actionLocationChanged(data.e.location));
    }

    async actionLocationChanged(location) {
        if (this.locatiton === location) return;
        await this.model.navigate(location);
    }
   
    dispose() { }
}