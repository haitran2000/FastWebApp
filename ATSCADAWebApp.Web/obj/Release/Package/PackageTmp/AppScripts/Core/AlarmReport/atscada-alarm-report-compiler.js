
import { AtscadaAlarmReportLog } from './atscada-alarm-report-log.js'

// giai ma = hoa hoa cac goi tin alarmLog
export class AtscadaAlarmReportCompiler {
    // giai ma akarm report log
    decodeAlarmReportLogs(response) {
        response = response || {};
        const alarmReportLogs = [];
        if (!this.checkFailed(response)) {
            for (const result of response['Result']) {
                alarmReportLogs.push(new AtscadaAlarmReportLog(result));
            }
        }
        return alarmReportLogs;
    }

    // ma hoa tham so truyen get alarmReportLog
    encodeAlarmReportParam(alarmReportParam) {
        alarmReportParam = alarmReportParam || {};
        return {
            'ID': alarmReportParam.id,
            'Content': alarmReportParam.content,
            'Connection': alarmReportParam.connection,
            'TableName': alarmReportParam.tableName,
            'FromDateTime': alarmReportParam.fromDateTime,
            'ToDateTime': alarmReportParam.toDateTime
        }
    }

    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}