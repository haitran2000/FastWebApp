
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'
import { AtscadaAlarmParam } from '../../Core/Alarm/atscada-alarm-param.js'
import { AtscadaAlarmAcknowledgeParam } from '../../Core/Alarm/atscada-alarm-acknowledge-param.js'
import { AtscadaAlarmService } from '../../Core/Alarm/atscada-alarm-service.js'


// Thong bao cho View (UI) biet
// 1. Da co du lieu Alarm ---> Yeu cau hien thi, cap nhat len UI (DataTable)
export class AtscadaAlarmViewerModel {
    constructor(element) {
        this.pollingID = undefined;
        this.operatingStatus = false;

        // chu ky cap nhat data
        this.interval = element.interval;
        // service ket noi, load alarmLog
        this.alarmService = new AtscadaAlarmService(element.timeout);
        this.dispatcher = new AtscadaDispatcher();
        this.alarmParam = new AtscadaAlarmParam(
            element.connection,
            element.tableName,
            element.limit);
        this.atscadaAlarmAcknowledgeParam = new AtscadaAlarmAcknowledgeParam(
            element.connection,
            element.tableName);
    }

    initialize() {
        if (this.operatingStatus) return;
        this.operatingStatus = true;
        this.polling();
    }

    // Hams polling
    // cap nhat lien tuc du lieu alarmLog
    // su dung timer
    polling() {
        if (!this.operatingStatus) return;
        this.pollingID = setTimeout(async () => {
            try {
                await this.update();
            }
            catch (e) {
                console.log(e.message);
            }
            finally {
                this.polling();
            }
        }, this.interval);
    }

    // xac nhan ack
    async acknowledge() {
        try {
            const acknowledgeResult = await this.alarmService.acknowledge(this.atscadaAlarmAcknowledgeParam);
            this.onEventAcknowledged(acknowledgeResult);
            await this.update();
        }
        catch (e) {
            console.log(e.message);
        }
    }

    // load alarmLog
    // thong bao update giao dien Table
    async update() {
        const alarms = await this.alarmService.getAlarms(this.alarmParam);
        this.onEventUpdated(alarms);
    }

    onEventUpdated(alarms) {
        alarms = alarms || [];
        this.dispatcher.dispatch('updated', alarms);
    }

    onEventAcknowledged(acknowledgeResult) {
        acknowledgeResult = acknowledgeResult || {};
        this.dispatcher.dispatch('acknowledged', acknowledgeResult);
    }

    dispose() {
        this.operatingStatus = false;
        if (this.pollingID)
            clearTimeout(this.pollingID);
    }
}
