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
        protected Button SideMenuButton { get; private set; }

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

        #region PageIcon

        /// <summary>
        /// The material design icon
        /// </summary>
        public PackIconKind PageIcon
        {
            get { return (PackIconKind)GetValue(PageIconProperty); }
            set { SetValue(PageIconProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PageIcon"/> dependency property
        /// </summary>
        public static readonly DependencyProperty PageIconProperty = DependencyProperty.Register(nameof(PageIcon), typeof(PackIconKind), typeof(SideMenuButtonComponent));

        #endregion

        #region PageTitle

        public string PageTitle
        {
            get { return GetValue(PageTitleProperty).ToString(); }
            set { SetValue(PageTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PageTitle"/> dependency property
        /// </summary>
        public static readonly DependencyProperty PageTitleProperty = DependencyProperty.Register(nameof(PageTitle), typeof(string), typeof(SideMenuButtonComponent));

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
            ButtonDataStackPanel = new StackPanel()
            {
                Width = 274,
                Height = 76,
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            ButtonIcon = new PackIcon()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(4),
                //Kind = PackIconKind.AddAlarm,
                Foreground = DarkBlue.HexToBrush(),
                Width = 40,
                Height = 40
            };

            // Binds the text property of the text block to the PageIcon property
            ButtonIcon.SetBinding(PackIcon.KindProperty, new Binding(nameof(PageIcon))
            {
                Source = this
            });

            ButtonDataStackPanel.Children.Add(ButtonIcon);

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
            ButtonTitle.SetBinding(TextBlock.TextProperty, new Binding(nameof(PageTitle))
            {
                Source = this
            });

            ButtonDataStackPanel.Children.Add(ButtonTitle);

            SideMenuButton = new Button()
            {
                Style = MaterialDesignStyles.FlatButton,
                Height = 80,
                Width = double.NaN,
                Padding = new Thickness(8),
                Content = ButtonDataStackPanel
            };

            Content = SideMenuButton;
        }

        #endregion
    }
}
