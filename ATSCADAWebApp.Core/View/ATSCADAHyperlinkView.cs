using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Dieu huong toi 1 page khac sau khoang thoi gian delay cai dat
    /// </summary>
    [DisplayName("HyperlinkView")]
    [Serializable()]
    [XmlType(TypeName = "atscada-hyperlink-view")]
    public class ATSCADAHyperlinkView : ComponentBase, IATSCADAView
    {
        #region FIELDS

        private string content = "Home";

        private string location = "home";

        private string icon = "home";

        private string roles = "Admin, Operator";

        private string link = "http://atscada.com";

        private decimal delay = 3;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Ten hien thi tren giao dien cua Page
        /// </summary>
        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        /// <summary>
        /// Dia chi Url cua page:
        /// Ex: locahost:9000/atscada#location
        /// Tinh chuoi ky sau # (hash) trong Url
        /// </summary>
        [XmlAttribute("at-location")]
        public string Location
        {
            get => this.location;
            set => SetField(ref this.location, value);
        }

        /// <summary>
        /// Icon hien thi tren Menu
        /// </summary>
        [XmlAttribute("at-icon")]
        public string Icon
        {
            get => this.icon;
            set => SetField(ref this.icon, value);
        }

        /// <summary>
        /// Quy dinh cac quyen cho phep truy cap
        /// Neu quyen k hop le, se an page khi dang nhap
        /// </summary>
        [XmlAttribute("at-roles")]
        public string Roles
        {
            get => this.roles;
            set => SetField(ref this.roles, value);
        }

        /// <summary>
        /// Link muon dieu huong (redirect)
        /// </summary>
        [XmlAttribute("at-link")]
        public string Link
        {
            get => this.link;
            set => SetField(ref this.link, value);
        }

        /// <summary>
        /// Thoi gian delay chuyen tiep trang
        /// </summary>
        [XmlAttribute("at-delay")]
        public decimal Delay
        {
            get => this.delay;
            set => SetField(ref this.delay, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAHyperlinkView()
           : base()
        {
            Name = "NewHyperlinkView";
            Level = ComponentLevel.View;
        }

        public ATSCADAHyperlinkView(IComposite parent)
           : base(parent)
        {
            Name = "NewHyperlinkView";
            Level = ComponentLevel.View;
            parent.Add(this);
        }

        public ATSCADAHyperlinkView(string name, IComposite parent)
            : base(name, parent)
        {
            Level = ComponentLevel.View;
            parent.Add(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nhat thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAHyperlinkViewEditor(this).ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-redirect
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<atscada-redirect ");
            builder.Append($"at-link=\"{Link}\" ");           
            builder.Append($"at-delay=\"{Delay}\" >");                  
            builder.AppendLine($"</atscada-redirect>");

            return builder.ToString();
        }

        #endregion
    }
}
