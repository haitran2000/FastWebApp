
const template = document.createElement('template');
template.innerHTML = `            
<atscada-toast at-title="Alarm Viewer"></atscada-toast>
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-alarm-viewer-content panel-title">Alarm viewer</h4>
        <div class="btn-group my-n1">
            <button type="button" class="btn btn-success btn-sm">Action</button>
            <button type="button" class="btn btn-success btn-sm dropdown-toggle" data-bs-toggle="dropdown"><b class="caret"></b></button>
            <div class="dropdown-menu dropdown-menu-end">
                <a class="atscada-alarm-viewer-ack dropdown-item">Acknowledge</a>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <atscada-data-table></atscada-data-table>
    </div>
</div>
`;

import { } from '../../Core/Component/DataTable/atscada-data-table-element.js'
import { } from '../../Core/Component/Toast/atscada-toast-element.js'
import { AtscadaAlarmViewerModel } from './atscada-alarm-viewer-model.js'
import { AtscadaAlarmViewerView } from './atscada-alarm-viewer-view.js'
import { AtscadaAlarmViewerController } from './atscada-alarm-viewer-controller.js'

// Component realtime alarmViewer
// Truy van lien tuc tu DataBase
class AtscadaAlarmViewerElement extends HTMLElement {   
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        // Tieu de hien thi
        this.contentElement = this.querySelector('.atscada-alarm-viewer-content');
        // Toast - bang hien thi thong bao
        this.toastElement = this.querySelector('atscada-toast');
        // DataTable hien thi du lieu
        this.dataTableElement = this.querySelector('atscada-data-table');
        // Button ACK
        this.ackButtonElement = this.querySelector('.atscada-alarm-viewer-ack');

        // Tieu de hien thi
        this.content = 'Alarm Viewer';
        // chuoi ket noi dataBase
        this.connection = 'atscada';
        // Table alarm log
        this.tableName = 'alarmlog';
        // Goi han so hang hien thi tren AlarmViewer
        this.limit = 50;
        // chu ky cap nhat data
        this.interval = 3000;
        // timeout ket noi
        this.timeout = 30000;
    }

    async connectedCallback() {

        // Get data tu attribute
        this.content = this.getAttribute('at-content') || this.content;
        this.connection = this.getAttribute('at-connection') || this.connection;
        this.tableName = this.getAttribute('at-table-name') || this.tableName;
        this.limit = this.getAttribute('at-limit') || this.limit;
        this.interval = this.getAttribute('at-interval') || this.interval;
        this.timeout = this.getAttribute('at-timeout') || this.timeout;
        
        this.model = new AtscadaAlarmViewerModel(this);
        this.view = new AtscadaAlarmViewerView(this.model, this);
        this.controller = new AtscadaAlarmViewerController(this.model, this.view);       
       
        this.model.initialize();
        await this.view.initialize();
        this.controller.initialize();
    }

    disconnectedCallback() {
        if (this.controller)
            this.controller.dispose();
        if (this.view)
            this.view.dispose();
        if (this.model)
            this.model.dispose();

        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }
}

customElements.define('atscada-alarm-viewer', AtscadaAlarmViewerElement);