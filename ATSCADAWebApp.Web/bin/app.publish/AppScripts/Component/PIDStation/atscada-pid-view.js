import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

export class AtscadaPIDStationView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();
        this.title = element.content;
        this.pressure1Text = element.pressure1Text;
        this.pressure2Text = element.pressure2Text;
        this.pressure3Text = element.pressure3Text;
        this.pressure4Text = element.pressure4Text;
        this.arrowIn = element.arrowIn;
        this.arrowOut = element.arrowOut;
        this.backPressure1 = element.backPressure1;
        this.backPressure2 = element.backPressure2;
        this.backFlow1 = element.backFlow1;
        this.backFlow2 = element.backFlow2;

        this.logo = element.logo;
        this.date = element.date;
        this.time = element.time;
        this.titleUp = element.titleUp;
        this.titleDown = element.titleDown;

        this.count = true;
        this.alarmStationID = [0, 1, 2];
        this.alarmParamID = [0, 1, 2, 3, 4];       
        this.show = [false, false, false];
        this.check = [false, false, false, false, false];       
    }

    initialize() {
        this.pressure1 = this.model.dataTags[0];
        this.pressure2 = this.model.dataTags[1];
        this.pressure3 = this.model.dataTags[2];
        this.pressure4 = this.model.dataTags[3];
        this.highalarmvalue1 = this.model.dataTags[4];
        this.highalarmvalue2 = this.model.dataTags[5];
        this.highalarmvalue3 = this.model.dataTags[6];
        this.highalarmvalue4 = this.model.dataTags[7];
        this.lowalarmvalue1 = this.model.dataTags[8];
        this.lowalarmvalue2 = this.model.dataTags[9];
        this.lowalarmvalue3 = this.model.dataTags[10];
        this.lowalarmvalue4 = this.model.dataTags[11];


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

        if (this.pressure3) {
            this.pressure3.dispatcher.on('valueChanged', (data) => this.pressure3ValueChanged(data.e.newValue));
            this.pressure3.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.pressure3ValueChanged(this.pressure3.value);
        }
        if (this.pressure4) {
            this.pressure4.dispatcher.on('valueChanged', (data) => this.pressure4ValueChanged(data.e.newValue));
            this.pressure4.dispatcher.on('statusChanged', (data) => this.tagStatus(data.e.newStatus));
            this.pressure4ValueChanged(this.pressure4.value);
        }

        // Alarm Pressure 1
        if (this.pressure1 && this.highalarmvalue1 && this.lowalarmvalue1) {
            this.highalarmvalue1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pressure1.value, data.e.newValue,
                    this.lowalarmvalue1.value, this.backPressure1, 0));

            this.lowalarmvalue1.dispatcher.on('valueChanged', (data) =>
                this.alarmStation(this.pressure1.value, this.highalarmvalue1.value, data.e.newValue,
                     this.backPressure1, 0));

            this.alarmStation(this.pressure1.value, this.highalarmvalue1.value,
                this.lowalarmvalue1.value, this.backPressure1, 0);
        }
      
        // Simulate 2 arrow in, out
        setInterval(() => {
            this.simulateArrow();
        }, 500);

        // Update datetime now
        setInterval(() => {
            this.now();
        }, 1000);

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
        this.alarmStation(this.pressure1.value, this.highalarmvalue1.value,
            this.lowalarmvalue1.value, this.backPressure1, 0);
    }

    pressure2ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.pressure2Text.innerHTML = roundValue;
        this.alarmStation(this.pressure2.value, this.highalarmvalue2.value,
        this.lowalarmvalue2.value, this.backPressure2, 1);
    }

    pressure3ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.pressure3Text.innerHTML = roundValue;
        this.alarmStation(this.pressure3.value, this.highpres3.value,
        this.lowpres3.value, this.backPressure3, 2);
    }
    pressure4ValueChanged(value) {
        if (!value) return;
        var roundValue = parseFloat(value).toFixed(1);
        this.pressure4Text.innerHTML = roundValue;
        this.alarmStation(this.pressure4.value, this.highpres4.value,
            this.lowpres4.value, this.backPressure4, 2);
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
    tagStatus(status) {
        if (status === 'Good') {

        }
        else {

        }
    }


    // Simulate 2 arrow in, out
    simulateArrow() {
        if (this.count) {
            this.arrowIn.style.display = "none";
            this.arrowOut.style.display = "none";
        }
        else {
            this.arrowIn.style.display = "inline";
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