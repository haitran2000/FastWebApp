
const template = document.createElement('template');
template.innerHTML = `
    <atscada-widget></atscada-widget>
`;

import { } from './../../Core/Component/Widget/atscada-widget-element.js'
import { AtscadaTaskModel } from '../../Core/Component/Task/atscada-task-model.js'
import { AtscadaCardView } from './atscada-card-view.js'

export class AtscadaCardElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        // Widget hien thi
        this.widget = this.querySelector('atscada-widget');
        // TagName
        this.dataTagName = 'TaskName.TagName';
        // Tieu de hien thi
        this.content = 'Card';
        // Mau sac background
        this.color = '#00acac';
        // Icon
        this.icon = 'fa fa-globe fa-fw';
        // So chu so thap phan lam tron, neu la so
        this.decimalPlaces = 2;          
    }
    
    connectedCallback() {
        // get data tu attribute
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.content = this.getAttribute('at-content') || this.content;
        this.color = this.getAttribute('at-color') || this.color;
        this.icon = this.getAttribute('at-icon') || this.icon;       
        this.decimalPlaces = this.getAttribute('at-decimal-places') || this.decimalPlaces;       

        // Khai bao MVC
        // Doi voi cac Component realtime ket noi du lieu voi Tag thi ...
        // Model chinh la Tag
        this.model = new AtscadaTaskModel(this);
        this.view = new AtscadaCardView(this.model, this);

        this.model.initialize();
        this.view.initialize();
    }

    disconnectedCallback() {       
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
}

customElements.define('atscada-card', AtscadaCardElement);