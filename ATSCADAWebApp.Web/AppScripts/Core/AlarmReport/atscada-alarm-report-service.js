
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaAlarmReportCompiler } from './atscada-alarm-report-compiler.js'

// service ket noi den Controller
export class AtscadaAlarmReportService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaAlarmReportCompiler();
    }

    // get alarmReport log
    async getAlarmReportLogs(alarmReportParam) {
        const encodeParam = this.compiler.encodeAlarmReportParam(alarmReportParam);
        // ReportController - GetAlarmLogs action
        const url = '/Report/GetAlarmReportLogs';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeAlarmReportLogs(response);
    }    
}

