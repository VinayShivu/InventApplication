using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Supplier
    {
        [Key]
        [Required]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please enter a Supplier Name.")]
        public string? SupplierName { get; set; }

        [Required(ErrorMessage = "Please enter a Supplier GST.")]
        public string? SupplierGST { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a Supplier Phone.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Please enter a Supplier Address.")]
        public string? Address { get; set; }
    }
}
