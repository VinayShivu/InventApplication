using InventApplication.Domain.DTOs.PurchaseOrder;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrderViewListDto>> GetPurchaseOrderist(PurchaseOrderSearchRequestDto getPurchaseOrderRequest);
        //Task<PubCenterDto> GetPubCenter(Int64 pubCenterId);
        Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest);
        // Task<Boolean> UpdatePubCenter(Int64 pubCenterId, PubCenter updatePubCenterRequest);
        //Task<Boolean> DeletePubCenter(PubCenterDeleteRequestDto pubCenterDeleteRequest);
        //Task<PubCenterDropDownValuesDto> GetPubCenterDropDownValues();
    }
}
