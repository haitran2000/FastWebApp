using System;
using System.ComponentModel;
using System.Linq;

namespace ATSCADAWebApp.Extension.Method
{
    public static class TypeExtensions
    {
        public static string GetDisplayName(this Type type)
        {
            var displayName = type
              .GetCustomAttributes(typeof(DisplayNameAttribute), true)
              .FirstOrDefault() as DisplayNameAttribute;

            if (displayName != null)
                return displayName.DisplayName;

            return string.Empty;
        }
    }
}
