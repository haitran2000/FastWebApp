
const template = document.createElement('template');
template.innerHTML = `              
<div>

</div>
`;

import { AtscadaTaskMultiModel } from '../../Core/Component/Task/atscada-task-multi-model.js'
import { AtscadaPIDStationController } from './atscada-pid-controller.js';
import { AtscadaPIDStationView } from './atscada-pid-view.js';

export class AtscadaPIDStationElement extends HTMLElement {
    constructor() {
        super();
        this.pressure1 = '.';
        this.pressure2 = '.';
        this.pressure3 = '.';
        this.pressure4 = '.';
        this.highalarmvalue1 = '.';
        this.highalarmvalue2 = '.';
        this.highalarmvalue3 = '.';
        this.highalarmvalue4 = '.';
        this.lowalarmvalue1 = '.';
        this.lowalarmvalue2 = '.';
        this.lowalarmvalue3 = '.';
        this.lowalarmvalue4 = '.';
        this.dataTagNames = [];
    }

    async connectedCallback() {
        try {
            this.content = this.getAttribute('at-content') || this.content;
            this.pressure1 = this.getAttribute('at-pressure-1') || this.pressure1;
            this.pressure2 = this.getAttribute('at-pressure-2') || this.pressure2;
            this.pressure3 = this.getAttribute('at-pressure-3') || this.pressure3;
            this.pressure4 = this.getAttribute('at-pressure-4') || this.pressure;
            this.highalarmvalue1 = this.getAttribute('at-highalarm-1') || this.highalarmvalue1;
            this.highalarmvalue2 = this.getAttribute('at-highalarm-2') || this.highalarmvalue2;
            this.highalarmvalue3 = this.getAttribute('at-highalarm-3') || this.highalarmvalue3;
            this.highalarmvalue4 = this.getAttribute('at-highalarm-4') || this.highalarmvalue4;
            this.lowalarmvalue1 = this.getAttribute('at-lowalarm-1') || this.lowalarmvalue1;
            this.lowalarmvalue2 = this.getAttribute('at-lowalarm-2') || this.lowalarmvalue2;
            this.lowalarmvalue3 = this.getAttribute('at-lowalarm-3') || this.lowalarmvalue3;
            this.lowalarmvalue4 = this.getAttribute('at-lowalarm-4') || this.lowalarmvalue4;
            this.arrowIn = document.getElementById('arrow_in_yellow');
            this.arrowOut = document.getElementById('arrow_out_yellow');
            this.backPressure1 = document.getElementById('back_pressure_1');
            this.backPressure2 = document.getElementById('back_pressure_2');
            this.dataTagNames.push(this.pressure1); // 1
            this.dataTagNames.push(this.pressure2); // 2
            this.dataTagNames.push(this.pressure3); // 3
            this.dataTagNames.push(this.pressure4); // 3
            this.dataTagNames.push(this.highalarmvalue1); // 1
            this.dataTagNames.push(this.highalarmvalue2); // 2
            this.dataTagNames.push(this.highalarmvalue3); // 3
            this.dataTagNames.push(this.highalarmvalue4); // 3
            this.dataTagNames.push(this.lowalarmvalue1); // 1
            this.dataTagNames.push(this.lowalarmvalue2); // 2
            this.dataTagNames.push(this.lowalarmvalue3); // 3
            this.dataTagNames.push(this.lowalarmvalue4); // 3

            // if host on cloud server; root = "/GasSupply/SVGFile/";
            // if host on built PC; root = root = "../../SVGFile/";
            var root = "/SVGFile/";
            var path = root.concat("Layout1", ".txt");
            var svgText = await this.readTextFile(path);
            const template = document.createElement('template');
            template.innerHTML = `              
                <div style="background-color:rgb(170,170,170);width: 1245px;">
                    ${svgText}
                </div>
                `;
            const clone = document.importNode(template.content, true);
            this.appendChild(clone);

            this.setup();
            this.model = new AtscadaTaskMultiModel(this);
            this.view = new AtscadaPIDStationView(this.model, this);
            this.controller = new AtscadaPIDStationController(this.view);

            this.model.initialize();
            this.view.initialize();
            this.controller.initialize();
        }
        catch { }
    }

    readTextFile(file) {

        return new Promise(function (resolve, reject) {
            var xhr = new XMLHttpRequest();
            xhr.open("GET", file, false);           
            xhr.onload = function () {
                var status = xhr.status;
                if (status == 200) {
                    resolve(xhr.responseText);
                } else {
                    reject(status);
                }
            };
            xhr.send();
        });
    }

    setup() {

        this.pressure1Text = document.getElementById('value_pressure_1');
        this.pressure2Text = document.getElementById('value_pressure_2');
        this.pressure3Text = document.getElementById('value_pressure_3');
        this.pressure4Text = document.getElementById('value_pressure_4');
        this.arrowIn = document.getElementById('arrow_in_yellow');
        this.arrowOut = document.getElementById('arrow_out_yellow');
        this.backPressure1 = document.getElementById('back_pressure_1');
        this.backPressure2 = document.getElementById('back_pressure_2');
        this.logo = document.getElementById('logo');
        this.titleUp = document.getElementById('title_station_up');
        this.titleDown = document.getElementById('title_station_down');
        this.date = document.getElementById('date');
        this.time = document.getElementById('time');       
    }

    disconnectedCallback() {

        if (this.controller)
            this.controller.dispose();
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
}

customElements.define('atscada-pid-station', AtscadaPIDStationElement);