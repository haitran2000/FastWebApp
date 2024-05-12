
// Nhan thong bao thay doi/ action tu View
// Call model action
export class AtscadaSwitchController {
    constructor(model, view) {
        this.model = model;
        this.view = view;

        this.timeoutWrite = undefined;
    }

    initialize() {
        // Switch thay doi gia tri
        this.view.dispatcher.on('requested', (data) => this.actionRequested(data));
    }

    actionRequested(data) {
        // ... Trong luc hco 1s. Neu co lenh tiep tuc ghi (do switch thay doi)
        // ... Huy lenh ghi cu truoc do. 
        if (this.timeoutWrite)
            clearTimeout(this.timeoutWrite);
        // Ghi gia tri sau thay doi Switch 1s
        this.timeoutWrite = setTimeout(() => {
            const dataTag = this.model.dataTag;
            if (dataTag) {
                dataTag.write(data.value, (view) => { return this.view === view });
            }                
        }, 1000);
    }

    dispose() { }
}
