using System.Net.Security;
using System.ServiceModel.Channels;

namespace ATSCADAWebApp.Service
{
    public class CustomNetTcpBinding : CustomBinding
    {
        public CustomNetTcpBinding() : base()
        {
        }

        // Phương thức override các binding
        public override BindingElementCollection CreateBindingElements()
        {
            return new BindingElementCollection
            {
                new BinaryMessageEncodingBindingElement { MessageVersion = MessageVersion.Soap12WSAddressing10 }, // Kieu ma hoa
                SecurityBindingElement.CreateUserNameOverTransportBindingElement(), // Important!!! Gán user/pass trên tầng Transport. Yêu cầu xác thực (UserName, Password) mỗi lần request
                new AutoSecuredTcpTransportElement()
            };
        }

        public override string Scheme { get { return "net.tcp"; } }
    }

    public class AutoSecuredTcpTransportElement : TcpTransportBindingElement, ITransportTokenAssertionProvider
    {
        public AutoSecuredTcpTransportElement()
        {
            MaxReceivedMessageSize = 2147483647;
            MaxBufferSize = 2147483647;
            MaxPendingConnections = 10000;
            ConnectionPoolSettings.MaxOutboundConnectionsPerEndpoint = 10000;
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(ISecurityCapabilities))
                return (T)(ISecurityCapabilities)new AutoSecuredTcpSecurityCapabilities();
            return base.GetProperty<T>(context);
        }

        public System.Xml.XmlElement GetTransportTokenAssertion()
        {
            return null;
        }
    }

    public class AutoSecuredTcpSecurityCapabilities : ISecurityCapabilities
    {
        public ProtectionLevel SupportedRequestProtectionLevel => ProtectionLevel.EncryptAndSign;

        public ProtectionLevel SupportedResponseProtectionLevel => ProtectionLevel.EncryptAndSign;

        public bool SupportsClientAuthentication => true;

        public bool SupportsClientWindowsIdentity => true;

        public bool SupportsServerAuthentication => true;

    }
}
