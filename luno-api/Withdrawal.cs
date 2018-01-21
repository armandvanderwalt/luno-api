using Newtonsoft.Json;

namespace luno_api
{
    public class Withdrawal
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}