
// tham so cua moi Filed du lieu
export class AtscadaDataReportItemParam {
    constructor(
        alias = 'DataReport',       
        color = '#000000') {

        // Alais - Ten Field trong tableLog
        this.alias = alias;
        // mau sac hien thi trong file Excel
        this.color = color;
    }
}