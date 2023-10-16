using Dapper;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IDataAccess _dataAccess;
        public PurchaseRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private bool PurchaseDataExists()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                connection.Open();
                var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM purchase");
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> AddPurchase(Purchase purchase)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO purchase (vendorid,vendorname,billno,billdate,paymentterms,duedate,itemsdata,totalbasicamount,totalgst,totaligst,totalamount) VALUES (@vendorid,@vendorname,@billno,@billdate,@paymentterms,@duedate,@itemsdata,@totalbasicamount,@totalgst,@totaligst,@totalamount)";
                connection.Open();
                result = await connection.ExecuteAsync(sql, purchase);

                connection.Close();
            }
            return result > 0;
        }

        public Task<bool> DeletePurchase(int purchaseid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetAllPurchaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> GetPurchaseByIdAsync(int purchaseid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePurchase(Purchase purchaseUpdate, int purchaseid)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemStock(int itemid, int stockqty)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = $"update items set stock = {stockqty} where itemid={itemid}";
                connection.Open();
                result = await connection.ExecuteAsync(sql);
                connection.Close();
            }
            return result > 0;
        }

        public async Task<bool> UpdatePayabletoVendor(int vendorid, decimal totalamount)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = $"update vendor set payables = {totalamount} where vendorid={vendorid}";
                connection.Open();
                result = await connection.ExecuteAsync(sql);
                connection.Close();
            }
            return result > 0;
        }
    }
}
