using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class ListOrderResponse
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}