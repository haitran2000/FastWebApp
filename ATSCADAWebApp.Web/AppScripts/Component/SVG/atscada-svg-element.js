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
        this.SVGHyperLinkItems = [];
        this.SVGControlValueItems = [];
        this.SVGItems = [];
        this.SVGItemsProperties = [];
        this.SVGItemsType = [];
        this.dataTagNames = [];
        this.dataAlarmTagNames = [];
        this.dataCutawayTagNames = [];
        this.dataHyperLinkTagNames = [];
        this.dataControlValueTagNames = [];
        this.listen();
    }
    listen() {
        // Tạo một <style> element và chèn vào <head> của trang
        const style = document.createElement('style');
        style.innerHTML = `
            #overlay {
                display: none; /* Ẩn overlay ban đầu */
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                background: rgba(0, 0, 0, 0.5);
            }
            #popup {
                display: none; /* Ẩn popup ban đầu */
                position: fixed;
                top: 50%;
                left: 50%;
                transform: translate(-50%, -50%);
                padding: 20px;
                border: 2px solid #fff;
                border-radius: 5px;
                background-color: #2e2828;
                box-shadow: 0 5px 15px rgba(0, 0, 0, 0.3);
                border: 1px solid #ccc;
            }
            #popup button {
                width: calc(100% - 10px);
                background-color: #40648b;
                color: #fff;
                border: none;
                padding: 3px 16px;
                border-radius: 8px;
                cursor: pointer;
            }
            #popup input[type="text"] {
                width: calc(100% - 10px);
                padding: 5px 0; /* Thay đổi giá trị padding top và bottom */
                margin-bottom: 10px;
                text-align: center;
            }
        `;
        document.head.appendChild(style);
        // Thêm HTML cho popup và overlay
        document.body.insertAdjacentHTML('beforeend', `
            <div id="overlay"></div>
            <div id="popup"></div>
        `);

        // Định nghĩa các keyframes cho animation blink-animation
        const keyframes = `
            @keyframes blink-animation {
                0% { opacity: 1; }
                50% { opacity: 0; }
                100% { opacity: 1; }
            }
        `;

        // Thêm keyframes vào <style> element đã tạo
        style.sheet.insertRule(keyframes, 0);

        // Lắng nghe sự kiện 'slotchange' của phần tử <slot> trong shadow DOM
        const slot = this.shadowRoot.querySelector('slot');
        slot.addEventListener('slotchange', (e) => {
            // Lấy các phần tử con có thẻ <atscada-svgvalue-item>, <atscada-svgalarm-item>, <atscada-svgcutaway-item>
            const elementsValue = document.getElementsByTagName('atscada-svgvalue-item');
            const elementsAlarm = document.getElementsByTagName('atscada-svgalarm-item');
            const elementsCutaway = document.getElementsByTagName('atscada-svgcutaway-item');
            const elementsLyperLink = document.getElementsByTagName('atscada-svghyperlink-item');
            const elementsControlValue = document.getElementsByTagName('atscada-svgcontrolvalue-item');

            // Chuyển đổi NodeList thành mảng
            const elementsArray = Array.from(elementsValue);
            const elementsArrayCutaway = Array.from(elementsCutaway);
            const elementsArrayAlarm = Array.from(elementsAlarm);
            const elementsArrayHyperLink = Array.from(elementsLyperLink);
            const elementsArrayControlValue = Array.from(elementsControlValue);
            // Xử lý các phần tử <atscada-svgcutaway-item>
            for (let i = 0; i < elementsArrayControlValue.length; i++) {
                // Lấy thông tin từ các phần tử và đưa vào các mảng dữ liệu của custom element
                this.dataControlValueTagNames.push(elementsArrayControlValue[i].dataTagName);
                const Arr = [elementsArrayControlValue[i].content, elementsArrayControlValue[i].dataTagName, elementsArrayControlValue[i].type, elementsArrayControlValue[i].atribute]
                this.SVGControlValueItems.push(Arr)
            }
            // Xử lý các phần tử <atscada-svgcutaway-item>
            for (let i = 0; i < elementsArrayHyperLink.length; i++) {
                // Lấy thông tin từ các phần tử và đưa vào các mảng dữ liệu của custom element
                this.dataHyperLinkTagNames.push(elementsArrayHyperLink[i].dataTagName);
                const Arr = [elementsArrayHyperLink[i].content, elementsArrayHyperLink[i].dataTagName, elementsArrayHyperLink[i].type, elementsArrayHyperLink[i].color]
                this.SVGHyperLinkItems.push(Arr)
            }
            // Xử lý các phần tử <atscada-svgcutaway-item>
            for (let i = 0; i < elementsArrayCutaway.length; i++) {
                // Lấy thông tin từ các phần tử và đưa vào các mảng dữ liệu của custom element
                this.dataCutawayTagNames.push(elementsArrayCutaway[i].dataTagName);
                const arr = [elementsArrayCutaway[i].content, elementsArrayCutaway[i].id2, elementsArrayCutaway[i].dataTagName, elementsArrayCutaway[i].min, elementsArrayCutaway[i].max]
                this.SVGCutawayItems.push(arr);
            }

            // Xử lý các phần tử <atscada-svgvalue-item>
            for (let i = 0; i < elementsArray.length; i++) {
                // Lấy thông tin từ các phần tử và đưa vào các mảng dữ liệu của custom element
                this.dataTagNames.push(elementsArray[i].dataTagName);
                this.SVGItems.push(elementsArray[i].content);
                this.SVGItemsProperties.push(elementsArray[i].properties);
                const typeValue = [elementsArray[i].type, elementsArray[i].speedTagName, elementsArray[i].min, elementsArray[i].max, elementsArray[i].attribute];
                this.SVGItemsType.push(typeValue);
            }

            // Xử lý các phần tử <atscada-svgalarm-item>
            for (let i = 0; i < elementsArrayAlarm.length; i++) {
                // Lấy thông tin từ các phần tử và đưa vào các mảng dữ liệu của custom element
                this.dataAlarmTagNames.push(elementsArrayAlarm[i].dataLowTagName);
                this.dataAlarmTagNames.push(elementsArrayAlarm[i].dataTagName);
                this.dataAlarmTagNames.push(elementsArrayAlarm[i].dataHighTagName);
                this.SVGAlarmItems.push(elementsArrayAlarm[i].content);
            }

            // Khởi tạo custom element sau khi đã lấy dữ liệu từ các phần tử con
            this.initialize();
        });

    }
    setup() {
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