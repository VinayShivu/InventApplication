using InventApplication.Domain.DTOs.User;
using InventApplication.Domain.Models;
using InventApplication.Domain.Models.JWT;
using System.Security.Claims;

namespace InventApplication.Domain.Interfaces.JWT
{
    public interface IJwtService
    {
        public JwtToken GenerateJwtToken(User user);
        public Task<JwtToken> GetRefreshToken(RefreshTokenRequest refreshTokenRequest);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
