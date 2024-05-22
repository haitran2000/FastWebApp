
export class AtscadaSVGValueItemElement extends HTMLElement {
    constructor() {
        super();

        this.content = 'SVGValue Item';
        this.dataTagName = 'TaskName.TagName';
        this.min = '0';
        this.max = '100';
        this.id2 = '100';
    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.min = this.getAttribute('at-min') || this.min;
        this.max = this.getAttribute('at-max') || this.max;
        this.id2 = this.getAttribute('at-id2') || this.id2;
    }   
}
customElements.define('atscada-svgcutaway-item', AtscadaSVGValueItemElement);