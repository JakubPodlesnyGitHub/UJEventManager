using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Enums
{
    public enum OrderSatatus
    {
        PENDING,
        PROCESSING,
        CANCELLED,
        PAID,
        ON_HOLD
    }
}
