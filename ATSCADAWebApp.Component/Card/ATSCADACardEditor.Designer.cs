
namespace ATSCADAWebApp.Component.Card
{
    partial class ATSCADACardEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADACardEditor));
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.lblGridColumn = new System.Windows.Forms.Label();
            this.nudDecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblDecimalPlaces = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblDataTagName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabElement.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 215);
            this.tabElement.TabIndex = 0;
            // 
            // pageBase
            // 
            this.pageBase.Controls.Add(this.txtDescription);
            this.pageBase.Controls.Add(this.lblDescription);
            this.pageBase.Controls.Add(this.txtName);
            this.pageBase.Controls.Add(this.lblName);
            this.pageBase.Location = new System.Drawing.Point(4, 26);
            this.pageBase.Name = "pageBase";
            this.pageBase.Padding = new System.Windows.Forms.Padding(3);
            this.pageBase.Size = new System.Drawing.Size(384, 185);
            this.pageBase.TabIndex = 0;
            this.pageBase.Text = "Base";
            this.pageBase.UseVisualStyleBackColor = true;
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
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.lblGridColumn);
            this.pageExtend.Controls.Add(this.nudDecimalPlaces);
            this.pageExtend.Controls.Add(this.txtIcon);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblDecimalPlaces);
            this.pageExtend.Controls.Add(this.lblIcon);
            this.pageExtend.Controls.Add(this.lblColor);
            this.pageExtend.Controls.Add(this.lblDataTagName);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 26);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 185);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(91, 151);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(277, 23);
            this.txtGridColumn.TabIndex = 8;
            // 
            // lblGridColumn
            // 
            this.lblGridColumn.AutoSize = true;
            this.lblGridColumn.Location = new System.Drawing.Point(17, 154);
            this.lblGridColumn.Name = "lblGridColumn";
            this.lblGridColumn.Size = new System.Drawing.Size(88, 17);
            this.lblGridColumn.TabIndex = 13;
            this.lblGridColumn.Text = "Grid column:";
            // 
            // nudDecimalPlaces
            // 
            this.nudDecimalPlaces.Location = new System.Drawing.Point(91, 123);
            this.nudDecimalPlaces.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDecimalPlaces.Name = "nudDecimalPlaces";
            this.nudDecimalPlaces.Size = new System.Drawing.Size(277, 23);
            this.nudDecimalPlaces.TabIndex = 7;
            // 
            // txtIcon
            // 
            this.txtIcon.Location = new System.Drawing.Point(91, 95);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(277, 23);
            this.txtIcon.TabIndex = 6;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(91, 14);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(277, 23);
            this.txtContent.TabIndex = 3;
            // 
            // lblDecimalPlaces
            // 
            this.lblDecimalPlaces.AutoSize = true;
            this.lblDecimalPlaces.Location = new System.Drawing.Point(17, 124);
            this.lblDecimalPlaces.Name = "lblDecimalPlaces";
            this.lblDecimalPlaces.Size = new System.Drawing.Size(86, 17);
            this.lblDecimalPlaces.TabIndex = 7;
            this.lblDecimalPlaces.Text = "Dec. places:";
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(17, 96);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(38, 17);
            this.lblIcon.TabIndex = 6;
            this.lblIcon.Text = "Icon:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(17, 71);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(45, 17);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Color:";
            // 
            // lblDataTagName
            // 
            this.lblDataTagName.AutoSize = true;
            this.lblDataTagName.Location = new System.Drawing.Point(17, 44);
            this.lblDataTagName.Name = "lblDataTagName";
            this.lblDataTagName.Size = new System.Drawing.Size(76, 17);
            this.lblDataTagName.TabIndex = 4;
            this.lblDataTagName.Text = "Tag name:";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(17, 17);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(61, 17);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "Content:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ATSCADACardEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 259);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADACardEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Card Editor";
            this.tabElement.ResumeLayout(false);
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimalPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.TabPage pageExtend;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDataTagName;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblDecimalPlaces;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.NumericUpDown nudDecimalPlaces;
        private ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagName;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.Label lblGridColumn;
        private Extension.Color.TextBoxColor txtColor;
    }
}