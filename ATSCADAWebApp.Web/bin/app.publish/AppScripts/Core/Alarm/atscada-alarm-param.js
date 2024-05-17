
// tham so truyen khi get danh sach alarm log
export class AtscadaAlarmParam {
    constructor(
        connection = 'atscada',
        tableName = 'alarmlog',
        limit = 50) {

        // chuoi ket noi database
        this.connection = connection;
        // table alarm log
        this.tableName = tableName;
        // gioi han so hang query
        this.limit = limit;
    }
}