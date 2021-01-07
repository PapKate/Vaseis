using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

using static Vaseis.Styles;

namespace Vaseis
{ 
    public class NavigationButtonComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The nav button with the image
        /// </summary>
        protected Button NavigationButton { get; private set; }

        /// <summary>
        /// The tool tip's text
        /// </summary>
        protected TextBlock NavTextBlock { get; private set; }

        /// <summary>
        /// The material design's icon for the nav button
        /// </summary>
        protected PackIcon NavButtonIcon { get; private set; }

        /// <summary>
        /// The tool tip's border
        /// </summary>
        protected Border ToolTipBorder { get; private set; }


        #endregion

        #region Dependency Properties

        #region Button Icon

        /// <summary>
        /// The material design icon
        /// </summary>
        public PackIconKind ButtonIcon
        {
            get { return (PackIconKind)GetValue(ButtonIconProperty); }
            set { SetValue(ButtonIconProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ButtonIcon"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ButtonIconProperty = DependencyProperty.Register(nameof(ButtonIcon), typeof(PackIconKind), typeof(NavigationButtonComponent));

        #endregion

        #region Button Text

        /// <summary>
        /// The button's text
        /// </summary>
        public string ButtonText
        {
            get { return GetValue(ButtonTextProperty).ToString(); }
            set { SetValue(ButtonTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ButtonText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register(nameof(ButtonText), typeof(string), typeof(NavigationButtonComponent));

        #endregion

        #endregion

        #region Constructors

        public NavigationButtonComponent()
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
            ToolTipBorder = new Border()
            {
                CornerRadius = new CornerRadius(8),
                Background = White.HexToBrush(),
                BorderThickness = new Thickness(4),
                Effect = ControlsFactory.CreateShadow()
            };

            // Creates the nav text
            NavTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = Calibri,
                FontSize = 20,
                Background = White.HexToBrush(),
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(8)
            };
            // Binds the button text property to the nav text block's text
            NavTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(ButtonText))
            {
                Source = this
            });

            ToolTipBorder.Child = NavTextBlock;

            NavButtonIcon = new PackIcon()
            {
                Width = 36,
                Height = 36,
                Foreground = White.HexToBrush()
            };
            // Binds the button icon property to the nav icon's kind
            NavButtonIcon.SetBinding(PackIcon.KindProperty, new Binding(nameof(ButtonIcon))
            {
                Source = this
            });

            // Creates the nav button
            NavigationButton = new Button()
            {
                Width = 52,
                Height = 52,
                Background = DarkBlue.HexToBrush(),
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
                Content = NavButtonIcon,
                ToolTip = ToolTipBorder
            };
            // Adds a corner radius to turn it into a circle
            ButtonAssist.SetCornerRadius(NavigationButton, new CornerRadius(26));
            // When button on focus calls method
            NavigationButton.GotFocus += OnGotFocusHandler;
            // When button loses focus calls method
            NavigationButton.LostFocus += OnLostFocusHandler;

            // Sets the component's content as the nav stack panel
            Content = NavigationButton;
        }
        
        /// <summary>
        /// When button gains focus turns it to dark pink
        /// </summary>
        private void OnGotFocusHandler(object sender, RoutedEventArgs e)
        {
            NavigationButton = e.Source as Button;
            NavigationButton.Background = DarkPink.HexToBrush();
        }
        /// <summary>
        /// When button loses focus turns it to dark blue
        /// </summary>
        private void OnLostFocusHandler(object sender, RoutedEventArgs e)
        {
            NavigationButton = e.Source as Button;
            NavigationButton.Background = DarkBlue.HexToBrush();
        }

        #endregion

    }
}
