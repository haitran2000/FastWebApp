
// Command. Doi tuong dong goi action Tag.Write

export class AtscadaDataCommand {
    constructor(param) {
        this.name = param.name;
        // Gia tri can ghi
        this.value = param.value;
        // callback thong bao hoan thanh 1 luot ghi
        this.result = param.result;

        // da hoan thanh viec ghi hay chua
        this.isCompleted = false;
        this.numberOfWrite = 0;
        this.maxNumberOfWrite = 10;
    }

    // Cap nhat trang thai tu goi tin Package (server) tra ve
    update(resultPackage) {       
        resultPackage = resultPackage || {};
        // Kiem tra goi tin tra ve. Cos dung Name, Value hay khong
        // ... Trang thai co Good hay khong
        if (resultPackage['Name'] === this.name &&
            resultPackage['Value'] === this.value &&
            resultPackage['Status'] === 'Good') {
            //... Neu Good thi bao da hoan thanh viec ghi

            // call callback
            this.result(resultPackage);
            this.isCompleted = true;
        }
        else {
            // ... Neu sai thi +1 so lan ghi (numberOfWrite)            
            this.numberOfWrite++;
            if (this.numberOfWrite < this.maxNumberOfWrite)
                return;
            resultPackage['Name'] = this.name;
            resultPackage['Value'] = this.value;
            this.result(resultPackage);
            this.isCompleted = true;
        }        
    }
}