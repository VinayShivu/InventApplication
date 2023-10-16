using InventApplication.Domain.DTOs.Items;
using InventApplication.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs.Purchase
{
    public class PurchaseDto
    {
        [Required(ErrorMessage = Messages.VendorIdRequired)]
        public int VendorID { get; set; }
        [Required(ErrorMessage = Messages.CompanyNameRequired)]
        public string? VendorName { get; set; }
        [Required(ErrorMessage = Messages.BillNoRequired)]
        public string? BillNo { get; set; }
        [Required(ErrorMessage = Messages.BillDateRequired)]
        public string? BillDate { get; set; }
        public string? PaymentTerms { get; set; }
        public string? DueDate { get; set; }
        public List<ItemsPurchaseDto>? ItemsData { get; set; }
        public decimal TotalBasicAmount { get; set; }
        public int TotalGST { get; set; }
        public int TotalIGST { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
