using MaterialDesignThemes.Wpf;

using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// The button that points to an employee's profile
    /// </summary>
    public class DataButtonComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The stack panel containing a user's name and username
        /// </summary>
        protected StackPanel DataStackPanel { get; private set; }

        /// <summary>
        /// The bold text
        /// </summary>
        protected TextBlock TitleTextBlock { get; private set; }

        /// <summary>
        /// The normal text
        /// </summary>
        protected TextBlock TextTextBlock { get; private set; }

        /// <summary>
        /// The button representing a user
        /// </summary>
        protected Button DataButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region Title

        /// <summary>
        /// The user's username
        /// </summary>
        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(DataButtonComponent));

        #endregion

        #region Text

        /// <summary>
        /// The user's full name
        /// </summary>
        public string Text
        {
            get { return GetValue(TextProperty).ToString(); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(DataButtonComponent));

        #endregion
        
        #endregion

        #region Constructors

        public DataButtonComponent()
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
            // Creates the stack panel
            DataStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            // Creates the text's text block
            TextTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                TextAlignment = TextAlignment.Center
            };

            // Binds the text property of the text block to the text property
            TextTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });
            // Adds it to the stack panel
            DataStackPanel.Children.Add(TextTextBlock);

            // Creates the title's text block
            TitleTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            };

            // Binds the text property of the text block to the title property
            TitleTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            // Adds it to the stack panel
            DataStackPanel.Children.Add(TitleTextBlock);

            // Creates the button
            DataButton = new Button()
            {
                Style = MaterialDesignStyles.RaisedButton,
                Height = double.NaN,
                Margin = new Thickness(24),
                Padding = new Thickness(8),
                BorderThickness = new Thickness(0),
                Content = DataStackPanel
            };
            // Binds the background property to the background
            DataButton.SetBinding(Button.BackgroundProperty, new Binding(nameof(Background))
            {
                Source = this
            });
            // Sets a corner radius to the button
            ButtonAssist.SetCornerRadius(DataButton, new CornerRadius(8));
            
            // Sets the component's content as the button
            Content = DataButton;
        }
     
        #endregion
    }
}

