using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Models
{
    public class ExchangeRateTable
    {
        [JsonProperty("table")]
        public string Table { get; set; }
        [JsonProperty("no")]
        public string No { get; set; }
        [JsonProperty("effectiveDate")]
        public DateTime EffectiveDate { get; set; }
        [JsonProperty("rates")]
        public List<Rate> Rates { get; set; }
    }

    public class Rate
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("Mid")]
        public decimal Mid { get; set; }
    }
}
