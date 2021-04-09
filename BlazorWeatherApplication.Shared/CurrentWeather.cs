using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlazorWeatherApplication.Shared
{
    public class CurrentWeather
    {
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public int ZipCode { get; set; }
    }
}
