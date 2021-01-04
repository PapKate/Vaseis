using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;
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
        public static Brush HexToBrush(this string hexColor)
        {
            // Converts hex values to colors
            var brushConverter = new BrushConverter();
            // Parses the hex to a brush
            var colorBrush = (Brush)brushConverter.ConvertFrom("#" + hexColor);
            // Returns the color 
            return colorBrush;
        }

        /// <summary>
        /// Converts a  hexadecimal value if correct to a windows media color
        /// </summary>
        /// <param name="hexColor">The hexadecimal value of a color</param>
        /// <returns></returns>
        public static Color HexToColor(this string hexColor)
        {
            // Parses a string to a windows media color and returns it
            return (Color)ColorConverter.ConvertFromString("#" + hexColor);
        }

        public static Button CreateDialogButton(string background, string text)
        {
            // Creates the dialog button
            var dialogButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = background.HexToBrush(),
                Height = 40,
                Width = 200,
                Margin = new Thickness(0, 32, 0, 32),
                Content = new TextBlock()
                {
                    Foreground = Styles.White.HexToBrush(),
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Styles.Calibri,
                    Text = text
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(dialogButton, new CornerRadius(8));

            // Returns the button
            return dialogButton;
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
