using System.Collections.Generic;
using Newtonsoft.Json;

namespace luno_api
{
    public class GetWithdrawalResponse
    {
        [JsonProperty("withdrawals")]
        public List<Withdrawal> Withdrawals { get; set; }
    }
}