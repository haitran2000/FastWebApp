
// Nhan thong bao thay doi/ action tu View
// Call model action
export class AtscadaSliderController {
    constructor(model, view) {
        this.model = model;
        this.view = view;

        this.timeoutWrite = undefined;
    }

    initialize() {
        // Slide truot duoc keo/tha thay doi gia tri
        this.view.dispatcher.on('sliderChanged', () => this.actionSliderChanged());
        // Dung keo tha. Hoan thanh
        this.view.dispatcher.on('sliderFinished', (data) => this.actionSliderFinished(data));
    }

    // ... Sau khi hoan thanh keo tha thanh truot
    // ... Se ghi gia tri xuong Tag sau 2s
    // ... Neu trong 2s nay. Thanh lai tiep tuc dc keo/tha
    // => Huy di hanh dong ghi Tag truoc do
    actionSliderChanged() {
        if (this.timeoutWrite) {
            clearTimeout(this.timeoutWrite);
            this.timeoutWrite = undefined;
        }
    }

    // Hoan thanh keo tha. Gii gia tri
    actionSliderFinished(data) {
        if (this.timeoutWrite)
            clearTimeout(this.timeoutWrite);
        // Ghi sau khi hoan thanh keo tha 2s
        this.timeoutWrite = setTimeout(() => {
            const dataTag = this.model.dataTag;
            if (dataTag) dataTag.write(data.from, (view) => { return this.view === view });
        }, 500);
    }

    dispose() { }
}
