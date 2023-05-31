using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int HSN { get; set; }
        public string Brand { get; set; }
        public string PartCode { get; set; }
        public int GST { get; set; }
        public int IGST { get; set; }
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; } = "Active";
    }
}
