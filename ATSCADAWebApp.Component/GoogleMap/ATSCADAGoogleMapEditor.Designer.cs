
namespace ATSCADAWebApp.Component.GoogleMap
{
    partial class ATSCADAGoogleMapEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAGoogleMapEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.ptnYtb = new System.Windows.Forms.PictureBox();
            this.txtApplication = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeyAPI = new System.Windows.Forms.RichTextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFrame = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lstvMapItem = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip_Application = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Connection = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Key = new System.Windows.Forms.ToolTip(this.components);
            this.pageExtend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptnYtb)).BeginInit();
            this.pageBase.SuspendLayout();
            this.tabElement.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(296, 302);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.ptnYtb);
            this.pageExtend.Controls.Add(this.txtApplication);
            this.pageExtend.Controls.Add(this.label5);
            this.pageExtend.Controls.Add(this.label4);
            this.pageExtend.Controls.Add(this.txtKeyAPI);
            this.pageExtend.Controls.Add(this.txtHeight);
            this.pageExtend.Controls.Add(this.txtConnection);
            this.pageExtend.Controls.Add(this.label3);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.label1);
            this.pageExtend.Controls.Add(this.lblFrame);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 22);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(440, 262);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // ptnYtb
            // 
            this.ptnYtb.Image = ((System.Drawing.Image)(resources.GetObject("ptnYtb.Image")));
            this.ptnYtb.Location = new System.Drawing.Point(88, 168);
            this.ptnYtb.Name = "ptnYtb";
            this.ptnYtb.Size = new System.Drawing.Size(20, 20);
            this.ptnYtb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptnYtb.TabIndex = 34;
            this.ptnYtb.TabStop = false;
            // 
            // txtApplication
            // 
            this.txtApplication.AutoCompleteCustomSource.AddRange(new string[] {
            "aaaa"});
            this.txtApplication.Location = new System.Drawing.Point(113, 46);
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.Size = new System.Drawing.Size(311, 20);
            this.txtApplication.TabIndex = 2;
            this.toolTip_Application.SetToolTip(this.txtApplication, "- This is file name of project, application name of folder on IIS.\r\n- Example: ht" +
        "tps://atlink.asia/DemoMap");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Application Name:";
            this.toolTip_Application.SetToolTip(this.label5, "- This is file name of project, application name of folder on IIS.\r\n- Example: ht" +
        "tps://atlink.asia/DemoMap");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "API Key:";
            this.toolTip_Key.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // txtKeyAPI
            // 
            this.txtKeyAPI.Location = new System.Drawing.Point(113, 168);
            this.txtKeyAPI.Name = "txtKeyAPI";
            this.txtKeyAPI.Size = new System.Drawing.Size(311, 79);
            this.txtKeyAPI.TabIndex = 7;
            this.txtKeyAPI.Text = "";
            this.toolTip_Key.SetToolTip(this.txtKeyAPI, resources.GetString("txtKeyAPI.ToolTip"));
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(113, 107);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(311, 20);
            this.txtHeight.TabIndex = 5;
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(113, 76);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(311, 20);
            this.txtConnection.TabIndex = 3;
            this.toolTip_Connection.SetToolTip(this.txtConnection, resources.GetString("txtConnection.ToolTip"));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Connection:";
            this.toolTip_Connection.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(113, 137);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(311, 20);
            this.txtGridColumn.TabIndex = 6;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(113, 16);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(311, 20);
            this.txtContent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Grid Column:";
            // 
            // lblFrame
            // 
            this.lblFrame.AutoSize = true;
            this.lblFrame.Location = new System.Drawing.Point(14, 111);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(41, 13);
            this.lblFrame.TabIndex = 5;
            this.lblFrame.Text = "Height:";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(14, 20);
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
            this.pageBase.Size = new System.Drawing.Size(440, 262);
            this.pageBase.TabIndex = 0;
            this.pageBase.Text = "Base";
            this.pageBase.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(91, 50);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(330, 114);
            this.txtDescription.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(330, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(17, 54);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Controls.Add(this.tabPage1);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(448, 288);
            this.tabElement.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEdit);
            this.tabPage1.Controls.Add(this.lstvMapItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(440, 262);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Items";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(353, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // lstvMapItem
            // 
            this.lstvMapItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAlias,
            this.colParam,
            this.colLocation,
            this.colColor,
            this.colTable,
            this.colShow});
            this.lstvMapItem.FullRowSelect = true;
            this.lstvMapItem.GridLines = true;
            this.lstvMapItem.HideSelection = false;
            this.lstvMapItem.Location = new System.Drawing.Point(3, 43);
            this.lstvMapItem.Name = "lstvMapItem";
            this.lstvMapItem.Size = new System.Drawing.Size(435, 216);
            this.lstvMapItem.TabIndex = 2;
            this.lstvMapItem.UseCompatibleStateImageBehavior = false;
            this.lstvMapItem.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 70;
            // 
            // colAlias
            // 
            this.colAlias.Text = "Alias";
            this.colAlias.Width = 70;
            // 
            // colParam
            // 
            this.colParam.Text = "Parameters";
            this.colParam.Width = 120;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Tag location";
            this.colLocation.Width = 120;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            // 
            // colTable
            // 
            this.colTable.Text = "Table";
            this.colTable.Width = 70;
            // 
            // colShow
            // 
            this.colShow.Text = "Show";
            this.colShow.Width = 70;
            // 
            // toolTip_Application
            // 
            this.toolTip_Application.AutoPopDelay = 10000;
            this.toolTip_Application.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Application.InitialDelay = 0;
            this.toolTip_Application.IsBalloon = true;
            this.toolTip_Application.ReshowDelay = 0;
            this.toolTip_Application.ShowAlways = true;
            this.toolTip_Application.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Application.ToolTipTitle = "Application Name";
            // 
            // toolTip_Connection
            // 
            this.toolTip_Connection.AutoPopDelay = 20000;
            this.toolTip_Connection.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Connection.InitialDelay = 0;
            this.toolTip_Connection.IsBalloon = true;
            this.toolTip_Connection.ReshowDelay = 0;
            this.toolTip_Connection.ShowAlways = true;
            this.toolTip_Connection.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Connection.ToolTipTitle = "Connection";
            // 
            // toolTip_Key
            // 
            this.toolTip_Key.AutoPopDelay = 20000;
            this.toolTip_Key.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Key.InitialDelay = 0;
            this.toolTip_Key.IsBalloon = true;
            this.toolTip_Key.ReshowDelay = 0;
            this.toolTip_Key.ShowAlways = true;
            this.toolTip_Key.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Key.ToolTipTitle = "API Key";
            // 
            // ATSCADAGoogleMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 333);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAGoogleMapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Google Map Editor";
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptnYtb)).EndInit();
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.tabElement.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage pageExtend;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lstvMapItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAlias;
        private System.Windows.Forms.ColumnHeader colParam;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colTable;
        private System.Windows.Forms.ColumnHeader colShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtKeyAPI;
        private System.Windows.Forms.TextBox txtApplication;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip_Application;
        private System.Windows.Forms.ToolTip toolTip_Connection;
        private System.Windows.Forms.ToolTip toolTip_Key;
        private System.Windows.Forms.PictureBox ptnYtb;
    }
}