using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorComponents.ChartJS
{
    public class ChartJSInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public ChartJSInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<bool> InitializeLineChart(ChartJSLineChart lineChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }

        public Task<bool> UpdateSize(string canvasId, int newWidth, int newHeight)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateSize", new object[] { canvasId, newWidth, newHeight });
        }

        public Task<bool> InitializeBarChart(ChartJSBarChart barChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeBarChart", new[] { barChart });
        }

        public Task<bool> UpdateLineChart(ChartJSLineChart lineChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }

        public Task<bool> UpdateBarChart(ChartJSBarChart barChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateBarChart", new[] { barChart });
        }

        public Task<bool> InitializeRadarChart(ChartJSRadarChart radarChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeRadarChart", new[] { radarChart });
        }

        public Task<bool> UpdateRadarChart(ChartJSRadarChart radarChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateRadarChart", new[] { radarChart });
        }

        public Task<bool> InitializePieChart(ChartJSPieChart pieChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializePieChart", new[] { pieChart });
        }

        public Task<bool> UpdatePieChart(ChartJSPieChart pieChart)
        {
            return _jsRuntime.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdatePieChart", new[] { pieChart });
        }

    }
}
