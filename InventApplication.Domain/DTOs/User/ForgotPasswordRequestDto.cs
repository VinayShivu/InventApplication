using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;

namespace InventApplication.Domain.DTOs.User
{
    public class ForgotPasswordRequestDto
    {
        [ValidateEmail(ErrorMessage = Messages.InvalidEmail)]
        public string Email { get; set; }
    }
}
