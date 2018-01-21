using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class TradeResponse
    {
        [JsonProperty("trades")]
        public List<Trade> Trades { get; set; }
    }
}