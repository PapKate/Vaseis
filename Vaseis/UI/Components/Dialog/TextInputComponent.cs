using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using MaterialDesignThemes.Wpf;
using System.Windows.Data;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// A generic text box with a hint bind 
    /// </summary>
    public class TextInputComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The input to enter
        /// </summary>
        protected TextBlock HintTitleBlock { get; private set; }

        /// <summary>
        /// The input area
        /// </summary>
        public TextBox InputTextBox { get; private set; }

        #endregion

        #region Dependency Properties

        #region HintText

        /// <summary>
        /// The required input text helper
        /// </summary>
        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="HintText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(nameof(HintText), typeof(string), typeof(TextInputComponent));

        #endregion

        #region Text

        /// <summary>
        /// The required input text helper
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextInputComponent));


        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextInputComponent()
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
            // Creates the input's text box
            InputTextBox = new TextBox()
            {
                FontSize = 24,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0)
            };
            // Binds the input text box's text property to text
            InputTextBox.SetBinding(TextBox.TextProperty, new Binding(nameof(Text))
            { 
                Source = this
            });

            // Creates the hint text
            HintTitleBlock = new TextBlock()
            {
                Foreground = DarkPink.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                TextTrimming = TextTrimming.CharacterEllipsis,
                IsHitTestVisible = false,
            };

            // Binds the hint's text to the hint text property
            HintTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(HintText))
            {
                Source = this
            });

            // Sets the text's color to dark pink
            HintAssist.SetForeground(InputTextBox, DarkPink.HexToBrush());
            // Sets the hint to the input text box
            HintAssist.SetHint(InputTextBox, HintTitleBlock);

            // Sets the component's content to the input text box
            Content = InputTextBox;
        }

        #endregion

    }
}
