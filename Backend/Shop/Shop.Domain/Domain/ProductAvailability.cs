using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Domain
{
    internal class ProductAvailability
    {
        public Guid Id { get; set; }
        public int Availability { get; set; }
        public string Status { get; set; }
    }
}
