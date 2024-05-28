
export class AtscadaSVGControlValueItemElement extends HTMLElement {
    constructor() {
        super();

        this.content = 'SVGValue Item';
        this.dataTagName = 'TaskName.TagName';
        this.type = '';
        this.atribute = '';
    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.type = this.getAttribute('at-type') || this.type;
        this.atribute = this.getAttribute('at-atribute') || this.atribute;
    }   
}
customElements.define('atscada-svgcontrolvalue-item', AtscadaSVGControlValueItemElement);