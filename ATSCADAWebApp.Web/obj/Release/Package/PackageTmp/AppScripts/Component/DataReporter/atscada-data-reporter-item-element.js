
// Truong (filed) du lieu report
// La cac cot trong table dataLog
export class AtscadaDataReporterItemElement extends HTMLElement {    
    constructor() {
        super();

        // Filed name
        this.alias = 'Alias';
        // Color. Mau nen cua Table + Chart excel
        this.color = '#FFFFFF';
    }

    connectedCallback() {
        this.alias = this.getAttribute('at-alias') || this.alias;
        this.color = this.getAttribute('at-color') || this.color;
    }

    get param() {
        return {
            alias: this.alias,
            color: this.color
        };
    }
}

customElements.define('atscada-data-reporter-item', AtscadaDataReporterItemElement);