using Newtonsoft.Json;

namespace luno_api
{
    public class AddAccountResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}