using InventApplication.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.DTOs.User
{
    public class RefreshTokenRequest
    {
        [Required(ErrorMessage = Messages.AccessTokenRequired)]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = Messages.RefreshTokenRequired)]
        public string RefreshToken { get; set; }
    }
}
