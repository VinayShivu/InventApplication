using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int VendorId { get; set; }
        public string? VendorName { get; set; }
        public string? BillNo { get; set; }
        public string? BillDate { get; set; }
        public string? PaymentTerms { get; set; }
        public string? DueDate { get; set; }
        public string? ItemsData { get; set; }
        public decimal TotalBasicAmount { get; set; }
        public int TotalGST { get; set; }
        public int TotalIGST { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
