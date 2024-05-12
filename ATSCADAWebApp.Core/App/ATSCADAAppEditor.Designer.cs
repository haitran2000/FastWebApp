
namespace ATSCADAWebApp.Core
{
    partial class ATSCADAAppEditor
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.ckbDarkMode = new System.Windows.Forms.CheckBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pageAuthentication = new System.Windows.Forms.TabPage();
            this.ckbRequirement = new System.Windows.Forms.CheckBox();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.pageService = new System.Windows.Forms.TabPage();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tabElement.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            this.pageAuthentication.SuspendLayout();
            this.pageService.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 181);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Controls.Add(this.pageAuthentication);
            this.tabElement.Controls.Add(this.pageService);
            this.tabElement.Location = new System.Drawing.Point(6, 6);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 169);
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
            this.pageBase.Size = new System.Drawing.Size(384, 143);
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
            this.pageExtend.Controls.Add(this.ckbDarkMode);
            this.pageExtend.Controls.Add(this.txtBrand);
            this.pageExtend.Controls.Add(this.txtAuthor);
            this.pageExtend.Controls.Add(this.txtTitle);
            this.pageExtend.Controls.Add(this.lblAuthor);
            this.pageExtend.Controls.Add(this.lblBrand);
            this.pageExtend.Controls.Add(this.lblTitle);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 143);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // ckbDarkMode
            // 
            this.ckbDarkMode.AutoSize = true;
            this.ckbDarkMode.Location = new System.Drawing.Point(91, 98);
            this.ckbDarkMode.Name = "ckbDarkMode";
            this.ckbDarkMode.Size = new System.Drawing.Size(78, 17);
            this.ckbDarkMode.TabIndex = 6;
            this.ckbDarkMode.Text = "Dark mode";
            this.ckbDarkMode.UseVisualStyleBackColor = true;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(91, 41);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(277, 20);
            this.txtBrand.TabIndex = 4;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(91, 69);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(277, 20);
            this.txtAuthor.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(91, 14);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(277, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(17, 72);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 5;
            this.lblAuthor.Text = "Author:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(17, 44);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 4;
            this.lblBrand.Text = "Brand:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(17, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title:";
            // 
            // pageAuthentication
            // 
            this.pageAuthentication.Controls.Add(this.ckbRequirement);
            this.pageAuthentication.Controls.Add(this.txtConnection);
            this.pageAuthentication.Controls.Add(this.lblConnection);
            this.pageAuthentication.Controls.Add(this.txtTableName);
            this.pageAuthentication.Controls.Add(this.lblTableName);
            this.pageAuthentication.Location = new System.Drawing.Point(4, 22);
            this.pageAuthentication.Name = "pageAuthentication";
            this.pageAuthentication.Padding = new System.Windows.Forms.Padding(3);
            this.pageAuthentication.Size = new System.Drawing.Size(384, 143);
            this.pageAuthentication.TabIndex = 2;
            this.pageAuthentication.Text = "Authentication";
            this.pageAuthentication.UseVisualStyleBackColor = true;
            // 
            // ckbRequirement
            // 
            this.ckbRequirement.AutoSize = true;
            this.ckbRequirement.Location = new System.Drawing.Point(91, 75);
            this.ckbRequirement.Name = "ckbRequirement";
            this.ckbRequirement.Size = new System.Drawing.Size(93, 17);
            this.ckbRequirement.TabIndex = 22;
            this.ckbRequirement.Text = "Requires login";
            this.ckbRequirement.UseVisualStyleBackColor = true;
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(91, 14);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(277, 20);
            this.txtConnection.TabIndex = 6;
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(17, 17);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(64, 13);
            this.lblConnection.TabIndex = 19;
            this.lblConnection.Text = "Connection:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(91, 43);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(277, 20);
            this.txtTableName.TabIndex = 7;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(17, 46);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(66, 13);
            this.lblTableName.TabIndex = 17;
            this.lblTableName.Text = "Table name:";
            // 
            // pageService
            // 
            this.pageService.Controls.Add(this.txtPort);
            this.pageService.Controls.Add(this.lblPort);
            this.pageService.Controls.Add(this.txtAddress);
            this.pageService.Controls.Add(this.lblAddress);
            this.pageService.Location = new System.Drawing.Point(4, 22);
            this.pageService.Name = "pageService";
            this.pageService.Padding = new System.Windows.Forms.Padding(3);
            this.pageService.Size = new System.Drawing.Size(384, 143);
            this.pageService.TabIndex = 3;
            this.pageService.Text = "Service";
            this.pageService.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(91, 43);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(277, 20);
            this.txtPort.TabIndex = 22;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(17, 46);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 23;
            this.lblPort.Text = "Port:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(91, 14);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(277, 20);
            this.txtAddress.TabIndex = 20;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(17, 17);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 21;
            this.lblAddress.Text = "Address:";
            // 
            // ATSCADAAppEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAAppEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "App Editor";
            this.tabElement.ResumeLayout(false);
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            this.pageAuthentication.ResumeLayout(false);
            this.pageAuthentication.PerformLayout();
            this.pageService.ResumeLayout(false);
            this.pageService.PerformLayout();
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
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TabPage pageAuthentication;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.CheckBox ckbRequirement;
        private System.Windows.Forms.CheckBox ckbDarkMode;
        private System.Windows.Forms.TabPage pageService;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
    }
}