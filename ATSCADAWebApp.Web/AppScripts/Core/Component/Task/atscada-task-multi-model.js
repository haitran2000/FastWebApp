
import { AtscadaTaskLoader } from './atscada-task-loader.js'

export class AtscadaTaskMultiModel {
    constructor(element) {
        this.dataTask = null;
        this.dataTags = [];
        this.dataAlarmTags = [];
        this.dataCutawayTagNames = [];
        this.dataHyperLinkTagNames = [];
        this.dataControlValueTagNames = [];
        this.dataTagAlarm = element.dataAlarmTagNames;
        this.dataTagNames = element.dataTagNames;
        this.dataTagCutaway = element.dataCutawayTagNames;
        this.dataTagHyperLink = element.dataHyperLinkTagNames;
        this.dataTagControlValue = element.dataControlValueTagNames;
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
            for (const dataHyperLinkTagName of this.dataTagHyperLink) {
                if (!dataCollection.contains(dataHyperLinkTagName))
                    dataCollection.add(dataHyperLinkTagName);
                this.dataHyperLinkTagNames.push(dataCollection.get(dataHyperLinkTagName));
            }
            for (const dataControlTagName of this.dataTagControlValue) {
                if (!dataCollection.contains(dataControlTagName))
                    dataCollection.add(dataControlTagName);
                this.dataControlValueTagNames.push(dataCollection.get(dataControlTagName));
            }
        }
    }

    dispose() { }
}