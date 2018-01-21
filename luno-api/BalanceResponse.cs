using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class BalanceResponse
    {
        [JsonProperty("balance")]
        public List<Balance> Balance { get; set; }
    }
}