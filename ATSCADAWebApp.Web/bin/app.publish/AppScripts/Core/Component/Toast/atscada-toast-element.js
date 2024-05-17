
const template = document.createElement('template');
template.innerHTML = `    
    <div class="toast-container">
        <div class="toast hide">
            <div class="toast-header">
                <div class="atscada-toast-icon rounded w-25px h-25px d-flex align-items-center justify-content-center text-white">
                    <i class="fa fa-bell"></i>
                </div>
                <strong class="me-auto ms-2">Notification</strong>
                <span class="atscada-toast-content">- - -</span>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="atscada-toast-body toast-body">
                - - -
            </div>
        </div>
    </div>
`;

export class AtscadaToastElememt extends HTMLElement {
    constructor() {
        super();

        var clone = document.importNode(template.content, true);
        this.appendChild(clone);

        this.toastElement = this.querySelector('.toast');
        this.contentElement = this.querySelector('.atscada-toast-content');
        this.bodyElement = this.querySelector('.atscada-toast-body');
        this.iconElement = this.querySelector('.atscada-toast-icon');
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

    showSuccess(message) {
        this.bodyElement.innerHTML = message;
        this.#changeIconColor('bg-green');
        this.#show();
    }

    showError(message) {
        this.bodyElement.innerHTML = message;
        this.#changeIconColor('bg-red');
        this.#show();
    }

    #changeIconColor(background) {       
        for (let index = this.iconElement.classList.length - 1; index >= 0; index--) {
            const className = this.iconElement.classList[index];
            if (className.startsWith('bg-')) {
                this.iconElement.classList.remove(className);
            }
        }
        this.iconElement.classList.add(background);
    }

    #show() {       
        const toast = new bootstrap.Toast(this.toastElement);
        toast.show();
    }
}

customElements.define('atscada-toast', AtscadaToastElememt);
