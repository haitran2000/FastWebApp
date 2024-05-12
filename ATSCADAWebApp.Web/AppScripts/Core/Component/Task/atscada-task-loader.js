
import { AtscadaTaskElement } from './atscada-task-element.js'

export class AtscadaTaskLoader {
    constructor(element) {
        this.element = element;       
        this.dataTask = undefined;       
    }

    load() {
        var parent = this.element.parentNode;
        while (parent) {
            if (parent instanceof AtscadaTaskElement) {
                this.dataTask = parent.dataTask;
                this.dataTask.start();
                break;
            }
            parent = parent.parentNode;
        }
        return this;
    }
}