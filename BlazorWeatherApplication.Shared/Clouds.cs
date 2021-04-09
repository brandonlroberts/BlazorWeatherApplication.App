using Newtonsoft.Json;

namespace BlazorWeatherApplication.Shared
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
