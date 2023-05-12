using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        public string? CompanyName { get; set; }
        public string? VendorGST { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? ContactPersons { get; set; }
    }
}
