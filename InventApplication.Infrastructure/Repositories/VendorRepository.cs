using Dapper;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly IDataAccess _dataAccess;
        public VendorRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private bool VendorExists()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                connection.Open();
                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM vendor");
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> AddVendor(Vendor vendor)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO vendor (companyname,vendorgst,email,phone,address,primarycontactname,contactpersons,payables) VALUES (@companyname,@vendorgst,@email,@phone,@address,@primarycontactname,@contactpersons,@payables)";
                connection.Open();
                result = await connection.ExecuteAsync(sql, vendor);
                connection.Close();
            }
            return result > 0;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorAsync()
        {
            if (VendorExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM vendor";
                    connection.Open();
                    var result = await connection.QueryAsync<Vendor>(sql);
                    connection.Close();
                    return result;
                }
            }
            else
            {
                return null;
            }

        }

        public async Task<Vendor> GetVendorByIdAsync(int vendorid)
        {
            if (VendorExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM vendor WHERE vendorid=@vendorid";
                    connection.Open();
                    var result = await connection.QueryAsync<Vendor>(sql, new { VendorId = vendorid });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateVendor(Vendor vendorUpdate, int vendorid)
        {
            if (VendorExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"UPDATE vendor Set companyname=@companyname,vendorgst=@vendorgst,email=@email,phone=@phone,address=@address,primarycontactname=@primarycontactname,contactpersons=@contactpersons WHERE vendorid=@vendorid";
                    connection.Open();
                    await connection.QueryAsync(sql, vendorUpdate);
                    connection.Close();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteVendor(int vendorid)
        {
            if (VendorExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"DELETE FROM vendor WHERE vendorid=@vendorid";
                    connection.Open();
                    await connection.QueryAsync(sql, new { VendorId = vendorid });
                    connection.Close();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<Vendor> GetVendorByNameAsync(string companyname)
        {
            if (VendorExists())
            {
                using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
                {
                    string sql = @"SELECT * FROM vendor WHERE companyname=@companyname";
                    connection.Open();
                    var result = await connection.QueryAsync<Vendor>(sql, new { CompanyName = companyname });
                    connection.Close();
                    return result.FirstOrDefault();
                }
            }
            else
            {
                return null;
            }
        }

    }
}
