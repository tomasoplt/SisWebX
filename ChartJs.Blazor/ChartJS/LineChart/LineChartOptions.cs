﻿using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartOptions : BaseChartConfigOptions
    {
        /// <summary>
        /// general animation time
        /// </summary>
        public Animation Animation { get; set; }

        /// <summary>
        /// duration of animations when hovering an item
        /// </summary>
        public LineChartOptionsHover Hover { get; set; }

        /// <summary>
        /// animation duration after a resize
        /// </summary>
        public long ResponsiveAnimationDuration { get; set; }

        public OptionsTitle Title { get; set; }
        public Tooltips Tooltips { get; set; }
        public Scales Scales { get; set; }

        /// <summary>
        /// If false, the lines between points are not drawn.
        /// </summary>
        public bool ShowLines { get; set; } = true;

        /// <summary>
        /// If false, NaN data causes a break in the line.
        /// </summary>
        public bool SpanGaps { get; set; } = true;
    }
}