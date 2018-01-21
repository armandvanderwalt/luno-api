using Newtonsoft.Json;

namespace luno_api
{
    public class FeeInfo
    {
        [JsonProperty("maker_fee")]
        public string MakerFee { get; set; }

        [JsonProperty("taker_fee")]
        public string TakerFee { get; set; }

        [JsonProperty("thirty_day_volume")]
        public string ThirtyDayVolume { get; set; }
    }
}