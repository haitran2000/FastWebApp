
// Service ket noi den URL qua ham fetch
export class AtscadaFetchService {

    static appLocatiton = window.location.origin + '/';

    constructor() {
        this.controller = undefined;
    }

    // call...
    async handler(url, options = {}) {
        try {
            const { timeout = 3000 } = options;

            // set thoi gian timeOut
            this.controller = new AbortController();
            const timeoutId = setTimeout(() => this.controller.abort(), timeout);

            url = `${AtscadaFetchService.appLocatiton}${url}`;
            const response = await fetch(url, {
                ...options,
                signal: this.controller.signal
            });

            clearTimeout(timeoutId);
            if (!response.ok) {
                const error = new Error(response.statusText);
                throw error;
            }
            return response.json();
        }
        catch (e) {
            console.log(e.message);
            return undefined;
        }
    }

    // Huy ket noi
    abort() {
        if (this.controller)
            this.controller.abort();
    }
}