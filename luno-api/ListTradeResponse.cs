using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class ListTradeResponse
    {
        [JsonProperty("trades")]
        public List<ListTrade> Trades { get; set; }
    }
}