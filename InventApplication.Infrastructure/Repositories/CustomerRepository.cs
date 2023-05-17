using Dapper;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataAccess _dataAccess;
        public CustomerRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private bool CustomerExists()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                connection.Open();
                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM customer");
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO customer (companyname,customergst,email,phone,address,primarycontactname,contactpersons,receivables) VALUES (@companyname,@customergst,@email,@phone,@address,@primarycontactname,@contactpersons,@receivables)";
                connection.Open();
                result = await connection.ExecuteAsync(sql, customer);
                connection.Close();
            }
            return result > 0;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            if (CustomerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM customer";
                    connection.Open();
                    var result = await connection.QueryAsync<Customer>(sql);
                    connection.Close();
                    return result;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteCustomer(int customerid)
        {
            if (CustomerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"DELETE FROM customer WHERE customerid=@customerid";
                    connection.Open();
                    await connection.QueryAsync(sql, new { customerId = customerid });
                    connection.Close();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerid)
        {
            if (CustomerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM customer WHERE customerid=@customerid";
                    connection.Open();
                    var result = await connection.QueryAsync<Customer>(sql, new { CustomerId = customerid });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Customer> GetCustomerByNameAsync(string companyname)
        {
            if (CustomerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM customer WHERE companyname=@companyname";
                    connection.Open();
                    var result = await connection.QueryAsync<Customer>(sql, new { CompanyName = companyname });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customerUpdate, int customerid)
        {
            if (CustomerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"UPDATE customer Set companyname=@companyname,customergst=@customergst,email=@email,phone=@phone,address=@address,primarycontactname=@primarycontactname,contactpersons=@contactpersons WHERE customerid=@customerid";
                    connection.Open();
                    await connection.QueryAsync(sql, customerUpdate);
                    connection.Close();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
