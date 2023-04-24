using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.DTOs
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierGST { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

    }
}
