using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IPurchaseRepository
    {
        public Task<bool> AddPurchase(Purchase purchase);
        public Task<Purchase> GetPurchaseByIdAsync(int purchaseid);
        public Task<IEnumerable<Purchase>> GetAllPurchaseAsync();
        public Task<bool> UpdatePurchase(Purchase purchaseUpdate, int purchaseid);
        public Task<bool> DeletePurchase(int purchaseid);
        public Task<bool> UpdateItemStock(int itemid, int stockqty);
        public Task<bool> UpdatePayabletoVendor(int vendorid, decimal totalamount);
    }
}
