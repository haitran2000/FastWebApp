
import { AtscadaAlarm } from './atscada-alarm.js'
import { AtscadaAlarmAcknowledgeResult } from './atscada-alarm-acknowledge-result.js'

// ma hoa - giai ma goi tin alarmALog, alarm ack (object c# va JS)
export class AtscadaAlarmCompiler {

    // giai ma goi tin alarm log tra ve tu Server
    decodeAlarms(response) {
        response = response || {};
        const alarms = [];
        if (!this.checkFailed(response)) {
            for (const result of response['Result']) {
                alarms.push(new AtscadaAlarm(result));
            }
        }
        return alarms;
    }

    // giai ma goi tin tra ve ket qua ACK
    decodeAcknowledgeResult(response) {
        response = response || {};
        if (!this.checkFailed(response))
            return new AtscadaAlarmAcknowledgeResult(response['Result']);
        return new AtscadaAlarmAcknowledgeResult();
    }

    // ma hoa tham so truyen get alarm log
    encodeAlarmParam(alarmParam) {
        alarmParam = alarmParam || {};
        return {
            'Connection': alarmParam.connection,
            'TableName': alarmParam.tableName,
            'Limit': alarmParam.limit,
        }
    }

    // ma hoa goi tra tin tra ve ket qua ACK
    encodeAlarmAcknowledgeParam(alarmAcknowledgeParam) {
        alarmAcknowledgeParam = alarmAcknowledgeParam || {};
        return {
            'Connection': alarmAcknowledgeParam.connection,
            'TableName': alarmAcknowledgeParam.tableName           
        }
    }

    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}