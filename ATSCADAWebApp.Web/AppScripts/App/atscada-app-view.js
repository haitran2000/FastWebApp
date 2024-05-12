import { AtscadaDispatcher } from '../Core/Common/atscada-dispatcher.js'

// quan ly cac su kien, thao tac tren UI -> thong bao cho Controller
// Cap nhat gaio dien hien thi khi co thong bao tu Model
export class AtscadaAppView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.appHeaderElement = element.appHeaderElement;
        this.appMenuElement = element.appMenuElement;
        this.appContentElement = element.appContentElement;
        this.dispatcher = new AtscadaDispatcher();
    }

    initialize() {
        this.appHeaderElement.brand = this.element.brand;
        // Moel thong bao view thay doi ---> thay doi giao dien View hien thi 
        // ... call ham actionViewChanged
        this.model.dispatcher.on('viewChanged', (data) => this.actionViewChanged(data));
        // khi so su kien bam chon tren bang menu (sideBar) -> thong bao cho Controller biet...
        // ... view (co dia chi location) nao vua duoc Click
        this.appMenuElement.dispatcher.on('menuItemClicked', (data) => this.dispatcher.dispatch('locationChanged', data));
    }

    actionViewChanged(data) {
        // set active. To mau highLight cho background button dai dien cho View dang hien thi
        this.appMenuElement.active(data.e.location);
        // Xoa View cu...
        this.appContentElement.clear();
        // ... Cap nhat View moi
        this.appContentElement.render(data.e.view);
    }    

    dispose() { }
}