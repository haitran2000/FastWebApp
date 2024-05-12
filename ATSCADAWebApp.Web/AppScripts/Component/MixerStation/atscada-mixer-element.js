const template = document.createElement('template');
template.innerHTML = `              
<div>

</div>
`;

import { AtscadaTaskMultiModel } from '../../Core/Component/Task/atscada-task-multi-model.js'
import { AtscadaMixerStationController } from './atscada-mixer-controller.js';
import { AtscadaMixerStationView } from './atscada-mixer-view.js';

export class AtscadaMixerStationElement extends HTMLElement {
    constructor() {
        super();
        this.pressure1 = '.';
        this.pressure2 = '.';
        this.temp1 = '.';
        this.temp2 = '.';
        this.flow1 = '.';
        this.flow2 = '.';
        this.percent = '.';
        this.pipeRatio = '.';
        this.heatTemp = '.';

        this.highpres1 = '.';
        this.lowpres1 = '.';
        this.highpres2 = '.';
        this.lowpres2 = '.';
        this.highTemp1 = '.';
        this.lowTemp1 = '.';
        this.highTemp2 = '.';
        this.lowTemp2 = '.';

        this.highflow1 = '.';
        this.lowflow1 = '.';
        this.highflow2 = '.';
        this.lowflow2 = '.';

        this.highPipeRatio = '.';
        this.lowPipeRatio = '.';
        this.highHeatTemp = '.';
        this.lowHeatTemp = '.';

        this.alarmPidTag = '.';
        this.alarmMixerTag = '.';
        this.alarmPruTag = '.';

        this.dataTagNames = [];
    }

