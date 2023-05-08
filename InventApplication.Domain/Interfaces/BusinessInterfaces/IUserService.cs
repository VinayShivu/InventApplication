using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models.JWT;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IUserService
    {
        public void RegisterUser(UserDto model);
        public Task<JwtToken> UserLogin(string userName, string password);

    }
}
