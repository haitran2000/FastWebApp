﻿
//export class AtscadaCardView {
//    constructor(model, element) {
//        this.model = model;
//        this.element = element;
//        this.widget = element.widget;
//    }

//    initialize() {
//        this.widget.content = this.element.content;
//        this.widget.color = this.element.color;
//        this.widget.icon = this.element.icon;

//        // Get tag
//        const dataTag = this.model.dataTag;
//        if (dataTag) {
//            // Dang ky su kien
//            // 1. Gia tri Value thay doi (ValueChanged)
//            // 2. Staus thay doi (StatusChanged)
//            dataTag.dispatcher.on('valueChanged', (data) => this.actionValueChanged(data));
//            dataTag.dispatcher.on('statusChanged', (data) => this.actionStatusChanged(data));
//        }
//    }

//    // Cap nhat thay doi Value hien thi
//    actionValueChanged(data) {
//        var value = data.e.newValue;
//        // Neu la so thi lam tron ...
//        if (!isNaN(parseFloat(value)) && !isNaN(value - 0)) {
//            value = this.format(Number(value), this.element.decimalPlaces, 3, ',', '.');
//        }
//        this.element.widget.number = value || '- - -';
//    }

//    // Cap nhat thay doi Status hien thi
//    actionStatusChanged(data) {
//        var status = data.e.newStatus;
//        this.element.widget.description = status;
//    }

//    // Lam tron so
//    format(number, n, x, s, c) {
//        var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\D' : '$') + ')',
//            num = number.toFixed(Math.max(0, ~~n));

//        return (c ? num.replace('.', c) : num).replace(new RegExp(re, 'g'), '$&' + (s || ','));
//    };

//    dispose() { }
//}