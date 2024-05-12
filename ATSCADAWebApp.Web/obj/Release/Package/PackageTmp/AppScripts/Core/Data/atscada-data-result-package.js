
// goi data truyen giua Client - Server
export class AtscadaDataResultPackage {
    constructor(result) {
        result = result || {};
        this['Name'] = result['Name'] || null;
        this['Value'] = result['Value'] || null;
        this['Status'] = result['Status'] || 'Uncertain';
        this['TimeStamp'] = result['TimeStamp'] || '';
    }    
}