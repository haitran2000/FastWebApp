
export class AtscadaSVGValueItemElement extends HTMLElement {
    constructor() {
        super();

        this.content = 'SVGValue Item';
        this.dataTagName = 'TaskName.TagName';
        this.properties='Value'
        this.type='Type'
        this.speedTagName ='TaskName.TagName'
        this.min='0'
        this.max='100'
    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.properties = this.getAttribute('at-properties') || this.properties;
        this.type = this.getAttribute('at-type') || this.type;
        this.speedTagName = this.getAttribute('at-speed') || this.type;
        this.min = this.getAttribute('at-min') || this.min;
        this.max = this.getAttribute('at-max') || this.max;
    }   
}
customElements.define('atscada-svgvalue-item', AtscadaSVGValueItemElement);