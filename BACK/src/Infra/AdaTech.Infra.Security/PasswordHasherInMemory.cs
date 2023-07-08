using System.Security.Cryptography;
using System.Text;

namespace AdaTech.Infra.Security
{
    public class PasswordHasherInMemory
    {
        public static byte[]? SaltInMemory { get; private set; } = GenerateSalt();
        
        public static string HashPassword(string username, string password)
        {
            SaltInMemory ??= GenerateSalt();
            var hash = HashPassword(username, password, SaltInMemory);

            return hash;
        }

        public bool VerifyPassword(string username, string password, string hash)
        {
            string computedHash = HashPassword(username, password, SaltInMemory!);
            return computedHash == hash;
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static string HashPassword(string username, string password, byte[] salt)
        {
            byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] combinedBytes = new byte[usernameBytes.Length + passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(usernameBytes, 0, combinedBytes, 0, usernameBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, usernameBytes.Length, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combinedBytes, usernameBytes.Length + passwordBytes.Length, salt.Length);

            using (var pbkdf2 = new Rfc2898DeriveBytes(combinedBytes, salt, 10000))
            {
                byte[] hashBytes = pbkdf2.GetBytes(20);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
