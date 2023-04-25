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

        public Task<bool> DeleteSupplier(int supplierid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSupplierByIdAsync(int supplierid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSupplier(Supplier supplierUpdate, int supplierid)
        {
            throw new NotImplementedException();
        }
    }
}
