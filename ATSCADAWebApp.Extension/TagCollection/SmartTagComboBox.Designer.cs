namespace ATSCADAWebApp.ToolExtensions.TagCollection
{
    partial class SmartTagComboBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxSmartTag = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxSmartTag
            // 
            this.cbxSmartTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSmartTag.FormattingEnabled = true;
            this.cbxSmartTag.Location = new System.Drawing.Point(0, 0);
            this.cbxSmartTag.Name = "cbxSmartTag";
            this.cbxSmartTag.Size = new System.Drawing.Size(121, 21);
            this.cbxSmartTag.TabIndex = 0;
            // 
            // SmartTagComboBoxUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxSmartTag);
            this.Name = "SmartTagComboBoxUser";
            this.Size = new System.Drawing.Size(121, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxSmartTag;
    }
}
