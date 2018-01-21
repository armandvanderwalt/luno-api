using Newtonsoft.Json;

namespace luno_api
{
    public class Trade
    {
        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("is_buy")]
        public bool IsBuy { get; set; }
    }
}