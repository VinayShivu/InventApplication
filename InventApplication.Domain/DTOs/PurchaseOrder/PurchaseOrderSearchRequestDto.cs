using InventApplication.Domain.Models;

namespace InventApplication.Domain.DTOs.PurchaseOrder
{
    public record PurchaseOrderSearchRequestDto : PaginationRequest
    {
        public string? PurchaseOrderNumber { get; set; }
    }
}
