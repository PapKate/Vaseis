using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    public class BioComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The grid containing the bio text block and text box
        /// </summary>
        protected Grid BioTextGrid { get; private set; }

        /// <summary>
        /// The bio text box
        /// </summary>
        public TextBox BioTextBox { get; private set; }

        /// <summary>
        /// The Bio Header Text
        /// </summary>
        protected TextBlock BioTitle { get; private set; }

        /// <summary>
        /// The bio block's scroll viewer
        /// </summary>
        protected ScrollViewer BioScrollViwer { get; private set; }

        /// <summary>
        /// The Bio 
        /// </summary>
        public TextBlock BioTextBlock { get; private set; }

        /// <summary>
        /// The stack panel containing bio text and the title
        /// </summary>
        protected StackPanel BioStackPanel { get; private set; }

        /// <summary>
        /// The bio's border
        /// </summary>
        protected Border BioBorder { get; private set; }
        #endregion

        #region Dependency Properties

        /// <summary>
        /// The User's Bio
        /// </summary>
        public string BioText
        {
            get { return (string)GetValue(BioProperty); }
            set { SetValue(BioProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BioText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BioProperty = DependencyProperty.Register(nameof(BioText), typeof(string), typeof(BioComponent));

        #endregion

        #region Constructors 

        public BioComponent() 
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the bio's title
            BioTitle = new TextBlock()
            {
                Text = "Bio",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush(),
                Margin = new Thickness(0, 0, 0, 12)
            };

            // Creates the bio's grid
            BioTextGrid = new Grid();

            // Creates the bio's text block
            BioTextBlock = new TextBlock()
            { 
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
            };

            // Binds the text property of the expander to the Bio property
            BioTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(BioText))
            {
                Source = this
            });

            // Creates the bio's scroll viewer
            BioScrollViwer = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Top,
                // With content the bio's text block
                Content = BioTextBlock,
                CanContentScroll = true,
                MaxHeight = 200
            };
            // Adds it to the bio's grid
            BioTextGrid.Children.Add(BioScrollViwer);

            // Creates the bio's text box
            BioTextBox = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                MaxHeight = 200,
                Visibility = Visibility.Collapsed
            };
            // Adds it to the bio's grid
            BioTextGrid.Children.Add(BioTextBox);

            BioStackPanel = new StackPanel()
            {
                Background = Styles.White.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(24),
            };
            // Adds the title to the stack panel
            BioStackPanel.Children.Add(BioTitle);
            // Adds the scroll viewer to the stack panel
            BioStackPanel.Children.Add(BioTextGrid);

            // Bio's border
            BioBorder = new Border()
            {
                // Adds corner radius
                CornerRadius = new CornerRadius(8),
                // No thickness
                BorderThickness = new Thickness(0), 
                // Adds a shadow
                Effect = ControlsFactory.CreateShadow(),
                Background = Styles.White.HexToBrush(),
                Width = 1000,
                Margin = new Thickness(24),
            };

            BioBorder.Child = BioStackPanel;

            Content = BioBorder;
        }

        #endregion
    }
}
