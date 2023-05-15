using InventApplication.Domain.Helpers;
using InventApplication.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.DTOs
{
    public class ForgotPasswordRequestDto
    {
        [ValidateEmailAttribute(ErrorMessage = Messages.InvalidEmail)]
        public string Email { get; set; }
    }
}
