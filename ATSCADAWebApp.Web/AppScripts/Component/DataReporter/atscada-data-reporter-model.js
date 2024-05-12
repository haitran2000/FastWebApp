
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'
import { AtscadaDataReportParam } from '../../Core/DataReport/atscada-data-report-param.js'
import { AtscadaExportParam } from '../../Core/Export/atscada-export-param.js'
import { AtscadaDataReportService } from '../../Core/DataReport/atscada-data-report-service.js'
import { AtscadaExportService } from '../../Core/Export/atscada-export-service.js'

export class AtscadaDataReporterModel {
    constructor(element) {
        this.element = element;
        // service ket noi Server. Get dataReport log
        this.dataReportService = new AtscadaDataReportService(element.timeout);
        // service xuat file excel
        this.exportService = new AtscadaExportService(element.timeout);
        this.dispatcher = new AtscadaDispatcher();
        this.exportParam = new AtscadaExportParam(element.id);

        this.dateRangePickerElement = element.dateRangePickerElement;
    }

    initialize() {
    }

    async report() {
        // Ket noi Controller qua service, ket noi lay du lieu dataReport
        const dataReportParam = new AtscadaDataReportParam(
            this.element.id,
            this.element.content,
            this.element.connection,
            this.element.tableName,
            this.dateRangePickerElement.startDate,
            this.dateRangePickerElement.endDate,           
            this.element.items
        );
        const dataReportLogs = await this.dataReportService.getDataReportLogs(dataReportParam);
        // Thong bao cho UI co su thay doi ve du lieu truy van
        // Cap nhat hien thi len UI (DataTable)
        this.onEventReported(dataReportLogs);
    }

    onEventReported(dataReportLogs) {
        dataReportLogs = dataReportLogs || [];
        this.dispatcher.dispatch('reported', dataReportLogs);
    }

    // Xuat file excel
    async export() {
        const result = await this.exportService.getDataReport(this.exportParam);
        return result;
    }

    dispose() { }
}
