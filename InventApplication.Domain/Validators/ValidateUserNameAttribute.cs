using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace InventApplication.Domain.Validators
{
    public class ValidateUserNameAttribute : ValidationAttribute
    {
        public static string AllowUserName { get; set; }
        public override bool IsValid(object value)
        {

            string userName = value as string;
            if (!string.IsNullOrEmpty(userName))
            {
                return IsValidUserName(userName);
            }
            return true;
        }
        public static bool IsValidUserName(string userName)
        {
            Regex UserNameAllowedCharacters = new("[^a-zA-Z0-9-._@+#,*!$'~`^%&\u00FC\u00E9\u00E2\u00E4\u00E0\u00E5\u00E7\u00EA\u00EB\u00E8\u00EF\u00EE\u00EC\u00C4\u017D\u00F4\u201C\u00F6\u201D\u00F2\u00FB\u2013\u00F9\u00FF\u00D6\u00E1\u00ED\u00F3\u00FA\u00E0\u00DF\u00E1\u00E2\u00E3\u00E4\u03C3\u00E5\u00E7\u00E8\u00E9\u00EA\u00EB\u00EC\u00ED\u00EE\u00EF\u00F0\u00F1\u00F2\u00F3\u00F4\u00F5\u00F6\u00F8\u00F9\u00FA\u00FB\u00FC\u00FD\u00FF\u2018\u2019\u201C\u201D\u0027\u0028\u0029\u00C5\u00C9\u00DC\u00D1\u00F1\\s-]");
            var result = !UserNameAllowedCharacters.IsMatch(userName);
            if (result)
            {
                return true;
            }
            return false;
        }
    }
}
