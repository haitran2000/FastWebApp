
// tham so truyen khi xac nhan ACK
export class AtscadaAlarmAcknowledgeParam {
    constructor(        
        connection = 'atscada',
        tableName = 'alarmlog') {

        // chuoi ket noi database
        this.connection = connection;
        // table alarm log
        this.tableName = tableName;
    }
}