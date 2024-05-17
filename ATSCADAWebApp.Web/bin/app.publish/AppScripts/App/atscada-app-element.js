
const template = document.createElement('template');
template.innerHTML = `
<div class="pace pace-inactive">
    <div class="pace-progress" data-progress-text="100%" data-progress="99" style="transform: translate3d(100%, 0px, 0px);">
        <div class="pace-progress-inner"></div>
    </div>
    <div class="pace-activity"></div>
</div>
<div id="loader" class="app-loader loaded">
    <div class="material-loader">
        <svg class="circular" viewBox="25 25 50 50">
            <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="2" stroke-miterlimit="10"></circle>
        </svg>
        <div class="message">Loading...</div>
    </div>
</div>
<div id="app" class="app app-header-fixed app-sidebar-fixed app-sidebar-minified">
    <atscada-app-header at-brand="Monitoring System"></atscada-app-header>
    <div id="sidebar" class="app-sidebar" data-disable-slide-animation="true">
        <div class="app-sidebar-content" data-scrollbar="true" data-height="100%">
            <atscada-app-menu></atscada-app-menu>
        </div>
    </div>
    <div class="app-sidebar-bg"></div>
    <div class="app-sidebar-mobile-backdrop"><a href="#" data-dismiss="app-sidebar-mobile" class="stretched-link"></a></div>
    <atscada-app-content></atscada-app-content>
    <a href="javascript:;" class="btn btn-icon btn-circle btn-success btn-scroll-to-top" data-toggle="scroll-to-top"><i class="fa fa-angle-up"></i></a>
</div>
`;

const cssUrls =
    [
        
    ]

const scriptUrls =
    [
        '/AppTemplate/js/vendor.min.js',
        '/AppTemplate/js/app.min.js',
        '/AppTemplate/js/theme/material.min.js'
    ]

import { AtscadaImporter } from '../Core/Common/atscada-importer.js'
import { AtscadaFetchService } from '../Core/Common/atscada-fetch-service.js'
import { } from './Layout/atscada-app-header-element.js'
import { } from './Layout/atscada-app-menu-element.js'
import { } from './Layout/atscada-app-content-element.js'
import { AtscadaAppViewElement } from './View/atscada-app-view-element.js'
import { AtscadaAppModel } from './atscada-app-model.js'
import { AtscadaAppView } from './atscada-app-view.js'
import { AtscadaAppController } from './atscada-app-controller.js'

let importer;

// Xay dung FastWeb theo co che SinglePage
// 1 Container duy nhat. Khi dieu huong sang cac View/Page khac nhau....
// La cap nhat, ghi de Content vao Container

export class AtscadaAppElement extends HTMLElement {
    constructor() {
        super();
        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        // Cau truc cua 1 app se bao gom 3 phan
        // 1. App header: Thanh tieu de, hien thi cac thong tin (Brand, User, Login-action, DarkMode-action)
        // 2. App menu: Bang menu (sideBar) dieu huong View
        // 3. App content: La khung chung. Chua phan tu con la View. Khi dieu huong, se xoa View hien tai, thay the bang View moi (update content)
        this.appHeaderElement = this.querySelector('atscada-app-header');
        this.appMenuElement = this.querySelector('atscada-app-menu');
        this.appContentElement = this.querySelector('atscada-app-content');

        // Co yeu cau dang nhap hat khong. Neu khong thi dieu huong truc tiep voi Home
        this.appAuthenticationRequired = 'true';
        // Tai khoan nguoi dung - duoc login
        this.userName = 'Admin';
        // Url trang web
        this.url = window.location.origin;
        // Url
        this.brand = "ATSCADA";
        this.timeout = 30000;
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `<slot></slot>`;
        // Lang nghe su thay doi cua cac Slot
        // Khi co bat ky 1 element nao duoc add vao danh sach phan tu con Childs
        // ... su kien slotChanged se ON
        this.listen();
    }

    // Load cac file css, js
    static get importer() {
        if (!importer) {
            importer = new AtscadaImporter();
            importer.addCss(cssUrls);
            importer.addScript(scriptUrls);
        }
        return importer;
    }

    // * Ham chay sau khi pha tu Element duoc them vao trinh duyet
    // Get cac thuoc tinh thong qua attribute
    connectedCallback() {
        this.brand = this.getAttribute('at-brand') || this.brand;
        this.timeout = this.getAttribute('at-timeout') || this.timeout;
        this.url = this.getAttribute('at-url') || this.url;
        this.userName = this.getAttribute('at-user-name') || this.userName;
        this.appAuthenticationRequired = this.getAttribute('at-authentication-required').toLowerCase() || this.appAuthenticationRequired;
        
        this.appMenuElement.userName = this.userName;
        // Url action logout
        this.appHeaderElement.logoutUrl = this.url + '/Home/Logout';
        this.appHeaderElement.setDisplayLogout(this.appAuthenticationRequired === 'true');
        AtscadaImporter.appLocatiton = this.url;
        AtscadaFetchService.appLocatiton = this.url;
    }

    // * Ham huy. Khi xoa, chuyen trang
    // Ham huy. Xoa tat ca phan tu con
    disconnectedCallback() {
        if (this.controller)
            this.controller.dispose();
        if (this.view)
            this.view.dispose();
        if (this.model)
            this.model.dispose();

        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    listen() {
        const slot = this.shadowRoot.querySelector('slot');
        // khi co them moi 1 slot - View duoc them vao trong danh sach con (slot)
        slot.addEventListener('slotchange', async (e) => {
            const itemElements = e.target.assignedElements();
            itemElements.forEach((itemElement) => {
                // Kiem tra phan tu them co phai la AppViewElement hay khong
                if (itemElement instanceof AtscadaAppViewElement) {
                    this.appMenuElement.addView(itemElement);
                }
            });
            const importer = AtscadaAppElement.importer;
            if (!importer.isLoaded) {
                importer.dispatcher.on('loaded', () => this.initialize());
                await importer.load();
                return;
            }
            this.initialize();
        });
    }
    
    initialize() {
        if (App) {

            // Init. Load project lan dau
            App.init();
            App.restartGlobalFunction();

            // Tao cac thanh phan MVC
            this.model = new AtscadaAppModel(this);
            this.view = new AtscadaAppView(this.model, this);
            this.controller = new AtscadaAppController(this.model, this.view);

            // Init khoi tao
            this.model.initialize();
            this.view.initialize();
            this.controller.initialize();

            // Load view mac dinh, hien thi dau tien.
            // ... Neu co luu lich su trong trinh duyet (history.state.lastLocation)
            // ... thi hien thi view duoc luu
            // ... Neu khong hien thi view dau tien trong danh sach View co quyen truy cap
            // ... danh sach khai bao sap xep theo thu tu tu tren xuong trong file Config.xml
            if (this.appMenuElement.appViews.length > 0) {
                var currentLocation = this.getCurrentLocation();
                this.appMenuElement.onEventMenuItemClicked(currentLocation);
            }
            
        }            
    }

    getCurrentLocation() {
        if (history.state) {
            if (history.state.lastLocation) {
                return history.state.lastLocation;
            }
        }

        return this.appMenuElement.appViews[0].location;
    }
}

customElements.define('atscada-app', AtscadaAppElement);