using InventApplication.Domain.DTOs.PurchaseOrder;
using InventApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrderViewListDto>> GetPurchaseOrderist(PurchaseOrderSearchRequestDto getPurchaseOrderRequest);
        //Task<PubCenterDto> GetPubCenter(Int64 pubCenterId);
        Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest);
        //Task<Boolean> UpdatePubCenter(PubCenter updatePubCenterRequest);
        //Task<Boolean> DeletePubCenter(PubCenterDeleteRequestDto pubCenterDeleteRequest);
    }
}
