using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.DTOs
{
    public class ResetPasswordRequestDto
    {
        [Required(ErrorMessage = Messages.AccessTokenRequired)]
        public string PasswordResetToken { get; set; } = string.Empty;

        [RegularExpression(@".{2,32}", ErrorMessage = Messages.Min2Max32)]
        [Required(ErrorMessage = Messages.PasswordRequired)]
        public string NewPassword { get; set; }
    }
}
