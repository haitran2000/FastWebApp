
namespace ATSCADAWebApp.Component.SVG
{
    partial class ATSCADASVGEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADASVGEditor));
            this.tabElement = new System.Windows.Forms.TabControl();
            this.tabBase = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.txtColor = new ATSCADAWebApp.Extension.Color.TextBoxColor();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabAddValue = new System.Windows.Forms.TabPage();
            this.lstvSVGValueItem = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProperties = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabAlarm = new System.Windows.Forms.TabPage();
            this.lstvSVGAlarmItem = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagLowName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagHighName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.filePicker = new System.Windows.Forms.OpenFileDialog();
            this.tabCutaway = new System.Windows.Forms.TabPage();
            this.lstvSVGCutawayItem = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEditCutaway = new System.Windows.Forms.Button();
            this.tabElement.SuspendLayout();
            this.tabBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            this.tabAddValue.SuspendLayout();
            this.tabAlarm.SuspendLayout();
            this.tabCutaway.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.tabBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Controls.Add(this.tabAddValue);
            this.tabElement.Controls.Add(this.tabAlarm);
            this.tabElement.Controls.Add(this.tabCutaway);
            this.tabElement.Location = new System.Drawing.Point(8, 8);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(704, 284);
            this.tabElement.TabIndex = 0;
            // 
            // tabBase
            // 
            this.tabBase.Controls.Add(this.txtDescription);
            this.tabBase.Controls.Add(this.lblDescription);
            this.tabBase.Controls.Add(this.txtName);
            this.tabBase.Controls.Add(this.lblName);
            this.tabBase.Location = new System.Drawing.Point(4, 26);
            this.tabBase.Name = "tabBase";
            this.tabBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabBase.Size = new System.Drawing.Size(696, 254);
            this.tabBase.TabIndex = 2;
            this.tabBase.Text = "Base";
            this.tabBase.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(95, 40);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(581, 208);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 43);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(581, 23);
            this.txtName.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.btnPickColor);
            this.pageExtend.Controls.Add(this.txtColor);
            this.pageExtend.Controls.Add(this.lblColor);
            this.pageExtend.Controls.Add(this.btnBrowse);
            this.pageExtend.Controls.Add(this.txtSelectedFile);
            this.pageExtend.Controls.Add(this.label3);
            this.pageExtend.Location = new System.Drawing.Point(4, 26);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(3);
            this.pageExtend.Size = new System.Drawing.Size(696, 254);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(316, 61);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(85, 25);
            this.btnPickColor.TabIndex = 18;
            this.btnPickColor.Text = "Pick Color";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.Color = "#008080";
            this.txtColor.Location = new System.Drawing.Point(140, 61);
            this.txtColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(169, 25);
            this.txtColor.TabIndex = 17;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(21, 61);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(76, 17);
            this.lblColor.TabIndex = 15;
            this.lblColor.Text = "BackColor:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(589, 18);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 28);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.Location = new System.Drawing.Point(141, 21);
            this.txtSelectedFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtSelectedFile.Multiline = true;
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(440, 25);
            this.txtSelectedFile.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Load SVG";
            // 
            // tabAddValue
            // 
            this.tabAddValue.Controls.Add(this.lstvSVGValueItem);
            this.tabAddValue.Controls.Add(this.btnEdit);
            this.tabAddValue.Location = new System.Drawing.Point(4, 26);
            this.tabAddValue.Name = "tabAddValue";
            this.tabAddValue.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddValue.Size = new System.Drawing.Size(696, 254);
            this.tabAddValue.TabIndex = 3;
            this.tabAddValue.Text = "Value";
            this.tabAddValue.UseVisualStyleBackColor = true;
            // 
            // lstvSVGValueItem
            // 
            this.lstvSVGValueItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colTagName,
            this.colProperties});
            this.lstvSVGValueItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstvSVGValueItem.FullRowSelect = true;
            this.lstvSVGValueItem.GridLines = true;
            this.lstvSVGValueItem.HideSelection = false;
            this.lstvSVGValueItem.Location = new System.Drawing.Point(3, 35);
            this.lstvSVGValueItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstvSVGValueItem.Name = "lstvSVGValueItem";
            this.lstvSVGValueItem.Size = new System.Drawing.Size(690, 216);
            this.lstvSVGValueItem.TabIndex = 11;
            this.lstvSVGValueItem.UseCompatibleStateImageBehavior = false;
            this.lstvSVGValueItem.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "ID";
            this.colName.Width = 113;
            // 
            // colTagName
            // 
            this.colTagName.DisplayIndex = 2;
            this.colTagName.Text = "Tag name";
            this.colTagName.Width = 394;
            // 
            // colProperties
            // 
            this.colProperties.DisplayIndex = 1;
            this.colProperties.Text = "Properties";
            this.colProperties.Width = 257;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(589, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 28);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tabAlarm
            // 
            this.tabAlarm.Controls.Add(this.lstvSVGAlarmItem);
            this.tabAlarm.Controls.Add(this.button1);
            this.tabAlarm.Location = new System.Drawing.Point(4, 26);
            this.tabAlarm.Name = "tabAlarm";
            this.tabAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlarm.Size = new System.Drawing.Size(696, 254);
            this.tabAlarm.TabIndex = 4;
            this.tabAlarm.Text = "Alarm";
            this.tabAlarm.UseVisualStyleBackColor = true;
            // 
            // lstvSVGAlarmItem
            // 
            this.lstvSVGAlarmItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.columnHeader1,
            this.colTagLowName,
            this.colTagHighName});
            this.lstvSVGAlarmItem.FullRowSelect = true;
            this.lstvSVGAlarmItem.GridLines = true;
            this.lstvSVGAlarmItem.HideSelection = false;
            this.lstvSVGAlarmItem.Location = new System.Drawing.Point(7, 47);
            this.lstvSVGAlarmItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstvSVGAlarmItem.MultiSelect = false;
            this.lstvSVGAlarmItem.Name = "lstvSVGAlarmItem";
            this.lstvSVGAlarmItem.Size = new System.Drawing.Size(665, 200);
            this.lstvSVGAlarmItem.TabIndex = 19;
            this.lstvSVGAlarmItem.UseCompatibleStateImageBehavior = false;
            this.lstvSVGAlarmItem.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 81;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tag name";
            this.columnHeader1.Width = 125;
            // 
            // colTagLowName
            // 
            this.colTagLowName.Text = "Low";
            this.colTagLowName.Width = 146;
            // 
            // colTagHighName
            // 
            this.colTagHighName.Text = "High";
            this.colTagHighName.Width = 259;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(556, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(637, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // filePicker
            // 
            this.filePicker.Filter = "SVG Files | *.SVG";
            // 
            // tabCutaway
            // 
            this.tabCutaway.Controls.Add(this.lstvSVGCutawayItem);
            this.tabCutaway.Controls.Add(this.btnEditCutaway);
            this.tabCutaway.Location = new System.Drawing.Point(4, 26);
            this.tabCutaway.Name = "tabCutaway";
            this.tabCutaway.Padding = new System.Windows.Forms.Padding(3);
            this.tabCutaway.Size = new System.Drawing.Size(696, 254);
            this.tabCutaway.TabIndex = 5;
            this.tabCutaway.Text = "Cutaway";
            this.tabCutaway.UseVisualStyleBackColor = true;
            // 
            // lstvSVGCutawayItem
            // 
            this.lstvSVGCutawayItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstvSVGCutawayItem.FullRowSelect = true;
            this.lstvSVGCutawayItem.GridLines = true;
            this.lstvSVGCutawayItem.HideSelection = false;
            this.lstvSVGCutawayItem.Location = new System.Drawing.Point(7, 47);
            this.lstvSVGCutawayItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstvSVGCutawayItem.MultiSelect = false;
            this.lstvSVGCutawayItem.Name = "lstvSVGCutawayItem";
            this.lstvSVGCutawayItem.Size = new System.Drawing.Size(665, 200);
            this.lstvSVGCutawayItem.TabIndex = 21;
            this.lstvSVGCutawayItem.UseCompatibleStateImageBehavior = false;
            this.lstvSVGCutawayItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tag name";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Min";
            this.columnHeader4.Width = 146;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Max";
            this.columnHeader5.Width = 259;
            // 
            // btnEditCutaway
            // 
            this.btnEditCutaway.Location = new System.Drawing.Point(589, 7);
            this.btnEditCutaway.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditCutaway.Name = "btnEditCutaway";
            this.btnEditCutaway.Size = new System.Drawing.Size(100, 28);
            this.btnEditCutaway.TabIndex = 20;
            this.btnEditCutaway.Text = "Edit";
            this.btnEditCutaway.UseVisualStyleBackColor = true;
            this.btnEditCutaway.Click += new System.EventHandler(this.btnEditCutaway_Click);
            // 
            // ATSCADASVGEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(724, 333);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADASVGEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGV Editor";
            this.tabElement.ResumeLayout(false);
            this.tabBase.ResumeLayout(false);
            this.tabBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            this.tabAddValue.ResumeLayout(false);
            this.tabAlarm.ResumeLayout(false);
            this.tabCutaway.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageExtend;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog filePicker;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabBase;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TabPage tabAddValue;
        private System.Windows.Forms.TabPage tabAlarm;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lstvSVGValueItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colProperties;
        private System.Windows.Forms.ColumnHeader colTagName;
        private Extension.Color.TextBoxColor txtColor;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lstvSVGAlarmItem;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colTagLowName;
        private System.Windows.Forms.ColumnHeader colTagHighName;
        private System.Windows.Forms.TabPage tabCutaway;
        private System.Windows.Forms.ListView lstvSVGCutawayItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnEditCutaway;
    }
}