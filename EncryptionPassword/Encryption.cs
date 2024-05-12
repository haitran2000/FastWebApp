using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EncryptionPassword
{
    public partial class Encryption : Form
    {
        public Encryption()
        {
            InitializeComponent();
        }

        private string ToMD5(string input)
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

        private void btnEncrypt_Click(object sender, System.EventArgs e)
        {
            var password = txtPassword.Text.Trim();
            var encryptText = ToMD5(password);
            rtxtEncryptText.Clear();
            rtxtEncryptText.AppendText(encryptText);
        }
    }
}
