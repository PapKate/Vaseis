using MaterialDesignThemes.Wpf;

using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// Contains helper methods for the GUI components
    /// </summary>
    public static class StyleHelpers
    {
        /// <summary>
        /// Converts a hexadecimal value if correct to a brush color
        /// </summary>
        /// <param name="hexColor">The hexadecimal value of a color</param>
        /// <returns></returns>
        public static Brush HexToBrush(string hexColor)
        {
            // Converts hex values to colors
            var brushConverter = new BrushConverter();
            // Parses the hex to a brush
            var colorBrush = (Brush)brushConverter.ConvertFrom("#" + hexColor);
            // Returns the color 
            return colorBrush;
        }

        /// <summary>
        /// Creates an icon from the material design by defining the icon's color and pack icon kind
        /// </summary>
        /// <param name="color">The icon's color</param>
        /// <param name="iconName">The pack icon kind name</param>
        /// <returns></returns>
        public static PackIcon MaterialIcon(string color, PackIconKind iconName)
        {
            // A pack icon from material design
            var materialIcon = new PackIcon()
            {
                Kind = iconName,
                Foreground = HexToBrush(color)
            };
            // Returns the material icon
            return materialIcon;
        }
    }
}
