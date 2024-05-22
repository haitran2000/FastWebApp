
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Component.SVGValue
{
    partial class ATSCADASVGValueItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADASVGValueItemEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageProperties = new System.Windows.Forms.TabPage();
            this.panelSettingAnimation = new System.Windows.Forms.Panel();
            this.inputNumber = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panelAnimation = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel_status_text = new System.Windows.Forms.Panel();
            this.textGood = new System.Windows.Forms.TextBox();
            this.textBad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_status_color = new System.Windows.Forms.Panel();
            this.txtGoodColor = new System.Windows.Forms.TextBox();
            this.txtBadColor = new System.Windows.Forms.TextBox();
            this.btnPickGoodColor = new System.Windows.Forms.Button();
            this.btnPickBadColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.importFileExcel = new System.Windows.Forms.Button();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.cbbProperties = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDataTagName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.lstvSVGValueItem = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panel = new System.Windows.Forms.Panel();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.tabElement.SuspendLayout();
            this.pageProperties.SuspendLayout();
            this.panelSettingAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumber)).BeginInit();
            this.panel_status_text.SuspendLayout();
            this.panel_status_color.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(885, 688);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(777, 688);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(356, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(9, 55);
            this.lblTagName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(76, 17);
            this.lblTagName.TabIndex = 17;
            this.lblTagName.Text = "Tag name:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(25, 17);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "ID:";
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageProperties);
            this.tabElement.Location = new System.Drawing.Point(11, 10);
            this.tabElement.Margin = new System.Windows.Forms.Padding(4);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(974, 270);
            this.tabElement.TabIndex = 17;
            // 
            // pageProperties
            // 
            this.pageProperties.Controls.Add(this.panelSettingAnimation);
            this.pageProperties.Controls.Add(this.panel_status_text);
            this.pageProperties.Controls.Add(this.panel_status_color);
            this.pageProperties.Controls.Add(this.importFileExcel);
            this.pageProperties.Controls.Add(this.cbbType);
            this.pageProperties.Controls.Add(this.lbType);
            this.pageProperties.Controls.Add(this.cbbProperties);
            this.pageProperties.Controls.Add(this.label1);
            this.pageProperties.Controls.Add(this.cbxDataTagName);
            this.pageProperties.Controls.Add(this.lblName);
            this.pageProperties.Controls.Add(this.lblTagName);
            this.pageProperties.Controls.Add(this.txtName);
            this.pageProperties.Location = new System.Drawing.Point(4, 25);
            this.pageProperties.Margin = new System.Windows.Forms.Padding(4);
            this.pageProperties.Name = "pageProperties";
            this.pageProperties.Padding = new System.Windows.Forms.Padding(4);
            this.pageProperties.Size = new System.Drawing.Size(966, 241);
            this.pageProperties.TabIndex = 0;
            this.pageProperties.Text = "Properties";
            this.pageProperties.UseVisualStyleBackColor = true;
            // 
            // panelSettingAnimation
            // 
            this.panelSettingAnimation.Controls.Add(this.inputNumber);
            this.panelSettingAnimation.Controls.Add(this.label7);
            this.panelSettingAnimation.Controls.Add(this.panelAnimation);
            this.panelSettingAnimation.Controls.Add(this.btnSubmit);
            this.panelSettingAnimation.Location = new System.Drawing.Point(456, 17);
            this.panelSettingAnimation.Name = "panelSettingAnimation";
            this.panelSettingAnimation.Size = new System.Drawing.Size(514, 224);
            this.panelSettingAnimation.TabIndex = 44;
            // 
            // inputNumber
            // 
            this.inputNumber.Location = new System.Drawing.Point(97, 18);
            this.inputNumber.Name = "inputNumber";
            this.inputNumber.Size = new System.Drawing.Size(120, 22);
            this.inputNumber.TabIndex = 9;
            this.inputNumber.ValueChanged += new System.EventHandler(this.inputNumber_TextChanged);
            this.inputNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputNumber_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "BandCount";
            // 
            // panelAnimation
            // 
            this.panelAnimation.AutoScroll = true;
            this.panelAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnimation.Location = new System.Drawing.Point(9, 53);
            this.panelAnimation.Name = "panelAnimation";
            this.panelAnimation.Size = new System.Drawing.Size(494, 164);
            this.panelAnimation.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(415, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 31);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Generate";
            this.btnSubmit.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // panel_status_text
            // 
            this.panel_status_text.Controls.Add(this.textGood);
            this.panel_status_text.Controls.Add(this.textBad);
            this.panel_status_text.Controls.Add(this.label4);
            this.panel_status_text.Controls.Add(this.label5);
            this.panel_status_text.Location = new System.Drawing.Point(461, 17);
            this.panel_status_text.Name = "panel_status_text";
            this.panel_status_text.Size = new System.Drawing.Size(430, 102);
            this.panel_status_text.TabIndex = 43;
            // 
            // textGood
            // 
            this.textGood.Location = new System.Drawing.Point(119, 56);
            this.textGood.Name = "textGood";
            this.textGood.Size = new System.Drawing.Size(292, 22);
            this.textGood.TabIndex = 40;
            // 
            // textBad
            // 
            this.textBad.Location = new System.Drawing.Point(119, 18);
            this.textBad.Name = "textBad";
            this.textBad.Size = new System.Drawing.Size(290, 22);
            this.textBad.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Good Text :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Bad Text :";
            // 
            // panel_status_color
            // 
            this.panel_status_color.Controls.Add(this.txtGoodColor);
            this.panel_status_color.Controls.Add(this.txtBadColor);
            this.panel_status_color.Controls.Add(this.btnPickGoodColor);
            this.panel_status_color.Controls.Add(this.btnPickBadColor);
            this.panel_status_color.Controls.Add(this.label3);
            this.panel_status_color.Controls.Add(this.label2);
            this.panel_status_color.Location = new System.Drawing.Point(461, 17);
            this.panel_status_color.Name = "panel_status_color";
            this.panel_status_color.Size = new System.Drawing.Size(411, 88);
            this.panel_status_color.TabIndex = 37;
            // 
            // txtGoodColor
            // 
            this.txtGoodColor.Location = new System.Drawing.Point(128, 56);
            this.txtGoodColor.Name = "txtGoodColor";
            this.txtGoodColor.Size = new System.Drawing.Size(179, 22);
            this.txtGoodColor.TabIndex = 42;
            // 
            // txtBadColor
            // 
            this.txtBadColor.Location = new System.Drawing.Point(128, 18);
            this.txtBadColor.Name = "txtBadColor";
            this.txtBadColor.Size = new System.Drawing.Size(179, 22);
            this.txtBadColor.TabIndex = 41;
            // 
            // btnPickGoodColor
            // 
            this.btnPickGoodColor.Location = new System.Drawing.Point(313, 53);
            this.btnPickGoodColor.Name = "btnPickGoodColor";
            this.btnPickGoodColor.Size = new System.Drawing.Size(85, 28);
            this.btnPickGoodColor.TabIndex = 40;
            this.btnPickGoodColor.Text = "Pick Color";
            this.btnPickGoodColor.UseVisualStyleBackColor = true;
            this.btnPickGoodColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPickBadColor
            // 
            this.btnPickBadColor.Location = new System.Drawing.Point(313, 16);
            this.btnPickBadColor.Name = "btnPickBadColor";
            this.btnPickBadColor.Size = new System.Drawing.Size(85, 28);
            this.btnPickBadColor.TabIndex = 39;
            this.btnPickBadColor.Text = "Pick Color";
            this.btnPickBadColor.UseVisualStyleBackColor = true;
            this.btnPickBadColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Good Color :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Bad Color :";
            // 
            // importFileExcel
            // 
            this.importFileExcel.Location = new System.Drawing.Point(87, 172);
            this.importFileExcel.Margin = new System.Windows.Forms.Padding(4);
            this.importFileExcel.Name = "importFileExcel";
            this.importFileExcel.Size = new System.Drawing.Size(356, 36);
            this.importFileExcel.TabIndex = 30;
            this.importFileExcel.Text = "Import";
            this.importFileExcel.UseVisualStyleBackColor = true;
            this.importFileExcel.Click += new System.EventHandler(this.importButton_Click);
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            "Bool",
            "Int",
            "Word",
            "Float",
            "Double",
            "String"});
            this.cbbType.Location = new System.Drawing.Point(87, 129);
            this.cbbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(356, 24);
            this.cbbType.TabIndex = 23;
            this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(9, 132);
            this.lbType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(44, 17);
            this.lbType.TabIndex = 22;
            this.lbType.Text = "Type:";
            // 
            // cbbProperties
            // 
            this.cbbProperties.FormattingEnabled = true;
            this.cbbProperties.Items.AddRange(new object[] {
            "Value",
            "Status",
            "Animation"});
            this.cbbProperties.Location = new System.Drawing.Point(87, 85);
            this.cbbProperties.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbProperties.Name = "cbbProperties";
            this.cbbProperties.Size = new System.Drawing.Size(356, 24);
            this.cbbProperties.TabIndex = 21;
            this.cbbProperties.SelectedIndexChanged += new System.EventHandler(this.cbbProperties_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Properties:";
            // 
            // cbxDataTagName
            // 
            this.cbxDataTagName.InRuntime = false;
            this.cbxDataTagName.Location = new System.Drawing.Point(88, 52);
            this.cbxDataTagName.Margin = new System.Windows.Forms.Padding(5);
            this.cbxDataTagName.Name = "cbxDataTagName";
            this.cbxDataTagName.Size = new System.Drawing.Size(355, 26);
            this.cbxDataTagName.TabIndex = 3;
            this.cbxDataTagName.TagName = "";
            // 
            // lstvSVGValueItem
            // 
            this.lstvSVGValueItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTagName,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstvSVGValueItem.FullRowSelect = true;
            this.lstvSVGValueItem.GridLines = true;
            this.lstvSVGValueItem.HideSelection = false;
            this.lstvSVGValueItem.Location = new System.Drawing.Point(11, 288);
            this.lstvSVGValueItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstvSVGValueItem.MultiSelect = false;
            this.lstvSVGValueItem.Name = "lstvSVGValueItem";
            this.lstvSVGValueItem.Size = new System.Drawing.Size(970, 392);
            this.lstvSVGValueItem.TabIndex = 18;
            this.lstvSVGValueItem.UseCompatibleStateImageBehavior = false;
            this.lstvSVGValueItem.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 100;
            // 
            // colTagName
            // 
            this.colTagName.Text = "Tag name";
            this.colTagName.Width = 198;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Properties";
            this.columnHeader1.Width = 212;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 188;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Attribute";
            this.columnHeader3.Width = 270;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(121, 688);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(9, 688);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(337, 688);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 28);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(229, 688);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 28);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(12, 50);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(360, 300);
            this.panel.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(100, 22);
            this.inputTextBox.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(200, 10);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            // 
            // ATSCADASVGValueItemEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(994, 729);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstvSVGValueItem);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADASVGValueItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SVGValue Item Editor";
            this.tabElement.ResumeLayout(false);
            this.pageProperties.ResumeLayout(false);
            this.pageProperties.PerformLayout();
            this.panelSettingAnimation.ResumeLayout(false);
            this.panelSettingAnimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumber)).EndInit();
            this.panel_status_text.ResumeLayout(false);
            this.panel_status_text.PerformLayout();
            this.panel_status_color.ResumeLayout(false);
            this.panel_status_color.PerformLayout();
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
        private System.Windows.Forms.ListView lstvSVGValueItem;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTagName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagName;
        private Extension.Color.TextBoxColor txtColor;
        private System.Windows.Forms.ComboBox cbbProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button importFileExcel;
        private System.Windows.Forms.Panel panel_status_color;
        private System.Windows.Forms.Button btnPickGoodColor;
        private System.Windows.Forms.Button btnPickBadColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_status_text;
        private System.Windows.Forms.TextBox textGood;
        private System.Windows.Forms.TextBox textBad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox txtGoodColor;
        private System.Windows.Forms.TextBox txtBadColor;
        private Panel panelSettingAnimation;
        private Label label7;
        private Panel panelAnimation;
        private Button btnSubmit;
        private NumericUpDown inputNumber;
    }
}