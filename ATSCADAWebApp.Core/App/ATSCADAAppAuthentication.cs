using System;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Tinh nang pha quyen cho app
    /// </summary>
    [Serializable()]
    [XmlType(TypeName = "atscada-app-authentication")]
    public class ATSCADAAppAuthentication : BindableCore
    {
        #region FIELDS

        private string connection = "atscada";

        private string tableName = "useraccount";

        private bool required = true;

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Chuoi ket noi toi DATABASE de kiem tra dang nhap, login
        /// Chuoi connection duoc cai dat trong file webConfig
        /// Gom: Server, Port, User, Pass, Database
        /// </summary>

        [XmlAttribute("at-connection")]
        public string Connection
        {
            get => this.connection;
            set => SetField(ref this.connection, value);
        }

        /// <summary>
        /// Ten cua table userAccount
        /// </summary>
        [XmlAttribute("at-table-name")]
        public string TableName
        {
            get => this.tableName;
            set => SetField(ref this.tableName, value);
        }

        /// <summary>
        /// Co yeu cau dang nhap hay khong
        /// Neu false: Vao thang truc tiep giao dien Home, khong can qua login
        /// </summary>
        [XmlAttribute("at-required")]
        public bool Required
        {
            get => this.required;
            set => SetField(ref this.required, value);
        }

        #endregion

        #region

        public ATSCADAAppAuthentication()
        {
        }

        #endregion

    }
}
