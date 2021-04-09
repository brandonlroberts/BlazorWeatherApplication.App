using Newtonsoft.Json;

namespace BlazorWeatherApplication.Shared
{
    public class TempatureTrend
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public long TimezoneOffset { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("minutely")]
        public Minutely[] Minutely { get; set; }

        [JsonProperty("daily")]
        public Daily[] Daily { get; set; }
    }
}
