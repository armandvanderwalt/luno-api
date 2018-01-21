using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class OrderBookResponse
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("bids")]
        public List<OrderBookItem> Bids { get; set; }

        [JsonProperty("asks")]
        public List<OrderBookItem> Asks { get; set; }
    }
}