using BlazorWeatherApplication.App.Services;
using BlazorWeatherApplication.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorWeatherApplication.App.Pages
{
    public partial class Index
    {
        private WeatherForecast forecast;
        private CurrentWeather currentWeather = new CurrentWeather();       

        [Inject]
        private IWeatherServices weatherServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                currentWeather.ZipCode = 45013;
                forecast = await weatherServices.GetWeatherForcastByEnteredZip(currentWeather.ZipCode);
            }
            catch (Exception)
            {
                toastService.ShowError("Error occured when loading...");
            }
        }

        protected async Task OnButtonSubmitAsync()
        {
            try
            {
                forecast = await weatherServices.GetWeatherForcastByEnteredZip(currentWeather.ZipCode);
            }
            catch (Exception)
            {
                toastService.ShowError("Zipcode could not be found. Please try again.");
            }
        }
    }
}
