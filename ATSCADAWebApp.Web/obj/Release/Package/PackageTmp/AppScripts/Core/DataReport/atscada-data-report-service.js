
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaDataReportCompiler } from './atscada-data-report-compiler.js'

// service ket noi den Controller...
export class AtscadaDataReportService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaDataReportCompiler();
    }

    // truy van du lieu dataReport
    async getDataReportLogs(dataReportParam) {
        const encodeParam = this.compiler.encodeDataReportParam(dataReportParam);
        // ReportContrller - GetDataReportLogs
        const url = '/Report/GetDataReportLogs';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeDataReportLogs(response);
    }
}