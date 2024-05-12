
import { AtscadaFetchService } from '../../Core/Common/atscada-fetch-service.js'
import { AtscadaAppRouterCompiler } from './atscada-app-router-compiler.js'

// Service ket noi den RouterController de get Content view can hien thi
// Tham so truyen la #hash location
export class AtscadaAppRouterService {
    constructor(timeout = 30000) {
        this.timeout = timeout;
        this.service = new AtscadaFetchService();
        this.compiler = new AtscadaAppRouterCompiler();
    }

    async getView(location) {        
        const url = `/Routing/GetView?location=${location}`;
        const options = {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },           
            timeout: this.timeout
        };
        const response = await this.service.handler(url, options);
        return this.compiler.decodeView(response);
    }
}