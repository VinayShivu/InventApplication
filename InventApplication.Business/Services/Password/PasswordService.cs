using InventApplication.Domain.Interfaces.Password;
using Microsoft.IdentityModel.Tokens;

namespace InventApplication.Business.Services.Password
{
    public class PasswordService : IPasswordService
    {
        private const int SaltWorkFactor = 10;

        public string HashPassword(string password)
        {
            if (password.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(password));
            }
            var salt = BCrypt.Net.BCrypt.GenerateSalt(SaltWorkFactor);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (password.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (hashedPassword.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }
            var result = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return result;
        }
    }
}
