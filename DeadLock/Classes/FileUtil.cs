using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DeadLock.Classes
{
    internal static class FileUtil
    {
        // ReSharper disable once InconsistentNaming
        internal static string GetSHA256FromFile(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                using (SHA256 sha = new SHA256Managed())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (byte t in sha.ComputeHash(fs))
                    {
                        sb.Append(t.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }
    }
}