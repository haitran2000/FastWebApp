
const template = document.createElement('template');
template.innerHTML = `            
<atscada-toast at-title="Alarm Reporter"></atscada-toast>
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-alarm-reporter-content panel-title">Alarm Reporter</h4>
    </div>
    <div class="panel-toolbar">
        <div class="form-group row">
            <div class="col-sm-4">
                <atscada-date-range-picker></atscada-date-range-picker>
            </div>
            <div class="col-sm-3">
                <div class="row">
                    <div class="col-sm-6">
                        <button title="Report" type="button" class="atscada-alarm-reporter-report btn btn-default w-100" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                            Report
                        </button>
                    </div>
                    <div class="col-sm-6">
                        <button title="Export" type="button" class="atscada-alarm-reporter-export btn btn-default w-100" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;" disabled>
                            Export
                        </button>
                    </div>
                </div>
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
import { } from '../../Core/Component/DateRangePicker/atscada-date-range-picker-element.js'
import { AtscadaAlarmReporterModel } from './atscada-alarm-reporter-model.js'
import { AtscadaAlarmReporterView } from './atscada-alarm-reporter-view.js'
import { AtscadaAlarmReporterController } from './atscada-alarm-reporter-controller.js'

// danh index hien thi cho cac AlarmReport tren cung 1 view
// Moi repoter se co 1 ID rieng
let index = 0;

// Component xuat bao cao alarmReport
class AtscadaAlarmReportElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        // Tieu de hien thi
        this.contentElement = this.querySelector('.atscada-alarm-reporter-content');
        // Toast - bang hien thi thong bao
        this.toastElement = this.querySelector('atscada-toast');
        // DataTable hien thi
        this.dataTableElement = this.querySelector('atscada-data-table');
        // Bang chon thoi gian (tu ngay den ngay)
        this.dateRangePickerElement = this.querySelector('atscada-date-range-picker');
        // Button bao cao (hien thi len DataTable)
        this.reportButtonElement = this.querySelector('.atscada-alarm-reporter-report');
        // Button xuat excel (sau khi da Report)
        this.exportButtonElement = this.querySelector('.atscada-alarm-reporter-export');

        this.id = AtscadaAlarmReportElement.getId();
        this.content = 'Alarm Report';
        this.connection = 'atscada';
        this.tableName = 'alarmlog';
        this.timeout = 30000;
    }


    static getId() {
        index += 1;
        return `${index}`;
    }

    async connectedCallback() {

        // Lay cac cau hinh cai dat tu xml attribute
        this.content = this.getAttribute('at-content') || this.content;
        this.connection = this.getAttribute('at-connection') || this.connection;
        this.tableName = this.getAttribute('at-table-name') || this.tableName;
        this.timeout = this.getAttribute('at-timeout') || this.timeout;

        this.model = new AtscadaAlarmReporterModel(this);
        this.view = new AtscadaAlarmReporterView(this.model, this);
        this.controller = new AtscadaAlarmReporterController(this.model, this.view);

        this.model.initialize();
        await this.view.initialize();
        this.controller.initialize();
    }

    disconnectedCallback() {
        index -= 1;
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

customElements.define('atscada-alarm-reporter', AtscadaAlarmReportElement);