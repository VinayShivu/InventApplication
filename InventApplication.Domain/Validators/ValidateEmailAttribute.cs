using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Validators
{
    public class ValidateEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;
            if (!string.IsNullOrEmpty(email))
            {
                return IsValidEmail(email);
            }
            return true;
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                _ = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
