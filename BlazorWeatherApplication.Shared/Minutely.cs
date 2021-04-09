using Newtonsoft.Json;

namespace BlazorWeatherApplication.Shared
{
    public class Minutely
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        //This changed during the day Friday causing the page to break.
        //[JsonProperty("precipitation")]
        //public long Precipitation { get; set; }
    }
}
