using System.Security.Cryptography;
using System.Text;

namespace IdentityServer.Application.Security
{
    public class PasswordHasher
    {
        private string _hash;
        private string _salt;
        public string Hash { get { return _hash; } }
        public string Salt { get { return _salt; } }
        public PasswordHasher(string password) : this(password, MakeSalt()) { }
        public PasswordHasher(string password, string salt)
        {
            _salt = salt;
            _hash = HashPassword(password, salt);
        }
        private string HashPassword(string password, string salt)
        {
            Encoding encoding = Encoding.UTF8;
            string saltAndPassword = string.Concat(salt, password);
            byte[] passwordBytes = encoding.GetBytes(saltAndPassword);
            using (HashAlgorithm hashAlgorithm = SHA256.Create())
            {
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(passwordBytes));
            }
        }
        private static string MakeSalt()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
