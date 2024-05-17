
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

// Nhan thong bao tu Model
// Cap nhat giao dien hien thi khi Model thay doi
export class AtscadaSwitchView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();

        //  Khoa update gia tri Value tu Tag (khi co su kien TagValueChanged)
        this.timeoutUpdate = undefined;
        this.isLockUpdate = false;

        this.contentElement = element.contentElement;
        this.switchElement = element.switchElement;
        this.statusElement = element.statusElement;
        this.valueOn = element.valueOn.trim();
        this.valueOff = element.valueOff.trim();
    }

    async initialize() {
        this.contentElement.innerHTML = this.element.content;
        // setup switch
        await this.switchElement.setup({
            color: this.element.color,
            size: this.element.size
        });

        if (this.switchElement.isCompleted) {
            this.actionSwitchCompleted();
        }
        else {
            this.switchElement.dispatcher.on('completed', () => this.actionSwitchCompleted())
        }
    }

    // Khi setup hoan thanhf
    // Dang ky theo su kien thay doi cua Tag
    actionSwitchCompleted() {
        this.dataTag = this.model.dataTag;
        this.instance = this.switchElement.instance;       

        if (this.dataTag && this.instance) {
            this.dataTag.dispatcher.on('writeCompleted', (data) => this.actionWriteCompleted(data));
            this.dataTag.dispatcher.on('valueChanged', (data) => this.updateValue(data.e.newValue.trim()));
            this.dataTag.dispatcher.on('statusChanged', (data) => this.updateStatus(data.e.newStatus));

            this.switchElement.addEventListener('click', (e) => {                           
                if (this.instance.isDisabled()) return;
                var value = this.instance.isChecked() ? this.valueOn : this.valueOff;
                this.dispatcher.dispatch('requested', { value: value });
            });

            this.updateValue(this.dataTag.value);
            this.updateStatus(this.dataTag.status);
        }
    }

    // Feedback lai gia tri sau qua tirnh write Tag
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

    // Cap nhat gia trij Status cua Switch
    updateValue(value) {
        if (!this.isLockUpdate) {
            if (this.instance) {
                var presentChecked = this.instance.isChecked();
                var newChecked =
                    value === this.valueOff ? false :
                        value === this.valueOn ? true :
                            presentChecked;
                if ((newChecked && !presentChecked) ||
                    (!newChecked && presentChecked)) {
                    this.instance.setPosition(true);
                    this.instance.handleOnchange(true);
                }
            }
        }
    }

    // Cap nhat Status : good/Bad
    updateStatus(status) {
        this.statusElement.innerHTML = status;
        for (let index = this.statusElement.classList.length - 1; index >= 0; index--) {
            const className = this.statusElement.classList[index];
            if (className.startsWith('text-')) {
                this.statusElement.classList.remove(className);
            }
        }
        this.statusElement.classList.add(status === 'Good' ? 'text-green' : 'text-red');
        if (status === 'Good')
            this.instance.enable();
        else
            this.instance.disable();
    }

    dispose() { }
}