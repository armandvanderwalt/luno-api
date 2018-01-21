using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class TransactionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}