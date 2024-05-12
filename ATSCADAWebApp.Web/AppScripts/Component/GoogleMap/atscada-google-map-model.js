
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'
import { AtscadaGoogleMapParam } from '../../Core/GoogleMap/atscada-google-map-param.js'
import { AtscadaGoogleMapService } from '../../Core/GoogleMap/atscada-google-map-service.js'

export class AtscadaGoogleMapModel {
    constructor(element) {
        this.element = element;
        this.inforItems = this.element.markerItems;
        this.dateRangePickerElement = element.dateRangePickerElement;
        this.googleMapService = new AtscadaGoogleMapService(element.timeout);
        this.dispatcher = new AtscadaDispatcher();
    }

    async loadDatabase() {

        var result = [];
        for (const item of this.inforItems) {
            var data = new AtscadaGoogleMapParam(
                this.element.id,
                this.element.content,
                this.element.connection,
                item.table,
                this.dateRangePickerElement.startDate,
                this.dateRangePickerElement.endDate
            );

            var getData = await this.googleMapService.loadDatabase(data);
            result.push({
                Data: getData
            });
        }
        
        return result;
    }

    dispose() { }
}
