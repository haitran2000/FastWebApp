
const template = document.createElement('template');
template.innerHTML = `
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-chart-content panel-title">- - -</h4>
        <!--<div class="panel-heading-btn">
            <a href="javascript:;" aria-label="ATSCADA" class="btn btn-xs btn-icon btn-default" data-toggle="panel-expand" data-tooltip-init="true"><i class="fa fa-expand"></i></a>
            <a href="javascript:;" aria-label="ATSCADA" class="btn btn-xs btn-icon btn-warning" data-toggle="panel-collapse" data-tooltip-init="true"><i class="fa fa-minus"></i></a>
        </div>-->
    </div>
    <div class="panel-body pe-1">
        <atscada-nvd3-chart></atscada-nvd3-chart>
    </div>
</div>
`;

import { AtscadaChartItemElement } from './atscada-chart-item-element.js'
import { AtscadaNvd3ChartElement } from '../../Core/Component/Nvd3Chart/atscada-nvd3-chart-element.js'
import { AtscadaTaskMultiModel } from '../../Core/Component/Task/atscada-task-multi-model.js'
import { AtscadaChartView } from './atscada-chart-view.js'

export class AtscadaChartElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `<slot></slot>`;
     
        this.contentElement = this.querySelector('.atscada-chart-content');
        this.chartElement = this.querySelector('atscada-nvd3-chart');
        this.content = 'Chart';
        this.type = 'line';
        this.height = '200px';
        this.sampleNum = 50;
        this.xlabel = 'Time';
        this.ylabel = 'Value';
        this.chartItems = [];
        this.dataTagNames = [];

        this.listen();
    }

    connectedCallback() {
        
        this.content = this.getAttribute('at-content') || this.content;
        this.type = this.getAttribute('at-type') || this.line;
        this.height = this.getAttribute('at-height') || this.height;
        this.sampleNum = Number(this.getAttribute('at-sample-num')) || this.sampleNum;
        this.xlabel = this.getAttribute('at-xlabel') || this.xlabel;
        this.ylabel = this.getAttribute('at-ylabel') || this.ylabel;

        this.contentElement.innerHTML = this.content;      
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

    listen() {
        const slot = this.shadowRoot.querySelector('slot');
        slot.addEventListener('slotchange', (e) => {
            const itemElements = e.target.assignedElements();
            itemElements.forEach((itemElement) => {
                if (itemElement instanceof AtscadaChartItemElement) {
                    this.dataTagNames.push(itemElement.dataTagName);
                    this.chartItems.push({
                        content: itemElement.content,
                        color: itemElement.color                        
                    });                    
                }
            });
            this.initialize();                
        });
    }

    initialize() {
        if (this.chartElement instanceof AtscadaNvd3ChartElement) {
            this.chartElement.height = this.height;
            this.chartElement.setup({
                type: this.type,
                height: this.height,
                sampleNum: this.sampleNum,
                xlabel: this.xlabel,
                ylabel: this.ylabel,
                items: this.chartItems
            });
        }

        this.model = new AtscadaTaskMultiModel(this);
        this.view = new AtscadaChartView(this.model, this);

        this.model.initialize();
        this.view.initialize();
    }
}

customElements.define('atscada-chart', AtscadaChartElement);