using Newtonsoft.Json;

namespace luno_api
{
    public class Balance
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("balance")]
        public string PurpleBalance { get; set; }

        [JsonProperty("reserved")]
        public string Reserved { get; set; }

        [JsonProperty("unconfirmed")]
        public string Unconfirmed { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}