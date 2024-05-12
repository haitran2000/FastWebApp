
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaAlarmCompiler } from './atscada-alarm-compiler.js'

// service ket noi controller ...
export class AtscadaAlarmService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaAlarmCompiler();
    }

    // lay danh sach alarm log qua sevice
    async getAlarms(alarmParam) {
        const encodeParam = this.compiler.encodeAlarmParam(alarmParam);
        // AlarmController - GetAlarms action
        const url = '/Alarm/GetAlarms';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeAlarms(response);
    }

    // xac nhan ACK
    async acknowledge(alarmAcknowledgeParam) {
        const encodeParam = this.compiler.encodeAlarmAcknowledgeParam(alarmAcknowledgeParam);
        const url = '/Alarm/Acknowledge';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeAcknowledgeResult(response);
    }    
}