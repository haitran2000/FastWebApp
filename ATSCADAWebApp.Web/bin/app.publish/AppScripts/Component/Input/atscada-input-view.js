
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

export class AtscadaInputView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();
        this.timeoutUpdate = undefined;
        this.timeoutLeaved = undefined;
        // Khoa, khong cho cap nhat thay doi gia tri tu Tag
        this.isLockUpdate = false;
        this.isLockLeave = false;

        this.contentElement = element.contentElement;
        this.textBoxElement = element.textBoxElement;
        this.buttonElement = element.buttonElement;
    }

    initialize() {
        this.contentElement.innerHTML = this.element.content;
        this.dataTag = this.model.dataTag;
        if (this.dataTag) {
            // Dang ky cac su kien thay doi cua Tag
            this.dataTag.dispatcher.on('writeCompleted', (data) => this.actionWriteCompleted(data));
            this.dataTag.dispatcher.on('valueChanged', (data) => this.updateValue(data.e.newValue));
            this.dataTag.dispatcher.on('statusChanged', (data) => this.updateStatus(data.e.newStatus));

            this.updateValue(this.dataTag.value);
            this.updateStatus(this.dataTag.status);
        }

        // su kien nhap chuyot (focus) vao o textBox
        this.textBoxElement.addEventListener('focus', () => this.actionTextboxFocus());
        // click button write tag
        this.buttonElement.addEventListener('mousedown', (e) => this.actionMouseDowned(e));
        // su kien re chuot ra khoi o textbox
        this.textBoxElement.addEventListener('blur', () => this.actionTextboxLeaved());
        
    }

    // Neu re chuot, nhap vao o textBox
    // ... thi khoa, khong update value tu Tag
    actionTextboxFocus() {
        this.isLockUpdate = true
    }

    actionMouseDowned(e) {
        e.preventDefault();
        e.stopPropagation();
        this.isLockLeave = true;
        this.textBoxElement.blur();
        this.dispatcher.dispatch(
            'buttonMouseDowned',
            { value: this.textBoxElement.value });
        this.isLockLeave = false;
    }

    // Khi roi, re chuot ra khoi o textBox
    actionTextboxLeaved() {
        if (this.isLockLeave) return;
        // Mo khoa, cho phep update value tu Tag (neu gia tri thay doi)
        this.isLockUpdate = false;
        if (this.timeoutLeaved)
            clearTimeout(this.timeoutLeaved);
        // Khoa qua trinh lock.... Tag co the da tahy doi Value
        // Nhung khong duoc cap nhat
        // ... Sau 1s ---> Update lai gia tri tu Tag
        this.timeoutLeaved = setTimeout(() => {
            this.updateValue(this.dataTag.value);
        }, 1000);
    }

    // Su kien tra ve cho hanh dong Tag write
    actionWriteCompleted(data) {
        if (!data.callback(this)) {
            this.isLockUpdate = false;
            return;
        }
        if (this.timeoutUpdate)
            clearTimeout(this.timeoutUpdate);
        this.isLockUpdate = true;

        // Kiem tra ghi co thanh cong hay khong
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

    updateValue(value) {
        // Neu khong bi lock thi cho phrp cap nhat (update)
        if (!this.isLockUpdate) {
            this.textBoxElement.value = value;
        }
    }

    updateStatus(status) {
        this.textBoxElement.classList.remove('is-valid', 'is-invalid');
        if (status === 'Good') {
            this.textBoxElement.classList.add('is-valid');
            this.textBoxElement.disabled = false;
            this.buttonElement.disabled = false;
        }
        else {
            this.textBoxElement.classList.add('is-invalid');
            this.textBoxElement.disabled = true;
            this.buttonElement.disabled = true;
        }
    }

    dispose() { }
}