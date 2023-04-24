using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.DTOs
{
    public class TokenResponse
    {
        public string? JWTToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
