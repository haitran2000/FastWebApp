
// goi tin alarm log
export class AtscadaAlarmReportLog {
    constructor(result) {
        result = result || {};
        this['DateTime'] = result['DateTime'] || null;
        this['TagName'] = result['TagName'] || null;
        this['TagAlias'] = result['TagAlias'] || null;
        this['Value'] = result['Value'] || null;
        this['HighLevel'] = result['HighLevel'] || null;
        this['LowLevel'] = result['LowLevel'] || null;
        this['Status'] = result['Status'] || null;
        this['ACK'] = result['ACK'] || null;
    }
}