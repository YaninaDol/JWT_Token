using System.Security.Cryptography;
using System.Text;

namespace JWT_Token.Controllers
{
    public class HashController
    {
        public string HashPassword(string password)
        {

            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }
    }
}
