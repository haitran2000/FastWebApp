
const template = document.createElement('template');
template.innerHTML = `            
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-switch-content panel-title">Control</h4>        
    </div>
    <div class="panel-toolbar">
        <div class="form-group row">
            <span>Status: <strong class="atscada-switch-status">---</strong></span>
        </div>
    </div>
    <div class="panel-body">
        <atscada-switchery></atscada-switchery>        
    </div>
</div>
`;

import { } from '../../Core/Component/Switchery/atscada-switchery-element.js'
import { AtscadaTaskModel } from '../../Core/Component/Task/atscada-task-model.js'
import { AtscadaSwitchView } from './atscada-switch-view.js'
import { AtscadaSwitchController } from './atscada-switch-controller.js'

class AtscadaSwitchElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        // Tieu de hien thi
        this.contentElement = this.querySelector('.atscada-switch-content');
        // switch
        this.switchElement = this.querySelector('atscada-switchery');
        // Status: Good/Bad
        this.statusElement = this.querySelector('.atscada-switch-status');
        // Tieu de
        this.content = 'Control';
        // TgaName
        this.dataTagName = '.';
        this.color = '#008080';
        this.size = 'default';
        this.valueOn = '1';
        this.valueOff = '0';
    }

    async connectedCallback() {
        // load data tu attribute
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.color = this.getAttribute('at-color') || this.color;
        this.size = this.getAttribute('at-size') || this.size;
        this.valueOn = this.getAttribute('at-value-on') || this.valueOn;
        this.valueOff = this.getAttribute('at-value-off') || this.valueOff;

         // Khai bao MVC
        // * Voi cac component khai bao su dung Tag
        // Model chinh la Task-Tag
        this.model = new AtscadaTaskModel(this);
        this.view = new AtscadaSwitchView(this.model, this);
        this.controller = new AtscadaSwitchController(this.model, this.view);

        this.model.initialize();
        await this.view.initialize();
        this.controller.initialize();
    }

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
}

customElements.define('atscada-switch', AtscadaSwitchElement);