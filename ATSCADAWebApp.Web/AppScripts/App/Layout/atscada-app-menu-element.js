
const template = document.createElement('template');
template.innerHTML = `
<div class="menu">
    <div class="menu-profile">
        <div class="menu-profile-cover with-shadow"></div>
        <div class="menu-profile-image menu-profile-image-icon bg-gray-900 text-gray-600">
            <i class="fa fa-user"></i>
        </div>
        <div class="menu-profile-info">
            <div class="d-flex align-items-center">
                <div class="atscada-user-name flex-grow-1">
                    Admin
                </div>
            </div>
        </div>
    </div>
    <div class="menu-header">Navigation</div>
    <div class="menu-item d-flex">
        <a href="javascript:;" class="app-sidebar-minify-btn ms-auto" data-toggle="app-sidebar-minify"><i class="fa fa-angle-double-left"></i></a>
    </div>
</div>
`;

import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'


// Bang menu - siderBar
export class AtscadaAppMenuElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.menuElement = this.querySelector('.menu');
        this.sidebarMinifyElement = this.querySelector('.menu-item');
        this.userNameElement = this.querySelector('.atscada-user-name');

        this.location = undefined;
        this.appViews = [];        
        this.dispatcher = new AtscadaDispatcher();
    }

    get userName() {
        return this.userNameElement.innerHTML;
    }

    set userName(value) {
        this.userNameElement.innerHTML = value;
    }

    disconnectedCallback() {
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    // Them moi View. Add them button hien thi trne bang Menu
    // Moi view se tuong ung mot nut button
    addView(appView) {
        const location = appView.location;
        const menuItem = appView.menuItem;
        // Su kien click nvao nutMenu tren bang Menu
        menuItem.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();           
            if (this.location === location) return;
            this.onEventMenuItemClicked(location);
        });        
        this.appViews.push(appView);
        this.menuElement.insertBefore(menuItem, this.sidebarMinifyElement);
    }

    // Set hien thi cho View, Button Menu
    active(location) {
        if (this.location === location) return;        
        this.location = location;
        for (const appView of this.appViews) {
            appView.active = appView.location === location;
        }       
    }
   
    onEventMenuItemClicked(location) {
        if (this.location === location) return;
        this.dispatcher.dispatch('menuItemClicked', {
            sender: this,
            e: {
                location: location               
            }
        });
    }
}

customElements.define('atscada-app-menu', AtscadaAppMenuElement);