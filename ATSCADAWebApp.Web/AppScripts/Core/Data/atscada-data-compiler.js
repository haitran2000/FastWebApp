
import { AtscadaDataResultPackage } from './atscada-data-result-package.js'

// Ma hoa - gia ma goi tin truyen. Chuyen doi giua object C# va JS 
export class AtscadaDataCompiler {

    // Giai ma goi tin tra ve tu Server
    decodeResultPackages(response) {
        response = response || {};        
        if (this.checkFailed(response)) return undefined;
        const resultPackages = [];
        for (const result of response['Result']) {
            resultPackages.push(
                new AtscadaDataResultPackage(result));
        }
        return resultPackages;
    }

    // Ma hoa command write
    encodeCommands(commands) {
        commands = commands || [];
        const encodeParam = [];
        for (const command of commands) {
            encodeParam.push({
                'Name': command.name,
                'Value': command.value
            });
        }
        return encodeParam;
    }

    checkFailed(response) {
        return !response || !response['Status'] || !response['Result'];
    }
}