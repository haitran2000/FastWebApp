
import { AtscadaAppRouter } from './Router/atscada-app-router.js'
import { AtscadaDispatcher } from '../Core/Common/atscada-dispatcher.js'

// Thgong bao cho View biet khi co su kien dieu huong
// Co 2 hanh dong:
// 1. Click button tren menuBar\
// 2. Thay doi #hash tren duong link Url (Back, Next, Type,...)
export class AtscadaAppModel {
    constructor(element) {
        // dam nhan dieu phoi cac View
        this.router = new AtscadaAppRouter(element.url, element.timeout);
        this.dispatcher = new AtscadaDispatcher();          
    }

    initialize() {
        this.router.initialize();
        // Khi co su kien Navigated thong bao thay doi View ----> Thong bao cho View de cap nhat moi giao dien
        this.router.dispatcher.on('navigated', (data) => this.actionNavigated(data))
    }

    async navigate(location) {
        await this.router.navigate(location);
    }

    actionNavigated(data) {
        this.dispatcher.dispatch('viewChanged', data);
    }

    dispose() { }
}