using InventApplication.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventApplication.Domain.Models
{
    public record PurchaseOrder
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.VendorIdRequired)]
        public int VendorID { get; set; }
        [JsonIgnore]
        public string? PurchaseOrderNumber { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? PaymentTerms { get; set; }
        public string? TermsandConditions { get; set; }
        public Boolean? IsReceived { get; set; }
        public int CreatedBy { get; set; }
        public List<POItemDetails>? ItemDetails { get; set; }
    }
    public record POItemDetails
    {
        public int ItemId { get; set; }
        public int PurchaseQty { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GSTTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
