
export class AtscadaNvd3PieChart {
    constructor(chartParam) {
        this.chartParam = chartParam || [];
        this.chart = {};
        this.chartData = [];
    }

    initialize() {
        for (const item of this.chartParam.items) {
            this.chartData.push(new AtscadaNvd3PieChartModel(
                item.content,
                item.color
            ));
        }

        this.chart = nv.models.pieChart().x(function (e) {
            return e.label
        }).y(function (e) {
            return e.value
        }).showLabels(!0).labelThreshold(.05).labelType("percent");

        this.chartParam.container.append("svg")
            .datum(this.chartData)
            .transition().duration(350)
            .call(this.chart);

        nv.addGraph(function () { return this.chart }.bind(this));
    }

    update(itemModels) {
        if (itemModels.length > 0) {
            const chartModels = this.chartData;
            for (var index = 0; index < chartModels.length; index++) {
                chartModels[index].update(itemModels[index])
            }
        }
        if (typeof this.chart.update === "function") {
            this.chart.update();
        }
    }
}

class AtscadaNvd3PieChartModel {
    constructor(content, color) {
        this.label = content;
        this.color = color;
        this.value = null;
    }

    update(itemModel) {
        this.value = itemModel.value;
    }
}
