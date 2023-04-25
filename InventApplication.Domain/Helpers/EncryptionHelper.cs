using System.Security.Cryptography;

namespace InventApplication.Domain.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly byte[] Key;

        static EncryptionHelper()
        {
            Key = GenerateKey();
        }

        private static byte[] GenerateKey()
        {
            byte[] key = new byte[32];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        // Other methods and properties here
    }
}
