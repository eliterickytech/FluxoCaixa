using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Rickytech.Utils
{
    public class Utils
    {
        public static string Base64(string file)
        {
            byte[] AsBytes = File.ReadAllBytes(file);
            return Convert.ToBase64String(AsBytes);
        }

        public static string GetMD5(string file)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(file))
                {
                    var hashBytes = md5.ComputeHash(stream);
                    var sb = new StringBuilder();
                    foreach (var t in hashBytes)
                    {
                        sb.Append(t.ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
        }

        public static string GetSHA256(string file)
        {
            using (var stream = File.OpenRead(file))
            {
                var sha = new SHA256Managed();
                var checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", string.Empty);
            }
        }

        public static string GetSHA1(string file)
        {
            using (var stream = File.OpenRead(file))
            {
                var sha = new SHA1Managed();
                var checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", string.Empty);
            }
        }

        public static string GetBoundary()
        {
            return String.Format("----------{0:N}", Guid.NewGuid());
        }
    }
}
