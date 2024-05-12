using System.Runtime.Serialization;

namespace ATSCADAWebApp.Service
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "WriteParam", Namespace = "http://schemas.datacontract.org/2004/07/ATSCADA.WebService")]
    [System.SerializableAttribute()]
    public class WriteParam
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }

    public static class WriteParamExtensiionMethods
    {
        /// <summary>
        /// Phương thức mã hóa gói tin
        /// </summary>
        /// <param name="writeParam"></param>
        /// <returns></returns>
        public static WriteParam Encrypt(this WriteParam writeParam)
        {
            return new WriteParam()
            {
                Name = writeParam.Name.EncryptAddress(),
                Value = writeParam.Value.EncryptValue()
            };
        }
        /// <summary>
        /// Phương thức mã hóa danh sách gói tin
        /// </summary>
        /// <param name="writeParams"></param>
        /// <returns></returns>
        public static WriteParam[] Encrypt(this WriteParam[] writeParams)
        {
            var paramEncrypt = new WriteParam[writeParams.Length];
            for (var i = 0; i < writeParams.Length; i++)
            {
                paramEncrypt[i] = writeParams[i].Encrypt();
            }
            return paramEncrypt;
        }
    }
}
