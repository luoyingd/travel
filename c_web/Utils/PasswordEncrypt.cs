using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace c_web.Utils
{
    public class PasswordEncrypt
    {
        public static string Encrypt(string password, IConfiguration configuration, string salt)
        {
            Dictionary<string, string> map = new();
            string plus = configuration.GetSection("AppSettings:hash_key").Value + salt;
            byte[] pwdBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(plus),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10,
                numBytesRequested: 256 / 8);
            return Convert.ToBase64String(pwdBytes);
        }
    }
}