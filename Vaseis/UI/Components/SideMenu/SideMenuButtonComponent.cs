using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Windows.Data;

namespace Vaseis
{
    /// <summary>
    /// Represents a side menu button
    /// </summary>
    public class SideMenuButtonComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// A side menu's button
        /// </summary>
        public Button SideMenuButton { get; private set; }

        /// <summary>
        /// The stack panel inside the button
        /// </summary>
        protected StackPanel ButtonDataStackPanel { get; private set; }

        /// <summary>
        /// The button's icon
        /// From material design
        /// </summary>
        protected PackIcon ButtonIcon { get; private set; } 

        /// <summary>
        /// The button's Title
        /// </summary>
        protected TextBlock ButtonTitle { get; private set; }

       
        #endregion

        #region Dependency Properties

        #region Icon

        /// <summary>
        /// The material design icon
        /// </summary>
        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(PageIconProperty); }
            set { SetValue(PageIconProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property
        /// </summary>
        public static readonly DependencyProperty PageIconProperty = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(SideMenuButtonComponent));

        #endregion

        #region Title

        public string Text
        {
            get { return GetValue(PageTitleProperty).ToString(); }
            set { SetValue(PageTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property
        /// </summary>
        public static readonly DependencyProperty PageTitleProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(SideMenuButtonComponent));

        #endregion

        #endregion

        #region Constructors

        public SideMenuButtonComponent()
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
            // Creates the button stack panel
            ButtonDataStackPanel = new StackPanel()
            {
                Width = 274,
                Height = 76,
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                
            };

            // Creates the button icon
            ButtonIcon = new PackIcon()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(4),
                Foreground = DarkBlue.HexToBrush(),
                Width = 40,
                Height = 40
            };

            // Binds the text property of the text block to the PageIcon property
            ButtonIcon.SetBinding(PackIcon.KindProperty, new Binding(nameof(Icon))
            {
                Source = this
            });

            // Adds the button icon to the button's stack panel
            ButtonDataStackPanel.Children.Add(ButtonIcon);

            // Creates the button name text
            ButtonTitle = new TextBlock()
            {
                Margin = new Thickness(12, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = DarkBlue.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 28,
                Width = 216,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontWeight = FontWeights.Normal,
                //Text = "Evaluation results"
            };
           
            // Binds the text property of the text block to the PageTitle property
            ButtonTitle.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });

            // Adds the button's name to the stack panel
            ButtonDataStackPanel.Children.Add(ButtonTitle);

            // Creates a button for the stack panel
            SideMenuButton = new Button()
            {
                Style = MaterialDesignStyles.FlatButton,
                Height = 80,
                Width = double.NaN,
                Padding = new Thickness(8),
                BorderThickness = new Thickness(0),
                Background = White.HexToBrush(),
                // With content the button's stack panel
                Content = ButtonDataStackPanel
            };
            
            // Sets the component's content to the side menu button
            Content = SideMenuButton;
        }

        #endregion
    }
}
