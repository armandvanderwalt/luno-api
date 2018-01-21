using Newtonsoft.Json;

namespace luno_api
{
    public class ListTrade
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("counter")]
        public string Counter { get; set; }

        [JsonProperty("fee_base")]
        public string FeeBase { get; set; }

        [JsonProperty("fee_counter")]
        public string FeeCounter { get; set; }

        [JsonProperty("is_buy")]
        public bool IsBuy { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }
    }
}