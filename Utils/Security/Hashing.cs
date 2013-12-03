using System.Security.Cryptography;
using System.Text;

namespace Utils.Security
{
    public class Hashing
    {
        public string SHA512(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] hash;
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);
            }

            return Encoding.UTF8.GetString(hash);
        }

        public string SHA256(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] hash;
            using (SHA256 shaM = new SHA256Managed())
            {
                hash = shaM.ComputeHash(data);
            }

            return Encoding.UTF8.GetString(hash);
        }
    }
}
