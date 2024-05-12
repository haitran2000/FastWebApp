
const template = document.createElement('template');
template.innerHTML = `
<a href="javascript:void(0)" class="btn btn-primary rounded-0">
    <span class="d-flex align-items-center text-left">
        <i class="fas fa-arrow-alt-circle-right fa-2x me-3 text-black"></i>      
        <span class="d-block">
            Redirection to <u class="atscada-redirect-link"></u> in:
            <b class="atscada-redirect-countdown">--- seconds</b>
        </span>
    </span>
</a>
`;

export class AtscadaRedirectElememt extends HTMLElement {
    constructor() {
        super();

        var clone = document.importNode(template.content, true);
        this.appendChild(clone);

        this.redirectLink = this.querySelector('.atscada-redirect-link');
        this.redirectCountDown = this.querySelector('.atscada-redirect-countdown');

        this.intervalID = undefined;
        this.link = 'http://atscada.com';
        this.delay = 3;
        this.seconds = 3;
    }

    connectedCallback() {
        this.link = this.getAttribute('at-link') || this.link;
        this.delay = Number(this.getAttribute('at-delay')) || this.delay;

        this.redirectLink.innerHTML = this.link;
        this.seconds = parseInt(this.delay);
        if (this.seconds <= 0) {
            this.redirect();
            return;
        }

        this.redirectCountDown.innerHTML = this.getCountDown(this.seconds);
        this.intervalID = setInterval(() => {
            this.redirectCountDown.innerHTML = this.getCountDown(this.seconds);
            this.seconds--;
            if (this.seconds < 0) {
                clearInterval(this.intervalID);
                this.redirect();
            }
        }, 1000);
    }

    disconnectedCallback() {
        if (this.intervalID)
            clearInterval(this.intervalID);
        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }

    getCountDown(seconds) {
        return `${seconds} ${seconds > 1 ? 'seconds' : 'second'}`;
    }

    redirect() {
        window.location.replace(this.link);
    }
}

customElements.define('atscada-redirect', AtscadaRedirectElememt);
