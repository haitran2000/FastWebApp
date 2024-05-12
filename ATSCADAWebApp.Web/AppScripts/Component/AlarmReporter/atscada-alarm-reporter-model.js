
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'
import { AtscadaAlarmReportParam } from '../../Core/AlarmReport/atscada-alarm-report-param.js'
import { AtscadaExportParam } from '../../Core/Export/atscada-export-param.js'
import { AtscadaAlarmReportService } from '../../Core/AlarmReport/atscada-alarm-report-service.js'
import { AtscadaExportService } from '../../Core/Export/atscada-export-service.js'

// Thong bao cho View (UI) biet
// 1. Da co du lieu report ---> Yeu cau hien thi, cap nhat len UI (DataTable)
export class AtscadaAlarmReporterModel {
    constructor(element) {
        this.element = element;
        this.alarmReportService = new AtscadaAlarmReportService(element.timeout);
        this.exportService = new AtscadaExportService(element.timeout);
        this.dispatcher = new AtscadaDispatcher();
        this.exportParam = new AtscadaExportParam(element.id);

        this.dateRangePickerElement = element.dateRangePickerElement;       
    }

    initialize() {
    }

    async report() {
        // Ham report.
        // Ket noi den Service de get du lieu AlarmReport
        const alarmReportParam = new AtscadaAlarmReportParam(
            this.element.id,
            this.element.content,
            this.element.connection,
            this.element.tableName,
            this.dateRangePickerElement.startDate,
            this.dateRangePickerElement.endDate
        );
        const alarmReportLogs = await this.alarmReportService.getAlarmReportLogs(alarmReportParam);
        // Thong bao da nhan duoc du lieu report
        this.onEventReported(alarmReportLogs);
    }
    
    onEventReported(alarmReportLogs) {
        alarmReportLogs = alarmReportLogs || [];
        this.dispatcher.dispatch('reported', alarmReportLogs);
    }

    async export() {
        // Xuat bao cao excel
        const result = await this.exportService.getAlarmReport(this.exportParam);
        return result;
    }

    dispose() { }
}
