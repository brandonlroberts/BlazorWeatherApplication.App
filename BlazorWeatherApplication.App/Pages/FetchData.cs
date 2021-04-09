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
        List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f), ChartColor.FromRgba(54, 162, 235, 0.2f), ChartColor.FromRgba(255, 206, 86, 0.2f), ChartColor.FromRgba(75, 192, 192, 0.2f), ChartColor.FromRgba(153, 102, 255, 0.2f), ChartColor.FromRgba(255, 159, 64, 0.2f) };
        List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };

        [Inject]
        public IWeatherServices weatherServices { get; set; }

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
            var data = await weatherServices.GetTemperatureTrends();
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
