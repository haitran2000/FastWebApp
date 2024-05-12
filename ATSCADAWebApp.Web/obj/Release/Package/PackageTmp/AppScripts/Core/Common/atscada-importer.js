
import { AtscadaDispatcher } from './atscada-dispatcher.js'

// Load, inport css, js
export class AtscadaImporter {
    constructor() {
        this.dispatcher = new AtscadaDispatcher();
        this.promises = [];
        this.isLoaded = false;
        this.isLoading = false;
    }

    static appLocatiton = window.location.origin + '/';

    addCss(cssUrls) {
        cssUrls.forEach((cssUrl) => {
            cssUrl = `${AtscadaImporter.appLocatiton}${cssUrl}`;
            const isCssLoaded = false;
            const styleSheets = document.styleSheets;
            for (var i = 0, max = styleSheets.length; i < max; i++) {
                if (styleSheets[i].href == cssUrl) {
                    isCssLoaded = true;
                    break;
                }
            }                
            if (!isCssLoaded) {
                const promise = new Promise(function (resolve, reject) {
                    var stylesheet = document.createElement("link");
                    stylesheet.href = cssUrl;
                    stylesheet.rel = 'stylesheet';
                    stylesheet.type = 'text/css';
                    stylesheet.onload = function () { resolve(cssUrl); };
                    stylesheet.onerror = function () { reject(cssUrl); };
                    document.head.appendChild(stylesheet);
                });
                this.promises.push(promise);
            }
        });
    }

    addScript(scriptUrls) {       
        scriptUrls.forEach((scriptUrl) => {
            scriptUrl = `${AtscadaImporter.appLocatiton}${scriptUrl}`;
            let isScriptLoaded = false;
            isScriptLoaded = document.querySelectorAll(`script[src='${scriptUrl}']`).length > 0;
            if (!isScriptLoaded) {
                const promise = new Promise(function (resolve, reject) {
                    let script = document.createElement('script');
                    script.src = scriptUrl;
                    script.async = false;
                    script.onload = function () { resolve(scriptUrl); };
                    script.onerror = function () { reject(scriptUrl); };
                    document.body.appendChild(script);
                });
                this.promises.push(promise);
            }
        });
    }

    async load() {
        if (this.isLoading) return;
        this.isLoading = true;
        if (this.promises.length > 0) {
            for (const promise of this.promises) {
                await promise;
            }
        }
        this.isLoading = false;
        this.isLoaded = true;
        this.dispatcher.dispatch('loaded', {});
    }
}