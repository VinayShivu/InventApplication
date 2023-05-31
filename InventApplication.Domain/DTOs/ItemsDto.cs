using InventApplication.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs
{
    public class ItemsDto
    {
        [Required(ErrorMessage = Messages.ItemNameRequired)]
        [RegularExpression(@".{4,360}", ErrorMessage = Messages.Min4Max360)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = Messages.UnitRequired)]
        public string Unit { get; set; }
        [Required(ErrorMessage = Messages.HSNRequired)]
        public int HSN { get; set; }
        public string Brand { get; set; }
        public string PartCode { get; set; }
        public int GST { get; set; }
        public int IGST { get; set; }
        [Required(ErrorMessage = Messages.SellingPriceRequired)]
        public decimal SellingPrice { get; set; }
    }
}
