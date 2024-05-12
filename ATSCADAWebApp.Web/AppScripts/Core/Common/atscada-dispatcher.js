
// Event args
export class AtscadaEvent {
    constructor(eventName) {
        // Ten cua Event
        this.eventName = eventName;
        // Danh sach cac callback duoc dang ky
        this.callbacks = [];
    }

    // Dang ky. Add callback vao mang
    register(callback) {
        this.callbacks.push(callback);
    }

    // Huy dang ky. Xoa callback trong mang
    unregister(callback) {
        const index = this.callbacks.indexOf(callback);
        if (index > -1) {
            this.callbacks.splice(index, 1);
        }
    }

    // Raise event...
    async fire(data) {
        // copy...
        const callbacks = this.callbacks.slice(0);
        // Duyet mang. Call, thuc thi tat ca cac callback duoc dang ky
        for (const callback of callbacks) {
            if (callback.constructor.name === 'AsyncFunction')
                await callback(data);
            else
                callback(data);
        }
    }
}

// Quan ly, dieu phoi cac event event
export class AtscadaDispatcher {
    constructor() {
        this.events = {};
    }

    // Fire event theo eventName
    dispatch(eventName, data) {
        // Get event by name
        const event = this.events[eventName];
        if (event) {
            event.fire(data);
        }
    }

    // Dang ky event
    on(eventName, callback) {
        let event = this.events[eventName];
        if (!event) {
            event = new AtscadaEvent(eventName);
            this.events[eventName] = event;
        }
        event.register(callback);
    }

    // Huy dang ky
    off(eventName, callback) {
        const event = this.events[eventName];
        if (event && event.callbacks.indexOf(callback) > -1) {
            event.unregister(callback);
            if (event.callbacks.length === 0) {
                delete this.events[eventName];
            }
        }
    }
}