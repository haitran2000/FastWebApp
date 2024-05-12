
const template = document.createElement('template');
template.innerHTML = `
<input type="hidden" />
`;
const optionsDefault = {
    min: 0,
    max: 100,
    step: 1,
    grid: true,
    skin: 'big'
}

const cssUrls =
    [
        '/AppTemplate/plugins/ion-rangeslider/css/ion.rangeSlider.min.css'
    ]

const scriptUrls =
    [
        '/AppTemplate/plugins/ion-rangeslider/js/ion.rangeSlider.min.js'
    ]

import { AtscadaImporter } from '../../Common/atscada-importer.js'
import { AtscadaDispatcher } from '../../Common/atscada-dispatcher.js'

let importer;

export class AtscadaIonRangeSliderElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        this.dispatcher = new AtscadaDispatcher();
        this.instance = null;
        this.isCompleted = false;
    }

    static get scriptLoader() {
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
        const importer = AtscadaIonRangeSliderElement.scriptLoader;
        if (!importer.isLoaded) {
            importer.dispatcher.on('loaded', () => this.initialize(options));
            await importer.load();
            return;
        }
        this.initialize(options);
    }

    initialize(options) {
        const customOptions = Object.assign({}, optionsDefault, options);
        $('input', this).ionRangeSlider(customOptions);
        $('input', this).show();
        this.instance = $('input', this).data('ionRangeSlider');        
        this.isCompleted = true;
        this.dispatcher.dispatch('completed', {});
    }    
}

customElements.define('atscada-ion-range-slider', AtscadaIonRangeSliderElement);