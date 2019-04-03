﻿using System.Collections.Generic;

namespace BlazorComponents.ChartJS
{
    public abstract class ChartJsDataset
    {
        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";
        /// <summary>
        /// Actual data. This is an int array.
        /// TO-DO: Explore if it makes any sense to have this as decimal.
        /// </summary>
        public List<double> Data { get; set; } = new List<double>();
        /// <summary>
        /// The fill color under the line. 
        /// AS-IS: We only accept colors as string values. Normal colors and HTML Hex colors are ok to use.
        /// TODO: Accept some form of actual color information rathen than strings.
        /// </summary>
        public List<string> BackgroundColor { get; set; } = new List<string>();
        /// <summary>
        /// The color of the line
        /// AS-IS: We only accept string colors.
        /// TODO: Accept some form of actual color information rathen than strings.
        /// </summary>
        public string BorderColor { get; set; }
    }
}
