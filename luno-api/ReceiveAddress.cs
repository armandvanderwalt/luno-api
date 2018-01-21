using Newtonsoft.Json;

namespace luno_api
{
    public class ReceiveAddress
    {
        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("total_received")]
        public string TotalReceived { get; set; }

        [JsonProperty("total_unconfirmed")]
        public string TotalUnconfirmed { get; set; }
    }
}