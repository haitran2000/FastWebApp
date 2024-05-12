﻿
namespace ATSCADAWebApp.Component.Input
{
    partial class ATSCADAInputEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAInputEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.cbxDataTagName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblGridColumn = new System.Windows.Forms.Label();
            this.lblDataTagName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.tabElement.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 172);
            this.tabElement.TabIndex = 10;
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
            this.pageBase.Size = new System.Drawing.Size(384, 146);
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
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.cbxDataTagName);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblGridColumn);
            this.pageExtend.Controls.Add(this.lblDataTagName);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 146);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
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
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(91, 67);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(277, 20);
            this.txtGridColumn.TabIndex = 5;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(91, 14);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(277, 20);
            this.txtContent.TabIndex = 3;
            // 
            // lblGridColumn
            // 
            this.lblGridColumn.AutoSize = true;
            this.lblGridColumn.Location = new System.Drawing.Point(17, 70);
            this.lblGridColumn.Name = "lblGridColumn";
            this.lblGridColumn.Size = new System.Drawing.Size(66, 13);
            this.lblGridColumn.TabIndex = 5;
            this.lblGridColumn.Text = "Grid column:";
            // 
            // lblDataTagName
            // 
            this.lblDataTagName.AutoSize = true;
            this.lblDataTagName.Location = new System.Drawing.Point(17, 43);
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
            // ATSCADAInputEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 218);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAInputEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Editor";
            this.tabElement.ResumeLayout(false);
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabPage pageExtend;
        private ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagName;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblGridColumn;
        private System.Windows.Forms.Label lblDataTagName;
        private System.Windows.Forms.Label lblContent;
    }
}