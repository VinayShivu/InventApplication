using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs.User
{
    public class UserDto
    {
        [Required(ErrorMessage = Messages.CompanyNameRequired)]
        public string Username { get; set; }

        [RegularExpression(@".{2,32}", ErrorMessage = Messages.Min2Max32)]
        [Required(ErrorMessage = Messages.PasswordRequired)]
        public string Password { get; set; }

        [ValidateEmail(ErrorMessage = Messages.InvalidEmail)]
        public string Email { get; set; }
        public string Roles { get; set; }
    }
}
