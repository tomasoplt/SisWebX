﻿
window.BlazorComponents = window.BlazorComponents || {};
window.BlazorComponents.BlazorCharts = [];
window.BlazorComponents.ChartJSInterop = {
    InitializeBarChart: function (data) {
        if (window.BlazorComponents.BlazorCharts.length > 0) {
            if (!window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId)) {
                let thisChart = initializeChartjsChart(data, 'bar');
                window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
            } else {
                let myChart = window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId);
                let myChartIndex = window.BlazorComponents.BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

                if (myChartIndex !== -1) {
                    myChart.chart.destroy();
                    window.BlazorComponents.BlazorCharts.splice(myChartIndex, 1);
                    let thisChart = initializeChartjsChart(data, 'bar');
                    window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
                }
            }
        }
        else {
            let thisChart = initializeChartjsChart(data, 'bar');
            window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeLineChart: function (data) {
        if (window.BlazorComponents.BlazorCharts.length > 0) {
            if (!window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId)) {
                let thisChart = initializeChartjsChart(data, 'line');
                window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
            } else {

                let myChart = window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId);
                let myChartIndex = window.BlazorComponents.BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

                if (myChartIndex !== -1) {
                    myChart.chart.destroy();
                    window.BlazorComponents.BlazorCharts.splice(myChartIndex, 1);
                    let thisChart = initializeChartjsChart(data, 'line');
                    window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
                }
            }
        }
        else {
            let thisChart = initializeChartjsChart(data, 'line');
            window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeRadarChart: function (data) {
        if (window.BlazorComponents.BlazorCharts.length > 0) {
            if (!window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId)) {
                let thisChart = initializeChartjsChart(data, 'radar');
                window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
            } else {

                let myChart = window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

                let myChartIndex = window.BlazorComponents.BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

                if (myChartIndex !== -1) {
                    myChart.chart.destroy();
                    window.BlazorComponents.BlazorCharts.splice(myChartIndex, 1);
                    let thisChart = initializeChartjsChart(data, 'radar');
                    window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
                }
            }
        }
        else {
            let thisChart = initializeChartjsChart(data, 'radar');
            window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializePieChart: function (data) {
        if (window.BlazorComponents.BlazorCharts.length > 0) {
            if (!window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId)) {
                let thisChart = initializeChartjsChart(data, 'pie');
                window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
            } else {

                let myChart = window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

                let myChartIndex = window.BlazorComponents.BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

                if (myChartIndex !== -1) {
                    myChart.chart.destroy();
                    window.BlazorComponents.BlazorCharts.splice(myChartIndex, 1);
                    let thisChart = initializeChartjsChart(data, 'pie');
                    window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
                }
            }
        }
        else {
            let thisChart = initializeChartjsChart(data, 'pie');
            window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
        }

        return true;
    },
    UpdateSize: function (canvasId, newWidth, newHeight) {
        let ctx = document.getElementById(canvasId);
        if (ctx) {
            ctx.width = newWidth;
            ctx.height = newHeight;
        }

        return true;
    }
    //UpdateLineChart: function (data) {

    //    return true;
    //},
    //UpdateBarChart: function (data) {

    //    if (!window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
    //        throw `Could not find a chart with the given id. ${canvasId}`;

    //    let myChart = window.BlazorComponents.BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

    //    let myChartIndex = window.BlazorComponents.BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

    //    if (myChartIndex !== -1) {
    //        myChart.chart.destroy();
    //        window.BlazorComponents.BlazorCharts.splice(myChartIndex, 1);
    //    }

    //    let thisChart = initializeChartjsChart(data, 'bar');
    //    window.BlazorComponents.BlazorCharts.push({ id: data.canvasId, chart: thisChart });
    //    return true;
    //},
    //UpdateRadarChart: function (data) {

    //    return true;
    //}
};


function initializeChartjsChart(data, type) {

    let ctx = document.getElementById(data.canvasId);

    data.data.datasets.forEach((item, i) => {
        if (item.backgroundColor.length === 1) {
            item.backgroundColor = item.backgroundColor[0];
        }

    });

    let myChart = new Chart(ctx, {
        type: type,
        data: data.data,
        options: data.options
    });

    return myChart;
}