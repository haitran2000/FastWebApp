
const template = document.createElement('template');
template.innerHTML = `
<div id="header" class="app-header">
    <div class="navbar-header">
        <button type="button" class="navbar-desktop-toggler" data-toggle="app-sidebar-minify">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <button type="button" class="navbar-mobile-toggler" data-toggle="app-sidebar-mobile">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <div class="navbar-brand">
        </div>
    </div>
    <div class="navbar-nav">
        <div class="atscada-header-dropdown navbar-item navbar-user dropdown">
            <div class="navbar-link dropdown-toggle d-flex align-items-center" data-bs-toggle="dropdown">
                <div class="image image-icon bg-gray-800 text-gray-600">
                    <i class="fa fa-user"></i>
                </div>
            </div>
            <div class="dropdown-menu dropdown-menu-end me-1">
                <a href="javascript:;" class="atscada-header-mode dropdown-item">- - -</a>
                <div class="atscada-header-divider dropdown-divider"></div>
                <a href="#" class="atscada-header-logout dropdown-item">Logout</a>
            </div>
        </div>
    </div>
</div>
`;


export class AtscadaAppHeaderElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        // Thanh header hien thi. Boa gom:
        // 1. Ten du an
        this.brandElement = this.querySelector('.navbar-brand');
        // 2. Che do giao dien hien tai (Dark - Light mode)
        this.modeElement = this.querySelector('.atscada-header-mode');
        this.dividerElement = this.querySelector('.atscada-header-divider');
        // 3. Nut logout
        this.logoutElement = this.querySelector('.atscada-header-logout');       
    }

    connectedCallback() {
        // khi bam nao nut Mode thi thay doi giao dien hien thi cua Trang
        // Chuyen doi luan phie giua 2 mode: Dark - Light
        this.modeElement.addEventListener('click', (e) => {
            e.preventDefault();
            this.setMode(false);
        });

        this.setMode(true);
    }

    disconnectedCallback() {
        // Khi xoa. Chuyen trang se xoa tat ca pha tu con chua trong
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }
    // Getter cua cac property
    get brand() {
        return this.brandElement.innerText;
    }

    set brand(value) {
        this.brandElement.innerHTML = value;
    }

    get logoutUrl() {
        return this.logoutElement.href;
    }

    set logoutUrl(value) {
        this.logoutElement.href = value;
    }

    // cho phep hien thi nut Logout hay khong
    setDisplayLogout(value) {
        var displayStyle = value ? 'block' : 'none';
        this.dividerElement.style.display = displayStyle;
        this.logoutElement.style.display = displayStyle;
    }

    // Set cho do giao dien hien thi
    // Them class "dark-mode" vao<html> de bat che do DarkMode
    setMode(init) {
        var htmlElement = document.querySelector('html');
        if (htmlElement.classList.contains('dark-mode')) {
            if (init) {
                this.modeElement.innerHTML = 'Light mode';
            }
            else {
                htmlElement.classList.remove("dark-mode");
                this.modeElement.innerHTML = 'Dark mode';
            }
            
        }
        else {
            if (init) {
                this.modeElement.innerHTML = 'Dark mode';
            }
            else {
                htmlElement.classList.add("dark-mode");
                this.modeElement.innerHTML = 'Light mode';
            }           
        }        
    }
}

customElements.define('atscada-app-header', AtscadaAppHeaderElement);