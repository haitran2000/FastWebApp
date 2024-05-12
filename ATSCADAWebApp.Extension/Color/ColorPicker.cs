using ATSCADAWebApp.Extension.Method;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ATSCADAWebApp.Extension.Color
{
    public class ColorPicker : ComboBox
    {
        public string Color
        {
            get
            {
                var color = System.Drawing.Color.FromName(this.Text);
                return color.ColorToHex();
            }
            set
            {
                var color = value.HexToColor();
                this.Text = color.GetColorName();
            }
        }

        public ColorPicker()
        {
            this.MaxDropDownItems = 10;
            this.IntegralHeight = false;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawItem += (sender, e) => OnComboxBoxDrawItem(e);
            this.SelectedIndexChanged += (sender, e) => OnComboxBoxSelectedIndexChanged();
        }

        public void Load()
        {                     
            this.DataSource = typeof(System.Drawing.Color).GetProperties()
                .Where(x => x.PropertyType == typeof(System.Drawing.Color))
                .Select(x => x.GetValue(null)).ToList();
        }

        private void OnComboxBoxDrawItem(DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    var text = this.GetItemText(this.Items[e.Index]);
                    var color = (System.Drawing.Color)this.Items[e.Index];
                    var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                        2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                    var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                        e.Bounds.Right, e.Bounds.Bottom);
                    using (var b = new SolidBrush(color))
                        e.Graphics.FillRectangle(b, r1);
                    e.Graphics.DrawRectangle(Pens.Black, r1);
                    TextRenderer.DrawText(e.Graphics, text, this.Font, r2,
                        this.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }
            }
            catch { }
        }

        private void OnComboxBoxSelectedIndexChanged()
        {
            this.Enabled = false;
            this.Enabled = true;
        }
    }
}
