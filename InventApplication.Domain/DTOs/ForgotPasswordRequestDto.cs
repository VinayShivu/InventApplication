using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;

namespace InventApplication.Domain.DTOs
{
    public class ForgotPasswordRequestDto
    {
        [ValidateEmailAttribute(ErrorMessage = Messages.InvalidEmail)]
        public string Email { get; set; }
    }
}
