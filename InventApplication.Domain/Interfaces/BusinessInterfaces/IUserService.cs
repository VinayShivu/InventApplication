using InventApplication.Domain.DTOs;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IUserService
    {
        public void RegisterUser(UserDto model);
        public Task<TokenResponse> UserLogin(string userName, string password);
    }
}
