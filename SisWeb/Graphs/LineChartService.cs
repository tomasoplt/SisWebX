using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Legends;
using ChartJs.Blazor.ChartJS.Common.Legends.OnClickHandler;
using ChartJs.Blazor.ChartJS.Common.Legends.OnHover;
using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.Util.Color;
using SisWeb.Services.Dto.Sis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisWeb.Graphs
{
    public class LineChartService
    {
        public LineChartConfig GetConfiguration(string caption, List<PlovakModelDto> plovakItems, int verticalRangeMin, int verticalRangeMax)
        {
            LineChartConfig lineChartConfig;

            lineChartConfig = new LineChartConfig
            {
                CanvasId = "LineChart",
                Options = new LineChartOptions
                {
                    Animation = new Animation
                    {
                        Duration = 0
                    },
                    Text = caption,
                    Display = true,
                    Responsive = true,
                    Title = new OptionsTitle { Display = true, Text = "Plováky" },
                    Tooltips = new Tooltips
                    {
                        Mode = Mode.nearest,
                        Intersect = false
                    },
                    Scales = new Scales
                    {
                        xAxes = new List<Axis>
                        {
                           
                            new Axis
                            {
                                ScaleLabel = new ScaleLabel
                                {
                                    LabelString = "Měřeno"
                                }
                            }
                        },
                        yAxes = new List<Axis>
                        {
                            new Axis
                            {
                                Ticks = new Ticks
                                {
                                    Min = verticalRangeMin,
                                    Max = verticalRangeMax,
                                    BeginAtZero = false
                                },
                                ScaleLabel = new ScaleLabel
                                {
                                    LabelString = "Napětí"
                                }
                            }
                        }
                    },
                    Hover = new LineChartOptionsHover
                    {
                        Intersect = true,
                        Mode = Mode.nearest
                    }
                }
            };


            var data = new LineChartData();
            data.Labels = new List<string>();
            data.Datasets = new List<LineChartDataset>();
            lineChartConfig.Data = data;

            var relevantData = plovakItems.Where(x => x.Mereno != null).ToList();

            foreach ( var plovak in relevantData)
            {
                data.Labels.Add(plovak.Mereno.Value.ToString("dd.MM HH:mm"));
            }

            var dataSet = new LineChartDataset
            {
                BackgroundColor = "#FDD7BE",
                BorderColor = "#445973",
                Label = "Napětí Aku",
                Data = new List<dynamic>(),
                Fill = true,
                BorderWidth = 2,
                PointRadius = 3,
                PointBorderWidth = 1
            };

            foreach (var plovak in relevantData)
            {
                dataSet.Data.Add(plovak.NapetiAku ?? 0.0);
            }
            data.Datasets.Add(dataSet);


            dataSet = new LineChartDataset
            {
                BackgroundColor = "#88B3EB",
                BorderColor = "#445973",
                Label = "Napětí Panel",
                Data = new List<dynamic>(),
                Fill = true,
                BorderWidth = 2,
                PointRadius = 3,
                PointBorderWidth = 1
            };

            foreach (var plovak in relevantData)
            {
                dataSet.Data.Add(plovak.NapetiPanel ?? 0.0);
            }
            data.Datasets.Add(dataSet);


            return lineChartConfig;
        }
    }
}
