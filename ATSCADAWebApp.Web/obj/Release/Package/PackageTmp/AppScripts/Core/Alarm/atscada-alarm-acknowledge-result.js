
// goi tin tra ve cua AlarmACk tu Server
export class AtscadaAlarmAcknowledgeResult {
    constructor(result) {
        result = result || {};
        this.connection = result['Connection'] || 'Unknown';
        this.tableName = result['TableName'] || 'Unknown';
        this.numberOfRows = result['NumberOfRows'] || 0;
        this.status = result['Status'] || false;
    }
}