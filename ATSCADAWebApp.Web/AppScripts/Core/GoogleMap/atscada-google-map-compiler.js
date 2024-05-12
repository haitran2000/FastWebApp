
import { AtscadaGoogleMapLog } from './atscada-google-map-log.js'

export class AtscadaGoogleMapCompiler {
    decodeGoogleMapLogs(response) {
        response = response || {};
        const data = [];
        if (!this.checkFailed(response)) {
            for (const result of response['Result']) {
                data.push(new AtscadaGoogleMapLog(result));
            }
        }
        return data;
    }

    encodeGoogleMapParam(data) {
        data = data || {};
        return {
            'ID': data.id,
            'Content': data.content,
            'Connection': data.connection,
            'TableName': data.tableName,
            'FromDateTime': data.fromDateTime,
            'ToDateTime': data.toDateTime
        }
    }

    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}