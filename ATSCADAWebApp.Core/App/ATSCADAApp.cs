using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// App Component
    /// La doi tuong cao nhat trong FastWeb
    /// La 1 project, 1 trang web
    /// </summary>
    [DisplayName("App")]
    [Serializable()]
    [XmlRoot("atscada-app")]
    public class ATSCADAApp : CompositeBase, IATSCADApp
    {
        #region FIELDS
        
        private string title = "ATSCADA";

        private string brand = "ATSCADA";

        private string author = "ATSCADA LAB";
        
        private bool darkMode = true;

        private ATSCADAAppAuthentication authentication = new ATSCADAAppAuthentication();

        private ATSCADAAppService service = new ATSCADAAppService();

        #endregion

        #region PROPERTIES      
        /// <summary>
        /// Title cua toan bo trang web
        /// </summary>
        [XmlAttribute("at-title")]
        public string Title
        {
            get => this.title;
            set => SetField(ref this.title, value);
        }

        /// <summary>
        /// Brand. Ten du an hien thi
        /// </summary>
        [XmlAttribute("at-brand")]
        public string Brand
        {
            get => this.brand;
            set => SetField(ref this.brand, value);
        }

        /// <summary>
        /// Tac gia. Ten cong ty
        /// </summary>
        [XmlAttribute("at-author")]
        public string Author
        {
            get => this.author;
            set => SetField(ref this.author, value);
        }

        /// <summary>
        /// Bat/tat che do DarkMode - hien thi giao dien toi
        /// </summary>
        [XmlAttribute("at-dark-mode")]
        public bool DarkMode
        {
            get => this.darkMode;
            set => SetField(ref this.darkMode, value);
        }

        /// <summary>
        /// Tinh nang phan quyen
        /// </summary>
        [XmlElement("at-authentication")]
        public ATSCADAAppAuthentication Authentication
        {
            get => this.authentication;
            set => SetField(ref this.authentication, value);
        }

        /// <summary>
        /// WebService. Connection ket noi du lieu toi Winforms
        /// </summary>
        [XmlElement("at-service")]
        public ATSCADAAppService Service
        {
            get => this.service;
            set => SetField(ref this.service, value);
        }
       
        #endregion

        #region CONSTRUCTORS

        public ATSCADAApp()
          : base()
        {
            Name = "NewApplication";
            Level = ComponentLevel.App;
            Description = "DIGITAL TRANSFORMATION";
        }

        public ATSCADAApp(string name)
            : base(name)
        {
            Name = "NewApplication";
            Level = ComponentLevel.App;
            Description = "DIGITAL TRANSFORMATION";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nhat thuoc tinh cho App
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAAppEditor(this).ShowDialog() == DialogResult.OK;           
        }

        #endregion
    }
}
