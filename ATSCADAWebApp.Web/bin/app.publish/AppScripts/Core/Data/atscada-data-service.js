
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaDataCompiler } from './atscada-data-compiler.js'

// service ket noi den cac Controller. Doc/Ghi gia tri cac tag
export class AtscadaDataService {
    constructor(timeout = 3000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaDataCompiler();
    }

    // Ham read
    async read(names) {
        // DataController - Read action
        const url = '/Data/Read';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(names),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeResultPackages(response);
    }

    // DataController - Write action
    async write(writeParams) {
        const encodeParam = this.compiler.encodeCommands(writeParams);
        const url = '/Data/Write';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeResultPackages(response);
    }

    abort() {
        this.service.abort();
    }
}