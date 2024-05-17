
const template = document.createElement('template');
template.innerHTML = `            
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-input-content panel-title">Control</h4>
    </div>   
    <div class="panel-body">
        <div class="input-group">
            <input type="text" class="atscada-input-textbox form-control text-center is-valid" />
            <button type="button" class="atscada-input-button btn btn-success">Update</button>
        </div>
    </div>
</div>
`;

import { AtscadaTaskModel } from '../../Core/Component/Task/atscada-task-model.js'
import { AtscadaInputView } from './atscada-input-view.js'
import { AtscadaInputController } from './atscada-input-controller.js'


// Component input, nhap/ghi du lieu xuong Tag
class AtscadaInputElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        // Tieu de hien thi
        this.contentElement = this.querySelector('.atscada-input-content');
        // O textBox  nhap du lieu
        this.textBoxElement = this.querySelector('.atscada-input-textbox');
        // Button write. Ghi click se ghi gia tri tu o textBox xuong tag
        this.buttonElement = this.querySelector('.atscada-input-button');
        this.content = 'Input';
        // TagName
        this.dataTagName = '.';
    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;

        // Khai bao MVC
        this.model = new AtscadaTaskModel(this);
        this.view = new AtscadaInputView(this.model, this);
        this.controller = new AtscadaInputController(this.model, this.view);

        this.model.initialize();
        this.view.initialize();
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

customElements.define('atscada-input', AtscadaInputElement);