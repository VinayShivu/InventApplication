using Dapper;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDataAccess _dataAccess;
        public SupplierRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<bool> AddSupplier(Supplier supplier)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO supplier (suppliername,suppliergst,email,phone,address) VALUES (@suppliername,@suppliergst,@email,@phone,@address)";
                connection.Open();
                result = await connection.ExecuteAsync(sql, supplier);
                connection.Close();
            }
            return result > 0;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT * FROM supplier";
                connection.Open();
                var result = await connection.QueryAsync<Supplier>(sql);
                connection.Close();
                return result;
            }
        }

        public async Task<Supplier> GetSupplierByIdAsync(int supplierid)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT * FROM supplier WHERE supplierid=@supplierid";
                connection.Open();
                var result = await connection.QueryAsync<Supplier>(sql, new { SupplierId = supplierid });
                connection.Close();
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateSupplier(Supplier supplierUpdate, int supplierid)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"UPDATE supplier Set suppliername=@suppliername,suppliergst=@suppliergst,email=@email,phone=@phone,address=@address WHERE supplierid=@supplierid";
                connection.Open();
                await connection.QueryAsync(sql, supplierUpdate);
                connection.Close();
                return true;
            }
        }

        public async Task<bool> DeleteSupplier(int supplierid)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"DELETE FROM supplier WHERE supplierid=@supplierid";
                connection.Open();
                await connection.QueryAsync(sql, new { SupplierId = supplierid });
                connection.Close();
                return true;
            }
        }

    }
}
