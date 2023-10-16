namespace InventApplication.Domain.DTOs.Items
{
    public class ItemsPurchaseDto
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public int HSN { get; set; }
        public int Quantity { get; set; }
        public string? Unit { get; set; }
        public decimal BasicPrice { get; set; }
        public int GST { get; set; }
        public int IGST { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
