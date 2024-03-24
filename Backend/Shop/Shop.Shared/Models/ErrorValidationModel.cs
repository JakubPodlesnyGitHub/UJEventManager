using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Models
{
    public class ErrorValidationModel
    {
        public object EnteredValue { get; set; }
        public string ErrorMessage { get; set; }
    }
}
