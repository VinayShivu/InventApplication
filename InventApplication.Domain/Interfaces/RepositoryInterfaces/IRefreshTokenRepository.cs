using InventApplication.Domain.Models.JWT;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IRefreshTokenRepository
    {
        public Task UpdateRefreshTokenAsync(JwtToken jwtToken, int userId);

        public Task<RefreshToken> GetRefreshTokenByTokenAsync(string refreshtokenreq);
    }
}
