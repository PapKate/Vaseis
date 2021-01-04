using static Vaseis.Styles;

using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace Vaseis
{
    public class ErrorDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        protected TextBlock ErrorBlock { get; private set; }

        #endregion

        #region Dependency Properties

        #region Error Message

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public string ErrorMessage
        {
            get { return GetValue(ErrorMessageProperty).ToString(); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ErrorMessage"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register(nameof(ErrorMessage), typeof(string), typeof(ErrorDialogComponent));

        #endregion

        #endregion

        #region Constructors

        public ErrorDialogComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            DialogTitle.Text = "Error";
            DialogTitle.Foreground = Red.HexToBrush();

            ErrorBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(24),
                Foreground = DarkGray.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                
            };

            // Binds the text property of the error block to the error message property
            ErrorBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(ErrorMessage))
            { 
                Source = this
            });

            InputWrapPanel.Children.Add(ErrorBlock);

            var okButton = StyleHelpers.CreateDialogButton(Red, "OK");
            okButton.Width = 164;
            okButton.Click += CloseDialogOnClick;

            DialogButtonsStackPanel.Children.Add(okButton);

            Content = DialogHost;
        }

        #endregion
    }
}
