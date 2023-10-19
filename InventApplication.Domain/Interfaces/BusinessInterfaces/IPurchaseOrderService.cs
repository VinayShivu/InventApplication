using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IPurchaseOrderService
    {
        // Task<List<PubCenterDto>> GetPubCenterList(PubCenterSearchRequestDto getPubCenterRequest);
        //Task<PubCenterDto> GetPubCenter(Int64 pubCenterId);
        Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest);
        // Task<Boolean> UpdatePubCenter(Int64 pubCenterId, PubCenter updatePubCenterRequest);
        //Task<Boolean> DeletePubCenter(PubCenterDeleteRequestDto pubCenterDeleteRequest);
        //Task<PubCenterDropDownValuesDto> GetPubCenterDropDownValues();
    }
}
