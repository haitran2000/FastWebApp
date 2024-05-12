using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Cac cot trong 1 hang Row. Phan chia cot theo Bootstrap Grid
    /// </summary>
    [DisplayName("Column")]
    [Serializable()]
    [XmlType(TypeName = "atscada-column")]
    public class ATSCADAColumn : CompositeBase, IATSCADAColumn, ISupportGrid
    {
        #region CONST

        private const string EmptyContent = "&nbsp;";

        #endregion

        #region FIELDS

        private string gridColumn = "col-sm-12";

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Grid column bootstrap. Quy dinh 1 hanng gom 12. 
        /// </summary>
        [XmlAttribute("at-grid-column")]
        public string GridColumn
        {
            get => this.gridColumn;
            set => SetField(ref this.gridColumn, value);
        }
        
        #endregion

        #region CONSTRUCTORS

        public ATSCADAColumn()
             : base()
        {
            Name = "NewColumn";
            Level = ComponentLevel.Column;
        }

        public ATSCADAColumn(IComposite parent)
             : base(parent)
        {
            Name = "NewColumn";
            Level = ComponentLevel.Column;
            parent.Add(this);
        }

        public ATSCADAColumn(string name, IComposite parent)
            : base(name, parent)
        {
            Level = ComponentLevel.Column;
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
            return new ATSCADAColumnEditor(this).ShowDialog() == DialogResult.OK;          
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// class="col-xx"
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            if (Count == 0) return EmptyContent;

            var builder = new StringBuilder();

            builder.AppendLine($"<div class=\"{GridColumn}\">");
            builder.AppendLine($"<div class=\"row\">");
            foreach (var component in Components)
                if (component is ISupportRender componentRender)
                    builder.Append(componentRender.Render());
            builder.AppendLine($"</div>");
            builder.AppendLine($"</div>");

            return builder.ToString();
        }

        #endregion
    }
}
