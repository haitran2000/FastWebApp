
// Du lieu dataLog ve lo trinh di chuyen
export class AtscadaGoogleMapLog {
    constructor(result) {
        result = result || {};
        this['DateTime'] = result['DateTime'] || null;
        this['Location'] = result['Location'] || null;
        for (const parameter of result['Parameters']) {
            this[parameter['Alias']] = parameter['Value'] || null;
        }
    }
}