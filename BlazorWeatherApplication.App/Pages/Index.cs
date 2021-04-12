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
                AppStateService.OnChange += StateHasChanged;
                currentWeather.ZipCode = 45013;
                forecast = await weatherServices.GetWeatherForcastByEnteredZip(currentWeather.ZipCode);
                await AppStateService.Set(new AppState { Lat = forecast.Coord.Lat, Lon = forecast.Coord.Lon });
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
                await AppStateService.Set(new AppState { Lat = forecast.Coord.Lat, Lon = forecast.Coord.Lon });
            }
            catch (Exception)
            {
                toastService.ShowError("Zipcode could not be found. Please try again.");
            }
        }

        public void Dispose()
        {
            AppStateService.OnChange -= StateHasChanged;
        }
    }
}
