
export class AtscadaNvd3BarChart {
    constructor(chartParam) {
        this.chartParam = chartParam || [];
        this.chart = {};
        this.chartData = [{ values: [] }];
    }

    initialize() {
        for (const item of this.chartParam.items) {
            this.chartData[0].values.push(new AtscadaNvd3BarChartModel(
                item.content,
                item.color
            ));
        }

        this.chart = nv.models.discreteBarChart().x(function (e) {
            return e.label
        }).y(function (e) {
            return e.value
        }).showValues(true).duration(250);
        this.chart.xAxis.axisLabel(this.chartParam.xlabel);
        this.chart.yAxis.axisLabel(this.chartParam.ylabel);

        this.chartParam.container.append("svg")
            .datum(this.chartData)
            .transition().duration(350)
            .call(this.chart);

        nv.addGraph(function () { return this.chart }.bind(this));
    }

    update(itemModels) {
        if (itemModels.length > 0) {
            const chartModels = this.chartData[0].values;
            for (var index = 0; index < chartModels.length; index++) {
                chartModels[index].update(itemModels[index])
            }
        }
        if (typeof this.chart.update === "function") {
            this.chart.update();
        }
    }
}

class AtscadaNvd3BarChartModel {
    constructor(content, color) {
        this.label = content;
        this.color = color;
        this.value = null;
    }

    update(itemModel) {
        this.value = itemModel.value;
    }
}
