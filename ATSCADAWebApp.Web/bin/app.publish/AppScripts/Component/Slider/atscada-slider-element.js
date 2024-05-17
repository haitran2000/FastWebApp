
const template = document.createElement('template');
template.innerHTML = `            
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-slider-content panel-title">Control</h4>        
    </div>
    <div class="panel-toolbar">
        <div class="form-group row">
            <span>Status: <strong class="atscada-slider-status">---</strong></span>
        </div>
    </div>
    <div class="panel-body">
        <atscada-ion-range-slider class="is-valid"></atscada-ion-range-slider>
    </div>
</div>
`;

import { } from '../../Core/Component/IonRangeSlider/atscada-ion-range-slider-element.js'
import { AtscadaTaskModel } from '../../Core/Component/Task/atscada-task-model.js'
import { AtscadaSliderView } from './atscada-slider-view.js'
import { AtscadaSliderController } from './atscada-slider-controller.js'

class AtscadaSliderElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        
        this.contentElement = this.querySelector('.atscada-slider-content');
        this.sliderElement = this.querySelector('atscada-ion-range-slider');
        this.statusElement = this.querySelector('.atscada-slider-status');

        this.content = 'Slider';
        this.dataTagName = 'TaskName.TagName';
        this.min = 0;
        this.max = 100;
        this.step = 0.1;
        this.skin = 'big';       
    }

    async connectedCallback() {
        // Load data tu attribute
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.min = this.getAttribute('at-min') || this.min;
        this.max = this.getAttribute('at-max') || this.max;
        this.step = this.getAttribute('at-step') || this.step;
        this.skin = this.getAttribute('at-skin') || this.skin;

        // Khai bao MVC
        // * Voi cac component khai bao su dung Tag
        // Model chinh la Task-Tag
        this.model = new AtscadaTaskModel(this);
        this.view = new AtscadaSliderView(this.model, this);
        this.controller = new AtscadaSliderController(this.model, this.view);

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

customElements.define('atscada-slider', AtscadaSliderElement);