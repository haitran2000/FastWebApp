
const template = document.createElement('template');
template.innerHTML = `
<div class="menu-item">
    <div class="menu-link">
        <div class="menu-icon">
            <i class="material-icons">home</i>
        </div>
        <div class="menu-text">Home</div>
    </div>
</div>
`;

// quan ly cho moi Component View trong FastWeb
export class AtscadaAppViewElement extends HTMLElement {
    constructor() {
        super();
        this.appView = document.importNode(template.content, true);
        this.menuItem = this.appView.querySelector('.menu-item');
        this.menuIcon = this.appView.querySelector('.menu-icon i');
        this.menuText = this.appView.querySelector('.menu-text');
        this.content = 'Home';
        this.location = '#';
        this.icon = 'home';       
    }

    connectedCallback() {
        // Tieu de View. Ten hien thi tren ButtonMenu
        this.content = this.getAttribute('at-content') || this.content;
        // link. Dia chi #hash
        this.location = this.getAttribute('at-location') || this.location;
        // Icon hien thi tren ButtonView
        this.icon = this.getAttribute('at-icon') || this.icon;       

        this.menuText.innerHTML = this.content;
        this.menuIcon.innerHTML = this.icon;        
    }

    disconnectedCallback() {
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();        
    }

    get active() {
        return this.menuItem.classList.contains('active');
    }

    // set action
    // De action. Them class "active" vao buttonMenu element
    set active(value) {
        const classList = this.menuItem.classList;
        if (value && !classList.contains('active')) {
            classList.add('active');
        }
        if (!value && classList.contains('active')) {
            classList.remove('active');
        }
    }
}

customElements.define('atscada-app-view', AtscadaAppViewElement);