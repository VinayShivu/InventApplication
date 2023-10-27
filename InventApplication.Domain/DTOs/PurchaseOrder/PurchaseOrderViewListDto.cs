namespace InventApplication.Domain.DTOs.PurchaseOrder
{
    public record PurchaseOrderViewListDto
    {
        public int Id { get; set; }
        public string? VendorName { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public Boolean? IsReceived { get; set; }
        public int TotalCount { get; set; }
    }
}
