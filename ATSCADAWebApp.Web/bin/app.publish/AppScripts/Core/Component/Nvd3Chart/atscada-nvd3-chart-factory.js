
import { AtscadaNvd3LineChart } from './atscada-nvd3-line-chart.js'
import { AtscadaNvd3BarChart } from './atscada-nvd3-bar-chart.js'
import { AtscadaNvd3PieChart } from './atscada-nvd3-pie-chart.js'
import { AtscadaNvd3DonutChart } from './atscada-nvd3-donut-chart.js'

export class AtscadaNvd3ChartFactory {

    static getChart(chartParam) {

        switch (chartParam.type) {
            case 'line':
                return new AtscadaNvd3LineChart(chartParam);
            case 'bar':
                return new AtscadaNvd3BarChart(chartParam);
            case 'pie':
                return new AtscadaNvd3PieChart(chartParam);
            case 'donut':
                return new AtscadaNvd3DonutChart(chartParam);
            default:
                return new AtscadaNvd3LineChart(chartParam);
        }
    }
}