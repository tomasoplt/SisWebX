using BlazorComponents.ChartJS;
using Microsoft.AspNetCore.Components;

namespace BlazorComponents.Shared
{
    public abstract class ChartBase : ComponentBase
    {
        [Parameter]
        protected int Width { get; set; } = 200;

        [Parameter]
        protected int Height { get; set; } = 200;

        protected abstract IChart GetChart();

        private readonly ChartJSInterop _chartJSInterop;

        public ChartBase(ChartJSInterop chartJSInterop)
        {
            _chartJSInterop = chartJSInterop;
        }
        /// <summary>
        /// Updates the size of the chart.
        /// </summary>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        public void UpdateSize(int newWidth, int newHeight)
        {
            _chartJSInterop.UpdateSize(GetChart().CanvasId, newWidth, newHeight);
        }

    }
}
