namespace InventApplication.Domain.DTOs.Vendor
{
    public record VendorResponseDto
    {
        public int VendorId { get; set; }
        public string? CompanyName { get; set; }
        public string? VendorGST { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public virtual Address? Address { get; set; }
        public string? PrimaryContactName { get; set; }
        public virtual List<ContactPersons>? ContactPersons { get; set; }
        public decimal Payables { get; set; }
        public string? Remarks { get; set; }
    }
}
