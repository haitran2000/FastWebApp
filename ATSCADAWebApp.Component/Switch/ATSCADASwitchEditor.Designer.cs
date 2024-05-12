
namespace ATSCADAWebApp.Component.Switch
{
    partial class ATSCADASwitchEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADASwitchEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtValueOff = new System.Windows.Forms.TextBox();
            this.lblValueOff = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.txtColor = new ATSCADAWebApp.Extension.Color.TextBoxColor();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.lblGridColumn = new System.Windows.Forms.Label();
            this.txtValueOn = new System.Windows.Forms.TextBox();
            this.cbxDataTagName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblValueOn = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblDataTagName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.cbxSize = new System.Windows.Forms.ComboBox();
            this.pageExtend.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.tabElement.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtValueOff
            // 
            this.txtValueOff.Location = new System.Drawing.Point(91, 151);
            this.txtValueOff.Name = "txtValueOff";
            this.txtValueOff.Size = new System.Drawing.Size(277, 20);
            this.txtValueOff.TabIndex = 8;
            // 
            // lblValueOff
            // 
            this.lblValueOff.AutoSize = true;
            this.lblValueOff.Location = new System.Drawing.Point(17, 154);
            this.lblValueOff.Name = "lblValueOff";
            this.lblValueOff.Size = new System.Drawing.Size(60, 13);
            this.lblValueOff.TabIndex = 13;
            this.lblValueOff.Text = "Value OFF:";
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.cbxSize);
            this.pageExtend.Controls.Add(this.txtColor);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.lblGridColumn);
            this.pageExtend.Controls.Add(this.txtValueOn);
            this.pageExtend.Controls.Add(this.txtValueOff);
            this.pageExtend.Controls.Add(this.lblValueOff);
            this.pageExtend.Controls.Add(this.cbxDataTagName);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblValueOn);
            this.pageExtend.Controls.Add(this.lblSize);
            this.pageExtend.Controls.Add(this.lblColor);
            this.pageExtend.Controls.Add(this.lblDataTagName);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 217);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // txtColor
            // 
            this.txtColor.Color = "#008080";
            this.txtColor.Location = new System.Drawing.Point(91, 67);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(277, 20);
            this.txtColor.TabIndex = 18;
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(91, 180);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(277, 20);
            this.txtGridColumn.TabIndex = 9;
            // 
            // lblGridColumn
            // 
            this.lblGridColumn.AutoSize = true;
            this.lblGridColumn.Location = new System.Drawing.Point(17, 183);
            this.lblGridColumn.Name = "lblGridColumn";
            this.lblGridColumn.Size = new System.Drawing.Size(66, 13);
            this.lblGridColumn.TabIndex = 17;
            this.lblGridColumn.Text = "Grid column:";
            // 
            // txtValueOn
            // 
            this.txtValueOn.Location = new System.Drawing.Point(91, 121);
            this.txtValueOn.Name = "txtValueOn";
            this.txtValueOn.Size = new System.Drawing.Size(277, 20);
            this.txtValueOn.TabIndex = 7;
            // 
            // cbxDataTagName
            // 
            this.cbxDataTagName.InRuntime = false;
            this.cbxDataTagName.Location = new System.Drawing.Point(91, 40);
            this.cbxDataTagName.Name = "cbxDataTagName";
            this.cbxDataTagName.Size = new System.Drawing.Size(277, 21);
            this.cbxDataTagName.TabIndex = 4;
            this.cbxDataTagName.TagName = "";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(91, 14);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(277, 20);
            this.txtContent.TabIndex = 3;
            // 
            // lblValueOn
            // 
            this.lblValueOn.AutoSize = true;
            this.lblValueOn.Location = new System.Drawing.Point(17, 124);
            this.lblValueOn.Name = "lblValueOn";
            this.lblValueOn.Size = new System.Drawing.Size(56, 13);
            this.lblValueOn.TabIndex = 7;
            this.lblValueOn.Text = "Value ON:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(17, 96);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 6;
            this.lblSize.Text = "Size:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(17, 69);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Color:";
            // 
            // lblDataTagName
            // 
            this.lblDataTagName.AutoSize = true;
            this.lblDataTagName.Location = new System.Drawing.Point(17, 45);
            this.lblDataTagName.Name = "lblDataTagName";
            this.lblDataTagName.Size = new System.Drawing.Size(58, 13);
            this.lblDataTagName.TabIndex = 4;
            this.lblDataTagName.Text = "Tag name:";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(17, 17);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(47, 13);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "Content:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(91, 42);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 87);
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(17, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 20);
            this.txtName.TabIndex = 1;
            // 
            // pageBase
            // 
            this.pageBase.Controls.Add(this.txtDescription);
            this.pageBase.Controls.Add(this.lblDescription);
            this.pageBase.Controls.Add(this.txtName);
            this.pageBase.Controls.Add(this.lblName);
            this.pageBase.Location = new System.Drawing.Point(4, 22);
            this.pageBase.Name = "pageBase";
            this.pageBase.Padding = new System.Windows.Forms.Padding(3);
            this.pageBase.Size = new System.Drawing.Size(384, 217);
            this.pageBase.TabIndex = 0;
            this.pageBase.Text = "Base";
            this.pageBase.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 243);
            this.tabElement.TabIndex = 10;
            // 
            // cbxSize
            // 
            this.cbxSize.FormattingEnabled = true;
            this.cbxSize.Items.AddRange(new object[] {
            "default",
            "small",
            "large"});
            this.cbxSize.Location = new System.Drawing.Point(91, 93);
            this.cbxSize.Name = "cbxSize";
            this.cbxSize.Size = new System.Drawing.Size(277, 21);
            this.cbxSize.TabIndex = 19;
            // 
            // ATSCADASwitchEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 286);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADASwitchEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Switch Editor";
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.tabElement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtValueOff;
        private System.Windows.Forms.Label lblValueOff;
        private System.Windows.Forms.TabPage pageExtend;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagName;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblValueOn;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblDataTagName;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TextBox txtValueOn;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.Label lblGridColumn;
        private Extension.Color.TextBoxColor txtColor;
        private System.Windows.Forms.ComboBox cbxSize;
    }
}