using Newtonsoft.Json;

namespace luno_api
{
    public class Ticker
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("bid")]
        public string Bid { get; set; }

        [JsonProperty("ask")]
        public string Ask { get; set; }

        [JsonProperty("last_trade")]
        public string LastTrade { get; set; }

        [JsonProperty("rolling_24_hour_volume")]
        public string Rolling24HourVolume { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }
    }
}