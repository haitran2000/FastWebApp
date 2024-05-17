
// Tham so truyen truy van
export class AtscadaDataReportParam {
    constructor(
        id = 'DataReport',
        content = 'Data Report',
        connection = 'atscada',
        tableName = 'datalog',
        fromDateTime = '01-01-2000 00:00:00',
        toDateTime = '12-31-2100 23:59:59',      
        items = []) {

        // id cua dataReporter. Dung de phan biet giua cac Report khac nhau tren cung 1 View
        this.id = id;
        // Tieu de hien thi        
        this.content = content;
        // Chuoi ket noi dataBase
        this.connection = connection;
        // table dataLog
        this.tableName = tableName;
        // Thoi gian truy van. Tu ngay
        this.fromDateTime = fromDateTime; 
        // Thoi gian truy van. Den ngay
        this.toDateTime = toDateTime;
        // danh sach cac Item (filed) can truy van
        this.items = items;
    }
}