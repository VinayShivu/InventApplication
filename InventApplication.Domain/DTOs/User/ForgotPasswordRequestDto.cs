using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;

namespace InventApplication.Domain.DTOs.User
{
    public record ForgotPasswordRequestDto
    {
        [ValidateEmail(ErrorMessage = Messages.InvalidEmail)]
        public string? Email { get; set; }
    }
}
