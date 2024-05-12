
const template = document.createElement('template');
template.innerHTML = `
   <canvas id="myGauge"></canvas>
`;

import { } from '../../Core/Component/Widget/atscada-widget-element.js'
import { AtscadaTaskModel } from '../../Core/Component/Task/atscada-task-model.js'
import { AtscadaGaugeView } from './atscada-gauge-view.js'
import { Gauge } from './gauge.js';
export class AtscadaGaugeElement extends HTMLElement {
    constructor() {
        super();
        var gauge = new Gauge(document.getElementById("myGauge"));

        gauge.setOptions({
            angle: 0.15, // Góc quét của vòng cung
            lineWidth: 0.4, // Độ dày của đường viền
            radiusScale: 1.0, // Kích thước của đồng hồ đo
            pointer: {
                length: 0.6, // Chiều dài kim đồng hồ
                strokeWidth: 0.035, // Độ dày kim đồng hồ
                color: '#000000' // Màu sắc kim đồng hồ
            },
            limitMax: false, // Cho phép giá trị vượt quá giá trị tối đa
            limitMin: false, // Cho phép giá trị thấp hơn giá trị tối thiểu
            colorStart: '#A01313', // Màu sắc bắt đầu của vòng cung
            colorStop: '#0D14DB', // Màu sắc kết thúc của vòng cung
            strokeColor: '#EEEEEE', // Màu sắc viền ngoài của đồng hồ đo
            generateGradient: true, // Tạo hiệu ứng chuyển màu cho vòng cung
            highDpiSupport: true, // Hỗ trợ màn hình độ phân giải cao
        });

        gauge.maxValue = 100; // Giá trị tối đa
        gauge.setMinValue(0); // Giá trị tối thiểu
        gauge.animationSpeed = 32; // Tốc độ chuyển động kim đồng hồ

        gauge.set(50); // Giá trị hiện tại
    }
    
    connectedCallback() {
        this.model = new AtscadaTaskModel(this);
        this.view = new AtscadaGaugeView(this.model, this);

        this.model.initialize();
        this.view.initialize();
    }

}

customElements.define('atscada-agauge', AtscadaGaugeElement);