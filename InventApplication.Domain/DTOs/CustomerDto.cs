using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs
{
    public class CustomerDto
    {
        [Required(ErrorMessage = Messages.CompanyNameRequired)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = Messages.CustomerGSTRequired)]
        public string CustomerGST { get; set; }
        [ValidateEmailAttribute(ErrorMessage = Messages.InvalidEmail)]
        public string Email { get; set; }
        [Required(ErrorMessage = Messages.CustomerPhoneRequired)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[1-9][0-9]{9}$", ErrorMessage = Messages.InvalidPhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = Messages.CustomerAddressRequired)]
        public string Address { get; set; }
        [Required(ErrorMessage = Messages.CustomerPrimaryContactNameRequired)]
        public string PrimaryContactName { get; set; }
        public string ContactPersons { get; set; }
    }
}
