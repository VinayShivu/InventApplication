using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public void RegisterUser(UserDto model);
        public Task<User> GetByUserName(string username);
    }
}
