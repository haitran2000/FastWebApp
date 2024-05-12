
// tham so truyen den Server de get alarmReport log
export class AtscadaAlarmReportParam {
    constructor(
        id = 'AlarmReport',
        content = 'Alarm Report',
        connection = 'atscada',
        tableName = 'alarmlog',
        fromDateTime = '01-01-2000 00:00:00',
        toDateTime = '12-31-2100 23:59:59') {

        // id cua alarmReport
        this.id = id;
        // Tieu de hien thi
        this.content = content;
        // chuoi ket noi den database
        this.connection = connection;
        // table alarm log
        this.tableName = tableName;
        // thoi gian truy van tu ngay
        this.fromDateTime = fromDateTime;
        // thoi gian truy van den ngay
        this.toDateTime = toDateTime;
    }
}