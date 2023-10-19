using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest)
        {
            bool status = await _purchaseOrderRepository.AddPurchaseOrder(addPurchaseOrderRequest);
            return status;
        }
    }
}
