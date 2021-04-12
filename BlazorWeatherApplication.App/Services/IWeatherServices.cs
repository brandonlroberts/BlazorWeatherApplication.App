using BlazorWeatherApplication.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWeatherApplication.App.Services
{
    public interface IWeatherServices
    {
        Task<Dictionary<double, DateTime>> GetTemperatureTrends(double lat, double lon);
        Task<WeatherForecast> GetWeatherForcastByEnteredZip(int zipCode);
    }
}