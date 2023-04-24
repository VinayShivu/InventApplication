using Dapper;
using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace InventApplication.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
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
        public IEnumerable<EmployeeDto> EmployeeDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM employeetbl";
                dbConnection.Open();
                return dbConnection.Query<EmployeeDto>(sql);
            }
        }
    }
}
