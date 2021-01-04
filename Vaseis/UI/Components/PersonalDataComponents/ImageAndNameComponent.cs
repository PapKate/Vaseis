using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace Vaseis.UI.Components.PersonalDataComponents
{
    public class ImageAndNameComponent : ContentControl
    {
        #region Protected Properties 

        /// <summary>
        /// The profile Picture
        /// </summary>
        public Image Image { get; private set; }

        /// <summary>
        /// The username
        /// </summary>
        public TextBlock UsernameTextBlock { get; private set; }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// The path of the image
        /// </summary>
        public string ImagePath
        {
            get { return GetValue(ImagePathProperty).ToString(); }
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

        /// <summary>
        /// The username
        /// </summary>
        public string Username
        {
            get { return GetValue(UsernameProperty).ToString(); }
            set { SetValue(UsernameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Username"/> dependency property
        /// </summary>
        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof(Username), typeof(string), typeof(ImageAndNameComponent));

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="HeaderImageAndTitleComponent.ImagePath"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnImagePathChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Constructors
        public ImageAndNameComponent() 
        {
           CreateGUI();
        }

        #endregion

        #region Private Methods


        private void CreateGUI()
        {

            // A stack panel for the image and title 
            var ImageAndUsernameStackPanel = new StackPanel()
            {
                // Has horizontal orientation
                Orientation = Orientation.Horizontal,
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
            ImageAndUsernameStackPanel.Children.Add(Image);

            //Binding?


            // A text block for the Title property
            UsernameTextBlock = new TextBlock()
            {
                DataContext = Username,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Styles.GhostWhite.HexToBrush(),
                FontWeight = FontWeights.Bold,
                FontStyle = FontStyles.Normal,
                FontFamily = Styles.Calibri,
                FontSize = 32
            };

            // Binds the text property of the text block to the Username property
            UsernameTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Username))
            {
                Source = this
            });

            ImageAndUsernameStackPanel.Children.Add(UsernameTextBlock);

            //image & username alignment -> center enw!,
            //trexctblocks apo katw alignment -> left 

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
