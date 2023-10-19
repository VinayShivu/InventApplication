using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IPurchaseOrderRepository
    {
        //Task<List<PubCenterDto>> GetPubCenterList(PubCenterSearchRequestDto getPubCenterRequest);
        //Task<PubCenterDto> GetPubCenter(Int64 pubCenterId);
        Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest);
        //Task<Boolean> UpdatePubCenter(PubCenter updatePubCenterRequest);
        //Task<Boolean> DeletePubCenter(PubCenterDeleteRequestDto pubCenterDeleteRequest);
    }
}
