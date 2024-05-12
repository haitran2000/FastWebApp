
export class AtscadaAlarmViewerController {
    constructor(model, view) {
        this.model = model;
        this.view = view;
    }

    initialize() {
        // Nhan thon bao tu UI
        // Click button ACK
        this.view.dispatcher.on('ackButtonClicked', () => this.actionAckButtonClicked());
    }

    actionAckButtonClicked() {
        // call model. Thog bao ACK
        this.model.acknowledge();
    }

    dispose() { }
}