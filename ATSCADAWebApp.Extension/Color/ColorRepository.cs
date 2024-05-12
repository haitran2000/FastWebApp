using System;
using System.Windows.Forms;

namespace ATSCADAWebApp.Extension.Color
{
    public class ColorRepository
    {
        #region FIELDS
      
        private static readonly Lazy<ColorRepository> lazy = new Lazy<ColorRepository>(() => new ColorRepository());

        #endregion

        #region PROPERTIES

        public static ColorRepository Instance => lazy.Value;

        public ColorDialog ColorDialog { get; private set; } 

        #endregion

        private ColorRepository()
        {
            ColorDialog = new ColorDialog();
        }
    }
}
