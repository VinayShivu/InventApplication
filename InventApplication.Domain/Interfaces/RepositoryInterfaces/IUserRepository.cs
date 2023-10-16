using InventApplication.Domain.DTOs.User;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<bool> RegisterUser(UserDto model);
        public Task<User> GetByUserName(string username);
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByID(int userid);
        public Task UpdatePasswordResetToken(string passwordresettoken, int userId, DateTime passwordresettokenexpires);
        public Task<User> GetUserByPasswordResetToken(string passwordresettoken);
        public Task<bool> UpdatePassword(int userId, string newPassword);
    }
}
