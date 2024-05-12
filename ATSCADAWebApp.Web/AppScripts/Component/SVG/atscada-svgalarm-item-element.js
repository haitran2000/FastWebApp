
export class AtscadaSVGAlarmItemElement extends HTMLElement {
    constructor() {
        super();

        this.content = 'SVGValue Item';
        this.dataTagName = 'TaskName.TagName';
        this.dataLowTagName = 'TaskName.TagName';
        this.dataHighTagName = 'TaskName.TagName';

    }

    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.dataTagName = this.getAttribute('at-data-tag-name') || this.dataTagName;
        this.dataLowTagName = this.getAttribute('at-data-low-tag-name') || this.dataLowTagName;
        this.dataHighTagName = this.getAttribute('at-data-hight-tag-name') || this.dataHighTagName;
    }   
}

customElements.define('atscada-svgalarm-item', AtscadaSVGAlarmItemElement);