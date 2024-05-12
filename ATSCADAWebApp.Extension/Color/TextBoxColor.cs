using ATSCADAWebApp.Extension.Method;
using System.Windows.Forms;

namespace ATSCADAWebApp.Extension.Color
{
    public partial class TextBoxColor : UserControl
    {
        public string Color
        {
            get => this.txtColor.Text;
            set => this.txtColor.Text = value;
        }

        public TextBoxColor()
        {
            InitializeComponent();

            this.pnlColor.Click += (sender, e) => ChooseColor();
            this.txtColor.TextChanged += (sender, e) => BindColor();

            this.txtColor.Text = "#008080";
        }

        private void ChooseColor()
        {
            var colorDialog = ColorRepository.Instance.ColorDialog;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                this.txtColor.Text = color.ColorToHex();
            }
        }

        private void BindColor()
        {            
            var color = this.txtColor.Text.HexToColor();
            this.pnlColor.BackColor = color;
        }
    }

    
}
