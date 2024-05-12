
// Khai bao Header va format data hien thi cho DataTable
const headerNames = ['DateTime', 'Tag Name', 'Alias', 'Value', 'High Value', 'Low Value', 'Status', 'ACK'];
const options = {
    columns: [
        { data: 'DateTime' },
        { data: 'TagName' },
        { data: 'TagAlias' },
        { data: 'Value' },
        { data: 'HighLevel' },
        { data: 'LowLevel' },
        { data: 'Status' },
        { data: 'ACK' }
    ]
}

import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'

export class AtscadaAlarmReporterView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();

        this.contentElement = element.contentElement;
        this.toastElement = element.toastElement;
        this.dataTableElement = element.dataTableElement;
        this.dateRangePickerElement = element.dateRangePickerElement;
        this.reportButtonElement = element.reportButtonElement;
        this.exportButtonElement = element.exportButtonElement
    }

    async initialize() {
        this.contentElement.innerHTML = this.element.content;
        this.toastElement.content = this.element.content;
        // Setup. Khoi tao danh sach cot theo cac Header khai bao o tren        
        await this.dataTableElement.setup({
            headerNames: headerNames,
            options: options
        });

        // Nhan thong bao, dang ky su kien tu Model
        // Khi du lieu bao cao duoc tra ve tu Server
        this.model.dispatcher.on('reported', (alarmLogs) => this.actionReported(alarmLogs));
        // Event click button
        this.reportButtonElement.addEventListener('click', async () => await this.actionReportButtonClicked());
        this.exportButtonElement.addEventListener('click', () => this.actionExportButtonClicked());
    }

    //  Cap nhat du lieu hien thi len UI DataTable
    actionReported(alarmReportLogs) {
        this.dataTableElement.update(alarmReportLogs);
        this.exportButtonElement.disabled = alarmReportLogs.length < 1;
    }

    // Thong bao controller su kien button Report click
    async actionReportButtonClicked() {
        this.reportButtonElement.disable = true;
        this.dataTableElement.showLoading({ maxSize: 60 });

        await this.dispatcher.dispatch('reportButtonClicked', {});

        this.reportButtonElement.disable = false;
        this.dataTableElement.hideLoading();
    }

    // Thong bao Controller su kien button export click
    actionExportButtonClicked() {
        this.dispatcher.dispatch('exportButtonClicked', {});       
    }

    dispose() { }
}