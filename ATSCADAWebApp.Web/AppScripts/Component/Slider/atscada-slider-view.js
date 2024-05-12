
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

// Nhan thong bao thay doi tu Model. Thay doi gia tri hien thi tren thanh truot
export class AtscadaSliderView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();

        this.timeoutUpdate = undefined;
        // Co khoa update gia tri tu Tag hay khong
        /// Khi co su kien TagValueChanged
        this.isLockUpdate = false;

        // Tieu de hien thi
        this.contentElement = element.contentElement;
        // Slider
        this.sliderElement = element.sliderElement;
        // Status (Good/Bad)
        this.statusElement = element.statusElement;
    }

    async initialize() {
        this.contentElement.innerHTML = this.element.content;
        // setup slider: Max, Min, Step
        await this.sliderElement.setup({
            min: this.element.min,
            max: this.element.max,
            skin: this.element.skin,
            step: this.element.step,
            onStart: (data) => this.dispatcher.dispatch('sliderStarted', data),
            onChange: (data) => this.dispatcher.dispatch('sliderChanged', data),
            onFinish: (data) => this.dispatcher.dispatch('sliderFinished', data),
            onUpdate: (data) => this.dispatcher.dispatch('sliderUpdated', data)
        });

        if (this.sliderElement.isCompleted) {
            this.actionSliderCompleted();
        }
        else {
            this.sliderElement.dispatcher.on('completed', () => this.actionSliderCompleted())
        }
    }

    // Setup slider hoan thanh
    // ... Dang ky su kien Tag
    actionSliderCompleted() {
        this.dataTag = this.model.dataTag;
        this.instance = this.sliderElement.instance;
        if (this.instance && this.dataTag) {
            this.dataTag.dispatcher.on('writeCompleted', (data) => this.actionWriteCompleted(data));
            this.dataTag.dispatcher.on('valueChanged', (data) => this.updateValue(data.e.newValue));
            this.dataTag.dispatcher.on('statusChanged', (data) => this.updateStatus(data.e.newStatus));

            this.updateValue(this.dataTag.value);
            this.updateStatus(this.dataTag.status);
        }
    }

    // Sau khi ghi xong. Update lai gai tri hien thi tren Slider
    actionWriteCompleted(data) {
        if (!data.callback(this)) {
            this.isLockUpdate = false;
            return;
        }
        if (this.timeoutUpdate)
            clearTimeout(this.timeoutUpdate);
        this.isLockUpdate = true;
        if (data.e.status === 'Good') {
            this.timeoutUpdate = setTimeout(() => {
                this.isLockUpdate = false;
                this.updateValue(this.dataTag.value);
            }, 20000);
        }
        else {
            this.isLockUpdate = false;
            this.updateValue(this.dataTag.value);
        }
    }

    // Upadte gia tri hien thi tren Slider khi co TagValueChanged
    updateValue(value) {
        if (!this.isLockUpdate) {
            if (this.instance) {
                if (!isNaN(parseFloat(value)) && !isNaN(value - 0)) {
                    value = Number(value);
                    this.instance.update({
                        from: value
                    });
                }
            }
        }
    }

    // update Status
    updateStatus(status) {
        this.statusElement.innerHTML = status;
        for (let index = this.statusElement.classList.length - 1; index >= 0; index--) {
            const className = this.statusElement.classList[index];
            if (className.startsWith('text-')) {
                this.statusElement.classList.remove(className);
            }
        }
        this.statusElement.classList.add(status === 'Good' ? 'text-green' : 'text-red');
        this.instance.update({ disable: status !== 'Good' });
    }

    dispose() { }
}