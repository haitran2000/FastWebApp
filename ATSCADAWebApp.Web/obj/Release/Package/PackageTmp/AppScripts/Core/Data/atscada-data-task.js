
import { AtscadaDispatcher } from '../Common/atscada-dispatcher.js'
import { AtscadaDataService } from './atscada-data-service.js'
import { AtscadaDataReader } from './atscada-data-reader.js'
import { AtscadaDataWriter } from './atscada-data-writer.js'
import { AtscadaDataCollection } from './atscada-data-collection.js'

// Task. Doi tuong quan ly viec docj, ghi dua lieu 
// Task se gom danh sach Tag
// Chu ky timer, ket noi den service, doc du lieu cac Tag
// Du lieu duoc luu vao buffer
// Tag update du lieu tu Buffer
// Raise event tag khi gia tri Tag (tagValue) thay doi

export class AtscadaDataTask {
    constructor(taskParam) {
        taskParam = taskParam || {};

        this.pollingID = undefined;
        // Task co dang running hay khong
        this.operatingStatus = false;
        // chu ky cap nhat tag
        this.interval = taskParam.interval || 1000;
        // so lan ghi tag toi da (neu bi BAD, khong ghi duoc)
        this.maxNumberOfWrite = taskParam.maxNumberOfWrite || 10;
        // timeout ket noi service
        this.timeout = taskParam.timeout || 900;

        // quan ly event cua Task. Bao gom caca event:
        // 1. beforeRefresh: Event thong bao bat dau Read/Update du lieu cac Tag
        // 2. refreshed: Update xong 
        this.dispatcher = new AtscadaDispatcher();
        // danh sach Tag
        this.dataCollection = new AtscadaDataCollection(this);
        // service ket noi Controller. Read/Write Tag
        this.dataService = new AtscadaDataService(this.timeout);
        // Su dung service read tag(s) -> Update buffer -> read tag from buffer
        this.dataReader = new AtscadaDataReader(this.dataService);
        // Su dung service write tag(s)
        this.dataWriter = new AtscadaDataWriter(this.dataService, this.maxNumberOfWrite);
    }

    // Ham start - bat dau cap nhat tag
    start() {
        if (this.operatingStatus) return;
        this.operatingStatus = true;
        this.polling();
    }

    // Ham stop - dung cap nhat tag
    stop() {
        this.operatingStatus = false;
        this.dataService.abort();
        if (this.pollingID)
            clearTimeout(this.pollingID);
    }

    // Ham quet, cap nhat du lieu cua tag thoe chu ky
    async polling() {

        if (!this.operatingStatus) return;
        try {
            // raise event beforeRefresh
            this.onEventRefresh('beforeRefresh');

            // lay danh sach tag can update
            const dataTags = this.dataCollection.getAll();
            // kiem tra co tag nao can ghi hay khong. Neu co thi ghi.
            // ... khi tag write. Command write se duoc luu trong 1 buffer.
            // ... khi den chu ky quet, se tien hanh ghi (co the la nhieu tag cung luc)
            await this.dataWriter.update();
            // doc cac tag qua TagName
            // gia tri doc luu vao buffer
            await this.dataReader.update(dataTags.map(x => x.name));
            // cap nhat tag tu buffer
            for (const dataTag of dataTags) {
                var data = dataTag.read();
                dataTag.update(data);
            }
        }
        catch (e) {
            console.log(e.message);            
        }
        finally {            
            try {
                // raise event refreshed
                this.onEventRefresh('refreshed');
            }
            catch (e) {
                console.log(e.message);
            }             
        }

        if (!this.operatingStatus) return;
        this.pollingID = setTimeout(async () => {
            await this.polling();
        }, this.interval);
    }    

    onEventRefresh(eventName) {
        this.dispatcher.dispatch(eventName, {
            sender: this,
            e: {
                timeStamp: new Date()
            }
        });
    }
}
