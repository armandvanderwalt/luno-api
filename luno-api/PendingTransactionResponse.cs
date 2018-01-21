using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class PendingTransactionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("pending")]
        public List<Pending> Pending { get; set; }
    }
}