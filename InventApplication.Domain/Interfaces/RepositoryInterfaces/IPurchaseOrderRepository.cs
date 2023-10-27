using InventApplication.Domain.DTOs.PurchaseOrder;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrderViewListDto>> GetPurchaseOrderist(PurchaseOrderSearchRequestDto getPurchaseOrderRequest);
        Task<PurchaseOrderDto> GetPurchaseOrder(int id);
        Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest);
        //Task<Boolean> UpdatePubCenter(PubCenter updatePubCenterRequest);
        //Task<Boolean> DeletePubCenter(PubCenterDeleteRequestDto pubCenterDeleteRequest);
    }
}
