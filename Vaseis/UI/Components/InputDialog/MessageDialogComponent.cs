
using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A message dialog
    /// </summary>
    public class MessageDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        protected TextBlock MessageBlock { get; private set; }

        protected Button OkButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region Color

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public Brush BrushColor
        {
            get { return (Brush)GetValue(HexColorProperty); }
            set { SetValue(HexColorProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BrushColor"/> dependency property
        /// </summary>
        public static readonly DependencyProperty HexColorProperty = DependencyProperty.Register(nameof(BrushColor), typeof(Brush), typeof(MessageDialogComponent));

        #endregion

        #region Title

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(MessageDialogComponent));

        #endregion

        #region Message

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public string Message
        {
            get { return GetValue(MessageProperty).ToString(); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Message"/> dependency property
        /// </summary>
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message), typeof(string), typeof(MessageDialogComponent));

        #endregion

        #endregion

        #region Constructors

        public MessageDialogComponent()
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
            DialogTitle.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            DialogTitle.SetBinding(TextBlock.ForegroundProperty, new Binding(nameof(BrushColor))
            {
                Source = this
            });

            //DialogTitle.Foreground = DarkBlue.HexToBrush();

            MessageBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(24),
                Foreground = DarkGray.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
            };

            // Binds the text property of the message block to the message property
            MessageBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Message))
            {
                Source = this
            });

            InputWrapPanel.Children.Add(MessageBlock);

            OkButton = new Button()
            {
                Background = DarkBlue.HexToBrush(),
                Height = 40,
                Width = 164,
                Content = new TextBlock()
                {
                    Foreground = White.HexToBrush(),
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "OK"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += CloseDialogOnClick;

            OkButton.SetBinding(Button.BackgroundProperty, new Binding(nameof(BrushColor))
            {
                Source = this
            });

            DialogButtonsStackPanel.Children.Add(OkButton);

            Content = DialogHost;
        }

        #endregion
    }
}
