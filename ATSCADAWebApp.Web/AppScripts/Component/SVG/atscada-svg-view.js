export class AtscadaSVGView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.originalBackgrounds = [];
        this.angle = 0;
    }
    initialize() {
        try {
             // Khởi tạo mảng rỗng this.arrAlarmTags để sử dụng cho việc xử lý Tag Alarm
            this.arrAlarmTags = [];
            // Lấy tất cả các Tag Alarm từ model.dataAlarmTags và gán vào this.arrAlarmItemsTag
            this.arrAlarmItemsTag = this.model.dataAlarmTags;
            // Lưu trữ độ dài của mảng this.arrAlarmItemsTag trong biến alarmTagsLength để sử dụng sau này
            const alarmTagsLength = this.arrAlarmItemsTag.length;
            // Lấy tất cả các ID của các mục SVG Alarm từ model.taskLoader.element.SVGAlarmItems và gán vào this.arrAlarmValueID
            this.arrAlarmValueID = this.model.taskLoader.element.SVGAlarmItems;
            // Chia mảng `this.arrAlarmItemsTag` thành các nhóm con gồm 3 phần tử và gán vào `this.arrAlarmTags`
            this.arrAlarmTags = Array.from({ length: alarmTagsLength / 3 }, (_, i) =>
                this.arrAlarmItemsTag.slice(i * 3, (i + 1) * 3)
            );
            // Đưa các ID của các mục SVG Alarm vào mảng con tương ứng trong `this.arrAlarmTags`
            for (let i = 0; i < this.arrAlarmValueID.length; i++) {
                this.arrAlarmTags[i].push(this.arrAlarmValueID[i]);
            }
            // Theo dõi sự kiện 'valueChanged' trên các mục Alarm để gọi hàm `this.alarmStation()`
            this.arrAlarmTags.forEach(value => {
                if (value) {
                    value[2].dispatcher.on('valueChanged', () => this.alarmStation());
                    value[0].dispatcher.on('valueChanged', () => this.alarmStation());
                    value[1].dispatcher.on('valueChanged', () => this.alarmStation());
                    this.alarmStation();
                }
            });

        }
        catch
        {

        };

        try {
            // Lấy tất cả các ID của các mục SVG từ model.taskLoader.element.SVGItems và gán vào this.arrValueID
            this.arrValueID = this.model.taskLoader.element.SVGItems;
            // Lấy tất cả các thuộc tính của các mục SVG từ model.taskLoader.element.SVGItemsProperties và gán vào this.arrValueProperties
            this.arrValueProperties = this.model.taskLoader.element.SVGItemsProperties;

            // Lấy tất cả các loại của các mục SVG từ model.taskLoader.element.SVGItemsType và gán vào this.arrValueType
            this.arrValueType = this.model.taskLoader.element.SVGItemsType;

            // Lấy tất cả các giá trị từ model.dataTags và gán vào this.arrValue
            this.arrValue = this.model.dataTags;
            // Gán các thuộc tính từ mảng `this.arrValueID`, `this.arrValueProperties`, `this.arrValueType` vào `this.arrValue`
            for (let i = 0; i < this.arrValue.length; i++) {
                // Tạo một bản sao của đối tượng để tránh tham chiếu cùng một đối tượng
                let currentItem = { ...this.arrValue[i] };

                // Gán các giá trị từ các mảng khác
                currentItem.id = this.arrValueID[i];
                currentItem.properties = this.arrValueProperties[i];
                currentItem.type = this.arrValueType[i][0];
                currentItem.min = this.arrValueType[i][2];
                currentItem.max = this.arrValueType[i][3];
                currentItem.attribute = this.arrValueType[i][4];

                // Gán lại bản sao đã cập nhật vào vị trí tương ứng trong mảng
                this.arrValue[i] = currentItem;
            };
            //this.arrValue.forEach((value, i) => {
            //    value.id = this.arrValueID[i];
            //    value.properties = this.arrValueProperties[i];
            //    value.type = this.arrValueType[i][0];
            //    value.min = this.arrValueType[i][2];
            //    value.max = this.arrValueType[i][3];
            //    value.attribute = this.arrValueType[i][4];
            //});
            // Theo dõi sự kiện 'valueChanged' trên các mục `this.arrValue` để gọi hàm `this.ValueChanged()`
            this.arrValue.forEach((value, index) => {
                if (value) {
                    value.dispatcher.on('valueChanged', (data) => this.ValueChanged(data.e.newValue, value, index));
                    this.ValueChanged(value.value, value, index);
                }
            });
        }
        catch {

        };

        try {
            // Lấy tất cả các ID của các mục SVG từ model.taskLoader.element.SVGHyperLink và gán vào this.arrValueID
            this.arrHyperLinkTagName = this.model.dataHyperLinkTagNames;

            this.arrHyperLink = this.model.taskLoader.element.SVGHyperLinkItems;
            // Theo dõi sự kiện 'valueChanged' trên các mục SVG để thực hiện hành động ``
            this.arrHyperLinkTagName.forEach(value => {
                if (value) {
                    this.arrHyperLink.forEach(hyperLink => {
                        if (value.name == hyperLink[1]) {
                            value.dispatcher.on('valueChanged', (data) => this.hyperLink(data.e.newValue, hyperLink, value));
                        }
                    });

                };
            }
            );
        }
        catch {

        };
        try {
            // Lấy tất cả các mục SVG Cutaway từ model.taskLoader.element.SVGCutawayItems và gán vào this.arrCutaway
            this.arrCutaway = this.model.taskLoader.element.SVGCutawayItems;

            // // Theo dõi sự kiện 'valueChanged' trên các mục SVG để thực hiện hành động `this.cutaway(data.e.newValue, cuteway)`
            this.arrValue.forEach(value => {
                if (value) {
                    this.arrCutaway.forEach(cuteway => {
                        if (value.name == cuteway[2]) {
                            value.dispatcher.on('valueChanged', (data) => this.cutaway(data.e.newValue, cuteway));
                        }
                    });
                }
            });
        }
        catch {
        };
        try {
            // Lấy tất cả các ID của các mục SVG từ model.taskLoader.element.SVGHyperLink và gán vào this.arrValueID
            this.arrControlValueTagName = this.model.dataControlValueTagNames;

            this.arrControlValue = this.model.taskLoader.element.SVGControlValueItems;
            // Theo dõi sự kiện 'valueChanged' trên các mục SVG để thực hiện hành động ``
            this.arrControlValueTagName.forEach(value => {
                if (value) {
                    this.arrControlValue.forEach(controlValue => {
                        if (value.name == controlValue[1]) {
                            value.dispatcher.on('valueChanged', (data) => this.controlValue(data.e.newValue, value, controlValue));
                        }
                    });

                };
            }
            );
        }
        catch (error)
        {
            console.error('An error occurred:', error);
        }
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
    hyperLink(value, item, ok) {
        const element = document.getElementById(item[0]);
        element.style.cursor = 'pointer';
        // Gắn sự kiện click
        element.addEventListener('click', function () {
            // Hành động sẽ thực hiện khi phần tử được click
            window.location.href = value;
        });
    }
    controlValue(value, data, controlValue) {
        const element = document.getElementById(controlValue[0]);
        element.style.cursor = 'pointer';
        if (controlValue[2] === "Bool Value") {
            element.addEventListener('click', function () {
                // Hành động sẽ thực hiện khi phần tử được click
                if (value === "1") {
                    data.write("0", (view) => { return this.view === view });
                    element.style.fill = 'red';
                }
                else {
                    data.write("1", (view) => { return this.view === view });
                    element.style.fill = 'green';
                }
            });
        }
        if (controlValue[2] === "Value") {
            element.addEventListener('click', function () {
                const popupHTML = `
                    <label for="popupInput">${controlValue[1]} : </label>
                    <input type="text" id="popupInput" value="${value}">
                    <button id="okButton">OK</button>
                `;
                document.getElementById('popup').innerHTML = popupHTML;

                // Hiển thị overlay và popup
                document.getElementById('overlay').style.display = 'block';
                document.getElementById('popup').style.display = 'block';
                // Lắng nghe sự kiện nhấn Enter trên input
                document.getElementById('popupInput').addEventListener('keydown', function (event) {
                    if (event.key === 'Enter') {
                        // Ngăn chặn hành vi mặc định của phím Enter trong form (submit form)
                        event.preventDefault();
                        // Gọi hành động khi nhấn Enter (tương tự như khi nhấn nút OK)
                        document.getElementById('okButton').click();
                    }
                });
                // Thêm sự kiện cho nút OK
                document.getElementById('okButton').addEventListener('click', function () {
                    var value = document.getElementById('popupInput').value;
                    data.write(value, (view) => { return this.view === view });
                    document.getElementById('overlay').style.display = 'none';
                    document.getElementById('popup').style.display = 'none';
                });
                // Thêm sự kiện cho overlay để đóng popup khi bên ngoài popup được nhấp
                document.getElementById('overlay').addEventListener('click', function () {
                    document.getElementById('overlay').style.display = 'none';
                    document.getElementById('popup').style.display = 'none';
                });

                // Ngăn chặn sự kiện lan truyền từ overlay vào popup
                document.getElementById('popup').addEventListener('click', function (event) {
                    event.stopPropagation();
                });
               
            });
            // Thêm sự kiện cho overlay để đóng popup khi bên ngoài popup được nhấp
document.getElementById('overlay').addEventListener('click', function () {
    document.getElementById('overlay').style.display = 'none';
    document.getElementById('popup').style.display = 'none';
});

// Ngăn chặn sự kiện lan truyền từ overlay vào popup
document.getElementById('popup').addEventListener('click', function (event) {
    event.stopPropagation();
});
        }
    }
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
                this.applyBlinkEffect1(element);
            } else {
                // Ngược lại, loại bỏ hiệu ứng nhấp nháy từ phần tử và khôi phục màu nền ban đầu
                this.removeBlinkEffectAlarm(element, this.originalBackgrounds[alarmTag[3]]);
            }
        }
    }
   // Hàm áp dụng hiệu ứng nhấp nháy cho khối vuông
    applyBlinkEffect(element,color) {
        element.style.fill = color; // Đổi màu nền thành đỏ
        element.style.animation = 'blink-animation 1s infinite';
    }
    applyBlinkEffect1(element) {
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
        if (!value && !item.value) {
            if (item.properties === "Status") {
                this.statusText = document.getElementById(item.id);
                const arrTextStatus = item.attribute.split("--");
                if (item.type === "Text") {
                    if (value != null) {
                        this.statusText.innerHTML = arrTextStatus[1];
                    }
                    else {
                        this.statusText.innerHTML = arrTextStatus[0];
                    }
                }
                if (item.type === "Color") {
                    if (value != null) {
                        this.statusText.style.fill = arrTextStatus[1];
                    }
                    else {
                        this.statusText.style.fill = arrTextStatus[0];
                    }
                }
            }
            return;
        };
        if (item.properties === "Status") {
            this.statusText = document.getElementById(item.id);
            const arrTextStatus = item.attribute.split("--");
            if (item.type === "Text") {
                if (value != null) {
                    this.statusText.innerHTML = arrTextStatus[1].toString();
                }
            }
            if (item.type === "Color") {
                if (value != null) {
                    this.statusText.style.fill = arrTextStatus[1].toString();
                }
            }
        }
        // Xử lý các trường hợp tùy thuộc vào thuộc tính của mục (item)
        if (item.properties === "Value") {
            // Nếu thuộc tính là "Value", chuyển đổi giá trị và hiển thị lên giao diện
            this.roundValue = this.convertValue(value, "String");
            this.valueText = document.getElementById(item.id);
            this.valueText.innerHTML = this.roundValue;
        } else if (item.properties === "Animation") {
            // Nếu thuộc tính là "Status"
            this.elemetAnimetion = document.getElementById(item.id);
            const pairs = item.attribute.split(',');

            // Khởi tạo mảng để lưu trữ các cặp key-value
            const keyValueList = [];

            // Lặp qua từng cặp key-value
            pairs.forEach(pair => {
                // Tách cặp key-value thành key và value
                const [key, value] = pair.split('-');

                // Tạo đối tượng mới chứa key và value và đưa vào mảng keyValueList
                keyValueList.push({ key: parseInt(key), value });
            });
            if (item.type === "Color") {
                // Nếu kiểu là "Color", thay đổi màu sắc dựa trên giá trị
                //this.elemetAnimetion.style.fill = value === "1" ? "red" : "green";
                for (let i = 0; i < keyValueList.length; i++) {
                    const currentElement = keyValueList[i];
                    if (value < currentElement.key) {
                        this.elemetAnimetion.style.fill = keyValueList[i].value;
                        break;
                    }
                    if (value >= currentElement.key && value <= keyValueList[i + 1].key) {
                        this.elemetAnimetion.style.fill = keyValueList[i + 1].value;
                        break;
                    }
                    if (value > keyValueList[keyValueList.length - 1].key) {
                        this.elemetAnimetion.style.fill = keyValueList[keyValueList.length - 1].value;
                        break;
                    }
                }
            }
            if (item.type === "Blink") {
                for (let i = 0; i < keyValueList.length; i++) {
                    const currentElement = keyValueList[i];
                    if (value < currentElement.key) {
                        this.applyBlinkEffect(this.elemetAnimetion,keyValueList[i].value);
                        break;
                    }
                    if (value >= currentElement.key && value <= keyValueList[i + 1].key) {
                        this.applyBlinkEffect(this.elemetAnimetion,keyValueList[i + 1].value);
                        break;
                    }
                    if (value > keyValueList[keyValueList.length - 1].key) {
                        this.applyBlinkEffect(this.elemetAnimetion,keyValueList[keyValueList.length - 1].value);
                        break;
                    }
                }
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