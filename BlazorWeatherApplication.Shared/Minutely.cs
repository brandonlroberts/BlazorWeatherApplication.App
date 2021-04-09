using Newtonsoft.Json;

namespace BlazorWeatherApplication.Shared
{
    public class Minutely
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("precipitation")]
        public long Precipitation { get; set; }
    }
}
