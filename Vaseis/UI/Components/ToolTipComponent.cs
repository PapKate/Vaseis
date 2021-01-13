using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;


namespace Vaseis
{
    public class ToolTipComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The tool tip's border
        /// </summary>
        protected Border ToolTipBorder { get; private set; }

        /// <summary>
        /// The tool tip's text
        /// </summary>
        protected TextBlock ToolTipTextBlock { get; private set; }

        #endregion

        #region Dependency Properties

        #region Text

        /// <summary>
        /// The text
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(ToolTipComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ToolTipComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the tool tip's border
            ToolTipBorder = new Border()
            {
                CornerRadius = new CornerRadius(8),
                Background = White.HexToBrush(),
                BorderThickness = new Thickness(4),
                Effect = ControlsFactory.CreateShadow()
            };

            // Creates the tool tip's text
            ToolTipTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = Calibri,
                FontSize = 20,
                Background = White.HexToBrush(),
                Foreground = DarkPink.HexToBrush(),
                Margin = new Thickness(8),
            };

            // Binds the text property of the text block to the Username property
            ToolTipTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });

            // Adds the text block to the border
            ToolTipBorder.Child = ToolTipTextBlock;

            // Returns the border
            Content = ToolTipBorder;
        }

        #endregion


    }
}
