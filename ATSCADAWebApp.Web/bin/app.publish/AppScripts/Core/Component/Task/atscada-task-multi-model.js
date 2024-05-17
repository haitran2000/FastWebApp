
import { AtscadaTaskLoader } from './atscada-task-loader.js'

export class AtscadaTaskMultiModel {
    constructor(element) {
        this.dataTask = null;
        this.dataTags = [];
        this.dataAlarmTags = [];
        this.dataCutawayTagNames = [];
        this.dataTagAlarm = element.dataAlarmTagNames;
        this.dataTagNames = element.dataTagNames;
        this.dataTagCutaway = element.dataCutawayTagNames;
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
            for (const dataAlarmTagName of this.dataTagAlarm) {
                if (!dataCollection.contains(dataAlarmTagName))
                    dataCollection.add(dataAlarmTagName);
                this.dataAlarmTags.push(dataCollection.get(dataAlarmTagName));
            }
            for (const dataCutewayTagName of this.dataTagCutaway) {
                if (!dataCollection.contains(dataCutewayTagName))
                    dataCollection.add(dataCutewayTagName);
                this.dataCutawayTagNames.push(dataCollection.get(dataCutewayTagName));
            }
        }
    }

    dispose() { }
}