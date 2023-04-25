using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Supplier
    {
        [Key]
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public string? SupplierName { get; set; }
        [Required]
        public string? SupplierGST { get; set; }

        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
