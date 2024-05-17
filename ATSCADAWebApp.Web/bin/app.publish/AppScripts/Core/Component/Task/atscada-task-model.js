
import { AtscadaTaskLoader } from './atscada-task-loader.js'

export class AtscadaTaskModel {
    constructor(element) {
        this.dataTask = undefined;
        this.dataTag = undefined;
        this.dataTagName = element.dataTagName;
        this.taskLoader = new AtscadaTaskLoader(element);
    }

    initialize() {
        this.taskLoader.load();
        this.dataTask = this.taskLoader.dataTask;
        if (this.dataTask) {
            const dataCollection = this.dataTask.dataCollection;
            if (!dataCollection.contains(this.dataTagName))
                dataCollection.add(this.dataTagName);
            this.dataTag = dataCollection.get(this.dataTagName);
        }
    }

    dispose() { }
}