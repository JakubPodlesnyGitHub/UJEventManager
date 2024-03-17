using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Domain
{
    internal class ShopOrder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OrderCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpectedLeadTime { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
    }
}
