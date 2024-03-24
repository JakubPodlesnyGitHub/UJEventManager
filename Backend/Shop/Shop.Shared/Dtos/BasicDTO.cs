using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Dtos
{
    public class BasicDTO
    {
        public bool? IsSucceded { get; set; }
        public object?  ObjectName { get; set; }
        public string? ErrorDetails  { get; set; }
        public string? ExceptionName { get; set; }
    }
}
