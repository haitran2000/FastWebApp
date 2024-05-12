const template = document.createElement('template');
import { AtscadaTaskMultiModel } from '../../Core/Component/Task/atscada-task-multi-model.js'
import { AtscadaSVGView } from './atscada-svg-view.js'

export class AtscadaSVGElement extends HTMLElement {
    constructor() {
        super();
        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `<slot></slot>`;
        this.SVGAlarmItems = [];
        this.SVGCutawayItems = [];
        this.SVGItems = [];
        this.SVGItemsProperties = [];
        this.SVGItemsType = [];
        this.dataTagNames = [];
        this.dataAlarmTagNames = [];
        this.dataCutawayTagNames = [];
        this.listen();
    }
    async connectedCallback() {
        try {
            this.arrowIn = document.getElementById('arrow_in_yellow');
            this.arrowOut = document.getElementById('arrow_out_yellow');
        }
        catch { }
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
        const style = document.createElement('style');
        document.head.appendChild(style);

        // Tạo @keyframes
        const keyframes = `
            @keyframes blink-animation {
                0% { opacity: 1; }
                50% { opacity: 0; }
                100% { opacity: 1; }
            }
        `;

        // Thêm @keyframes vào style element
        style.sheet.insertRule(keyframes, 0);
        const slot = this.shadowRoot.querySelector('slot');
        slot.addEventListener('slotchange', (e) => {
            const elementsValue = document.getElementsByTagName('atscada-svgvalue-item');
            const elementsAlarm = document.getElementsByTagName('atscada-svgalarm-item');
            const elementsCutaway = document.getElementsByTagName('atscada-svgcutaway-item');
            const elementsArray = Array.from(elementsValue);
            ///
            const elementsArrayCutaway = Array.from(elementsCutaway);
            for (let i = 0; i < elementsArrayCutaway.length; i++) {
                this.dataCutawayTagNames.push(elementsArrayCutaway[i].dataTagName);
                const arr = [elementsArrayCutaway[i].content, elementsArrayCutaway[i].id2, elementsArrayCutaway[i].dataTagName, elementsArrayCutaway[i].min, elementsArrayCutaway[i].max]
                this.SVGCutawayItems.push(arr);
            }
            for (let i = 0; i < elementsArray.length; i++) {
                this.dataTagNames.push(elementsArray[i].dataTagName);
                this.SVGItems.push(elementsArray[i].content)
                this.SVGItemsProperties.push(elementsArray[i].properties)
                const typeValue = [elementsArray[i].type, elementsArray[i].speedTagName, elementsArray[i].min, elementsArray[i].max];
                this.SVGItemsType.push(typeValue)
            }
            ///
            const elementsArrayAlarm = Array.from(elementsAlarm);
            for (let i = 0; i < elementsArrayAlarm.length; i++) {
                this.dataAlarmTagNames.push(elementsArrayAlarm[i].dataLowTagName);
                this.dataAlarmTagNames.push(elementsArrayAlarm[i].dataTagName);
                this.dataAlarmTagNames.push(elementsArrayAlarm[i].dataHighTagName);
                this.SVGAlarmItems.push(elementsArrayAlarm[i].content)
            }
            this.initialize();
        });
    }
    setup() {
        this.arrowIn = document.getElementById('arrow_in_yellow');
        this.arrowOut = document.getElementById('arrow_out_yellow');
    }
    initialize() {
        this.model = new AtscadaTaskMultiModel(this);
        this.view = new AtscadaSVGView(this.model, this);
        this.setup();
        this.model.initialize();
        this.view.initialize();
    }
}

customElements.define('atscada-svg', AtscadaSVGElement);