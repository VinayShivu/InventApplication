using InventApplication.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs.Items
{
    public record ItemsDto
    {
        [Required(ErrorMessage = Messages.ItemNameRequired)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = Messages.UnitRequired)]
        public string? Unit { get; set; }
        [Required(ErrorMessage = Messages.HSNRequired)]
        public int HSN { get; set; }
        public string? Brand { get; set; }
        public string? PartCode { get; set; }
        public int GST { get; set; }
        public int IGST { get; set; }
        [Required(ErrorMessage = Messages.SellingPriceRequired)]
        public decimal SellingPrice { get; set; }
    }
}
