using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Image = System.Windows.Controls.Image;

namespace Vaseis
{
    public class ImageAndNameComponent : ContentControl
    {
        #region Protected Properties 

        protected StackPanel ImageAndNameStackPanel { get; private set; }

        /// <summary>
        /// The profile Picture
        /// </summary>
        protected Image Image { get; private set; }

        /// <summary>
        /// The username
        /// </summary>
        protected TextBlock NameTextBlock { get; private set; }

        /// <summary>
        /// The tool tip
        /// </summary>
        protected ToolTipComponent TextToolTip { get; private set; }

        #endregion

        #region Dependency Properties

        #region ImagePath
        
        /// <summary>
        /// The path of the image
        /// </summary>
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ImagePath"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(nameof(ImagePath), typeof(string), typeof(ImageAndNameComponent), new PropertyMetadata(OnImagePathChanged));

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property
        /// </summary>
        private static void OnImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ImageAndNameComponent;

            sender.OnImagePathChangedCore(e);
        }

        #endregion

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
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(ImageAndNameComponent));

        #endregion

        #endregion

        #region Protected Methods


        #endregion

        /// <summary>
        /// Handles the change of the <see cref="HeaderImageAndTitleComponent.ImagePath"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnImagePathChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        #region Constructors
        public ImageAndNameComponent() 
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
            // A stack panel for the image and title 
            ImageAndNameStackPanel = new StackPanel()
            {
                // Has horizontal orientation
                Orientation = Orientation.Vertical,
                Margin = new Thickness(24)
            };

            // An image that for the Image property
            Image = new Image()
            {
                Margin = new Thickness(8),
                Width = 240,
                Height = 240,
                HorizontalAlignment = HorizontalAlignment.Center,
                // Fills the area it's to
                Stretch = Stretch.Fill,
                // Clips the image to a circle
                Clip = new EllipseGeometry(new Point(120, 120), 120, 120),
            };

            // Add's to the left stack panel the image
            ImageAndNameStackPanel.Children.Add(Image);

            // A text block for the Title property
            NameTextBlock = new TextBlock()
            {
                DataContext = Text,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = Styles.DarkGray.HexToBrush(),
                FontWeight = FontWeights.Bold,
                FontFamily = Styles.Calibri,
                FontSize = 44,
                TextTrimming = TextTrimming.CharacterEllipsis,
            };

            // Binds the text property of the text block to the Username property
            NameTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });
            // Creates the tool tip
            TextToolTip = new ToolTipComponent();
            // Binds its text property to the text
            TextToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding((nameof(Text)))
            {
                Source = this
            });
            NameTextBlock.ToolTip = TextToolTip;

            ImageAndNameStackPanel.Children.Add(NameTextBlock);

            Content = ImageAndNameStackPanel;
        }

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnImagePathChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (string)e.NewValue;

            if (newValue == null)
            {
                Image.Source = null;
            }
            else
            {
                // Create the bitmap image
                var bitmapImage = new BitmapImage(new Uri(newValue));

                // Set it to the image
                Image.Source = bitmapImage;
            }

            // Further handle the change
            OnImagePathChanged(e);
        }

        #endregion

    }
}
