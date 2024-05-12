
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaExportCompiler } from './atscada-export-compiler.js'

// Service ket noi den controller
export class AtscadaExportService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaExportCompiler();
    }

    // tra ve du lieu Array cua FileExcel AlarmrReport
    async getAlarmReport(exportParam) {
        const encodeParam = this.compiler.encodeExportParam(exportParam);
        const url = '/Export/GetAlarmReport';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeExcel('AlarmReport', response);
    }

    // tra ve du lieu Array cua FileExcel DataReport
    async getDataReport(exportParam) {
        const encodeParam = this.compiler.encodeExportParam(exportParam);
        const url = '/Export/GetDataReport';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeExcel('DataReport', response);
    }
}