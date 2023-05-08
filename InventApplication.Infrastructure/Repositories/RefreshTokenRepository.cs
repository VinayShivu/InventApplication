using Dapper;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models.JWT;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IDataAccess _dataAccess;
        public RefreshTokenRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task UpdateRefreshTokenAsync(JwtToken jwttoken, int userId)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"UPDATE registertbl SET refreshtoken = @refreshtokennew, refreshtokencreated = @created, refreshtokenexpires = @expires WHERE userid = @userId";
                connection.Open();
                var refreshtokennew = jwttoken.RefreshToken.Token;
                var created = jwttoken.RefreshToken.Created;
                var expires = jwttoken.RefreshToken.Expires;
                await connection.ExecuteAsync(sql, new { refreshtokennew, created, expires, userId });
                connection.Close();
            }
        }

        public async Task<RefreshToken> GetRefreshTokenByTokenAsync(string refreshtoken)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT refreshtoken,refreshtokencreated, refreshtokenexpires FROM registertbl WHERE refreshtoken=@refreshtokenreq";
                var param = new { refreshtokenreq = refreshtoken };
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync(sql, param);
                if (result == null)
                {
                    throw new RepositoryException(Messages.InvalidToken);
                }
                RefreshToken existingRefreshToken = new RefreshToken()
                {
                    Token = result.refreshtoken,
                    Created = result.refreshtokencreated,
                    Expires = result.refreshtokenexpires
                };
                connection.Close();
                return existingRefreshToken;
            }
        }
    }
}
