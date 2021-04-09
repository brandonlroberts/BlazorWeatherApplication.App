using Blazored.Toast.Services;
using BlazorWeatherApplication.App.Services;
using BlazorWeatherApplication.Shared;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Telerik.JustMock;
using Xunit;

namespace BlazorWeatherApplication.Tests
{
    public class CurrentWeatherTests : TestContext
    {
        public CurrentWeatherTests()
        {
            var weatherServiceMock = Mock.Create<IWeatherServices>();
            Mock.Arrange(() => weatherServiceMock.GetWeatherForcastByEnteredZip(Arg.IsAny<int>()))
                .Returns(new TaskCompletionSource<WeatherForecast>().Task);
            Services.AddHttpClient<IWeatherServices, WeatherServices>(client => client.BaseAddress = new Uri("https://localhost:44325/"));

            var toastServiceMock = Mock.Create<IToastService>();
            Services.AddSingleton<IToastService>(toastServiceMock);
        }
        [Fact]
        public void Index_Razor_Tests()
        {

            var component = RenderComponent<App.Pages.Index>();

            component.Find("button");

            component.MarkupMatches(@"<h1>Weather forecast</h1>
                                      <p>
                                        <em>This component demonstrates fetching the weather forecast data from a server.</em>
                                      </p>
                                      <br>
                                      <form >
                                        <div class=""col-12 row"">
                                          <div class=""col-xs-12 col-sm-8"">
                                            <label for=""Name"">Zip Code</label>
                                            <input step=""any"" id=""zipcode"" type=""number"" class=""valid"" value=""45013"" >
                                            <button type=""submit"">Submit</button>
                                          </div>
                                          <div class=""col-xs-12 col-sm-8"">
                                          </div>
                                        </div>
                                      </form>
                                      <br>
                                      <p>
                                        <em>Loading...</em>
                                      </p>");
        }
    }
}
