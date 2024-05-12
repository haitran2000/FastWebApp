using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ATSCADAWebApp.Service
{
    public class CertificateEngine
    {        
        private const string CertificateName = @"AppCertificate/ATSCADAClient.pfx";

        private const string Password = "ATSCADA";

        public X509Certificate2 GetCertificate(string serverPath)
        {
            var certificatePath = Path.Combine(serverPath, CertificateName);
            if (File.Exists(certificatePath))
            {
                return new X509Certificate2(certificatePath, Password,
                               X509KeyStorageFlags.MachineKeySet
                             | X509KeyStorageFlags.PersistKeySet
                             | X509KeyStorageFlags.Exportable);
            }

            return null;
        }
    }
}
