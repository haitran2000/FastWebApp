
namespace ATSCADAWebApp.Component.GoogleMap
{
    partial class ATSCADAMarkerItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAMarkerItemEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageProperties = new System.Windows.Forms.TabPage();
            this.ptnSettings = new System.Windows.Forms.PictureBox();
            this.chbMovable = new System.Windows.Forms.CheckBox();
            this.chbOpenNewTab = new System.Windows.Forms.CheckBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbShow = new System.Windows.Forms.CheckBox();
            this.cbxLocationTagName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.txtColor = new ATSCADAWebApp.Extension.Color.TextBoxColor();
            this.lstvMapItem = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagParam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNewTab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMovable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.toolTip_Alias = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Table = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Color = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Url = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Param = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Movable = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Show = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_NewTab = new System.Windows.Forms.ToolTip(this.components);
            this.tabElement.SuspendLayout();
            this.pageProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptnSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(470, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(393, 367);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(296, 14);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(123, 20);
            this.txtAlias.TabIndex = 2;
            this.toolTip_Alias.SetToolTip(this.txtAlias, "This alias is marker\'s name will show on map.");
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(257, 87);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 19;
            this.lblColor.Text = "Color:";
            this.toolTip_Color.SetToolTip(this.lblColor, "This color will be route\'s color.");
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(257, 18);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(32, 13);
            this.lblContent.TabIndex = 18;
            this.lblContent.Text = "Alias:";
            this.toolTip_Alias.SetToolTip(this.lblContent, "This alias is marker\'s name will show on map.");
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(8, 52);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(69, 13);
            this.lblTagName.TabIndex = 17;
            this.lblTagName.Text = "Tag location:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name:";
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageProperties);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(535, 181);
            this.tabElement.TabIndex = 17;
            // 
            // pageProperties
            // 
            this.pageProperties.Controls.Add(this.ptnSettings);
            this.pageProperties.Controls.Add(this.chbMovable);
            this.pageProperties.Controls.Add(this.chbOpenNewTab);
            this.pageProperties.Controls.Add(this.txtUrl);
            this.pageProperties.Controls.Add(this.label3);
            this.pageProperties.Controls.Add(this.txtParam);
            this.pageProperties.Controls.Add(this.label1);
            this.pageProperties.Controls.Add(this.txtTable);
            this.pageProperties.Controls.Add(this.label2);
            this.pageProperties.Controls.Add(this.chbShow);
            this.pageProperties.Controls.Add(this.cbxLocationTagName);
            this.pageProperties.Controls.Add(this.txtColor);
            this.pageProperties.Controls.Add(this.txtAlias);
            this.pageProperties.Controls.Add(this.lblName);
            this.pageProperties.Controls.Add(this.lblTagName);
            this.pageProperties.Controls.Add(this.txtName);
            this.pageProperties.Controls.Add(this.lblContent);
            this.pageProperties.Controls.Add(this.lblColor);
            this.pageProperties.Location = new System.Drawing.Point(4, 22);
            this.pageProperties.Name = "pageProperties";
            this.pageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.pageProperties.Size = new System.Drawing.Size(527, 155);
            this.pageProperties.TabIndex = 0;
            this.pageProperties.Text = "Properties";
            this.pageProperties.UseVisualStyleBackColor = true;
            // 
            // ptnSettings
            // 
            this.ptnSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptnSettings.Image = ((System.Drawing.Image)(resources.GetObject("ptnSettings.Image")));
            this.ptnSettings.Location = new System.Drawing.Point(494, 117);
            this.ptnSettings.Name = "ptnSettings";
            this.ptnSettings.Size = new System.Drawing.Size(20, 20);
            this.ptnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptnSettings.TabIndex = 34;
            this.ptnSettings.TabStop = false;
            // 
            // chbMovable
            // 
            this.chbMovable.AutoSize = true;
            this.chbMovable.Checked = true;
            this.chbMovable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMovable.Location = new System.Drawing.Point(430, 16);
            this.chbMovable.Name = "chbMovable";
            this.chbMovable.Size = new System.Drawing.Size(67, 17);
            this.chbMovable.TabIndex = 8;
            this.chbMovable.Text = "Movable";
            this.chbMovable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip_Movable.SetToolTip(this.chbMovable, "- Tick: This marker is movable.\r\n- Untick: This marker is fixed.");
            this.chbMovable.UseVisualStyleBackColor = true;
            // 
            // chbOpenNewTab
            // 
            this.chbOpenNewTab.AutoSize = true;
            this.chbOpenNewTab.Checked = true;
            this.chbOpenNewTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOpenNewTab.Location = new System.Drawing.Point(430, 85);
            this.chbOpenNewTab.Name = "chbOpenNewTab";
            this.chbOpenNewTab.Size = new System.Drawing.Size(93, 17);
            this.chbOpenNewTab.TabIndex = 10;
            this.chbOpenNewTab.Text = "Open new tab";
            this.chbOpenNewTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip_NewTab.SetToolTip(this.chbOpenNewTab, "- Tick: Allow to open the Url link in a new tab of browser when click to the mark" +
        "er.\r\n- Untick: Allow to open the Url link in parent frame of browser when click " +
        "to the marker.");
            this.chbOpenNewTab.UseVisualStyleBackColor = true;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(78, 83);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(170, 20);
            this.txtUrl.TabIndex = 5;
            this.txtUrl.Text = "http://";
            this.toolTip_Url.SetToolTip(this.txtUrl, "- Leave this field empty if you dont want to redirect link.\r\n- Otherwise, fill in" +
        " like this: ~/layout, ~/report, ~/settings, https://youtube.com,...");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Link Url:";
            this.toolTip_Url.SetToolTip(this.label3, "- Leave this field empty if you dont want to redirect link.\r\n- Otherwise, fill in" +
        " like this: ~/layout, ~/report, ~/settings, https://youtube.com,...");
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(78, 117);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(414, 20);
            this.txtParam.TabIndex = 7;
            this.toolTip_Param.SetToolTip(this.txtParam, "Syntax: \"Name=Alias=TaskName.TagName|Name=Alias=TaskName.TagName|...\"");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Parameters:";
            this.toolTip_Param.SetToolTip(this.label1, "Syntax: \"Name=Alias=TaskName.TagName|Name=Alias=TaskName.TagName|...\"");
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(296, 48);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(123, 20);
            this.txtTable.TabIndex = 4;
            this.txtTable.Text = "datalog";
            this.toolTip_Table.SetToolTip(this.txtTable, "This is table name of location variable in database.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Table:";
            this.toolTip_Table.SetToolTip(this.label2, "This is table name of location variable in database.");
            // 
            // chbShow
            // 
            this.chbShow.AutoSize = true;
            this.chbShow.Checked = true;
            this.chbShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShow.Location = new System.Drawing.Point(430, 50);
            this.chbShow.Name = "chbShow";
            this.chbShow.Size = new System.Drawing.Size(91, 17);
            this.chbShow.TabIndex = 9;
            this.chbShow.Text = "Show on map";
            this.chbShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip_Show.SetToolTip(this.chbShow, "- Tick: Allow to show this marker on map.\r\n- Untick: Not allow to show this marke" +
        "r on map.");
            this.chbShow.UseVisualStyleBackColor = true;
            // 
            // cbxLocationTagName
            // 
            this.cbxLocationTagName.InRuntime = false;
            this.cbxLocationTagName.Location = new System.Drawing.Point(78, 48);
            this.cbxLocationTagName.Name = "cbxLocationTagName";
            this.cbxLocationTagName.Size = new System.Drawing.Size(170, 21);
            this.cbxLocationTagName.TabIndex = 3;
            this.cbxLocationTagName.TagName = "";
            // 
            // txtColor
            // 
            this.txtColor.Color = "#008080";
            this.txtColor.Location = new System.Drawing.Point(296, 83);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(123, 20);
            this.txtColor.TabIndex = 6;
            this.toolTip_Color.SetToolTip(this.txtColor, "This color will be route\'s color.");
            // 
            // lstvMapItem
            // 
            this.lstvMapItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colContent,
            this.colTagParam,
            this.colTagLocation,
            this.colColor,
            this.colTable,
            this.colUrl,
            this.colNewTab,
            this.colMovable,
            this.colShow});
            this.lstvMapItem.FullRowSelect = true;
            this.lstvMapItem.GridLines = true;
            this.lstvMapItem.HideSelection = false;
            this.lstvMapItem.Location = new System.Drawing.Point(9, 195);
            this.lstvMapItem.MultiSelect = false;
            this.lstvMapItem.Name = "lstvMapItem";
            this.lstvMapItem.Size = new System.Drawing.Size(531, 166);
            this.lstvMapItem.TabIndex = 18;
            this.lstvMapItem.UseCompatibleStateImageBehavior = false;
            this.lstvMapItem.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 80;
            // 
            // colContent
            // 
            this.colContent.Text = "Alias";
            this.colContent.Width = 80;
            // 
            // colTagParam
            // 
            this.colTagParam.Text = "Parameters";
            this.colTagParam.Width = 150;
            // 
            // colTagLocation
            // 
            this.colTagLocation.Text = "Tag location";
            this.colTagLocation.Width = 150;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            // 
            // colTable
            // 
            this.colTable.Text = "Table";
            this.colTable.Width = 80;
            // 
            // colUrl
            // 
            this.colUrl.Text = "Link Url";
            this.colUrl.Width = 150;
            // 
            // colNewTab
            // 
            this.colNewTab.Text = "New Tab";
            this.colNewTab.Width = 70;
            // 
            // colMovable
            // 
            this.colMovable.Text = "Movable";
            this.colMovable.Width = 70;
            // 
            // colShow
            // 
            this.colShow.Text = "Show";
            this.colShow.Width = 70;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(85, 367);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 23);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(8, 367);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(239, 367);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(70, 23);
            this.btnDown.TabIndex = 14;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(162, 367);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(70, 23);
            this.btnUp.TabIndex = 13;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // toolTip_Alias
            // 
            this.toolTip_Alias.AutoPopDelay = 10000;
            this.toolTip_Alias.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Alias.InitialDelay = 0;
            this.toolTip_Alias.IsBalloon = true;
            this.toolTip_Alias.ReshowDelay = 0;
            this.toolTip_Alias.ShowAlways = true;
            this.toolTip_Alias.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Alias.ToolTipTitle = "Alias";
            // 
            // toolTip_Table
            // 
            this.toolTip_Table.AutoPopDelay = 10000;
            this.toolTip_Table.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Table.InitialDelay = 0;
            this.toolTip_Table.IsBalloon = true;
            this.toolTip_Table.ReshowDelay = 0;
            this.toolTip_Table.ShowAlways = true;
            this.toolTip_Table.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Table.ToolTipTitle = "Table";
            // 
            // toolTip_Color
            // 
            this.toolTip_Color.AutoPopDelay = 10000;
            this.toolTip_Color.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Color.InitialDelay = 0;
            this.toolTip_Color.IsBalloon = true;
            this.toolTip_Color.ReshowDelay = 0;
            this.toolTip_Color.ShowAlways = true;
            this.toolTip_Color.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Color.ToolTipTitle = "Color";
            // 
            // toolTip_Url
            // 
            this.toolTip_Url.AutoPopDelay = 20000;
            this.toolTip_Url.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Url.InitialDelay = 0;
            this.toolTip_Url.IsBalloon = true;
            this.toolTip_Url.ReshowDelay = 0;
            this.toolTip_Url.ShowAlways = true;
            this.toolTip_Url.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Url.ToolTipTitle = "Link URL";
            // 
            // toolTip_Param
            // 
            this.toolTip_Param.AutoPopDelay = 10000;
            this.toolTip_Param.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Param.InitialDelay = 0;
            this.toolTip_Param.IsBalloon = true;
            this.toolTip_Param.ReshowDelay = 0;
            this.toolTip_Param.ShowAlways = true;
            this.toolTip_Param.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Param.ToolTipTitle = "Parameters";
            // 
            // toolTip_Movable
            // 
            this.toolTip_Movable.AutoPopDelay = 10000;
            this.toolTip_Movable.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Movable.InitialDelay = 0;
            this.toolTip_Movable.IsBalloon = true;
            this.toolTip_Movable.ReshowDelay = 0;
            this.toolTip_Movable.ShowAlways = true;
            this.toolTip_Movable.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Movable.ToolTipTitle = "Movable";
            // 
            // toolTip_Show
            // 
            this.toolTip_Show.AutoPopDelay = 10000;
            this.toolTip_Show.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_Show.InitialDelay = 0;
            this.toolTip_Show.IsBalloon = true;
            this.toolTip_Show.ReshowDelay = 0;
            this.toolTip_Show.ShowAlways = true;
            this.toolTip_Show.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_Show.ToolTipTitle = "Show on map";
            // 
            // toolTip_NewTab
            // 
            this.toolTip_NewTab.AutoPopDelay = 10000;
            this.toolTip_NewTab.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip_NewTab.InitialDelay = 0;
            this.toolTip_NewTab.IsBalloon = true;
            this.toolTip_NewTab.ReshowDelay = 0;
            this.toolTip_NewTab.ShowAlways = true;
            this.toolTip_NewTab.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_NewTab.ToolTipTitle = "Open New Tab";
            // 
            // ATSCADAMarkerItemEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(547, 399);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstvMapItem);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADAMarkerItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marker Item Editor";
            this.tabElement.ResumeLayout(false);
            this.pageProperties.ResumeLayout(false);
            this.pageProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptnSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageProperties;
        private System.Windows.Forms.ListView lstvMapItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colContent;
        private System.Windows.Forms.ColumnHeader colTagParam;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private Extension.Color.TextBoxColor txtColor;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxLocationTagName;
        private System.Windows.Forms.ColumnHeader colTagLocation;
        private System.Windows.Forms.CheckBox chbShow;
        private System.Windows.Forms.ColumnHeader colTable;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colUrl;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbOpenNewTab;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colNewTab;
        private System.Windows.Forms.ColumnHeader colMovable;
        private System.Windows.Forms.CheckBox chbMovable;
        private System.Windows.Forms.ColumnHeader colShow;
        private System.Windows.Forms.ToolTip toolTip_Alias;
        private System.Windows.Forms.ToolTip toolTip_Table;
        private System.Windows.Forms.ToolTip toolTip_Color;
        private System.Windows.Forms.ToolTip toolTip_Url;
        private System.Windows.Forms.ToolTip toolTip_Param;
        private System.Windows.Forms.ToolTip toolTip_Movable;
        private System.Windows.Forms.ToolTip toolTip_Show;
        private System.Windows.Forms.ToolTip toolTip_NewTab;
        private System.Windows.Forms.PictureBox ptnSettings;
    }
}