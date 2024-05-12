
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

export class AtscadaDataReporterView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();

        // Tieu de hien thi
        this.contentElement = element.contentElement;
        // Bang thong bao
        this.toastElement = element.toastElement;
        // DataTable hien thi du lieu DataReport
        this.dataTableElement = element.dataTableElement;
        // Button report hien thi du lieu bao cao len DataTable
        this.reportButtonElement = element.reportButtonElement;
        // Button export. Xuat file excel
        this.exportButtonElement = element.exportButtonElement;
    }

    async initialize() {
        this.contentElement.innerHTML = this.element.content;
        this.toastElement.content = this.element.content;
        await this.dataTableElement.setup({
            headerNames: this.element.headerNames,
            options: this.element.options
        });

        // Khi model thong bao co su thay doi du lieu bao cao --> Cap nhat len UI DataTable
        this.model.dispatcher.on('reported', (historicalLogs) => this.actionReported(historicalLogs));
        // Thong bao cho Controller
        // 1. Su kien bam nut Report
        this.reportButtonElement.addEventListener('click', async () => await this.actionReportButtonClicked());
        // 2. Su kien bam nut Export
        this.exportButtonElement.addEventListener('click', () => this.actionExportButtonClicked());
    }

    // Cap nhat du lieu len DataTable
    actionReported(dataReportLogs) {
        this.dataTableElement.update(dataReportLogs);
        this.exportButtonElement.disabled = dataReportLogs.length < 1;        
    }

    // call action model
    async actionReportButtonClicked() {
        this.reportButtonElement.disable = true;
        this.dataTableElement.showLoading({ maxSize: 60 });

        await this.dispatcher.dispatch('reportButtonClicked', {});

        this.reportButtonElement.disable = false;
        this.dataTableElement.hideLoading();
    }

    // call action model
    actionExportButtonClicked() {
        this.dispatcher.dispatch('exportButtonClicked', {});
    }

    dispose() { }
}