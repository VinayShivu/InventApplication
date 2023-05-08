using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenCreated { get; set; }
        public DateTime RefreshTokenExpires { get; set; }


    }
}
