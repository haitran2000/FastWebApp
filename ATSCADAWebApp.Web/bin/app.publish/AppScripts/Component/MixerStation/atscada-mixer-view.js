import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

export class AtscadaMixerStationView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();
        this.title = element.content;
        this.pressure1Text = element.pressure1Text;
        this.pressure2Text = element.pressure2Text;
        this.temp1Text = element.temp1Text;
        this.temp2Text = element.temp2Text;
        this.flow1Text = element.flow1Text;
        this.flow2Text = element.flow2Text;
        this.pipeRatioText = element.pipeRatioText;
        this.heatTempText = element.heatTempText;
        this.percentText = element.percentText;

        this.arrowIn1 = element.arrowIn1;
        this.arrowIn2 = element.arrowIn2;
        this.arrowOut = element.arrowOut;
        this.backPressure1 = element.backPressure1;
        this.backPressure2 = element.backPressure2;
        this.backTemp1 = element.backTemp1;
        this.backTemp2 = element.backTemp2;
        this.backFlow1 = element.backFlow1;
        this.backFlow2 = element.backFlow2;
        this.backPipeRatio = element.backPipeRatio;
        this.backHeatTemp = element.backHeatTemp;
        this.alarmPIDImage = element.alarmPID;
        this.alarmMixerImage = element.alarmMixer;
        this.alarmPRUImage = element.alarmPRU;

        this.logo = element.logo;
        this.date = element.date;
        this.time = element.time;
        this.titleUp = element.titleUp;
        this.titleDown = element.titleDown;

        this.count = true;
        this.alarmStationID = [0, 1, 2];
        this.alarmParamID = [0, 1, 2, 3, 4, 5, 6, 7];       
        this.show = [false, false, false];
        this.check = [false, false, false, false, false];       
    }

    initialize() {
        this.pressure1 = this.model.dataTags[0];
        this.pressure2 = this.model.dataTags[1];
        this.temp1 = this.model.dataTags[2];
        this.temp2 = this.model.dataTags[3];
        this.flow1 = this.model.dataTags[4];
        this.flow2 = this.model.dataTags[5];
        this.percent = this.model.dataTags[6];
        this.pipeRatio = this.model.dataTags[7];
        this.heatTemp = this.model.dataTags[8];
        this.highpres1 = this.model.dataTags[9];
        this.lowpres1 = this.model.dataTags[10];
        this.highpres2 = this.model.dataTags[11];
        this.lowpres2 = this.model.dataTags[12];
        this.highTemp1 = this.model.dataTags[13];
        this.lowTemp1 = this.model.dataTags[14];
        this.highTemp2 = this.model.dataTags[15];
        this.lowTemp2 = this.model.dataTags[16];
        this.highflow1 = this.model.dataTags[17];
        this.lowflow1 = this.model.dataTags[18];
        this.highflow2 = this.model.dataTags[19];
        this.lowflow2 = this.model.dataTags[20];
        this.alarmPID = this.model.dataTags[21];
        this.alarmMixer = this.model.dataTags[22];
        this.alarmPRU = this.model.dataTags[23];
        this.highPipeRatio = this.model.dataTags[24];
        this.lowPipeRatio = this.model.dataTags[25];
        this.highHeatTemp = this.model.dataTags[26];
        this.lowHeatTemp = this.model.dataTags[27];

        if (this.pressure1) {
            this.pressure1.dispatcher.on('valueChanged', (data) => this.pressure1ValueChanged(data.e.newValue));
            this.pressure1.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.pressure1ValueChanged(this.pressure1.value);
        }

        if (this.pressure2) {
            this.pressure2.dispatcher.on('valueChanged', (data) => this.pressure2ValueChanged(data.e.newValue));
            this.pressure2.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.pressure2ValueChanged(this.pressure2.value);
        }

        if (this.temp1) {
            this.temp1.dispatcher.on('valueChanged', (data) => this.temp1ValueChanged(data.e.newValue));
            this.temp1.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.temp1ValueChanged(this.temp1.value);
        }

        if (this.temp2) {
            this.temp2.dispatcher.on('valueChanged', (data) => this.temp2ValueChanged(data.e.newValue));
            this.temp2.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.temp2ValueChanged(this.temp2.value);
        }

        if (this.flow1) {
            this.flow1.dispatcher.on('valueChanged', (data) => this.flow1ValueChanged(data.e.newValue));
            this.flow1.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.flow1ValueChanged(this.flow1.value);
        }

        if (this.flow2) {
            this.flow2.dispatcher.on('valueChanged', (data) => this.flow2ValueChanged(data.e.newValue));
            this.flow2.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.flow2ValueChanged(this.flow2.value);
        }

        if (this.percent) {
            this.percent.dispatcher.on('valueChanged', (data) => this.percentValueChanged(data.e.newValue));
            this.percent.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.percentValueChanged(this.percent.value);
        }

        if (this.pipeRatio) {
            this.pipeRatio.dispatcher.on('valueChanged', (data) => this.pipeRatioValueChanged(data.e.newValue));
            this.pipeRatio.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.pipeRatioValueChanged(this.pipeRatio.value);
        }

        if (this.heatTemp) {
            this.heatTemp.dispatcher.on('valueChanged', (data) => this.heatTempValueChanged(data.e.newValue));
            this.heatTemp.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.heatTempValueChanged(this.heatTemp.value);
        }

        // Alarm Pressure 1
        if (this.pressure1 && this.highpres1 && this.lowpres1) {
            this.highpres1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pressure1.value, data.e.newValue,
                    this.lowpres1.value, this.backPressure1, 0));

            this.lowpres2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pressure1.value, this.highpres1.value,
                    data.e.newValue, this.backPressure1, 0));

            this.alarmStation(this.pressure1.value, this.highpres1.value,
                this.lowpres1.value, this.backPressure1, 0);
        }

        // Alarm Pressure 2
        if (this.pressure2 && this.highpres2 && this.lowpres2) {
            this.highpres2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pressure2.value, data.e.newValue,
                    this.lowpres2.value, this.backPressure2, 1));

            this.lowpres2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pressure2.value, this.highpres2.value,
                    data.e.newValue, this.backPressure2, 1));

            this.alarmStation(this.pressure2.value, this.highpres2.value,
                this.lowpres2.value, this.backPressure2, 1);
        }

        // Alarm Temp 1
        if (this.temp1 && this.highTemp1 && this.lowTemp1) {
            this.highTemp1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.temp1.value, data.e.newValue,
                    this.lowTemp1.value, this.backTemp1, 2));

            this.lowTemp1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.temp1.value, this.highTemp1.value,
                    data.e.newValue, this.backTemp1, 2));

            this.alarmStation(this.temp1.value, this.highTemp1.value,
                this.lowTemp1.value, this.backTemp1, 2);
        }

        // Alarm Temp 2
        if (this.temp2 && this.highTemp2 && this.lowTemp2) {
            this.highTemp2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.temp2.value, data.e.newValue,
                    this.lowTemp2.value, this.backTemp2, 3));

            this.lowTemp2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.temp2.value, this.highTemp2.value,
                    data.e.newValue, this.backTemp2, 3));

            this.alarmStation(this.temp2.value, this.highTemp2.value,
                this.lowTemp2.value, this.backTemp2, 3);
        }

        // Alarm Flow 1
        if (this.flow1 && this.highflow1 && this.lowflow1) {
            this.highflow1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.flow1.value, data.e.newValue,
                    this.lowflow1.value, this.backFlow1, 4));

            this.lowflow1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.flow1.value, this.highflow1.value,
                    data.e.newValue, this.backFlow1, 4));

            this.alarmStation(this.flow1.value, this.highflow1.value,
                this.lowflow1.value, this.backFlow1, 4);
        }

        // Alarm Flow 2
        if (this.flow2 && this.highflow2 && this.lowflow2) {
            this.highflow2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.flow2.value, data.e.newValue,
                    this.lowflow2.value, this.backFlow2, 5));

            this.lowflow2.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.flow2.value, this.highflow2.value,
                    data.e.newValue, this.backFlow2, 5));

            this.alarmStation(this.flow2.value, this.highflow2.value,
                this.lowflow2.value, this.backFlow2, 5);
        }

        // Alarm Pipe Ratio
        if (this.pipeRatio && this.highPipeRatio && this.lowPipeRatio) {
            this.highPipeRatio.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pipeRatio.value, data.e.newValue,
                    this.lowPipeRatio.value, this.backPipeRatio, 6));

            this.lowPipeRatio.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pipeRatio.value, this.highPipeRatio.value,
                    data.e.newValue, this.backPipeRatio, 6));

            this.alarmStation(this.pipeRatio.value, this.highPipeRatio.value,
                this.lowPipeRatio.value, this.backPipeRatio, 6);
        }

        // Alarm Heat Temp
        if (this.heatTemp && this.highHeatTemp && this.lowHeatTemp) {
            this.highHeatTemp.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.heatTemp.value, data.e.newValue,
                    this.lowHeatTemp.value, this.backHeatTemp, 7));

            this.lowHeatTemp.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.heatTemp.value, this.highHeatTemp.value,
                    data.e.newValue, this.backHeatTemp, 7));

            this.alarmStation(this.heatTemp.value, this.highHeatTemp.value,
                this.lowHeatTemp.value, this.backHeatTemp, 7);
        }

        if (this.alarmPID) {
            this.alarmPID.dispatcher.on('valueChanged', (data) => {
               this.alarmTotal(data.e.newValue, this.alarmPIDImage, 0)
            });
            this.alarmTotal(this.alarmPID.value, this.alarmPIDImage, 0);
        }

        if (this.alarmMixer) {
            this.alarmMixer.dispatcher.on('valueChanged', (data) => {
                this.alarmTotal(data.e.newValue, this.alarmMixerImage, 1)
            });
            this.alarmTotal(this.alarmMixer.value, this.alarmMixerImage, 1);
        }

        if (this.alarmPRU) {
            this.alarmPRU.dispatcher.on('valueChanged', (data) => this.alarmTotal(data.e.newValue, this.alarmPRUImage, 2));
            this.alarmTotal(this.alarmPRU.value, this.alarmPRUImage, 2);
        }

        // Change the title of page
        this.titleUp.innerHTML = this.title;
        this.titleDown.innerHTML = this.title;
        var color = this.titleUp.style.cssText;
        var change = color.replaceAll("rgb(0, 0, 0)", "rgb(255, 255, 255)");
        this.titleUp.style.cssText = change;

        // Simulate 3 arrow in, out
        setInterval(() => {
            this.simulateArrow();
        }, 500);

        // Update datetime now
        setInterval(() => {
            this.now();
        }, 1000);

        // Subcribe event to redirect link
        this.backPressure1.addEventListener("click", () => { this.redirectLink("https://www.sojitz.com/en/") });
        this.backPressure2.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.backTemp1.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.backTemp2.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.backFlow1.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.backFlow2.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.backPipeRatio.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.backHeatTemp.addEventListener("click", () => { this.redirectLink("~/mixerchart") });
        this.alarmPIDImage.addEventListener("click", () => { this.redirectLink("~/pidstation") });
        this.alarmMixerImage.addEventListener("click", () => { this.redirectLink("~/mixerstation") });
        this.alarmPRUImage.addEventListener("click", () => { this.redirectLink("~/prustation") });
        this.logo.addEventListener("click", () => { this.redirectLink("https://www.sojitz.com/en/") });

        this.logo.addEventListener("mouseover", () => {
            this.logo.style.cursor = "pointer";
        });
        this.backPressure1.addEventListener("mouseover", () => {
            this.backPressure1.style.cursor = "pointer";
        });
        this.backPressure2.addEventListener("mouseover", () => {
            this.backPressure2.style.cursor = "pointer";
        });
        this.backTemp1.addEventListener("mouseover", () => {
            this.backTemp1.style.cursor = "pointer";
        });
        this.backTemp2.addEventListener("mouseover", () => {
            this.backTemp2.style.cursor = "pointer";
        });
        this.backFlow1.addEventListener("mouseover", () => {
            this.backFlow1.style.cursor = "pointer";
        });
        this.backFlow2.addEventListener("mouseover", () => {
            this.backFlow2.style.cursor = "pointer";
        });
        this.backPipeRatio.addEventListener("mouseover", () => {
            this.backPipeRatio.style.cursor = "pointer";
        });
        this.backHeatTemp.addEventListener("mouseover", () => {
            this.backHeatTemp.style.cursor = "pointer";
        });
        this.alarmPIDImage.addEventListener("mouseover", () => {
            this.alarmPIDImage.style.cursor = "pointer";
        });
        this.alarmMixerImage.addEventListener("mouseover", () => {
            this.alarmMixerImage.style.cursor = "pointer";
        });
        this.alarmPRUImage.addEventListener("mouseover", () => {
            this.alarmPRUImage.style.cursor = "pointer";
        });
    }

    information(msg, duration) {
    var element = document.createElement("div");
    element.setAttribute("style", "position:absolute;top:20%;left:5.5%;background-color:yellow;fill:red");
    element.innerHTML = msg;
    element.style.font = "15px sans-serif";
    setTimeout(() => {
        element.parentNode.removeChild(element);
    }, duration);
    document.body.appendChild(element);
    }

    pressure1ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.pressure1Text.innerHTML = roundValue;
        this.alarmStation(this.pressure1.value, this.highpres1.value,
        this.lowpres1.value, this.backPressure1, 0);
    }

    pressure2ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.pressure2Text.innerHTML = roundValue;
        this.alarmStation(this.pressure2.value, this.highpres2.value,
        this.lowpres2.value, this.backPressure2, 1);
    }

    temp1ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.temp1Text.innerHTML = roundValue;
        this.alarmStation(this.temp1.value, this.highTemp1.value,
        this.lowTemp1.value, this.backTemp1, 2);
    }

    temp2ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.temp2Text.innerHTML = roundValue;
        this.alarmStation(this.temp2.value, this.highTemp2.value,
        this.lowTemp2.value, this.backTemp2, 3);
    }

    flow1ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.flow1Text.innerHTML = roundValue;
        this.alarmStation(this.flow1.value, this.highflow1.value,
        this.lowflow1.value, this.backFlow1, 4);
    }

    flow2ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.flow2Text.innerHTML = roundValue;
        this.alarmStation(this.flow2.value, this.highflow2.value,
        this.lowflow2.value, this.backFlow2, 5);
    }

    pipeRatioValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.pipeRatioText.innerHTML = roundValue;
        this.alarmStation(this.pipeRatio.value, this.highPipeRatio.value,
        this.lowPipeRatio.value, this.backPipeRatio, 6);
    }

    heatTempValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.heatTempText.innerHTML = roundValue;
        this.alarmStation(this.heatTemp.value, this.highHeatTemp.value,
        this.lowHeatTemp.value, this.backHeatTemp, 7);
    }

    percentValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.percentText.innerHTML = roundValue + ' %';  
    }

    alarmStation(param, highAlarm, lowAlarm, background, id) {
        if (highAlarm && lowAlarm && param) {
            var pr = parseFloat(param);
            var high = parseFloat(highAlarm);
            var low = parseFloat(lowAlarm);
            if (pr > high || pr < low) {
                if (this.alarmParamID[id] != null) {
                    clearInterval(this.alarmParamID[id]);

                    var idTimer = setInterval(() => {
                        this.simulateAlarm(background, id);
                    }, 500);

                    this.alarmParamID[id] = idTimer;
                }
            }
            else {
                clearInterval(this.alarmParamID[id]);
                var newCss = background.style.cssText.replaceAll("rgb(255, 0, 0)", "rgb(255, 255, 255)");
                background.style.cssText = newCss;
            }
        }
    }

    alarmTotal(value, image, id) {
        if (!value) return;
        if (value === "0") {
            if (this.alarmStationID[id] != null) {
                clearInterval(this.alarmStationID[id]);

                var idTimer = setInterval(() => {
                    if (this.show[id]) {
                        image.style.display = "none";
                    }
                    else
                        image.style.display = "inline";
                    this.show[id] = !this.show[id];
                }, 500);

                this.alarmStationID[id] = idTimer;
            }
        }
        else {
            this.show[id] = false;
            clearInterval(this.alarmStationID[id]);
            image.style.display = "inline";
        }
    }

    tagStatus(status) {
        if (status === 'Good') {

        }
        else {

        }
    }

    // Simulate 2 arrow in, out
    simulateArrow() {
        if (this.count) {
            this.arrowIn1.style.display = "none";
            this.arrowIn2.style.display = "none";
            this.arrowOut.style.display = "none";
        }
        else {
            this.arrowIn1.style.display = "inline";
            this.arrowIn2.style.display = "inline";
            this.arrowOut.style.display = "inline";
        }

        this.count = !this.count;
    }

    simulateAlarm(parameter, id) {
        var alarmCss = parameter.style.cssText;
        if (this.check[id]) {
            var newCss = alarmCss.replaceAll("rgb(255, 255, 255)", "rgb(255, 0, 0)");
            parameter.style.cssText = newCss;
        }
        else {
            var newCss = alarmCss.replaceAll("rgb(255, 0, 0)", "rgb(255, 255, 255)");
            parameter.style.cssText = newCss;
        }

        this.check[id] = !this.check[id];
    }

    redirectLink(url) {
        if (url == '' || url === 'http://') return;
        if (url.includes('http')) {
            window.open(url, '_blank');
        }
        else if (url.includes('~/')) {
            window.location.hash = `/${url.split('/')[1]}`;
        }
    }

    now() {
        var date = new Date();
        let day = ("0" + date.getDate()).slice(-2);
        let month = ("0" + (date.getMonth() + 1)).slice(-2);
        let year = date.getFullYear();
        let hour = ("0" + date.getHours()).slice(-2);
        let minute = ("0" + date.getMinutes()).slice(-2);
        let second = ("0" + date.getSeconds()).slice(-2);
        let currentDate = `${day}/${month}/${year}`;
        let currentTime = `${hour}:${minute}:${second}`;
        this.date.innerHTML = currentDate;
        this.time.innerHTML = currentTime;
    }

    dispose() { }
}