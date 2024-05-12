
namespace ATSCADAWebApp.Component.StreamCamera
{
    partial class ATSCADAStreamCameraEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAStreamCameraEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.cbxFrame = new System.Windows.Forms.ComboBox();
            this.txtTokenTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.cbxNetwork = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFrame = new System.Windows.Forms.Label();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pageExtend.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.tabElement.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.txtConnection);
            this.pageExtend.Controls.Add(this.label3);
            this.pageExtend.Controls.Add(this.cbxFrame);
            this.pageExtend.Controls.Add(this.txtTokenTime);
            this.pageExtend.Controls.Add(this.label2);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.cbxNetwork);
            this.pageExtend.Controls.Add(this.label1);
            this.pageExtend.Controls.Add(this.lblFrame);
            this.pageExtend.Controls.Add(this.lblNetwork);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 189);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // cbxFrame
            // 
            this.cbxFrame.FormattingEnabled = true;
            this.cbxFrame.Location = new System.Drawing.Point(106, 127);
            this.cbxFrame.Name = "cbxFrame";
            this.cbxFrame.Size = new System.Drawing.Size(262, 21);
            this.cbxFrame.TabIndex = 6;
            // 
            // txtTokenTime
            // 
            this.txtTokenTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTokenTime.Location = new System.Drawing.Point(106, 99);
            this.txtTokenTime.Name = "txtTokenTime";
            this.txtTokenTime.Size = new System.Drawing.Size(262, 20);
            this.txtTokenTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Token time (min):";
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(106, 156);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(262, 20);
            this.txtGridColumn.TabIndex = 7;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(106, 14);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(262, 20);
            this.txtContent.TabIndex = 2;
            // 
            // cbxNetwork
            // 
            this.cbxNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNetwork.FormattingEnabled = true;
            this.cbxNetwork.Location = new System.Drawing.Point(106, 70);
            this.cbxNetwork.Name = "cbxNetwork";
            this.cbxNetwork.Size = new System.Drawing.Size(262, 21);
            this.cbxNetwork.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Grid column:";
            // 
            // lblFrame
            // 
            this.lblFrame.AutoSize = true;
            this.lblFrame.Location = new System.Drawing.Point(15, 130);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(39, 13);
            this.lblFrame.TabIndex = 5;
            this.lblFrame.Text = "Frame:";
            // 
            // lblNetwork
            // 
            this.lblNetwork.AutoSize = true;
            this.lblNetwork.Location = new System.Drawing.Point(15, 74);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(50, 13);
            this.lblNetwork.TabIndex = 4;
            this.lblNetwork.Text = "Network:";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(15, 18);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(47, 13);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "Content:";
            // 
            // pageBase
            // 
            this.pageBase.Controls.Add(this.txtDescription);
            this.pageBase.Controls.Add(this.txtName);
            this.pageBase.Controls.Add(this.lblDescription);
            this.pageBase.Controls.Add(this.lblName);
            this.pageBase.Location = new System.Drawing.Point(4, 22);
            this.pageBase.Name = "pageBase";
            this.pageBase.Padding = new System.Windows.Forms.Padding(3);
            this.pageBase.Size = new System.Drawing.Size(384, 189);
            this.pageBase.TabIndex = 0;
            this.pageBase.Text = "Base";
            this.pageBase.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(91, 42);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 71);
            this.txtDescription.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 20);
            this.txtName.TabIndex = 0;
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
            this.tabElement.Location = new System.Drawing.Point(6, 7);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 215);
            this.tabElement.TabIndex = 13;
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(106, 42);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(262, 20);
            this.txtConnection.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Connection:";
            // 
            // ATSCADAStreamCameraEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 262);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAStreamCameraEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stream Camera Editor";
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
        private System.Windows.Forms.TabPage pageExtend;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ComboBox cbxNetwork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TextBox txtTokenTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxFrame;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label label3;
    }
}