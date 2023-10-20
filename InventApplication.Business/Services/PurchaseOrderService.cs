using InventApplication.Domain.DTOs.PurchaseOrder;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
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

        #region Private
        private static String GetSortFieldName(String SortField)
        {
            return SortField switch
            {
                "poDate" => "po_date",
                "purchaseOrderNumber" => "purchase_order_no",
                "referenceNumber" => "reference_no",
                _ => SortField,
            };
        }
        #endregion


        #region Public
        public async Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest)
        {
            bool status = await _purchaseOrderRepository.AddPurchaseOrder(addPurchaseOrderRequest);
            return status;
        }

        public async Task<List<PurchaseOrderViewListDto>> GetPurchaseOrderist(PurchaseOrderSearchRequestDto getPurchaseOrderRequest)
        {
           // getPurchaseOrderRequest.SortField = GetSortFieldName(getPurchaseOrderRequest.SortField);
            List<PurchaseOrderViewListDto> purchaseOrderList = await _purchaseOrderRepository.GetPurchaseOrderist(getPurchaseOrderRequest);
            if (!purchaseOrderList.Any() && purchaseOrderList.Count == 0)
            {
                throw new CustomException(Messages.NoData);
            }
            return purchaseOrderList;
        }
        #endregion
    }
}
    