    async connectedCallback() {
        try {
            this.content = this.getAttribute('at-content') || this.content;
            this.pressure1 = this.getAttribute('at-pressure-1') || this.pressure1;
            this.pressure2 = this.getAttribute('at-pressure-2') || this.pressure2;
            this.temp1 = this.getAttribute('at-temp-1') || this.temp1;
            this.temp2 = this.getAttribute('at-temp-2') || this.temp2;
            this.flow1 = this.getAttribute('at-flow-1') || this.flow1;
            this.flow2 = this.getAttribute('at-flow-2') || this.flow2;
            this.percent = this.getAttribute('at-percent') || this.percent;
            this.pipeRatio = this.getAttribute('at-pipe-ratio') || this.pipeRatio;
            this.heatTemp = this.getAttribute('at-heat-temp') || this.heatTemp;

            this.highpres1 = this.getAttribute('at-high-pres-1') || this.highpres1;
            this.lowpres1 = this.getAttribute('at-low-pres-1') || this.lowpres1;
            this.highpres2 = this.getAttribute('at-high-pres-2') || this.highpres2;
            this.lowpres2 = this.getAttribute('at-low-pres-2') || this.lowpres2;

            this.highTemp1 = this.getAttribute('at-high-temp-1') || this.highTemp1;
            this.lowTemp1 = this.getAttribute('at-low-temp-1') || this.lowTemp1;
            this.highTemp2 = this.getAttribute('at-high-temp-2') || this.highTemp2;
            this.lowTemp2 = this.getAttribute('at-low-temp-2') || this.lowTemp2;

            this.highflow1 = this.getAttribute('at-high-flow-1') || this.highflow1;
            this.lowflow1 = this.getAttribute('at-low-flow-1') || this.lowflow1;
            this.highflow2 = this.getAttribute('at-high-flow-2') || this.highflow2;
            this.lowflow2 = this.getAttribute('at-low-flow-2') || this.lowflow2;

            this.highPipeRatio = this.getAttribute('at-high-pipe-ratio') || this.highPipeRatio;
            this.lowPipeRatio = this.getAttribute('at-low-pipe-ratio') || this.lowPipeRatio;
            this.highHeatTemp = this.getAttribute('at-high-heat-temp') || this.highHeatTemp;
            this.lowHeatTemp = this.getAttribute('at-low-heat-temp') || this.lowHeatTemp;

            this.alarmPidTag = this.getAttribute('at-alarm-pid') || this.alarmPidTag;
            this.alarmMixerTag = this.getAttribute('at-alarm-mixer') || this.alarmMixerTag;
            this.alarmPruTag = this.getAttribute('at-alarm-pru') || this.alarmPruTag;

            this.dataTagNames.push(this.pressure1); // 1
            this.dataTagNames.push(this.pressure2); // 2
            this.dataTagNames.push(this.temp1); // 3
            this.dataTagNames.push(this.temp2);  // 4
            this.dataTagNames.push(this.flow1);  // 5
            this.dataTagNames.push(this.flow2);  // 6
            this.dataTagNames.push(this.percent);  // 7
            this.dataTagNames.push(this.pipeRatio);  // 8
            this.dataTagNames.push(this.heatTemp);  // 9
            this.dataTagNames.push(this.highpres1);  // 10
            this.dataTagNames.push(this.lowpres1);  // 11
            this.dataTagNames.push(this.highpres2); // 12
            this.dataTagNames.push(this.lowpres2);  // 13
            this.dataTagNames.push(this.highTemp1); // 14
            this.dataTagNames.push(this.lowTemp1);  // 15
            this.dataTagNames.push(this.highTemp2); // 16
            this.dataTagNames.push(this.lowTemp2);  // 17
            this.dataTagNames.push(this.highflow1); // 18
            this.dataTagNames.push(this.lowflow1);  // 19
            this.dataTagNames.push(this.highflow2); // 20
            this.dataTagNames.push(this.lowflow2);  // 21
            this.dataTagNames.push(this.alarmPidTag);    // 22
            this.dataTagNames.push(this.alarmMixerTag);  // 23
            this.dataTagNames.push(this.alarmPruTag);    // 24
            this.dataTagNames.push(this.highPipeRatio);  // 25
            this.dataTagNames.push(this.lowPipeRatio);   // 26
            this.dataTagNames.push(this.highHeatTemp);   // 27
            this.dataTagNames.push(this.lowHeatTemp);    // 28

            // if host on cloud server; root = "/GasSupply/SVGFile/";
            // if host on built PC; root = root = "../../SVGFile/";
            var root = "/SVGFile/";
            var path = root.concat("Layout3", ".txt");
            var svgText = await this.readTextFile(path);
            const template = document.createElement('template');
            template.innerHTML = `              
                <div style="background-color:rgb(170,170,170)">
                    ${svgText}
                </div>
                `;
            const clone = document.importNode(template.content, true);
            this.appendChild(clone);

            this.setup();
            this.model = new AtscadaTaskMultiModel(this);
            this.view = new AtscadaMixerStationView(this.model, this);
            this.controller = new AtscadaMixerStationController(this.view);

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
        this.temp1Text = document.getElementById('value_temp_1');
        this.temp2Text = document.getElementById('value_temp_2');

        this.flow1Text = document.getElementById('value_flow_1');
        this.flow2Text = document.getElementById('value_flow_2');

        this.pipeRatioText = document.getElementById('value_pipe');
        this.heatTempText = document.getElementById('value_heat');
        this.percentText = document.getElementById('value_ratio');

        this.arrowIn1 = document.getElementById('arrow_in_yellow1');
        this.arrowIn2 = document.getElementById('arrow_in_yellow2');
        this.arrowOut = document.getElementById('arrow_out_yellow');

        this.backPressure1 = document.getElementById('back_pressure_1');
        this.backPressure2 = document.getElementById('back_pressure_2');
        this.backTemp1 = document.getElementById('back_temp_1');
        this.backTemp2 = document.getElementById('back_temp_2');
        this.backFlow1 = document.getElementById('back_flow_1');
        this.backFlow2 = document.getElementById('back_flow_2');
        this.backPipeRatio = document.getElementById('back_pipe_ratio');
        this.backHeatTemp = document.getElementById('back_heat_temp');

        this.logo = document.getElementById('logo');
        this.alarmPID = document.getElementById('alarm_pid');
        this.alarmMixer = document.getElementById('alarm_mixer');
        this.alarmPRU = document.getElementById('alarm_pru');

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

customElements.define('atscada-mixer-station', AtscadaMixerStationElement);