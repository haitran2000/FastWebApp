
import { AtscadaFetchService } from '../Common/atscada-fetch-service.js'
import { AtscadaGoogleMapCompiler } from './atscada-google-map-compiler.js'

// Service ket noi den Databse de lay du lieu lich su thoi gian di chuyen
export class AtscadaGoogleMapService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaGoogleMapCompiler();
    }

    // Load data from database
    async loadDatabase(data) {
        const encodeParam = this.compiler.encodeGoogleMapParam(data);
        const url = '/GoogleMap/LoadDatabase';
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(encodeParam),
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeGoogleMapLogs(response);
    }
}

