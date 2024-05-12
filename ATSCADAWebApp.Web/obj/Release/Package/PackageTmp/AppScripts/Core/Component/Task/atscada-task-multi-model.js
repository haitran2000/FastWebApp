
import { AtscadaTaskLoader } from './atscada-task-loader.js'

export class AtscadaTaskMultiModel {
    constructor(element) {
        this.dataTask = null;
        this.dataTags = [];
        this.dataTagAlarm=[];
        this.dataTagNames = element.dataTagNames;
        this.taskLoader = new AtscadaTaskLoader(element);       
    }

    initialize() {
        this.taskLoader.load();
        this.dataTask = this.taskLoader.dataTask;
        if (this.dataTask) {
            const dataCollection = this.dataTask.dataCollection;
            for (const dataTagName of this.dataTagNames) {
                if (!dataCollection.contains(dataTagName))
                    dataCollection.add(dataTagName);
                this.dataTags.push(dataCollection.get(dataTagName));
            }
        }
    }

    dispose() { }
}