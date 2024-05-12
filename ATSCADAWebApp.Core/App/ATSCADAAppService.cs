using System;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Connection ket noi den iWebService tren Winforms
    /// </summary>
    [Serializable()]
    [XmlType(TypeName = "atscada-app-service")]
    public class ATSCADAAppService : BindableCore
    {
        #region FIELDS

        private string address = "localhost";

        private string port = "8010";        

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Dia chi IP chay Win
        /// </summary>
        [XmlAttribute("at-address")]
        public string Address
        {
            get => this.address;
            set => SetField(ref this.address, value);
        }

        /// <summary>
        /// Port web Service
        /// </summary>
        [XmlAttribute("at-port")]
        public string Port
        {
            get => this.port;
            set => SetField(ref this.port, value);
        }
        
        #endregion

        #region CONSTRUCTOR

        public ATSCADAAppService()
        {
        }

        #endregion
    }
}
