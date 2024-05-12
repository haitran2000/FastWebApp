
export class AtscadaChartItemElement extends HTMLElement {
    constructor() {
        super();

        this.content = 'Chart Item';
        this.color = '#00acac';
        this.dataTagName = 'TaskName.TagName';
    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.color = this.getAttribute('at-color') || this.color;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
    }   
}

customElements.define('atscada-chart-item', AtscadaChartItemElement);