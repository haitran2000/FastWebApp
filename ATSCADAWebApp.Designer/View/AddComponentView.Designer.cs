
namespace ATSCADAWebApp.Designer.View
{
    partial class AddComponentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddComponentView));
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lstbComponent = new System.Windows.Forms.ListBox();
            this.componentContainer = new System.Windows.Forms.SplitContainer();
            this.lblWebsite = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.componentContainer)).BeginInit();
            this.componentContainer.Panel1.SuspendLayout();
            this.componentContainer.Panel2.SuspendLayout();
            this.componentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(275, 213);
            this.txtDescription.TabIndex = 2;
            // 
            // lstbComponent
            // 
            this.lstbComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbComponent.FormattingEnabled = true;
            this.lstbComponent.Location = new System.Drawing.Point(0, 0);
            this.lstbComponent.Name = "lstbComponent";
            this.lstbComponent.Size = new System.Drawing.Size(153, 213);
            this.lstbComponent.TabIndex = 1;
            // 
            // componentContainer
            // 
            this.componentContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.componentContainer.Location = new System.Drawing.Point(8, 7);
            this.componentContainer.Name = "componentContainer";
            // 
            // componentContainer.Panel1
            // 
            this.componentContainer.Panel1.Controls.Add(this.lstbComponent);
            // 
            // componentContainer.Panel2
            // 
            this.componentContainer.Panel2.Controls.Add(this.lblWebsite);
            this.componentContainer.Panel2.Controls.Add(this.txtDescription);
            this.componentContainer.Size = new System.Drawing.Size(432, 213);
            this.componentContainer.SplitterDistance = 153;
            this.componentContainer.TabIndex = 14;
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(1, 44);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(109, 13);
            this.lblWebsite.TabIndex = 3;
            this.lblWebsite.TabStop = true;
            this.lblWebsite.Text = "https://atscada.com/";
            this.lblWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblWebsite_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(365, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(284, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AddComponentView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(446, 256);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.componentContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddComponentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Component";
            this.componentContainer.Panel1.ResumeLayout(false);
            this.componentContainer.Panel2.ResumeLayout(false);
            this.componentContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentContainer)).EndInit();
            this.componentContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ListBox lstbComponent;
        private System.Windows.Forms.SplitContainer componentContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel lblWebsite;
    }
}