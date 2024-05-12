
const template = document.createElement('template');
template.innerHTML = `
<input type="checkbox"/>
`;
const optionsDefault = {
    color: '#008080'
}

const cssUrls =
    [
        '/AppTemplate/plugins/switchery/dist/switchery.min.css'
    ]

const scriptUrls =
    [
        '/AppTemplate/plugins/switchery/dist/switchery.min.js'
    ]

import { AtscadaImporter } from '../../Common/atscada-importer.js'
import { AtscadaDispatcher } from '../../Common/atscada-dispatcher.js'

let importer;

export class AtscadaSwitcheryElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.inputElement = this.querySelector('input');

        this.dispatcher = new AtscadaDispatcher();
        this.instance = null;
        this.isCompleted = false;
    }

    static get importer() {
        if (!importer) {
            importer = new AtscadaImporter();
            importer.addCss(cssUrls);
            importer.addScript(scriptUrls);
        }
        return importer;
    }

    disconnectedCallback() {
        if (this.instance)
            this.instance.destroy();
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }
    
    async setup(options) {      
        const importer = AtscadaSwitcheryElement.importer;
        if (!importer.isLoaded) {
            importer.dispatcher.on('loaded', () => this.initialize(options));
            await importer.load();
            return;
        }
        this.initialize(options);
    }

    initialize(options) {
        const customOptions = Object.assign({}, optionsDefault, options);
        this.instance = new Switchery(this.inputElement, customOptions);      
        this.isCompleted = true;
        this.dispatcher.dispatch('completed', {});
    }
}

customElements.define('atscada-switchery', AtscadaSwitcheryElement);