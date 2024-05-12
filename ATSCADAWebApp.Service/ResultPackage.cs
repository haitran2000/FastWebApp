using System.Runtime.Serialization;

namespace ATSCADAWebApp.Service
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResultPackage", Namespace = "http://schemas.datacontract.org/2004/07/ATSCADA.WebService")]
    [System.SerializableAttribute()]
    public class ResultPackage
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string TimeStamp { get; set; }

    }

    public static class ResultPackageExtensionMethods
    {
        /// <summary>
        /// Phương thức giải mã gói tin
        /// </summary>
        /// <param name="resultPackage"></param>
        /// <returns></returns>
        public static ResultPackage Decrypt(this ResultPackage resultPackage)
        {
            return new ResultPackage()
            {
                Name = resultPackage.Name.DecryptAddress(),
                Value = resultPackage.Value.DecryptValue(),
                Status = resultPackage.Status,
                TimeStamp = resultPackage.TimeStamp
            };
        }

        /// <summary>
        /// Phương thức giải mã danh sách gói tin
        /// </summary>
        /// <param name="resultPackages"></param>
        /// <returns></returns>
        public static ResultPackage[] Decrypt(this ResultPackage[] resultPackages)
        {
            var packageDecrypt = new ResultPackage[resultPackages.Length];
            for (var i = 0; i < resultPackages.Length; i++)
            {
                packageDecrypt[i] = resultPackages[i].Decrypt();
            }
            return packageDecrypt;
        }
    }
}
