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
                    Height = 36
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
    }
}