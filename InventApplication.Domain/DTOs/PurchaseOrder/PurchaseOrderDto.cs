namespace InventApplication.Domain.DTOs.PurchaseOrder
{
    public record PurchaseOrderDto
    {
        public int Id { get; set; }
        public int VendorID { get; set; }
        public string? VendorName { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? PaymentTerms { get; set; }
        public string? TermsandConditions { get; set; }
        public Boolean? IsReceived { get; set; }
        public int CreatedBy { get; set; }
        public decimal POSubTotal { get; set; }
        public decimal POGSTTotal { get; set; }
        public decimal POGrandTotal { get; set; }
        public List<POItemDetailsView>? ItemDetails { get; set; }
    }

    public record POItemDetailsView
    {
        public int ItemId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseQty { get; set; }
        public bool IsIGST { get; set; }
        public int GST { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GSTTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
