export class AtscadaSVGView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.arrowIn = element.arrowIn;
        this.arrowOut = element.arrowOut;
        this.alarmStationID = [0, 1, 2];
        this.alarmParamID = [0, 1, 2, 3, 4];
        this.alarmState = [];
        this.originalBackgrounds = [];
        this.show = [false, false, false];
        this.check = [false, false, false, false, false];
        this.intervalMap = new Map();
        this.alarmStateMap = new Map();
        this.resultMap = new Map();
        this.alarmMap = new Map();
        this.angle = 0;
        this.alarm = false;
    }
    initialize() {
        this.arrAlarmItemsTag = this.model.dataAlarmTags;// lấy tất cả Tag Alarm
        this.arrValue = this.model.dataTags;
        this.arrValueID = this.model.taskLoader.element.SVGItems;
        this.arrCutaway = this.model.taskLoader.element.SVGCutawayItems;
        this.arrValueProperties = this.model.taskLoader.element.SVGItemsProperties;
        this.arrValueType = this.model.taskLoader.element.SVGItemsType;
        this.arrAlarmValueID = this.model.taskLoader.element.SVGAlarmItems;
        this.arrAlarmTags = [];
        const alarmTagsLength = this.arrAlarmItemsTag.length;
        this.arrAlarmTags = Array.from({ length: alarmTagsLength / 3 }, (_, i) =>
            this.arrAlarmItemsTag.slice(i * 3, (i + 1) * 3)
        );

        for (let i = 0; i < this.arrAlarmValueID.length; i++) {
            this.arrAlarmTags[i].push(this.arrAlarmValueID[i]);
        }
        for (let i = 0; i < this.arrValue.length; i++) {
            this.arrValue[i].id = this.arrValueID[i];
            this.arrValue[i].properties = this.arrValueProperties[i];
            this.arrValue[i].type = this.arrValueType[i][0];
            this.arrValue[i].min = this.arrValueType[i][2];
            this.arrValue[i].max = this.arrValueType[i][3];
        }
        
        this.arrValue.forEach(value1 => {
            for (let i = 0; i < this.arrCutaway.length; i++) {
                const cuteway = this.arrCutaway[i];
                if (value1 && value1.name == cuteway[2]) {
                    value1.dispatcher.on('valueChanged', (data) => this.cutaway(data.e.newValue,cuteway));
                }
            }
            
        });
        for (let i = 0; i < this.arrAlarmTags.length; i++) {
            if (this.arrAlarmTags[i]) {
                var value = this.arrAlarmTags[i];
                value[2].dispatcher.on('valueChanged', (data) =>
                    this.alarmStation(value[1].value, data.e.newValue,
                        value[0].value, document.getElementById(value[3]), value[3]));
                value[0].dispatcher.on('valueChanged', (data) =>
                    this.alarmStation(value[1].value, value[2].value, data.e.newValue,
                        value[3], value[3]));
                value[1].dispatcher.on('valueChanged', (data) => this.alarmStation(data.e.newValue, value[2].value, value[0].value, value[3], value[3]));
                this.alarmStation(value[1].value, value[2].value,
                    value[0].value, value[3], value[3]);
            }
        };
        for (let i = 0; i < this.arrAlarmTags.length; i++) {
            this.alarmStateMap[i] = {
                isBlinking: false,
                intervalId: null
            };
        }

        this.arrValue.forEach((value,index) => {
            if (value) {
                value.dispatcher.on('valueChanged', (data) => this.ValueChanged(data.e.newValue, value, index));
                this.ValueChanged(value.value, value,index);
            }
        });
        setInterval(() => {
            this.simulateArrow();
        }, 500);
        setInterval(() => {
            this.now();
        }, 1000);
    }
    cutaway = (value, item) => {
        const [rect, container] = item.length > 0 ? item.slice(0, 2).map(id => document.getElementById(id)) : [];
        if (rect && container) {
            const height = parseFloat(container.getAttribute("height")).toFixed(1);
            const [, , , min, max] = item;
            rect.style.height = (((parseFloat(max) - parseFloat(value)) / parseFloat(max)) * height).toString();
        }
    };
    alarmStation(param, highAlarm, lowAlarm, id_background, id) {
        if (!param || !highAlarm || !lowAlarm || !id_background || !id) {
            return;
        }

        for (let i = 0; i < this.arrAlarmTags.length; i++) {
            const alarmTag = this.arrAlarmTags[i];
            const element = document.getElementById(alarmTag[3]);

            const currentValue = parseFloat(alarmTag[1].value);
            const highValue = parseFloat(alarmTag[2].value);
            const lowValue = parseFloat(alarmTag[0].value);
            this.originalBackgrounds[alarmTag[3]] ||= window.getComputedStyle(element).fill;
            if (highValue < currentValue || lowValue > currentValue) {
                this.applyBlinkEffect(element);
            } else {
                this.removeBlinkEffectAlarm(element, this.originalBackgrounds[alarmTag[3]]);
            }
        }
        //if (!param || !highAlarm || !lowAlarm || !id_background || !id) {
        //    return;
        //}
        //for (let i = 0; i < this.arrAlarmTags.length; i++) {
        //    if (this.alarmState[i]) {
        //        this.alarmState[i] = {
        //            isBlinking: false,
        //            intervalId: null
        //        };
        //    }
        //    var AlarmTags = this.arrAlarmTags[i];
        //    const element = document.getElementById(AlarmTags[3]);
        //    // Chuyển đổi sang kiểu số
        //    const pr = parseFloat(AlarmTags[1].value);
        //    const high = parseFloat(AlarmTags[2].value);
        //    const low = parseFloat(AlarmTags[0].value);
        //    this.originalBackgrounds[AlarmTags[3]] ||= window.getComputedStyle(element).fill;
        //    if (high < pr || low > pr) {
                    
        //        this.applyBlinkEffect(element);
        //    }
        //    else {
        //        this.removeBlinkEffect(element, this.originalBackgrounds[AlarmTags[3]]);
        //    }
        //}
    }
   // Hàm áp dụng hiệu ứng nhấp nháy cho khối vuông
    applyBlinkEffect(element) {
        element.style.fill = 'red'; // Đổi màu nền thành đỏ
        element.style.animation = 'blink-animation 1s infinite';
    }
    // Hàm loại bỏ hiệu ứng nhấp nháy khỏi khối vuông
    removeBlinkEffectAlarm(element,color) {
        element.style.animation = 'none';
        element.style.fill = color;
    }
    // Hàm loại bỏ hiệu ứng nhấp nháy khỏi khối vuông
    removeBlinkEffect(element) {
        element.style.animation = 'none';
        element.style.fill = 'green';
    }
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
    startAlarm(elementStatus, id) {
        this.alarmStateMap.set(id, { isBlinking: true });

        return this.setIntervalWrapper(() => {
            this.simulateAlarm(elementStatus, id);
        }, 1000);
    }
    stopAlarm(id,index) {
        this.alarmStateMap.delete(index);

        if (this.intervalMap.has(id)) {
            const intervalId = id;
            this.clearIntervalWrapper(intervalId);
        }
    }
    setIntervalWrapper(callback, milliseconds) {
        const intervalId = setInterval(callback, milliseconds);
        this.intervalMap.set(intervalId, callback);
        return intervalId;
        }

    clearIntervalWrapper(intervalId) {
        clearInterval(intervalId);
        this.intervalMap.delete(intervalId);
    }
    ValueChanged(value,item,index) {
        if (!value) return;

        if (item.properties === "Value") {
            this.roundValue = this.convertValue(value, item.type);
            this.pressure1Text = document.getElementById(item.id);
            this.pressure1Text.innerHTML = this.roundValue;
        } else if (item.properties === "Status") {
            this.elemetStatus = document.getElementById(item.id);
            if (item.type === "Color") {
                this.elemetStatus.style.fill = value === "1" ? "red" : "green";
            }
            if (item.type === "Blink") {
                if (value === "1") {
                    this.applyBlinkEffect(this.elemetStatus);
                }
                else {
                    this.removeBlinkEffect(this.elemetStatus);
                }
            }
            if (item.type == "IsRunning") {
              
                //this.fan = document.getElementById(item.id);
                //const styleElement = document.createElement("style");

                //styleElement.textContent = `
                //  #fan {
                //    animation: rotate 2s linear infinite;
                //    transform-origin: center;
                //  }

                //  @keyframes rotate {
                //    from {
                //      transform: rotate(0deg);
                //    }
                //    to {
                //      transform: rotate(360deg);
                //    }
                //  }
                //`;

                //document.head.appendChild(styleElement);
                //this.rotate();
            }
            
        }
    }
    rotate() {
        this.angle += 1;
        this.gElement.style.transform = `rotate(${this.angle}deg) translate(-50%, -50%)`;
        requestAnimationFrame(this.rotate);
    }

    convertValue(value, type) {
        switch (type) {
            case "Int":
                return parseInt(value);
            case "Float":
                return parseFloat(value).toFixed(2);
            case "Double":
                return parseFloat(value).toFixed(2);
            case "Bool":
                return value === "1" ? true : false;
            case "String":
                return value.toString();
            default:
                return null;  // Handle unsupported types gracefully
        }
    }
    simulateStatusBlink(parameter, id) {
        const isBlinking = this.alarmStateMap.get(id).isBlinking;

        if (this.alarm) {
            parameter.style.fill = "rgb(255, 0, 0)";
        } else {
            parameter.style.fill = "rgb(255, 255, 255)";
        }
        this.alarm = !this.alarm;
        this.alarmStateMap.get(id).isBlinking = !isBlinking;
    }
    actionRefreshed(data) {
        const itemModels = [];
        const time = data.e.timeStamp.getTime();
        for (const dataTag of this.model.dataTags) {
            this.pressure1Text = dataTag.value;
            itemModels.push({
                time: time,
                value: this.getSVGValue(dataTag.status, dataTag.value)
            });
        }
    }
    dispose() { }
}