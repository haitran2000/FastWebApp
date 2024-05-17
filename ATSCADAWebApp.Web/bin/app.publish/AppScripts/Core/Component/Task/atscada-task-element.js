
import { AtscadaDataTask } from '../../Data/atscada-data-task.js'

export class AtscadaTaskElement extends HTMLElement {   
    constructor() {
        super();
        
        this.interval = 1000;
        this.maxNumberOfWrite = 10;
        this.timeout = 3000;
    }

    connectedCallback() {
        this.interval = Number(this.getAttribute('at-interval')) || this.interval;
        this.maxNumberOfWrite = Number(this.getAttribute('at-max-number-of-write')) || this.maxNumberOfWrite;
        this.timeout = Number(this.getAttribute('at-timeout')) || this.timeout;

        this.dataTask = new AtscadaDataTask({
            interval: this.interval,
            maxNumberOfWrite: this.maxNumberOfWrite,
            timeout: this.timeout
        });
    }

    disconnectedCallback() {
        if (this.dataTask)
            this.dataTask.stop();
        this.remove();
    }
}

customElements.define('atscada-task', AtscadaTaskElement)
