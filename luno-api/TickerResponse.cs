using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class TickerResponse
    {
        [JsonProperty("tickers")]
        public List<Ticker> Tickers { get; set; }
    }
}