using Blazorise.Charts;
using BlazorWeatherApplication.App.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWeatherApplication.App.Pages
{
    public partial class FetchData
    {
        LineChart<double> lineChart;
        static List<string> dates = new List<string>();
        List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f) };
        List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f) };

        [Inject]
        private IWeatherServices weatherServices { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await HandleRedraw();
            }
        }

        async Task HandleRedraw()
        {
            await lineChart.Clear();
            dates.Clear();
            await lineChart.AddLabelsDatasetsAndUpdate(dates, await GetLineChartDataset());
        }

        public async Task<LineChartDataset<double>> GetLineChartDataset()
        {
            var lat = AppStateService.State.Lat;
            var lon = AppStateService.State.Lon;
            var data = await weatherServices.GetTemperatureTrends(lat, lon);
            var trends = new List<double>();
            foreach (var item in data)
            {
                trends.Add(item.Key);
                dates.Add(item.Value.ToShortDateString());
            }
            return new LineChartDataset<double>
            {
                Label = "Current weather trends for set location.",
                Data = trends,
                BackgroundColor = backgroundColors,
                BorderColor = borderColors,
                Fill = true, 
                PointRadius = 1,
                BorderDash = new List<int> { }
            };
        }
    }
}
