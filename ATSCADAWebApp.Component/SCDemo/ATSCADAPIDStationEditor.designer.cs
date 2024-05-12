
namespace ATSCADAWebApp.Component.PIDStation
{
    partial class ATSCADAPIDStationEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADAPIDStationEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageBase = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pageExtend = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGridColumn = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.pageMeters = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDataTagName = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxTag_Pressure4 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_Pressure3 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_Pressure2 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_Pressure1 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmHighValue2 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmLowValue2 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmHighValue1 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmLowValue1 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmHighValue4 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmLowValue4 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmHighValue3 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.cbxTag_alarmLowValue3 = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.tabElement.SuspendLayout();
            this.pageBase.SuspendLayout();
            this.pageExtend.SuspendLayout();
            this.pageMeters.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(428, 434);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(320, 434);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageBase);
            this.tabElement.Controls.Add(this.pageExtend);
            this.tabElement.Controls.Add(this.pageMeters);
            this.tabElement.Controls.Add(this.tabPage1);
            this.tabElement.Location = new System.Drawing.Point(8, 10);
            this.tabElement.Margin = new System.Windows.Forms.Padding(4);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(523, 417);
            this.tabElement.TabIndex = 11;
            // 
            // pageBase
            // 
            this.pageBase.Controls.Add(this.label5);
            this.pageBase.Controls.Add(this.label4);
            this.pageBase.Controls.Add(this.txtDescription);
            this.pageBase.Controls.Add(this.lblDescription);
            this.pageBase.Controls.Add(this.txtName);
            this.pageBase.Controls.Add(this.lblName);
            this.pageBase.Location = new System.Drawing.Point(4, 25);
            this.pageBase.Margin = new System.Windows.Forms.Padding(4);
            this.pageBase.Name = "pageBase";
            this.pageBase.Padding = new System.Windows.Forms.Padding(4);
            this.pageBase.Size = new System.Drawing.Size(515, 388);
            this.pageBase.TabIndex = 0;
            this.pageBase.Text = "Base";
            this.pageBase.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(121, 53);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(368, 111);
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 55);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 17);
            this.lblDescription.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(368, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 17);
            this.lblName.TabIndex = 0;
            // 
            // pageExtend
            // 
            this.pageExtend.Controls.Add(this.label1);
            this.pageExtend.Controls.Add(this.txtGridColumn);
            this.pageExtend.Controls.Add(this.txtContent);
            this.pageExtend.Controls.Add(this.lblContent);
            this.pageExtend.Location = new System.Drawing.Point(4, 25);
            this.pageExtend.Margin = new System.Windows.Forms.Padding(4);
            this.pageExtend.Name = "pageExtend";
            this.pageExtend.Padding = new System.Windows.Forms.Padding(4);
            this.pageExtend.Size = new System.Drawing.Size(515, 388);
            this.pageExtend.TabIndex = 1;
            this.pageExtend.Text = "Extend";
            this.pageExtend.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Grid Column:";
            // 
            // txtGridColumn
            // 
            this.txtGridColumn.Location = new System.Drawing.Point(123, 63);
            this.txtGridColumn.Margin = new System.Windows.Forms.Padding(4);
            this.txtGridColumn.Name = "txtGridColumn";
            this.txtGridColumn.Size = new System.Drawing.Size(365, 22);
            this.txtGridColumn.TabIndex = 26;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(123, 23);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(365, 22);
            this.txtContent.TabIndex = 3;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(17, 28);
            this.lblContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(61, 17);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "Content:";
            // 
            // pageMeters
            // 
            this.pageMeters.Controls.Add(this.cbxTag_Pressure4);
            this.pageMeters.Controls.Add(this.label6);
            this.pageMeters.Controls.Add(this.label3);
            this.pageMeters.Controls.Add(this.label2);
            this.pageMeters.Controls.Add(this.lblDataTagName);
            this.pageMeters.Controls.Add(this.cbxTag_Pressure3);
            this.pageMeters.Controls.Add(this.cbxTag_Pressure2);
            this.pageMeters.Controls.Add(this.cbxTag_Pressure1);
            this.pageMeters.Location = new System.Drawing.Point(4, 25);
            this.pageMeters.Margin = new System.Windows.Forms.Padding(4);
            this.pageMeters.Name = "pageMeters";
            this.pageMeters.Size = new System.Drawing.Size(515, 388);
            this.pageMeters.TabIndex = 2;
            this.pageMeters.Text = "Meters";
            this.pageMeters.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Value 4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Value 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value 2";
            // 
            // lblDataTagName
            // 
            this.lblDataTagName.AutoSize = true;
            this.lblDataTagName.Location = new System.Drawing.Point(12, 20);
            this.lblDataTagName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataTagName.Name = "lblDataTagName";
            this.lblDataTagName.Size = new System.Drawing.Size(56, 17);
            this.lblDataTagName.TabIndex = 6;
            this.lblDataTagName.Text = "Value 1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxTag_alarmHighValue2);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cbxTag_alarmLowValue2);
            this.tabPage1.Controls.Add(this.cbxTag_alarmHighValue1);
            this.tabPage1.Controls.Add(this.cbxTag_alarmLowValue1);
            this.tabPage1.Controls.Add(this.cbxTag_alarmHighValue4);
            this.tabPage1.Controls.Add(this.cbxTag_alarmLowValue4);
            this.tabPage1.Controls.Add(this.cbxTag_alarmHighValue3);
            this.tabPage1.Controls.Add(this.cbxTag_alarmLowValue3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(515, 388);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Alarm Value";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 115);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "High Value 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 17);
            this.label12.TabIndex = 26;
            this.label12.Text = "Low Value 2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 45);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "High Value 1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "Low Value 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 251);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "High Value 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 214);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Low Value 4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 181);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "High Value 3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 148);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Low Value 3";
            // 
            // cbxTag_Pressure4
            // 
            this.cbxTag_Pressure4.InRuntime = false;
            this.cbxTag_Pressure4.Location = new System.Drawing.Point(116, 118);
            this.cbxTag_Pressure4.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_Pressure4.Name = "cbxTag_Pressure4";
            this.cbxTag_Pressure4.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_Pressure4.TabIndex = 11;
            this.cbxTag_Pressure4.TagName = "";
            // 
            // cbxTag_Pressure3
            // 
            this.cbxTag_Pressure3.InRuntime = false;
            this.cbxTag_Pressure3.Location = new System.Drawing.Point(116, 81);
            this.cbxTag_Pressure3.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_Pressure3.Name = "cbxTag_Pressure3";
            this.cbxTag_Pressure3.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_Pressure3.TabIndex = 9;
            this.cbxTag_Pressure3.TagName = "";
            // 
            // cbxTag_Pressure2
            // 
            this.cbxTag_Pressure2.InRuntime = false;
            this.cbxTag_Pressure2.Location = new System.Drawing.Point(116, 48);
            this.cbxTag_Pressure2.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_Pressure2.Name = "cbxTag_Pressure2";
            this.cbxTag_Pressure2.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_Pressure2.TabIndex = 7;
            this.cbxTag_Pressure2.TagName = "";
            // 
            // cbxTag_Pressure1
            // 
            this.cbxTag_Pressure1.InRuntime = false;
            this.cbxTag_Pressure1.Location = new System.Drawing.Point(116, 15);
            this.cbxTag_Pressure1.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_Pressure1.Name = "cbxTag_Pressure1";
            this.cbxTag_Pressure1.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_Pressure1.TabIndex = 5;
            this.cbxTag_Pressure1.TagName = "";
            // 
            // cbxTag_alarmHighValue2
            // 
            this.cbxTag_alarmHighValue2.InRuntime = false;
            this.cbxTag_alarmHighValue2.Location = new System.Drawing.Point(125, 110);
            this.cbxTag_alarmHighValue2.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmHighValue2.Name = "cbxTag_alarmHighValue2";
            this.cbxTag_alarmHighValue2.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmHighValue2.TabIndex = 27;
            this.cbxTag_alarmHighValue2.TagName = "";
            // 
            // cbxTag_alarmLowValue2
            // 
            this.cbxTag_alarmLowValue2.InRuntime = false;
            this.cbxTag_alarmLowValue2.Location = new System.Drawing.Point(125, 73);
            this.cbxTag_alarmLowValue2.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmLowValue2.Name = "cbxTag_alarmLowValue2";
            this.cbxTag_alarmLowValue2.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmLowValue2.TabIndex = 25;
            this.cbxTag_alarmLowValue2.TagName = "";
            // 
            // cbxTag_alarmHighValue1
            // 
            this.cbxTag_alarmHighValue1.InRuntime = false;
            this.cbxTag_alarmHighValue1.Location = new System.Drawing.Point(125, 40);
            this.cbxTag_alarmHighValue1.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmHighValue1.Name = "cbxTag_alarmHighValue1";
            this.cbxTag_alarmHighValue1.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmHighValue1.TabIndex = 23;
            this.cbxTag_alarmHighValue1.TagName = "";
            // 
            // cbxTag_alarmLowValue1
            // 
            this.cbxTag_alarmLowValue1.InRuntime = false;
            this.cbxTag_alarmLowValue1.Location = new System.Drawing.Point(125, 7);
            this.cbxTag_alarmLowValue1.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmLowValue1.Name = "cbxTag_alarmLowValue1";
            this.cbxTag_alarmLowValue1.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmLowValue1.TabIndex = 21;
            this.cbxTag_alarmLowValue1.TagName = "";
            // 
            // cbxTag_alarmHighValue4
            // 
            this.cbxTag_alarmHighValue4.InRuntime = false;
            this.cbxTag_alarmHighValue4.Location = new System.Drawing.Point(125, 246);
            this.cbxTag_alarmHighValue4.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmHighValue4.Name = "cbxTag_alarmHighValue4";
            this.cbxTag_alarmHighValue4.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmHighValue4.TabIndex = 19;
            this.cbxTag_alarmHighValue4.TagName = "";
            // 
            // cbxTag_alarmLowValue4
            // 
            this.cbxTag_alarmLowValue4.InRuntime = false;
            this.cbxTag_alarmLowValue4.Location = new System.Drawing.Point(125, 209);
            this.cbxTag_alarmLowValue4.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmLowValue4.Name = "cbxTag_alarmLowValue4";
            this.cbxTag_alarmLowValue4.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmLowValue4.TabIndex = 17;
            this.cbxTag_alarmLowValue4.TagName = "";
            // 
            // cbxTag_alarmHighValue3
            // 
            this.cbxTag_alarmHighValue3.InRuntime = false;
            this.cbxTag_alarmHighValue3.Location = new System.Drawing.Point(125, 176);
            this.cbxTag_alarmHighValue3.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmHighValue3.Name = "cbxTag_alarmHighValue3";
            this.cbxTag_alarmHighValue3.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmHighValue3.TabIndex = 15;
            this.cbxTag_alarmHighValue3.TagName = "";
            // 
            // cbxTag_alarmLowValue3
            // 
            this.cbxTag_alarmLowValue3.InRuntime = false;
            this.cbxTag_alarmLowValue3.Location = new System.Drawing.Point(125, 143);
            this.cbxTag_alarmLowValue3.Margin = new System.Windows.Forms.Padding(5);
            this.cbxTag_alarmLowValue3.Name = "cbxTag_alarmLowValue3";
            this.cbxTag_alarmLowValue3.Size = new System.Drawing.Size(369, 26);
            this.cbxTag_alarmLowValue3.TabIndex = 13;
            this.cbxTag_alarmLowValue3.TagName = "";
            // 
            // ATSCADAPIDStationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 474);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabElement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ATSCADAPIDStationEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo Component";
            this.tabElement.ResumeLayout(false);
            this.pageBase.ResumeLayout(false);
            this.pageBase.PerformLayout();
            this.pageExtend.ResumeLayout(false);
            this.pageExtend.PerformLayout();
            this.pageMeters.ResumeLayout(false);
            this.pageMeters.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabElement;
        private System.Windows.Forms.TabPage pageExtend;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGridColumn;
        private System.Windows.Forms.TabPage pageMeters;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_Pressure3;
        private System.Windows.Forms.Label label3;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_Pressure2;
        private System.Windows.Forms.Label label2;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_Pressure1;
        private System.Windows.Forms.Label lblDataTagName;
        private System.Windows.Forms.TabPage pageBase;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_Pressure4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmHighValue2;
        private System.Windows.Forms.Label label11;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmLowValue2;
        private System.Windows.Forms.Label label12;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmHighValue1;
        private System.Windows.Forms.Label label13;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmLowValue1;
        private System.Windows.Forms.Label label14;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmHighValue4;
        private System.Windows.Forms.Label label7;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmLowValue4;
        private System.Windows.Forms.Label label8;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmHighValue3;
        private System.Windows.Forms.Label label9;
        private ToolExtensions.TagCollection.SmartTagComboBox cbxTag_alarmLowValue3;
        private System.Windows.Forms.Label label10;
    }
}