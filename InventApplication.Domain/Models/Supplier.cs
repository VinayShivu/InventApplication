using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
