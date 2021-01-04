using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// Provides helpers for creating predefined controls
    /// </summary>
    public static class ControlsFactory
    {
        /// <summary>
        /// Creates an add button for the pages
        /// </summary>
        /// <param name="background">The hexadecimal value representing a color</param>
        public static Button CreateAddButton(string background)
        {
            // Creates the add button
            var addButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Background = background.HexToBrush(),
                Height = 52,
                Width = 120,
                Margin = new Thickness(0, 0, 0, 32),
                Content = new TextBlock()
                {
                    Foreground = Styles.White.HexToBrush(),
                    FontSize = 28,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Styles.Calibri,
                    Text = "Add"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(addButton, new CornerRadius(8));
            
            // Returns the button
            return addButton;
        }


        /// <summary>
        /// Creates a square button with a pack icon
        /// </summary>
        /// <param name="packIconKind"></param>
        /// <returns></returns>
        public static Button CreateControlButton(PackIconKind packIconKind)
        {
            var button = new Button()
            {
                Content = new PackIcon()
                {
                    Kind = packIconKind,
                    Width = 36,
                    Height = 36,

                Foreground = Styles.White.HexToBrush(),


              },
                Width = 40,
                Height = 40,
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            ButtonAssist.SetCornerRadius(button, new CornerRadius(8));

            return button;
        }

        /// <summary>
        /// Creates an add button for the pages
        /// </summary>
        /// <param name="background">The hexadecimal value representing a color</param>
        public static Button CreateAddButton(string background)
        {
            // Creates the add button
            var addButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Background = background.HexToBrush(),
                Height = 52,
                Width = 120,
                Margin = new Thickness(0, 0, 0, 32),
                Content = new TextBlock()
                {
                    Foreground = Styles.White.HexToBrush(),
                    FontSize = 28,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Styles.Calibri,
                    Text = "Add"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(addButton, new CornerRadius(8));

            // Returns the button
            return addButton;
        }


        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as an edit button
        /// </summary>
        /// <returns></returns>
        public static Button CreateEditButton()
        {
            var button = CreateControlButton(PackIconKind.Edit);

            button.Background = StyleHelpers.HexToBrush(Styles.DarkPink);

            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a close button
        /// </summary>
        /// <returns></returns>
        public static Button CreateCloseButton()
        {
            var button = CreateControlButton(PackIconKind.Close);

            button.Background = StyleHelpers.HexToBrush(Styles.Red);

            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a back button
        /// </summary>
        /// <returns></returns>
        public static Button CreateBackButton()
        {
            var button = CreateControlButton(PackIconKind.ArrowLeft);

            button.Background = StyleHelpers.HexToBrush(Styles.Green);
           

            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a check button
        /// </summary>
        /// <returns></returns>
        public static Button CreateCheckButton()
        {
            var button = CreateControlButton(PackIconKind.Check);

            button.Background = StyleHelpers.HexToBrush(Styles.Green);
      
            return button;
        }

    }
}