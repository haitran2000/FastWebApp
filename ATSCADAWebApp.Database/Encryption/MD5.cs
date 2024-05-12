using System.Security.Cryptography;
using System.Text;

namespace ATSCADAWebApp.Database.Encryption
{
    /// <summary>
    /// Ham ma hoa MD5 phuc vu cho ma hoa tai khoan dang nhap
    /// </summary>
    public static class MD5Extensions
    {
        public static string ToMD5(this string input)
        {            
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
               
                var stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
