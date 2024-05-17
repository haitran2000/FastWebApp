
const template = document.createElement('template');
template.innerHTML = `
    <div class="panel panel-default panel-hover-icon">
        <div class="panel-heading">
            <h4 class="panel-title atscada-stream-camera-content"></h4>
        </div>           
        <div class="panel-body">
            <video class="atscada-stream-camera-video video-js vjs-default-skin" muted autoplay controls preload="none">    
            </video>
        </div>
    </div>
`;

import { AtscadaFetchService } from '../../Core/Common/atscada-fetch-service.js'

export class AtscadaStreamCameraElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.contentElement = this.querySelector('.atscada-stream-camera-content');
        this.videoElement = this.querySelector('.atscada-stream-camera-video');

        this.player = null;
        this.content = 'Camera';
        this.connection = 'camera';
        this.network = 'Cloud';
        this.frame = 'vjs-fluid';
        this.tokenTime = '300';
        this.token = '';
        this.isOnline = true;
        this.timeoutTokenID = undefined;
        this.timeoutOnlineID = undefined;
        this.maxTimesRequest = 5;

        this.timeout = 10000;
        this.service = new AtscadaFetchService();
    }

    connectedCallback() {

        this.content = this.getAttribute('at-content') || this.content;
        this.network = this.getAttribute('at-network') || this.network;
        this.tokenTime = this.getAttribute('at-token-time') || this.tokenTime;
        this.frame = this.getAttribute('at-frame-size') || this.frame;
        this.connection = this.getAttribute('at-connection') || this.connection;

        this.contentElement.innerHTML = this.content;
        this.videoElement.classList.add(this.frame);
        this.player = videojs(this.videoElement);
        this.player.muted(true);

        setTimeout(async () => {
            var i;
            for (i = 0; i < this.maxTimesRequest; i++) {
                let result = await this.loadCamera();
                if (result) break;
                await new Promise(r => setTimeout(r, 2000));
            }
            this.requestToken();
            this.requestOnline();
        }, 500);
    }    

    disconnectedCallback() {

        if (this.timeoutTokenID)
            clearTimeout(this.timeoutTokenID);

        if (this.timeoutOnlineID)
            clearTimeout(this.timeoutOnlineID);

        if (this.player) {            
            this.player.dispose();
        }

        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    requestToken() {
        this.timeoutTokenID = setTimeout(async () => {
            var i;
            for (i = 0; i < this.maxTimesRequest; i++) {
                let result = await this.loadCamera();
                if (result) break;
                await new Promise(r => setTimeout(r, 2000));
            }            
            this.requestToken();
        }, this.tokenTime * 60 * 1000)
    }

    requestOnline() {
        this.timeoutOnlineID = setTimeout(async () => {

            var isOnline = await this.checkOnline();
            if (this.isOnline !== isOnline) {
                this.isOnline = isOnline;

                if (this.isOnline) await this.loadCamera();
            }
            this.requestOnline();
        }, 20000)
    }


    async loadCamera() {
        try {
            var param = { Connection: this.connection };
            const url = '/Camera/Web';
            const options = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8',
                    'Access-Control-Allow-Origin': '*'
                },
                body: JSON.stringify(param),
                timeout: this.timeout
            };
            let response = await this.service.handler(url, options);
            if (response) {
                this.token = response.Token;
                if (response.Status) {
                    if (response.Link) {
                        if (this.player) {
                            this.player.src({ type: 'application/x-mpegURL', src: response.Link });
                            return true;
                        }
                    }                    
                }
            }

            return false;
        }
        catch {
            return false;
        }
    }

    async checkOnline() {
        var param = { Connection: this.connection, Token: this.token };
        try {
            const url = '/Camera/Online';
            const options = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8',
                    'Access-Control-Allow-Origin': '*'
                },
                body: JSON.stringify(param),
                timeout: this.timeout
            };
            const response = await this.service.handler(url, options);
            if (response)
                if (response.Status) {
                    return response.Result;
                }

            return false;
        }
        catch {
            return false;
        }
    }
}

customElements.define('atscada-stream-camera', AtscadaStreamCameraElement)