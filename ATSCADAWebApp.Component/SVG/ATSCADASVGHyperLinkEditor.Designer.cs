
namespace ATSCADAWebApp.Component.SVGHyperLink
{
    partial class ATSCADASVGHyperLinkItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATSCADASVGHyperLinkItemEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabElement = new System.Windows.Forms.TabControl();
            this.pageProperties = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColorLink = new System.Windows.Forms.TextBox();
            this.cbxDataTagName = new ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox();
            this.lstvSVGHyperLinkItem = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.btnCancel.Location = new System.Drawing.Point(624, 482);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(516, 482);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(23, 62);
            this.lblTagName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(76, 17);
            this.lblTagName.TabIndex = 17;
            this.lblTagName.Text = "Tag name:";
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
            // 
            // tabElement
            // 
            this.tabElement.Controls.Add(this.pageProperties);
            this.tabElement.Location = new System.Drawing.Point(11, 10);
            this.tabElement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabElement.Name = "tabElement";
            this.tabElement.SelectedIndex = 0;
            this.tabElement.Size = new System.Drawing.Size(713, 143);
            this.tabElement.TabIndex = 17;
            // 
            // pageProperties
            // 
            this.pageProperties.Controls.Add(this.label3);
            this.pageProperties.Controls.Add(this.txtType);
            this.pageProperties.Controls.Add(this.label2);
            this.pageProperties.Controls.Add(this.txtColorLink);
            this.pageProperties.Controls.Add(this.cbxDataTagName);
            this.pageProperties.Controls.Add(this.lblName);
            this.pageProperties.Controls.Add(this.lblTagName);
            this.pageProperties.Controls.Add(this.txtName);
            this.pageProperties.Location = new System.Drawing.Point(4, 25);
            this.pageProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageProperties.Name = "pageProperties";
            this.pageProperties.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageProperties.Size = new System.Drawing.Size(705, 114);
            this.pageProperties.TabIndex = 0;
            this.pageProperties.Text = "Properties";
            this.pageProperties.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(482, 21);
            this.txtType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(119, 22);
            this.txtType.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Color";
            // 
            // txtColorLink
            // 
            this.txtColorLink.Location = new System.Drawing.Point(482, 58);
            this.txtColorLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtColorLink.Name = "txtColorLink";
            this.txtColorLink.Size = new System.Drawing.Size(119, 22);
            this.txtColorLink.TabIndex = 22;
            // 
            // cbxDataTagName
            // 
            this.cbxDataTagName.InRuntime = false;
            this.cbxDataTagName.Location = new System.Drawing.Point(107, 58);
            this.cbxDataTagName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbxDataTagName.Name = "cbxDataTagName";
            this.cbxDataTagName.Size = new System.Drawing.Size(229, 26);
            this.cbxDataTagName.TabIndex = 3;
            this.cbxDataTagName.TagName = "";
            // 
            // lstvSVGHyperLinkItem
            // 
            this.lstvSVGHyperLinkItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTagName,
            this.columnHeader1,
            this.columnHeader2});
            this.lstvSVGHyperLinkItem.FullRowSelect = true;
            this.lstvSVGHyperLinkItem.GridLines = true;
            this.lstvSVGHyperLinkItem.HideSelection = false;
            this.lstvSVGHyperLinkItem.Location = new System.Drawing.Point(11, 161);
            this.lstvSVGHyperLinkItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstvSVGHyperLinkItem.MultiSelect = false;
            this.lstvSVGHyperLinkItem.Name = "lstvSVGHyperLinkItem";
            this.lstvSVGHyperLinkItem.Size = new System.Drawing.Size(707, 314);
            this.lstvSVGHyperLinkItem.TabIndex = 18;
            this.lstvSVGHyperLinkItem.UseCompatibleStateImageBehavior = false;
            this.lstvSVGHyperLinkItem.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 100;
            // 
            // colTagName
            // 
            this.colTagName.Text = "TagName";
            this.colTagName.Width = 146;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 212;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Color";
            this.columnHeader2.Width = 239;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(123, 482);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(11, 482);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(339, 482);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(100, 28);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(231, 482);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(100, 28);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // ATSCADASVGHyperLinkItemEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(729, 514);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstvSVGHyperLinkItem);
            this.Controls.Add(this.tabElement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATSCADASVGHyperLinkItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SVGValue HyperLink Editor";
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
        private System.Windows.Forms.ListView lstvSVGHyperLinkItem;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTagName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private ATSCADAWebApp.ToolExtensions.TagCollection.SmartTagComboBox cbxDataTagName;
        private Extension.Color.TextBoxColor txtColor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColorLink;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}