using Newtonsoft.Json;

namespace luno_api
{
    public class PostOrderResponse
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}