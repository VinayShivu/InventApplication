using InventApplication.Domain.DTOs.Purchase;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IPurchaseService
    {
        public Task<string> AddPurchase(PurchaseDto purchase);
        public Task<Purchase> GetPurchaseByIdAsync(int purchaseid);
        public Task<IEnumerable<Purchase>> GetAllPurchaseAsync();
        public Task<bool> UpdatePurchase(Purchase purchaseUpdate, int purchaseid);
        public Task<bool> DeletePurchase(int purchaseid);
    }
}
