
namespace ATSCADAWebApp.Component.SVGAlarm
{
    partial class ATSCADASVGAlarmItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADASVGAlarmItemEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageProperties = new System.Windows.Forms.TabPage();
            this.cbxDataTagLowName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDataTagHighName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDataTagName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.lstvSVGAlarmItem = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagLowName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagHighName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.tabElement.SuspendLayout();
            this.pageProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(622, 399);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(514, 399);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(23, 55);
            this.lblTagName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(76, 17);
            this.lblTagName.TabIndex = 17;
            this.lblTagName.Text = "Tag name:";
            this.lblTagName.Click += new System.EventHandler(this.lblTagName_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(25, 17);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "ID:";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageProperties);
            this.tabElement.Location = new System.Drawing.Point(13, 13);
            this.tabElement.Margin = new System.Windows.Forms.Padding(4);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(713, 124);
            this.tabElement.TabIndex = 17;
            this.tabElement.SelectedIndexChanged += new System.EventHandler(this.tabElement_SelectedIndexChanged);
            // 
            // pageProperties
            // 
            this.pageProperties.Controls.Add(this.cbxDataTagLowName);
            this.pageProperties.Controls.Add(this.label2);
            this.pageProperties.Controls.Add(this.cbxDataTagHighName);
            this.pageProperties.Controls.Add(this.label1);
            this.pageProperties.Controls.Add(this.cbxDataTagName);
            this.pageProperties.Controls.Add(this.lblName);
            this.pageProperties.Controls.Add(this.lblTagName);
            this.pageProperties.Controls.Add(this.txtName);
            this.pageProperties.Location = new System.Drawing.Point(4, 25);
            this.pageProperties.Margin = new System.Windows.Forms.Padding(4);
            this.pageProperties.Name = "pageProperties";
            this.pageProperties.Padding = new System.Windows.Forms.Padding(4);
            this.pageProperties.Size = new System.Drawing.Size(705, 95);
            this.pageProperties.TabIndex = 0;
            this.pageProperties.Text = "Properties";
            this.pageProperties.UseVisualStyleBackColor = true;
            this.pageProperties.Click += new System.EventHandler(this.pageProperties_Click);
            // 
            // cbxDataTagLowName
            // 
            this.cbxDataTagLowName.InRuntime = false;
            this.cbxDataTagLowName.Location = new System.Drawing.Point(454, 13);
            this.cbxDataTagLowName.Margin = new System.Windows.Forms.Padding(5);
            this.cbxDataTagLowName.Name = "cbxDataTagLowName";
            this.cbxDataTagLowName.Size = new System.Drawing.Size(229, 26);
            this.cbxDataTagLowName.TabIndex = 21;
            this.cbxDataTagLowName.TagName = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Low name:";
            // 
            // cbxDataTagHighName
            // 
            this.cbxDataTagHighName.InRuntime = false;
            this.cbxDataTagHighName.Location = new System.Drawing.Point(454, 52);
            this.cbxDataTagHighName.Margin = new System.Windows.Forms.Padding(5);
            this.cbxDataTagHighName.Name = "cbxDataTagHighName";
            this.cbxDataTagHighName.Size = new System.Drawing.Size(229, 26);
            this.cbxDataTagHighName.TabIndex = 19;
            this.cbxDataTagHighName.TagName = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "High name:";
            // 
            // cbxDataTagName
            // 
            this.cbxDataTagName.InRuntime = false;
            this.cbxDataTagName.Location = new System.Drawing.Point(108, 52);
            this.cbxDataTagName.Margin = new System.Windows.Forms.Padding(5);
            this.cbxDataTagName.Name = "cbxDataTagName";
            this.cbxDataTagName.Size = new System.Drawing.Size(229, 26);
            this.cbxDataTagName.TabIndex = 3;
            this.cbxDataTagName.TagName = "";
            this.cbxDataTagName.Load += new System.EventHandler(this.cbxDataTagName_Load);
            // 
            // lstvSVGAlarmItem
            // 
            this.lstvSVGAlarmItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTagName,
            this.colTagLowName,
            this.colTagHighName});
            this.lstvSVGAlarmItem.FullRowSelect = true;
            this.lstvSVGAlarmItem.GridLines = true;
            this.lstvSVGAlarmItem.HideSelection = false;
            this.lstvSVGAlarmItem.Location = new System.Drawing.Point(13, 145);
            this.lstvSVGAlarmItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstvSVGAlarmItem.MultiSelect = false;
            this.lstvSVGAlarmItem.Name = "lstvSVGAlarmItem";
            this.lstvSVGAlarmItem.Size = new System.Drawing.Size(707, 246);
            this.lstvSVGAlarmItem.TabIndex = 18;
            this.lstvSVGAlarmItem.UseCompatibleStateImageBehavior = false;
            this.lstvSVGAlarmItem.View = System.Windows.Forms.View.Details;
            this.lstvSVGAlarmItem.SelectedIndexChanged += new System.EventHandler(this.lstvSVGAlarmItem_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 81;
            // 
            // colTagName
            // 
            this.colTagName.Text = "Tag name";
            this.colTagName.Width = 147;
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
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(121, 399);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 399);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(337, 399);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 28);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(229, 399);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 28);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // ATSCADASVGAlarmItemEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(729, 443);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstvSVGAlarmItem);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADASVGAlarmItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SVGAlarm Item Editor";
            this.tabElement.ResumeLayout(false);
            this.pageProperties.ResumeLayout(false);
            this.pageProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageProperties;
        private System.Windows.Forms.ListView lstvSVGAlarmItem;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTagName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagName;
        private Extension.Color.TextBoxColor txtColor;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagLowName;
        private System.Windows.Forms.Label label2;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagHighName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colTagLowName;
        private System.Windows.Forms.ColumnHeader colTagHighName;
    }
}