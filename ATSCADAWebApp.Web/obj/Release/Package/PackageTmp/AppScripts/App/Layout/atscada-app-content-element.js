
const template = document.createElement('template');
template.innerHTML = `
<div id="content" class="app-content"></div>
`;

const warningTemplate = document.createElement('template');
warningTemplate.innerHTML = `
<a href="javascript:history.back()" class="btn btn-danger rounded-0">
    <span class="d-flex align-items-center text-left">
        <i class="fas fa-arrow-alt-circle-right fa-rotate-180 fa-2x me-3 text-black"></i>
        <span>
        <span class="d-block"><b>Not found!&nbsp;</b> Click here to go back</span>
    </span>
</a>
`;

// Container hien thi View
export class AtscadaAppContentElement extends HTMLElement {
    constructor() {
        super();
        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.appContent = this.querySelector('.app-content');
    }

    connectedCallback() {
    }

    // Khi xoa. De xoa, huy tat ca phan tu con chua ben trong
    disconnectedCallback() {
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    // Ham render, hien thi View
    render(html) {
        var content = undefined;
        if (html) {
            const contentTemplate = document.createElement('template');
            contentTemplate.innerHTML = html;
            content = document.importNode(contentTemplate.content, true);
        }
        else {
            content = document.importNode(warningTemplate.content, true);
        }

        this.appContent.appendChild(content);
    }

    // Xoa giao dien (View) hien tai
    clear() {
        let child = this.appContent.lastElementChild;
        while (child) {
            this.appContent.removeChild(child);
            child = this.appContent.lastElementChild;
        }
    }
}

customElements.define('atscada-app-content', AtscadaAppContentElement);