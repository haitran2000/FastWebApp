
export class AtscadaDataReporterController {
    constructor(model, view) {
        this.model = model;
        this.view = view;
    }

    initialize() {
        // Nhan thong bao tu UI
        // 1. Click button report
        this.view.dispatcher.on('reportButtonClicked', async () => await this.actionReportButtonClicked());
        // 2. Click button export
        this.view.dispatcher.on('exportButtonClicked', async () => await this.actionExportButtonClicked());
        // . Click button export PDF
        this.view.dispatcher.on('exportPDFButtonClicked', async () => await this.actionExportPDFButtonClicked());
    }

    async actionReportButtonClicked() {
        await this.model.report();
    }

    async actionExportButtonClicked() {
        await this.model.export();
    }
    async actionExportPDFButtonClicked() {
        await this.model.export_pdf();
    }
    dispose() { }
}
