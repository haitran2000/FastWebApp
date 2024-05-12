
export class AtscadaChartView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
    }

    initialize() {
        const dataTask = this.model.dataTask;
        if (dataTask) {
            dataTask.dispatcher.on('refreshed', (data) => this.actionRefreshed(data));
        }
    }

    actionRefreshed(data) {
        const itemModels = [];
        const time = data.e.timeStamp.getTime();
        for (const dataTag of this.model.dataTags) {
            itemModels.push({
                time: time,
                value: this.getChartValue(dataTag.status, dataTag.value)
            });
        }
        this.element.chartElement.update(itemModels);
    }

    getChartValue(status, value) {        
        if (!isNaN(parseFloat(value)) && !isNaN(value - 0) && status === 'Good')
            return Number(value);
        return null;       
    }

    dispose() { }
}