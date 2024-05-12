
namespace ATSCADAWebApp.Core
{
    partial class ATSCADAViewEditor
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
            this.txtRoles = new System.Windows.Forms.TextBox();
            this.lblRoles = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.pageConnection = new System.Windows.Forms.TabPage();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.nudMaxNumberOfWrite = new System.Windows.Forms.NumericUpDown();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblMaxNumberOfWrite = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.tabElement.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            this.pageConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxNumberOfWrite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 181);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Controls.Add(this.pageConnection);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 169);
            this.tabElement.TabIndex = 13;
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
            this.pageExtend.Controls.Add(this.txtRoles);
            this.pageExtend.Controls.Add(this.lblRoles);
            this.pageExtend.Controls.Add(this.txtLocation);
            this.pageExtend.Controls.Add(this.txtIcon);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblIcon);
            this.pageExtend.Controls.Add(this.lblLocation);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 147);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // txtRoles
            // 
            this.txtRoles.Location = new System.Drawing.Point(91, 97);
            this.txtRoles.Name = "txtRoles";
            this.txtRoles.Size = new System.Drawing.Size(277, 20);
            this.txtRoles.TabIndex = 6;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(17, 100);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(37, 13);
            this.lblRoles.TabIndex = 24;
            this.lblRoles.Text = "Roles:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(91, 41);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(277, 20);
            this.txtLocation.TabIndex = 4;
            // 
            // txtIcon
            // 
            this.txtIcon.Location = new System.Drawing.Point(91, 69);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(277, 20);
            this.txtIcon.TabIndex = 5;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(91, 14);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(277, 20);
            this.txtContent.TabIndex = 3;
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(17, 72);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(31, 13);
            this.lblIcon.TabIndex = 5;
            this.lblIcon.Text = "Icon:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(17, 44);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Location:";
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
            // pageConnection
            // 
            this.pageConnection.Controls.Add(this.nudTimeout);
            this.pageConnection.Controls.Add(this.nudMaxNumberOfWrite);
            this.pageConnection.Controls.Add(this.nudInterval);
            this.pageConnection.Controls.Add(this.lblTimeout);
            this.pageConnection.Controls.Add(this.lblMaxNumberOfWrite);
            this.pageConnection.Controls.Add(this.lblInterval);
            this.pageConnection.Location = new System.Drawing.Point(4, 22);
            this.pageConnection.Name = "pageConnection";
            this.pageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.pageConnection.Size = new System.Drawing.Size(384, 217);
            this.pageConnection.TabIndex = 2;
            this.pageConnection.Text = "Connection";
            this.pageConnection.UseVisualStyleBackColor = true;
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(91, 69);
            this.nudTimeout.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(277, 20);
            this.nudTimeout.TabIndex = 20;
            // 
            // nudMaxNumberOfWrite
            // 
            this.nudMaxNumberOfWrite.Location = new System.Drawing.Point(91, 42);
            this.nudMaxNumberOfWrite.Name = "nudMaxNumberOfWrite";
            this.nudMaxNumberOfWrite.Size = new System.Drawing.Size(277, 20);
            this.nudMaxNumberOfWrite.TabIndex = 19;
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(91, 15);
            this.nudInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(277, 20);
            this.nudInterval.TabIndex = 18;
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(17, 72);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(70, 13);
            this.lblTimeout.TabIndex = 23;
            this.lblTimeout.Text = "Timeout (ms):";
            // 
            // lblMaxNumberOfWrite
            // 
            this.lblMaxNumberOfWrite.AutoSize = true;
            this.lblMaxNumberOfWrite.Location = new System.Drawing.Point(17, 44);
            this.lblMaxNumberOfWrite.Name = "lblMaxNumberOfWrite";
            this.lblMaxNumberOfWrite.Size = new System.Drawing.Size(58, 13);
            this.lblMaxNumberOfWrite.TabIndex = 22;
            this.lblMaxNumberOfWrite.Text = "Max. Write";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(17, 17);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(67, 13);
            this.lblInterval.TabIndex = 21;
            this.lblInterval.Text = "Interval (ms):";
            // 
            // ATSCADAViewEditor
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
            this.Name = "ATSCADAViewEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Editor";
            this.tabElement.ResumeLayout(false);
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            this.pageConnection.ResumeLayout(false);
            this.pageConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxNumberOfWrite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
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
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtRoles;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.TabPage pageConnection;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.NumericUpDown nudMaxNumberOfWrite;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Label lblMaxNumberOfWrite;
        private System.Windows.Forms.Label lblInterval;
    }
}