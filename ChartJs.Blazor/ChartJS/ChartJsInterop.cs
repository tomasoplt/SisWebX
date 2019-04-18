using Microsoft.JSInterop;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public async static void Resize(this IJSRuntime jsRuntime)
        {
            try
            {
                await jsRuntime.InvokeAsync<object>("Resizer.Resize");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public static async Task<object> SetupChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                await jsRuntime.InvokeAsync<object>("ChartJSInterop.SetupChart", SerializeConfig(chartConfig));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

            return await Task.FromResult<bool>(false);
        }

        public static async Task<bool> UpdateChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                await jsRuntime.InvokeAsync<object>("ChartJSInterop.UpdateChart", SerializeConfig(chartConfig));
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }

            return await Task.FromResult<bool>(false);
        }

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        private static string SerializeConfig(ChartConfigBase config)
        {
            var json = JsonConvert.SerializeObject(config, JsonSettings);
            return json;
        }
    }
}