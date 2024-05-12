
// Nhan thong bao tu View
// Call action model
export class AtscadaInputController {
    constructor(model, view) {
        this.model = model;
        this.view = view;

        this.timeoutWrite = undefined;
    }

    initialize() {
        // Khi button Write duoc click (mouse down)
        // Tien hanh ghi Tag
        this.view.dispatcher.on('buttonMouseDowned', (data) => this.actionButtonMouseDowned(data));
    }
  
    actionButtonMouseDowned(data) {
        if (this.timeoutWrite)
            clearTimeout(this.timeoutWrite);
        // write tag
        // Co xet toi thoi gian timeout
        this.timeoutWrite = setTimeout(() => {
            const dataTag = this.model.dataTag;
            // callback: Phai dung voi Component wirte
            if (dataTag) dataTag.write(data.value, (view) => { return this.view === view });
        }, 2000);
    }

    dispose() { }
}
