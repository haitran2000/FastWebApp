
const template = document.createElement('template');
template.innerHTML = `
<div class="table-responsive">
    <table class="table table-bordered table-hover w-100">
        <thead>
            <tr>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
</div>
`;

const cssUrls =
    [
        '/AppTemplate/plugins/datatables.net-bs5/css/dataTables.bootstrap5.min.css',
        '/AppTemplate/plugins/datatables.net-responsive-bs5/css/responsive.bootstrap5.min.css',
    ]

const scriptUrls =
    [
        '/AppTemplate/plugins/datatables.net/js/jquery.dataTables.min.js',
        '/AppTemplate/plugins/datatables.net-bs5/js/dataTables.bootstrap5.min.js',
        '/AppTemplate/plugins/datatables.net-responsive/js/dataTables.responsive.min.js',
        '/AppTemplate/plugins/datatables.net-responsive-bs5/js/responsive.bootstrap5.min.js',
        '/AppTemplate/plugins/loading-overlay/js/loadingoverlay.min.js',
    ]

const optionsDefault = {
    dom: "Blfrtip",
    columnDefs: [{
        defaultContent: "-",
        targets: "_all"
    }],
    lengthMenu: [[10, 20, 50, -1], [10, 20, 50, 'Limit']],
    responsive: true,
    ordering: false
};

import { AtscadaImporter } from '../../Common/atscada-importer.js'

let importer;

export class AtscadaDataTableElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        this.headerElement = this.querySelector('table').tHead.children[0];
        this.loadingElement = $('table', this);
    }

    disconnectedCallback() {
        if (this.dataTable)
            this.dataTable.destroy();
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    static get importer() {
        if (!importer) {
            importer = new AtscadaImporter();
            importer.addCss(cssUrls);
            importer.addScript(scriptUrls);
        }
        return importer;
    }

    async setup(tableParam) {
        const importer = AtscadaDataTableElement.importer;
        if (!importer.isLoaded) {
            importer.dispatcher.on('loaded', () => this.initialize(tableParam));
            await importer.load();
            return;
        }
        this.initialize(tableParam);
    }

    initialize(tableParam) {        
        this.headerElement.innerHTML = '';
        for (const headerName of tableParam.headerNames) {
            const tableHeader = document.createElement('th');
            tableHeader.innerHTML = headerName;
            this.headerElement.appendChild(tableHeader);
        }
        if ($.fn.DataTable.isDataTable(this.dataTable)) {
            this.dataTable.destroy();
        }
        const customOptions = Object.assign({}, optionsDefault, tableParam.options);
        this.dataTable = $('.table', this).DataTable(customOptions);
    }

    update(data) {
        if (this.dataTable) {
            this.dataTable.clear();
            this.dataTable.rows.add(data);
            this.dataTable.draw(false);
        }        
    }

    showLoading(options) {
        this.loadingElement.LoadingOverlay('show', options);
    }

    hideLoading() {
        this.loadingElement.LoadingOverlay('hide');
    }
}

customElements.define('atscada-data-table', AtscadaDataTableElement);