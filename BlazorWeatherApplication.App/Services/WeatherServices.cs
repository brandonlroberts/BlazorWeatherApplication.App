using BlazorWeatherApplication.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWeatherApplication.App.Services
{
    public class WeatherServices : IWeatherServices
    {
        private readonly HttpClient _httpClient;

        public WeatherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<WeatherForecast> GetWeatherForcastByEnteredZip(int zipCode)
        {
            return await JsonSerializer.DeserializeAsync<WeatherForecast>
                (await _httpClient.GetStreamAsync($"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid=535d5e1bc65e23d1d5dc4a936dcd9900"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Dictionary<double, DateTime>> GetTemperatureTrends(double lat, double lon)
        {
            // Daily has the max temp so I removed it from the exclude in the api call. 
            var result = await JsonSerializer.DeserializeAsync<TempatureTrend>
                (await _httpClient.GetStreamAsync($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=hourly&appid=535d5e1bc65e23d1d5dc4a936dcd9900"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            Dictionary<double, DateTime> data = new Dictionary<double, DateTime>();


            foreach (var item in result.Daily)
            {
                
                item.ConvertedDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(item.Dt);
                var temp = (item.Temp.Max - 273.15) * 9 / 5 + 32;
                data.Add(temp, item.ConvertedDate);
            }

            return data.Take(3).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
