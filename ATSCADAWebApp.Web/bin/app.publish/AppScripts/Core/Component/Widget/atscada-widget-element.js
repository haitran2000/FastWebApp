
const template = document.createElement('template');
template.innerHTML = `
    <div class="widget widget-stats mb-10px">
        <div class="atscada-widget-icon stats-icon stats-icon-lg"><i class="fa fa-globe fa-fw"></i></div>
        <div class="stats-content">
            <div class="atscada-widget-content stats-title">Name</div>
            <div class="atscada-widget-number stats-number">- - - </div>
            <div class="atscada-widget-description stats-desc">Status: <strong>- - -</strong></div>
        </div>
    </div>   
`;

export class AtscadaWidget extends HTMLElement {

    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);

        this.widgetElement = this.querySelector('.widget');
        this.iconElement = this.querySelector('.atscada-widget-icon i');
        this.contentElement = this.querySelector('.atscada-widget-content');
        this.numberElement = this.querySelector('.atscada-widget-number');
        this.descriptionElement = this.querySelector('.atscada-widget-description strong');
    }

    disconnectedCallback() {
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    get content() {
        return this.contentElement.innerText;
    }

    set content(value) {
        this.contentElement.innerHTML = value;
    }

    get color() {
        return this.widgetElement.style.backgroundColor;
    }

    set color(value) {
        this.widgetElement.style.backgroundColor = value;
    }

    get icon() {
        return this.iconElement.classList;
    }

    set icon(value) {
        this.iconElement.classList = value
    }

    get number() {
        return this.numberElement.innerText;
    }

    set number(value) {
        this.numberElement.innerHTML = value;
    }

    get description() {
        return this.descriptionElement.innerText;
    }

    set description(value) {
        this.descriptionElement.innerText = value;
    }
}

customElements.define('atscada-widget', AtscadaWidget);