
export class AtscadaSVGHyperLinkItemElement extends HTMLElement {
    constructor() {
        super();

        this.content = 'SVGValue Item';
        this.dataTagName = 'TaskName.TagName';
        this.type = '';
        this.color = '';
    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.type = this.getAttribute('at-type') || this.type;
        this.color = this.getAttribute('at-color') || this.color;
    }   
}
customElements.define('atscada-svghyperlink-item', AtscadaSVGHyperLinkItemElement);