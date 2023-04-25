using Dapper;
using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
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

        public async void RegisterUser(UserDto model)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO registertbl (firstname,lastname,username,password) VALUES (@firstname,@lastname,@username,@password)";
                connection.Open();
                await connection.ExecuteAsync(sql, model);
                connection.Close();
            }
        }

        public UserDto GetByUser(string username, string password)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT * FROM registertbl WHERE username=@username and password=@password ";
                connection.Open();
                return connection.Query<UserDto>(sql, new { UserName = username, Password = password }).FirstOrDefault();
            }
        }

        public UserDto GetByUserName(string username)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT * FROM registertbl WHERE username=@username ";
                connection.Open();
                return connection.Query<UserDto>(sql, new { UserName = username }).FirstOrDefault();
            }
        }
    }
}
