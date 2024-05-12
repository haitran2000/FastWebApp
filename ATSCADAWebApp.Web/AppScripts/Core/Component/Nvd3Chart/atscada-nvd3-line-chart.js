
export class AtscadaNvd3LineChart {
    constructor(chartParam) {
        this.chartParam = chartParam || {};
        this.chart = {};
        this.chartData = [];

        this.sampleNum = this.chartParam.sampleNum || 50;
    }

    initialize() {
        for (const item of this.chartParam.items) {
            this.chartData.push(new AtscadaNvd3LineChartModel(
                item.content,
                item.color,
                this.sampleNum
            ));
        }

        this.chart = nv.models.lineChart().options({
            transitionDuration: 300,
            useInteractiveGuideline: true,
            showLegend: true,
            transitionDuration: 250,
            interpolate: 'basis'
        });
        this.chart.xAxis.axisLabel(this.chartParam.xlabel).tickFormat(function (d) {
            return d3.time.format('%X')(new Date(d))
        });
        this.chart.yAxis.axisLabel(this.chartParam.ylabel).tickFormat(function (e) {
            return null == e ? "N/A" : d3.format(",.2f")(e)
        });

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

class AtscadaNvd3LineChartModel {
    constructor(content, color, sampleNum) {
        this.key = content;
        this.color = color;
        this.sampleNum = sampleNum;
        this.values = [{x: new Date().getTime(), y: null}];
    }

    update(itemModel) {
        while (this.values.length > this.sampleNum)
            this.values.shift();
        this.values.push({
            x: itemModel.time,
            y: itemModel.value
        });
    }
}
