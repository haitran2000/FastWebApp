
// doi tuong dataReport log
export class AtscadaDataReportLog {
    constructor(result) {
        result = result || {};
        this['DateTime'] = result['DateTime'] || null;
        for (const dataReportItem of result['DataReportItemLogs']) {
            // alias cua dataReport se uduco gan lam Property cua object
            this[dataReportItem['Alias']] = dataReportItem['Value'] || null;
        }
    }
}