using Newtonsoft.Json;

namespace luno_api
{
    public class Transaction
    {
        [JsonProperty("row_index")]
        public long RowIndex { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("available")]
        public double Available { get; set; }

        [JsonProperty("balance_delta")]
        public double BalanceDelta { get; set; }

        [JsonProperty("available_delta")]
        public double AvailableDelta { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}