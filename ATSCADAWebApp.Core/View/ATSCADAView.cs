using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Giao dien SCADA. Tuong duong 1 page
    /// Chua san connection ket noi du lieu qua Tag
    /// </summary>
    [DisplayName("View")]
    [Serializable()]
    [XmlType(TypeName = "atscada-view")]
    public class ATSCADAView : CompositeBase, IATSCADAView
    {
        #region CONST

        private const string EmptyContent = "&nbsp;";

        #endregion

        #region FIELDS

        private string content = "Home";

        private string location = "home";

        private string icon = "home";
        
        private string roles = "Admin, Operator";
        
        private decimal interval = 1000;

        private decimal maxNumberOfWrite = 10;

        private decimal timeout = 3000;
        
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
        /// Chu ky (quet) cap nhat du lieu tren trang
        /// </summary>
        [XmlAttribute("at-interval")]
        public decimal Interval
        {
            get => this.interval;
            set => SetField(ref this.interval, value);
        }

        /// <summary>
        /// So lan ghi Tag toi da (khi ghi that bai)
        /// </summary>
        [XmlAttribute("at-max-number-of-write")]
        public decimal MaxNumberOfWrite
        {
            get => this.maxNumberOfWrite;
            set => SetField(ref this.maxNumberOfWrite, value);
        }

        /// <summary>
        /// Thoi gian timeout khi read/write tag
        /// </summary>
        [XmlAttribute("at-timeout")]
        public decimal Timeout
        {
            get => this.timeout;
            set => SetField(ref this.timeout, value);
        }        

        #endregion

        #region CONSTRUCTORS

        public ATSCADAView()
           : base()
        {
            Name = "NewView";
            Level = ComponentLevel.View;
        }

        public ATSCADAView(IComposite parent)
           : base(parent)
        {
            Name = "NewView";
            Level = ComponentLevel.View;
            parent.Add(this);
        }

        public ATSCADAView(string name, IComposite parent)
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
            return new ATSCADAViewEditor(this).ShowDialog() == DialogResult.OK;
        }        

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-task
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            if (Count == 0) return EmptyContent;

            var builder = new StringBuilder();

            builder.Append($"<atscada-task ");
            builder.Append($"at-interval=\"{Interval}\" ");
            builder.Append($"at-max-number-of-write=\"{MaxNumberOfWrite}\" ");
            builder.Append($"at-timeout=\"{Timeout}\" >");
            foreach (var component in Components)
                if (component is ISupportRender componentRender)
                    builder.Append(componentRender.Render());
            builder.AppendLine($"</atscada-task>");

            return builder.ToString();
        }

        #endregion
    }    
}
