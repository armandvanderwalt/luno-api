using Newtonsoft.Json;

namespace luno_api
{
    public class Order
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("counter")]
        public string Counter { get; set; }

        [JsonProperty("creation_timestamp")]
        public long CreationTimestamp { get; set; }

        [JsonProperty("expiration_timestamp")]
        public long ExpirationTimestamp { get; set; }

        [JsonProperty("completed_timestamp")]
        public long CompletedTimestamp { get; set; }

        [JsonProperty("fee_base")]
        public string FeeBase { get; set; }

        [JsonProperty("fee_counter")]
        public string FeeCounter { get; set; }

        [JsonProperty("limit_price")]
        public string LimitPrice { get; set; }

        [JsonProperty("limit_volume")]
        public string LimitVolume { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}