
const template = document.createElement('template');
template.innerHTML = `
<div class="input-group">
    <input type="text" name="daterange" class="form-control" value="" placeholder="Click to select the date range" />
    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
</div>
`;

const cssUrls =
    [
        '/AppTemplate/plugins/bootstrap-daterangepicker/daterangepicker.css'
    ]

const scriptUrls =
    [
        '/AppTemplate/plugins/moment/min/moment.min.js',
        '/AppTemplate/plugins/bootstrap-daterangepicker/daterangepicker.js'
    ]

import { AtscadaImporter } from '../../Common/atscada-importer.js'

let importer;

class ATSCADADateRangePickerElement extends HTMLElement {   
    constructor() {
        super();
        var clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.dateRange = $('input[name = "daterange"]', this);
        this.format = 'MM-DD-YYYY HH:mm:00';      
    }

    static get importer() {
        if (!importer) {
            importer = new AtscadaImporter();
            importer.addCss(cssUrls);
            importer.addScript(scriptUrls);
        }
        return importer;
    }

    async connectedCallback() {
        const importer = ATSCADADateRangePickerElement.importer;
        if (!importer.isLoaded) {
            importer.dispatcher.on('loaded', () => this.initialize());
            await importer.load();
            return;
        }
        this.initialize();
    }

    disconnectedCallback() {
        this.dateRange.data('daterangepicker').remove();
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }
    
    initialize() {
        const start = moment().startOf('month');
        const end = moment();
        this.dateRange.daterangepicker({
            opens: "right",
            autoUpdateInput: false,
            timePicker: true,
            timePicker24Hour: true,
            timePickerIncrement: 5,
            startDate: start,
            endDate: end,
            minDate: "01/01/2000",
            maxDate: "12/31/2100",
        });
        this.dateRange.on('apply.daterangepicker', (ev, picker) => {
            const value = this.getDateRangeValue(picker.startDate, picker.endDate);
            this.dateRange.val(value);
        });
        const value = this.getDateRangeValue(start, end);
        this.dateRange.val(value);
    }

    get startDate() {
        return this.dateRange
            .data('daterangepicker')
            .startDate
            .format(this.format);
    }

    get endDate() {
        return this.dateRange
            .data('daterangepicker')
            .endDate
            .format(this.format);
    }   
   
    getDateRangeValue(startDate, endDate) {
        return startDate.format(this.format) + " - " + endDate.format(this.format);
    }   
}

customElements.define('atscada-date-range-picker', ATSCADADateRangePickerElement);
