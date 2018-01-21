using Newtonsoft.Json;

namespace luno_api
{
    public class OrderBookItem
    {
        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}