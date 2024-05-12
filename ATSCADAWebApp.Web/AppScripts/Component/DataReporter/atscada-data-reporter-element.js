
const template = document.createElement('template');
template.innerHTML = `            
<atscada-toast at-title="Data Reporter"></atscada-toast>
<div class="panel panel-default panel-hover-icon">
    <div class="panel-heading">
        <h4 class="atscada-data-reporter-content panel-title">Data Reporter</h4>
    </div>
    <div class="panel-toolbar">
        <div class="form-group row">
            <div class="col-sm-4">
                <atscada-date-range-picker></atscada-date-range-picker>
            </div>
            <div class="col-sm-3">
                <div class="row">
                    <div class="col-sm-6">
                        <button title="Report" type="button" class="atscada-data-reporter-report btn btn-default w-100" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">
                            Report
                        </button>
                    </div>
                    <div class="col-sm-6">
                        <button title="Export" type="button" class="atscada-data-reporter-export btn btn-default w-100" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;" disabled>
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
import { AtscadaDataReporterModel } from './atscada-data-reporter-model.js'
import { AtscadaDataReporterView } from './atscada-data-reporter-view.js'
import { AtscadaDataReporterController } from './atscada-data-reporter-controller.js'
import { AtscadaDataReporterItemElement } from './atscada-data-reporter-item-element.js'


// danh index hien thi cho cac DataReport tren cung 1 view
// Moi repoter se co 1 ID rieng
let index = 0;

// Component xuat bao cao dataReport

class AtscadaDataReporterElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `<slot></slot>`;
        // tieu de hien thi
        this.contentElement = this.querySelector('.atscada-data-reporter-content');
        // bang thong bao
        this.toastElement = this.querySelector('atscada-toast');
        // DataTable
        this.dataTableElement = this.querySelector('atscada-data-table');
        // Bang chon thoi gian tu ngay den ngay
        this.dateRangePickerElement = this.querySelector('atscada-date-range-picker');
        // Button bao cao (hien thi len DataTable)
        this.reportButtonElement = this.querySelector('.atscada-data-reporter-report');
         // Button xuat excel (sau khi da Report)
        this.exportButtonElement = this.querySelector('.atscada-data-reporter-export');

        this.id = AtscadaDataReporterElement.getId();
        this.content = 'Data Report';
        this.connection = 'atscada';
        this.tableName = 'datalog';
        this.timeout = 30000;
        this.headerNames = ['DateTime'];
        this.options = { columns: [{ data: 'DateTime' }] };
        this.items = [];

        this.listen();
    }

    static getId() {
        index += 1;
        return `${index}`;
    }

    connectedCallback() {

        // Lay cac cau hinh cai dat tu xml attribute
        this.content = this.getAttribute('at-content') || this.content;
        this.connection = this.getAttribute('at-connection') || this.connection;
        this.tableName = this.getAttribute('at-table-name') || this.tableName;
        this.timeout = this.getAttribute('at-timeout') || this.timeout;
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

    listen() {
        // Dang ky su kien Slot den phat hien phan tu con duoc them vao 
        const slot = this.shadowRoot.querySelector('slot');
        slot.addEventListener('slotchange', (e) => {
            const elements = e.target.assignedElements();
            elements.forEach((element) => {
                // Kiem tra phan tu con co phai la ReportItem hay khong
                if (element instanceof AtscadaDataReporterItemElement) {
                    if (!this.headerNames.includes(element.alias)) {
                        // Them header, column hien thi tren Datatable theo Alias
                        this.headerNames.push(element.alias);
                        this.options.columns.push({
                            data: element.alias
                        });
                        this.items.push(element.param);
                    }
                }
            });
            this.initialize();
        });
    }

    async initialize() {
        // Khai bao MVC
        this.model = new AtscadaDataReporterModel(this);
        this.view = new AtscadaDataReporterView(this.model, this);
        this.controller = new AtscadaDataReporterController(this.model, this.view);

        this.model.initialize();
        await this.view.initialize();
        this.controller.initialize();
    }
}

customElements.define('atscada-data-reporter', AtscadaDataReporterElement);