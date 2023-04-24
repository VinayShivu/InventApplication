using Dapper;
using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace InventApplication.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IDbConnection Connection
        {
            get
            {
                string query = _configuration["ConnectionStrings:connectionstring"];
                return new NpgsqlConnection(query);

            }

        }
        public void RegisterUser(UserDto model)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO registertbl (userid,firstname,lastname,username,password) VALUES (@userid,@firstname,@lastname,@username,@password )";
                dbConnection.Open();
                dbConnection.Execute(sql, model);
                dbConnection.Close();
            }
        }

        public UserDto GetByUser(string username, string password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM registertbl WHERE username=@username and password=@password ";
                dbConnection.Open();
                return dbConnection.Query<UserDto>(sql, new { UserName = username, Password = password }).FirstOrDefault();
            }
        }
    }
}
