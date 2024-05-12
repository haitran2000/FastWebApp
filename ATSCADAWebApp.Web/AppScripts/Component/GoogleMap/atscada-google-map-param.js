
export class AtscadaParamItemElement extends HTMLElement {
    constructor() {
        super();

        this.alias = 'Param Item';
        this.paramTagName = 'TaskName.TagName';       
    }

    connectedCallback() {
        this.alias = this.getAttribute('at-alias') || this.alias;
        this.paramTagName = this.getAttribute('at-param-tag-name') || this.paramTagName;
    }   
}

customElements.define('atscada-param-item', AtscadaParamItemElement);