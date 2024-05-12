
import { AtscadaDataReportLog } from './atscada-data-report-log.js'

// giai ma - ma hoa cac goi tin dataReport
export class AtscadaDataReportCompiler {

    // ma hoa goi tin dataReport tra ve tu Server
    decodeDataReportLogs(response) {
        response = response || {};
        const dataReportLogs = [];
        if (!this.checkFailed(response)) {
            for (const result of response['Result']) {
                dataReportLogs.push(
                    new AtscadaDataReportLog(result));
            }
        }
        return dataReportLogs;
    }

    // ma hoa tham so truy van report
    encodeDataReportParam(dataReportParam) {
        dataReportParam = dataReportParam || {};
        return {
            'ID': dataReportParam.id,
            'Content': dataReportParam.content,
            'Connection': dataReportParam.connection,
            'TableName': dataReportParam.tableName,
            'FromDateTime': dataReportParam.fromDateTime,
            'ToDateTime': dataReportParam.toDateTime,           
            'Items': dataReportParam.items
        }
    }

    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}