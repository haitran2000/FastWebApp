
// Header va format data hien thi tren AlarmViewer Table
const headerNames = ['DateTime', 'Tag Name', 'Alias', 'Value', 'High Value', 'Low Value', 'Status', 'ACK'];
const options = {
    createdRow: function (row, data) {
        if (data['ACK'] === 'No') {
            $(row).addClass('bg-red-400');
            $(row).addClass('text-white');
        }
        else {
            //$(row).addClass('bg-silver-200');
            $(row).addClass('text-black');
        }
    },
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

export class AtscadaAlarmViewerView {    
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.dispatcher = new AtscadaDispatcher();
        // Tieu de hien thi
        this.contentElement = element.contentElement;
        // Bang thong bao
        this.toastElement = element.toastElement;
        // DataTable - hien thi alarmLog
        this.dataTableElement = element.dataTableElement;
        // nut xac nhan ACK
        this.ackButtonElement = element.ackButtonElement
    }

    async initialize() {
        this.contentElement.innerHTML = this.element.content;
        this.toastElement.content = this.element.content;
        // setup dataTable
        await this.dataTableElement.setup({
            headerNames: headerNames,
            options: options
        });        

        // Khi model thong bao thay doi --> Update UI
        // 1. Updated: Thong bao co du lieu mo duoc cap nhat
        this.model.dispatcher.on('updated', (alarmLogs) => this.actionUpdate(alarmLogs));
        // 2. Xac nhan ACK
        this.model.dispatcher.on('acknowledged', (acknowledgeResult) => this.actionAcknowledge(acknowledgeResult));

        // Thong bao cho Controller biet co su kien click button ACK
        this.ackButtonElement.addEventListener('click', () => this.dispatcher.dispatch('ackButtonClicked', {}));
    }

    actionUpdate(alarms) {
        // xoa du lieu cu tren DataTable
        // update, hien thi du lieu moi
        this.dataTableElement.update(alarms);
    }

    actionAcknowledge(acknowledgeResult) {
        // Hien thi bang thong bao
        // Co bao nhieu hang du lieu alarmLog duoc xac nhan ACK
        if (acknowledgeResult.status) {
            this.toastElement.showSuccess(
                `Success: Table <strong>${acknowledgeResult.tableName}</strong> 
                acknowledged <strong>${acknowledgeResult.numberOfRows}</strong> alarm logs`);
        }
        else {
            this.toastElement.showError('Error: Please try again!');
        }
    }

    dispose() { }
}