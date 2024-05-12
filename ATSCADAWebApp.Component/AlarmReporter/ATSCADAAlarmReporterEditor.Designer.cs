﻿
namespace ATSCADAWebApp.Component.AlarmReporter
{
    partial class ATSCADAAlarmReporterEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAAlarmReporterEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblDecimalPlaces = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.tabElement.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(323, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 208);
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
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(392, 195);
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
            this.pageBase.Size = new System.Drawing.Size(384, 169);
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
            this.pageExtend.Controls.Add(this.txtConnection);
            this.pageExtend.Controls.Add(this.lblConnection);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.label1);
            this.pageExtend.Controls.Add(this.nudTimeout);
            this.pageExtend.Controls.Add(this.txtTableName);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblDecimalPlaces);
            this.pageExtend.Controls.Add(this.lblTableName);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(384, 169);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(91, 43);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(277, 20);
            this.txtConnection.TabIndex = 4;
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(17, 46);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(64, 13);
            this.lblConnection.TabIndex = 15;
            this.lblConnection.Text = "Connection:";
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(91, 130);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(277, 20);
            this.txtGridColumn.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Grid column:";
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(91, 101);
            this.nudTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(277, 20);
            this.nudTimeout.TabIndex = 6;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(91, 72);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(277, 20);
            this.txtTableName.TabIndex = 5;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(91, 14);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(277, 20);
            this.txtContent.TabIndex = 3;
            // 
            // lblDecimalPlaces
            // 
            this.lblDecimalPlaces.AutoSize = true;
            this.lblDecimalPlaces.Location = new System.Drawing.Point(17, 103);
            this.lblDecimalPlaces.Name = "lblDecimalPlaces";
            this.lblDecimalPlaces.Size = new System.Drawing.Size(70, 13);
            this.lblDecimalPlaces.TabIndex = 7;
            this.lblDecimalPlaces.Text = "Timeout (ms):";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(17, 75);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(66, 13);
            this.lblTableName.TabIndex = 6;
            this.lblTableName.Text = "Table name:";
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
            // ATSCADAAlarmReporterEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 238);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAAlarmReporterEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlarmReporter Properties";
            this.tabElement.ResumeLayout(false);
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
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
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblDecimalPlaces;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label lblConnection;
    }
}