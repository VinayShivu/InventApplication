using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs.Vendor
{
    public class VendorRequestDto
    {
        [Required(ErrorMessage = Messages.CompanyNameRequired)]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = Messages.VendorGSTRequired)]
        public string? VendorGST { get; set; }
        [ValidateEmail(ErrorMessage = Messages.InvalidEmail)]
        public string? Email { get; set; }
        [Required(ErrorMessage = Messages.VendorPhoneRequired)]
        [RegularExpression(@"^[1-9][0-9]{9}$", ErrorMessage = Messages.InvalidPhoneNumber)]
        public string? Phone { get; set; }
        [Required(ErrorMessage = Messages.VendorAddressRequired)]
        public virtual Address? Address { get; set; }
        [Required(ErrorMessage = Messages.VendorPrimaryContactNameRequired)]
        public string? PrimaryContactName { get; set; }
        public virtual List<ContactPersons>? ContactPersons { get; set; }
        public string? Remarks { get; set; }
    }

    public class Address
    {
        public string? Attention { get; set; }
        public string? Country { get; set; }
        public string? NewAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PINCode { get; set; }
    }

    public class ContactPersons
    {
        public string? Salutation { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [ValidateEmail(ErrorMessage = Messages.InvalidEmail)]
        public string? EmailAddress { get; set; }
        public string? WorkPhone { get; set; }
        [RegularExpression(@"^[1-9][0-9]{9}$", ErrorMessage = Messages.InvalidPhoneNumber)]
        public string? Mobile { get; set; }
    }
}
