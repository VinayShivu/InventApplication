namespace InventApplication.Domain.DTOs
{
    public class ItemsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int HSN { get; set; }
        public string Brand { get; set; }
        public string PartCode { get; set; }
        public int GST { get; set; }
        public int IGST { get; set; }
        public string SellingPrice { get; set; }
    }
}
