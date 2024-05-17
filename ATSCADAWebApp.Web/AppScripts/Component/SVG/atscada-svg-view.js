export class AtscadaSVGView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.originalBackgrounds = [];
        this.angle = 0;
    }
    initialize() {
        // Lấy tất cả các Tag Alarm từ model.dataAlarmTags và gán vào this.arrAlarmItemsTag
        this.arrAlarmItemsTag = this.model.dataAlarmTags;

        // Lấy tất cả các giá trị từ model.dataTags và gán vào this.arrValue
        this.arrValue = this.model.dataTags;

        // Lấy tất cả các ID của các mục SVG từ model.taskLoader.element.SVGItems và gán vào this.arrValueID
        this.arrValueID = this.model.taskLoader.element.SVGItems;

        // Lấy tất cả các mục SVG Cutaway từ model.taskLoader.element.SVGCutawayItems và gán vào this.arrCutaway
        this.arrCutaway = this.model.taskLoader.element.SVGCutawayItems;

        // Lấy tất cả các thuộc tính của các mục SVG từ model.taskLoader.element.SVGItemsProperties và gán vào this.arrValueProperties
        this.arrValueProperties = this.model.taskLoader.element.SVGItemsProperties;

        // Lấy tất cả các loại của các mục SVG từ model.taskLoader.element.SVGItemsType và gán vào this.arrValueType
        this.arrValueType = this.model.taskLoader.element.SVGItemsType;

        // Lấy tất cả các ID của các mục SVG Alarm từ model.taskLoader.element.SVGAlarmItems và gán vào this.arrAlarmValueID
        this.arrAlarmValueID = this.model.taskLoader.element.SVGAlarmItems;

        // Khởi tạo mảng rỗng this.arrAlarmTags để sử dụng cho việc xử lý Tag Alarm
        this.arrAlarmTags = [];

        // Lưu trữ độ dài của mảng this.arrAlarmItemsTag trong biến alarmTagsLength để sử dụng sau này
        const alarmTagsLength = this.arrAlarmItemsTag.length;
        // Chia mảng `this.arrAlarmItemsTag` thành các nhóm con gồm 3 phần tử và gán vào `this.arrAlarmTags`
        this.arrAlarmTags = Array.from({ length: alarmTagsLength / 3 }, (_, i) =>
            this.arrAlarmItemsTag.slice(i * 3, (i + 1) * 3)
        );

        // Đưa các ID của các mục SVG Alarm vào mảng con tương ứng trong `this.arrAlarmTags`
        for (let i = 0; i < this.arrAlarmValueID.length; i++) {
            this.arrAlarmTags[i].push(this.arrAlarmValueID[i]);
        }

        // Gán các thuộc tính từ mảng `this.arrValueID`, `this.arrValueProperties`, `this.arrValueType` vào `this.arrValue`
        for (let i = 0; i < this.arrValue.length; i++) {
            this.arrValue[i].id = this.arrValueID[i];
            this.arrValue[i].properties = this.arrValueProperties[i];
            this.arrValue[i].type = this.arrValueType[i][0];
            this.arrValue[i].min = this.arrValueType[i][2];
            this.arrValue[i].max = this.arrValueType[i][3];
        }

        // Theo dõi sự kiện 'valueChanged' trên các mục SVG để thực hiện hành động `this.cutaway(data.e.newValue, cuteway)`
        this.arrValue.forEach(value => {
            if (value) {
                this.arrCutaway.forEach(cuteway => {
                    if (value.name == cuteway[2]) {
                        value.dispatcher.on('valueChanged', (data) => this.cutaway(data.e.newValue, cuteway));
                    }
                });
            }
        });
        // Theo dõi sự kiện 'valueChanged' trên các mục Alarm để gọi hàm `this.alarmStation()`
        this.arrAlarmTags.forEach(value => {
            if (value) {
                value[2].dispatcher.on('valueChanged', () => this.alarmStation());
                value[0].dispatcher.on('valueChanged', () => this.alarmStation());
                value[1].dispatcher.on('valueChanged', () => this.alarmStation());
                this.alarmStation();
            }
        });

        // Theo dõi sự kiện 'valueChanged' trên các mục `this.arrValue` để gọi hàm `this.ValueChanged()`
        this.arrValue.forEach((value, index) => {
            if (value) {
                value.dispatcher.on('valueChanged', (data) => this.ValueChanged(data.e.newValue, value, index));
                this.ValueChanged(value.value, value, index);
            }
        });      
    }
    // Định nghĩa hàm cutaway là một arrow function với hai đối số value và item
    cutaway = (value, item) => {
        // Giải nén mảng item để lấy ra rect và container từ các phần tử trong mảng
        const [rect, container] = item.length > 0 ? item.slice(0, 2).map(id => document.getElementById(id)) : [];

        // Kiểm tra xem rect và container có tồn tại
        if (rect && container) {
            // Lấy chiều cao của container và chuyển đổi thành số thập phân, giữ một chữ số thập phân
            const height = parseFloat(container.getAttribute("height")).toFixed(1);

            // Giải nén mảng item để lấy min và max từ các phần tử còn lại
            const [, , , min, max] = item;

            // Tính toán chiều cao mới của rect dựa trên giá trị mới (value)
            // và cập nhật chiều cao của rect bằng cách thay đổi style
            rect.style.height = (((parseFloat(max) - parseFloat(value)) / parseFloat(max)) * height).toString();
        }
    };

    // Hàm `alarmStation()` kiểm tra các giá trị hiện tại của các Tag Alarm và áp dụng các hiệu ứng tương ứng
    alarmStation() {
        // Duyệt qua mảng các Tag Alarm trong `this.arrAlarmTags`
        for (let i = 0; i < this.arrAlarmTags.length; i++) {
            // Lấy một Tag Alarm từ mảng `this.arrAlarmTags`
            const alarmTag = this.arrAlarmTags[i];

            // Lấy phần tử HTML tương ứng bằng cách sử dụng id từ Tag Alarm
            const element = document.getElementById(alarmTag[3]);

            // Lấy các giá trị hiện tại, ngưỡng cao và ngưỡng thấp từ Tag Alarm
            const currentValue = parseFloat(alarmTag[1].value);
            const highValue = parseFloat(alarmTag[2].value);
            const lowValue = parseFloat(alarmTag[0].value);

            // Lưu trữ màu nền ban đầu của phần tử để khôi phục sau này
            this.originalBackgrounds[alarmTag[3]] ||= window.getComputedStyle(element).fill;

            // Kiểm tra nếu giá trị hiện tại nằm ngoài ngưỡng cao hoặc ngưỡng thấp
            if (highValue < currentValue || lowValue > currentValue) {
                // Nếu điều kiện đúng, áp dụng hiệu ứng nhấp nháy lên phần tử
                this.applyBlinkEffect(element);
            } else {
                // Ngược lại, loại bỏ hiệu ứng nhấp nháy từ phần tử và khôi phục màu nền ban đầu
                this.removeBlinkEffectAlarm(element, this.originalBackgrounds[alarmTag[3]]);
            }
        }
    }
   // Hàm áp dụng hiệu ứng nhấp nháy cho khối vuông
    applyBlinkEffect(element) {
        element.style.fill = 'red'; // Đổi màu nền thành đỏ
        element.style.animation = 'blink-animation 1s infinite';
    }
    // Hàm loại bỏ hiệu ứng nhấp nháy khỏi khối vuông theo Alarm
    removeBlinkEffectAlarm(element,color) {
        element.style.animation = 'none';
        element.style.fill = color;
    }
    // Hàm loại bỏ hiệu ứng nhấp nháy khỏi khối vuông theo Status
    removeBlinkEffect(element) {
        element.style.animation = 'none';
        element.style.fill = 'green';
    }
    // Hàm `ValueChanged(value, item, index)` được gọi khi giá trị của một mục thay đổi
    ValueChanged(value, item, index) {
        // Kiểm tra nếu giá trị là null hoặc undefined, thoát khỏi hàm
        if (!value) {
            //if (item.properties === "Status") {
            //    this.statusText = document.getElementById(item.id);
            //    if (item.value != null) {
            //        this.statusText.innerHTML = "GOOD";
            //    }
            //    else {
            //        this.statusText.innerHTML = "BAD";
            //    }
            //}
            return;
        }
        //else {
        //    if (item.properties === "Status") {
        //        this.statusText = document.getElementById(item.id);
        //        if (item.value != null) {
        //            this.statusText.innerHTML = "GOOD";
        //        }
        //        else {
        //            this.statusText.innerHTML = "BAD";
        //        }
        //    }
        //};

        // Xử lý các trường hợp tùy thuộc vào thuộc tính của mục (item)
        if (item.properties === "Value") {
            // Nếu thuộc tính là "Value", chuyển đổi giá trị và hiển thị lên giao diện
            this.roundValue = this.convertValue(value, item.type);
            this.valueText = document.getElementById(item.id);
            this.valueText.innerHTML = this.roundValue;
        } else if (item.properties === "Status") {
            // Nếu thuộc tính là "Status"
            this.elemetAnimetion = document.getElementById(item.id);
            if (item.type === "Color") {
                // Nếu kiểu là "Color", thay đổi màu sắc dựa trên giá trị
                this.elemetAnimetion.style.fill = value === "1" ? "red" : "green";
            }
            if (item.type === "Blink") {
                // Nếu kiểu là "Blink", áp dụng hiệu ứng nhấp nháy
                if (value === "1") {
                    this.applyBlinkEffect(this.elemetAnimetion);
                } else {
                    this.removeBlinkEffect(this.elemetAnimetion);
                }
            }
            if (item.type == "IsRunning") {
                // Nếu kiểu là "IsRunning", xử lý hiển thị chạy của một thành phần (ví dụ: quạt)
                // Gợi ý: code đang bị comment để tránh tạo ra CSS mới mỗi lần xảy ra sự kiện "ValueChanged"
                // Nếu cần, hãy bỏ comment để tạo hiệu ứng quay (rotate) trên thành phần
                //this.fan = document.getElementById(item.id);
                //const styleElement = document.createElement("style");

                //styleElement.textContent = `
                //  #fan {
                //    animation: rotate 2s linear infinite;
                //    transform-origin: center;
                //  }

                //  @keyframes rotate {
                //    from {
                //      transform: rotate(0deg);
                //    }
                //    to {
                //      transform: rotate(360deg);
                //    }
                //  }
                //`;

                //document.head.appendChild(styleElement);
                //this.rotate();
            }
        }
    }
    rotate() {
        this.angle += 1;
        this.gElement.style.transform = `rotate(${this.angle}deg) translate(-50%, -50%)`;
        requestAnimationFrame(this.rotate);
    }
    convertValue(value, type) {
        switch (type) {
            case "Int":
                return parseInt(value);
            case "Float":
                return parseFloat(value).toFixed(2);
            case "Double":
                return parseFloat(value).toFixed(2);
            case "Bool":
                return value === "1" ? true : false;
            case "String":
                return value.toString();
            default:
                return null;  // Handle unsupported types gracefully
        }
    }
    dispose() { }
}