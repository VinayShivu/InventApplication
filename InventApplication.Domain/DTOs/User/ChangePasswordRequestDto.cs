using InventApplication.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs.User
{
    public record ChangePasswordRequestDto
    {
        [Required(ErrorMessage = Messages.UserIdRequired)]
        public int UserId { get; set; }
        [RegularExpression(@".{2,32}", ErrorMessage = Messages.Min2Max32)]
        [Required(ErrorMessage = Messages.CurrentPasswordRequired)]
        public string? CurrentPassword { get; set; }
        [RegularExpression(@".{2,32}", ErrorMessage = Messages.Min2Max32)]
        [Required(ErrorMessage = Messages.NewPasswordRequired)]
        public string? NewPassword { get; set; }
    }
}
