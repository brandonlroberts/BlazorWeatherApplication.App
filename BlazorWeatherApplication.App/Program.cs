using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorWeatherApplication.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeatherApplication.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
              .AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true;
              })
              .AddBootstrapProviders()
              .AddFontAwesomeIcons()
              .AddBlazoredToast();
                
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IWeatherServices, WeatherServices>(client => client.BaseAddress = new Uri("https://localhost:44325/"));

            await builder.Build().RunAsync();
        }
    }
}
