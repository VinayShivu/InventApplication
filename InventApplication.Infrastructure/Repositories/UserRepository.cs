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
                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM registertbl");
                if (count == 0)
                {
                    return null;
                }
                return connection.Query<UserDto>(sql, new { UserName = username, Password = password }).FirstOrDefault();
            }
        }

        public async Task<UserDto> GetByUserName(string username)
        {
            if (UserExists(username))
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM registertbl WHERE username=@username ";
                    connection.Open();
                    var result = await connection.QueryAsync<UserDto>(sql, new { UserName = username });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        private bool UserExists(string username)
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
    }
}
