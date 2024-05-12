using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    partial class AboutView : Form
    {
        public AboutView()
        {
            InitializeComponent();
            this.txtDescription.Text =
                $"FastWeb is one of the softwares is developed by ATSCADA Lab.\r\n \r\n" +
                $"To support developers to design a website quickly and does not need lots of knowledge about web development languages.";            
        }      
    }
}
