using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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

        #region Bio

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

        /// <summary>
        /// The Bio's Title
        /// </summary>
        public string BioTextTitle
        {
            get { return (string)GetValue(BioTextTitleProperty); }
            set { SetValue(BioTextTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BioTextTitle"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BioTextTitleProperty = DependencyProperty.Register(nameof(BioTextTitle), typeof(string), typeof(BioComponent));


        #endregion

        #region IsEditable

        /// <summary>
        /// The is editable bool
        /// </summary>
        public bool IsEditable
        {
            get { return (bool)GetValue(IsEdidableProperty); }
            set { SetValue(IsEdidableProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="IsEditable"/> dependency property
        /// </summary>
        public static readonly DependencyProperty IsEdidableProperty = DependencyProperty.Register(nameof(IsEditable), typeof(bool), typeof(BioComponent), new PropertyMetadata(EditText));


        /// <summary>
        /// Handles the change of the <see cref="IsEditable"/> property
        /// </summary>
        private static void EditText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as BioComponent;

            sender.EditTextCore(e);
        }

        #endregion

        #region SaveEdit

        /// <summary>
        /// The is save edits bool
        /// </summary>
        public bool SaveEdit
        {
            get { return (bool)GetValue(SaveEditProperty); }
            set { SetValue(SaveEditProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="SaveEdit"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SaveEditProperty = DependencyProperty.Register(nameof(SaveEdit), typeof(bool), typeof(BioComponent), new PropertyMetadata(AfterEditText));

        /// <summary>
        /// Handles the change of the <see cref="SaveEdit"/> property
        /// </summary>
        private static void AfterEditText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as BioComponent;

            sender.AfterEditTextCore(e);
        }

        #endregion

        #endregion

        #region Constructors 

        public BioComponent() 
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="BioComponent.IsEditable"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void EditText(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the change of the <see cref="BioComponent.SaveEdit"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void AfterEditText(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the bio's title
            BioTitle = new TextBlock()
            {
                Text = BioTextTitle,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush(),
                Margin = new Thickness(0, 0, 0, 12),
                Width = 960
            };

            // Binds the text property of the BiooTitle to the BioTextTitle property
            BioTitle.SetBinding(TextBlock.TextProperty, new Binding(nameof(BioTextTitle))
            {
                Source = this
            });


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
                Visibility = Visibility.Collapsed,
                Width = 940
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

        /// <summary>
        /// Handles the change of the <see cref="EditCommand"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void EditTextCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                // Collapse the block
                BioTextBlock.Visibility = Visibility.Collapsed;
                // Show the box
                BioTextBox.Visibility = Visibility.Visible;
                // The box's text gets the block's text
                BioTextBox.Text = BioTextBlock.Text;
            }
            // If the edit is false...
            if(newValue == false)
            {
                // Collapse the box
                BioTextBlock.Visibility = Visibility.Visible;
                // Show the block
                BioTextBox.Visibility = Visibility.Collapsed;
            }
            // Calls the virtual method
            EditText(e);
        }

        /// <summary>
        /// Handles the change of the <see cref="EditCommand"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void AfterEditTextCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If save is true...
            if (newValue == true)
            {
                // Sets the text from the box to the block
                BioTextBlock.Text = BioTextBox.Text;
            }
            // Calls the virtual method
            AfterEditText(e);
        }

        #endregion
    }
}
