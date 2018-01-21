using Newtonsoft.Json;

namespace luno_api
{
    public class StopOrderResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}