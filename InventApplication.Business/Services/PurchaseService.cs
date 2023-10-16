using InventApplication.Domain.DTOs.Items;
using InventApplication.Domain.DTOs.Purchase;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Newtonsoft.Json;

namespace InventApplication.Business.Services
{
    public class PurchaseService : IPurchaseService
    {
        public readonly IPurchaseRepository _purchaseRepository;
        public readonly IItemsRepository _itemsRepository;
        public readonly IVendorRepository _vendorRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository, IItemsRepository itemsRepository, IVendorRepository vendorRepository)
        {
            _purchaseRepository = purchaseRepository;
            _itemsRepository = itemsRepository;
            _vendorRepository = vendorRepository;
        }

        public async Task<string> AddPurchase(PurchaseDto purchase)
        {
            foreach (ItemsPurchaseDto item in purchase.ItemsData)
            {
                var getitem = await _itemsRepository.GetItemByIdAsync(item.ItemId);

                int presentstock = getitem.Stock;
                int totalstock = presentstock + item.Quantity;
                bool updateitem = await _purchaseRepository.UpdateItemStock(getitem.ItemId, totalstock);
                if (!updateitem)
                {
                    throw new NotFoundException(Messages.UpdateItemStockError);
                }
            }
            var getvendor = await _vendorRepository.GetVendorByIdAsync(purchase.VendorID);
            if (getvendor == null)
            {
                throw new NotFoundException(Messages.InvalidVendorId);
            }
            decimal totalpayable = getvendor.Payables + purchase.TotalAmount;
            bool updatevendor = await _purchaseRepository.UpdatePayabletoVendor(purchase.VendorID, totalpayable);
            if (!updatevendor)
            {
                throw new NotFoundException(Messages.UpdatePayabletoVendorError);
            }
            var newPurchase = new Purchase
            {
                VendorId = purchase.VendorID,
                VendorName = purchase.VendorName,
                BillNo = purchase.BillNo,
                BillDate = purchase.BillDate,
                PaymentTerms = purchase.PaymentTerms,
                DueDate = purchase.DueDate,
                ItemsData = JsonConvert.SerializeObject(purchase.ItemsData),
                TotalBasicAmount = purchase.TotalBasicAmount,
                TotalGST = purchase.TotalGST,
                TotalIGST = purchase.TotalIGST,
                TotalAmount = purchase.TotalAmount
            };
            bool retVal = await _purchaseRepository.AddPurchase(newPurchase);
            return retVal ? purchase.VendorName : null;
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
    }
}
