using Dapper;
using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataAccess _dataAccess;
        public UserRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private bool UserExists()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                connection.Open();
                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM registertbl");
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async void RegisterUser(UserDto model)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO registertbl (username,password,email,roles) VALUES (@username,@password,@email,@roles)";
                connection.Open();
                await connection.ExecuteAsync(sql, model);
                connection.Close();
            }
        }
        public async Task<User> GetByUserName(string username)
        {
            if (UserExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM registertbl WHERE username=@username ";
                    connection.Open();
                    var result = await connection.QueryAsync<User>(sql, new { UserName = username });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            if (UserExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM registertbl WHERE email=@email ";
                    connection.Open();
                    var result = await connection.QueryAsync<User>(sql, new { Email = email });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }
        public async Task UpdatePasswordResetToken(string passwordresettoken, int userId, DateTime passwordresettokenexpires)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"UPDATE registertbl SET passwordresettoken=@passwordresettoken, passwordresettokenexpires = @passwordresettokenexpires WHERE userid = @userId";
                connection.Open();
                await connection.ExecuteAsync(sql, new { passwordresettoken, passwordresettokenexpires, userId });
                connection.Close();
            }
        }

        public async Task<User> GetUserByPasswordResetToken(string passwordresettoken)
        {
            if (UserExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM registertbl WHERE passwordresettoken=@passwordresettoken";
                    var result = await connection.QueryAsync<User>(sql, new { PasswordResetToken = passwordresettoken });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdatePassword(int userid, string newPassword)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"UPDATE registertbl SET password=@newPassword, passwordresettoken= NULL, passwordresettokenexpires = NULL WHERE userid = @userid";
                connection.Open();
                await connection.ExecuteAsync(sql, new { newPassword, userid });
                connection.Close();
                return true;
            }
        }
    }
}
