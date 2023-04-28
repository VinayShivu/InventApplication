using Dapper;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly IDataAccess _dataAccess;
        public BuyerRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private bool BuyerExists()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                connection.Open();
                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM buyer");
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> AddBuyer(Buyer buyer)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO buyer (buyername,buyergst,phone,email,address) VALUES (@buyername,@buyergst,@phone,@email,@address)";
                connection.Open();
                result = await connection.ExecuteAsync(sql, buyer);
                connection.Close();
            }
            return result > 0;
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyerAsync()
        {
            if (BuyerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM buyer";
                    connection.Open();
                    var result = await connection.QueryAsync<Buyer>(sql);
                    connection.Close();
                    return result;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteBuyer(int buyerid)
        {
            if (BuyerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"DELETE FROM buyer WHERE buyerid=@buyerid";
                    connection.Open();
                    await connection.QueryAsync(sql, new { BuyerId = buyerid });
                    connection.Close();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerid)
        {
            if (BuyerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM buyer WHERE buyerid=@buyerid";
                    connection.Open();
                    var result = await connection.QueryAsync<Buyer>(sql, new { BuyerId = buyerid });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Buyer> GetBuyerByNameAsync(string buyername)
        {
            if (BuyerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM buyer WHERE buyername=@buyername";
                    connection.Open();
                    var result = await connection.QueryAsync<Buyer>(sql, new { BuyerName = buyername });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateBuyer(Buyer buyerUpdate, int buyerid)
        {
            if (BuyerExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"UPDATE buyer Set buyername=@buyername,buyergst=@buyergst,phone=@phone,email=@email,address=@address WHERE buyerid=@buyerid";
                    connection.Open();
                    await connection.QueryAsync(sql, buyerUpdate);
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
