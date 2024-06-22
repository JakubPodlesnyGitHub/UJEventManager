using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Dtos.Response
{
    public class AuthDTO : BasicDTO
    {
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string Role { get; set; }
    }
}
