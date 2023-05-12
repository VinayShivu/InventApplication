using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs
{
    public class VendorDto
    {
        [Required(ErrorMessage = Messages.CompanyNameRequired)]
        [RegularExpression(@".{4,360}", ErrorMessage = Messages.Min4Max360)]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = Messages.VendorGSTRequired)]
        public string? VendorGST { get; set; }
        [ValidateEmailAttribute(ErrorMessage = Messages.InvalidEmail)]
        public string? Email { get; set; }
        [Required(ErrorMessage = Messages.VendorPhoneRequired)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[1-9][0-9]{9}$", ErrorMessage = Messages.InvalidPhoneNumber)]
        public string? Phone { get; set; }
        [Required(ErrorMessage = Messages.VendorAddressRequired)]
        public string? Address { get; set; }
        [Required(ErrorMessage = Messages.VendorPrimaryContactNameRequired)]
        public string? PrimaryContactName { get; set; }
        public string? ContactPersons { get; set; } = string.Empty;
    }
}
