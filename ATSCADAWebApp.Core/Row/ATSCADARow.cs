using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Phan chia cac hang trong 1 page giao dien View
    /// Cau truc 1 page - View thanh 1 table, gom cac hang, cac cot
    /// </summary>
    [DisplayName("Row")]
    [Serializable()]
    [XmlType(TypeName = "atscada-row")]
    public class ATSCADARow : CompositeBase, IATSCADARow
    {
        #region CONST

        private const string EmptyContent = "&nbsp;";

        #endregion

        #region PROPERTIES      

        #endregion

        #region CONSTRUCTORS

        public ATSCADARow()
             : base() 
        {
            Name = "NewRow";
            Level = ComponentLevel.Row;
        }

        public ATSCADARow(IComposite parent)
             : base(parent)
        {
            Name = "NewRow";
            Level = ComponentLevel.Row;
            parent.Add(this);
        }

        public ATSCADARow(string name, IComposite parent)
            : base(name, parent)
        {
            Name = "NewRow";
            Level = ComponentLevel.Row;
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
            return new ATSCADARowEditor(this).ShowDialog() == DialogResult.OK; 
        }

        /// <summary>
        /// Render thanh CustomHTMLElement
        /// class="row" -> Bootstrap
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            if (Count == 0) return EmptyContent;

            var builder = new StringBuilder();

            builder.AppendLine($"<div class=\"row\">");
            foreach (var component in Components)
                if (component is ISupportRender componentRender)
                    builder.Append(componentRender.Render());
            builder.AppendLine($"</div>");

            return builder.ToString();
        }
        
        #endregion
    }
}
