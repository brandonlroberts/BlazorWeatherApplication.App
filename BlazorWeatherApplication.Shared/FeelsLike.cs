using Newtonsoft.Json;

namespace BlazorWeatherApplication.Shared
{
    public class FeelsLike
    {
        [JsonProperty("day")]
        public double Day { get; set; }

        [JsonProperty("night")]
        public double Night { get; set; }

        [JsonProperty("eve")]
        public double Eve { get; set; }

        [JsonProperty("morn")]
        public double Morn { get; set; }
    }
}
