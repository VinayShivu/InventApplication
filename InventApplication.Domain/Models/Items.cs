using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Items
    {
        [Key]
        [Required]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please enter a Item Name.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Unit")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Please enter a HSN")]
        public int HSN { get; set; }
        public string Brand { get; set; }
        public string PartCode { get; set; }

        [Required(ErrorMessage = "Please enter a GST")]
        public int GST { get; set; }

        [Required(ErrorMessage = "Please enter a IGST")]
        public int IGST { get; set; }

        [Required(ErrorMessage = "Please enter a Selling Price")]
        public string SellingPrice { get; set; }
    }
}
