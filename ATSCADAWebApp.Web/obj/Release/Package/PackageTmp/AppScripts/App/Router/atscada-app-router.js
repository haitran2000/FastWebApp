
import { AtscadaAppRouterService } from './atscada-app-router-service.js'
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

// Router quan ly dieu huong trang qua #hash
export class AtscadaAppRouter {
    constructor(url, timeout = 3000) {
        this.service = new AtscadaAppRouterService(timeout);
        this.url = url;
        this.dispatcher = new AtscadaDispatcher();
        this.isUpdating = false;        
    }

    initialize() {
        // khi co su thay doi cua #hash tren URL thi thong bao dieu huong trang
        window.addEventListener('hashchange', async () => {
            var hash = window.location.hash;
            const location = hash.substring(hash.indexOf('#/') + 2);
            await this.navigate(location, false);
        });

        window.addEventListener('load', (e) => {
            // load lan dau thi cap nhat #hash (trang hien thi ban dau)
            // ... la dia chi gan nhat duoc luu tron lich su trinh duyet
            if (history.state)
                window.location.hash = `/${history.state.lastLocation}`;
        });
    }

    // Dieu huong. Thong bao su kien co su thay doi #hash -> dieu huong trang
    // Push location hien tai vao danh sach nho cua tirnh duyet
    // ... Phuc vu cho tinh nang NAEXT - BACK
    async navigate(location, allowPushState = true) {
        if (this.isUpdating) return;
        this.isUpdating = true;
        const view = await this.service.getView(location);
        this.onEventNavigated(location, view);
        if (allowPushState)
            history.pushState({ lastLocation: location }, null, `${this.url}#/${location}`);        
        this.isUpdating = false;
    }

    onEventNavigated(location, view) {
        
        this.dispatcher.dispatch('navigated', {
            sender: this,
            e: {
                location: location,
                view: view
            }
        });
    }
}