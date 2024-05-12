
var template = document.createElement('template');
template.innerHTML = `
<div class="atscada-nvd3-observer-container">
    <div class="atscada-nvd3-chart-container"></div>
</div>
`;

const cssUrls =
    [
        '/AppTemplate/plugins/nvd3/build/nv.d3.css'
    ]

const scriptUrls =
    [
        '/AppTemplate/plugins/d3/d3.min.js',
        '/AppTemplate/plugins/nvd3/build/nv.d3.min.js'
    ]

import { AtscadaImporter } from '../../Common/atscada-importer.js'
import { AtscadaNvd3ChartFactory } from './atscada-nvd3-chart-factory.js'

let importer;

export class AtscadaNvd3ChartElement extends HTMLElement {
    constructor() {
        super();
        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        this.observerContainer = this.querySelector('.atscada-nvd3-observer-container');
        this.chartContainer = this.querySelector('.atscada-nvd3-chart-container');
        this.preWidth = this.observerContainer.clientWidth;
    }

    static get importer() {
        if (!importer) {
            importer = new AtscadaImporter();
            importer.addCss(cssUrls);
            importer.addScript(scriptUrls);
        }
        return importer;
    }

    async connectedCallback() {
        const observer = new ResizeObserver(changes => {
            for (const change of changes) {
                if (change.contentRect.width === this.preWidth) return;
                this.preWidth = change.contentRect.width;
                if (this.instance)
                    setTimeout(() => {
                        this.instance.update([]);
                    }, 200);
            }
        });
        observer.observe(this.observerContainer);
    }

    disconnectedCallback() {
        d3.select(this).select('.atscada-nvd3-chart-container').select('svg').remove();
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    async setup(chartParam) {
        const importer = AtscadaNvd3ChartElement.importer;
        if (!importer.isLoaded) {
            importer.dispatcher.on('loaded', () => this.initialize(chartParam));
            await importer.load();
            return;
        }
        this.initialize(chartParam);
    }

    initialize(chartParam) {
        this.chartContainer.style.height = chartParam.height;
        this.instance = AtscadaNvd3ChartFactory.getChart({
            ...chartParam,
            container: d3.select(this).select('.atscada-nvd3-chart-container')
        });
        this.instance.initialize();
        document.addEventListener("touchmove", () => {
            d3.selectAll('.nvtooltip').style('opacity', '0');
        }, false);
        document.addEventListener("scroll", () => {
            d3.selectAll('.nvtooltip').style('opacity', '0');
        }, false);
        document.addEventListener("mouseout", () => {
            d3.selectAll('.nvtooltip').style('opacity', '0');
        }, false);
    }

    update(itemModels) {
        if (this.instance) {
            this.instance.update(itemModels);
        }
    }
}

customElements.define('atscada-nvd3-chart', AtscadaNvd3ChartElement);