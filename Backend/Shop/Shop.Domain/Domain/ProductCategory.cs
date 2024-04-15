using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Domain
{
    public class ProductCategory
    {
        public Guid IdProduct { get; set; }
        public Guid IdCategory { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Product ProductNavigation { get; set; } = null!;
        public virtual Category CategoryNavigation { get; set; } = null!;
    }
}
