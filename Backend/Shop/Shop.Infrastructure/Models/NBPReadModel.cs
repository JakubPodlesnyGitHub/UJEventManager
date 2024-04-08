using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Models
{
    public class NBPReadModel
    {
        public List<NBPDataReadModel> Data { get; set; }
    }

    public class NBPDataReadModel
    {
        public string Table { get; set; }
        public string No { get; set; }
        public DateTime EffectiveDate { get; set; }
        public List<NBPCurrencyReadModel> Rates { get; set; }
    }

    public class NBPCurrencyReadModel
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }
    }
}
