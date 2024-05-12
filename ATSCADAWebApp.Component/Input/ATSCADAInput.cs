using ATSCADAWebApp.Core;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ATSCADAWebApp.Component.Input
{
    /// <summary>
    /// input nhap, ghi du lieu xuong Tag
    /// </summary>
    [DisplayName("iInput")]
    [Serializable()]
    [XmlType(TypeName = "atscada-attribute")]
    public class ATSCADAInput : ComponentBase, ISupportGrid, ISupportRender
    {
        #region FILEDS

        private string content = "Name";

        private string dataTagName = "TaskName.TagName";                

        private string gridColumn = "col-sm-3";

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Tieu de hien thi
        /// </summary>
        [XmlAttribute("at-content")]
        public string Content
        {
            get => this.content;
            set => SetField(ref this.content, value);
        }

        /// <summary>
        /// TagName
        /// </summary>
        [XmlAttribute("at-data-tag-name")]
        public string DataTagName
        {
            get => this.dataTagName;
            set => SetField(ref this.dataTagName, value);
        }

        /// <summary>
        /// So cot hien thi trong Column. Theo bootsrap grid
        /// </summary>
        [XmlAttribute("at-grid-column")]
        public string GridColumn
        {
            get => this.gridColumn;
            set => SetField(ref this.gridColumn, value);
        }

        #endregion

        #region CONSTRUCTORS

        public ATSCADAInput()
            : base()
        {
            Name = "NewInput";
            Description = "Input - ATSCADA Web Component";
        }

        public ATSCADAInput(IComposite parent)
            : base(parent)
        {
            Name = "NewInput";
            Description = "Input - ATSCADA Web Component";
        }

        public ATSCADAInput(string name, IComposite parent)
            : base(name, parent)
        {
            Description = "Input - ATSCADA Web Component";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// UI cap nhat thuoc tinh
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return new ATSCADAInputEditor(this).ShowDialog() == DialogResult.OK;       
        }
        /// <summary>
        /// Render thanh CustomHTMLElement
        /// atscada-input
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            var builder = new StringBuilder();

            builder.Append($"<div class=\"{GridColumn}\"><atscada-input ");
            builder.Append($"at-content=\"{Content}\" ");
            builder.Append($"at-data-tag-name=\"{DataTagName}\" >");
            builder.AppendLine($"</atscada-input></div>");

            return builder.ToString();
        }

        #endregion
    }
}
