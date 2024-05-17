
// Tham so truy van Database
export class AtscadaGoogleMapParam {
    constructor(
        id = 'GoogleMap',
        content = 'Google Map',
        connection = 'atscada',
        tableName = 'datalog',
        fromDateTime = '01-01-2000',
        toDateTime = '31-12-2100') {

        // Ma ID duy nhat gan cho tung Map tren View
        this.id = id;
        // Tieu de hien thi
        this.content = content;
        // Chuoi ket noi database
        this.connection = connection;
        // Table chua du lieu ve thong tin lo trinh di chuyen
        // ... Thoi gian, toa do (kinh do, vi do)
        this.tableName = tableName;
        // truy van tu ngay
        this.fromDateTime = fromDateTime;
        // ... den ngay
        this.toDateTime = toDateTime;
    }
}