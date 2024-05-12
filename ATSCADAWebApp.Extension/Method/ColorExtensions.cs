using System.Drawing;
using System.Linq;
using System.Reflection;

namespace ATSCADAWebApp.Extension.Method
{
    public static class ColorExtensions
    {
        public static string ColorToHex(this System.Drawing.Color color)
        {
            try
            {
                var hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
                return hex;
            }
            catch
            {
                return "#FFFFFF";
            }            
        }

        public static System.Drawing.Color HexToColor(this string hex)
        {
            try
            {
                var color = ColorTranslator.FromHtml(hex);
                return color;
            }
            catch
            {
                return System.Drawing.Color.Transparent;
            }
            
        }

        public static string GetColorName(this System.Drawing.Color color)
        {
            var colorProperties = typeof(System.Drawing.Color)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(System.Drawing.Color));
            foreach (var colorProperty in colorProperties)
            {
                var colorPropertyValue = (System.Drawing.Color)colorProperty.GetValue(null, null);
                if (colorPropertyValue.R == color.R
                       && colorPropertyValue.G == color.G
                       && colorPropertyValue.B == color.B)
                {
                    return colorPropertyValue.Name;
                }
            }
            return ColorTranslator.ToHtml(color);
        }
    }
}
