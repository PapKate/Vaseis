using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    public class LoginPage : ContentControl   
    {
        #region Public Properties

        /// <summary>
        /// The login screen app name
        /// </summary>
        public TextBlock AppName { get; set; }

        /// <summary>
        /// The login screen welcome back text
        /// </summary>
        public TextBlock WelcomeBackText { get; set; }

        /// <summary>
        /// The login screen username textblock
        /// </summary>
        public TextBlock UsernameTextBlock { get; set; }

        /// <summary>
        /// The login screen username textbox
        /// </summary>
        public TextBox EnterUsername { get; set; }

        /// <summary>
        /// The login screen password textblock
        /// </summary>
        public TextBlock PasswordTextBlock { get; set; }

        /// <summary>
        /// The login screen password textbox
        /// </summary>
        public PasswordBox EnterPassword { get; private set; }

        /// <summary>
        /// The login screen login button
        /// </summary>
        public Button LoginButton { get; private set; }

        #endregion

        #region Dependency properties 

        #region Username

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username
        {
            get { return GetValue(UsernameProperty).ToString(); }
            set { SetValue(UsernameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Username"/> dependency property
        /// </summary>
        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof(Username), typeof(string), typeof(LoginPage));

        #endregion

        #region Password
        /// <summary>
        /// The user's username
        /// </summary>
        public string Password
        {
            get { return GetValue(PasswordProperty).ToString(); }
            set { SetValue(PasswordProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Password"/> dependency property
        /// </summary>
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(nameof(Password), typeof(string), typeof(LoginPage));

        #endregion

        #endregion

        #region Constructor 

        public LoginPage()
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
            #region Login Column

            AppName = new TextBlock()
            {
                Text = "Courabiedes",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 77,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush(),
            };


            WelcomeBackText = new TextBlock()
            {
                Text = "Welcome Back!",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 50,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkPink.HexToBrush(),
                Margin = new Thickness(15)

            };


            UsernameTextBlock = new TextBlock()
            {
                Text = "username",
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
            };

            EnterUsername = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
                Margin = new Thickness(8, 0, 8, 0)
            };

            // Binds the text property of the text box to the Username property
            UsernameTextBlock.SetBinding(TextBox.TextProperty, new Binding(nameof(Username))
            {
                Source = this
            });

            PasswordTextBlock = new TextBlock()
            {
                Text = "password",
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
            };

            EnterPassword = new PasswordBox()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
                Margin = new Thickness(8, 0, 8, 0)
            };

            // Binds the text property of the text boxto the Password property
            PasswordTextBlock.SetBinding(TextBox.TextProperty, new Binding(nameof(Password))
            {
                Source = this
            });

            LoginButton = new Button()
            {
                Width = 160,
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 45,
                Margin = new Thickness(32),
                BorderThickness = new Thickness(0),
                Content = new TextBlock()
                {
                    FontSize = 28,
                    FontFamily = Calibri,
                    FontWeight = FontWeights.Bold,
                    Foreground = White.HexToBrush(),
                    Text = "Login"
                }
            };
            // Sets the button's corner radius
            ButtonAssist.SetCornerRadius(LoginButton, new CornerRadius(8));

            //creates a border hosy the username textbox
            var usernameBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = DarkBlue.HexToBrush(),
                Background = White.HexToBrush(),
                CornerRadius = new CornerRadius(8),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 320,
            };

            usernameBorder.Child = EnterUsername;
          

            //creates a border hosy the password textbox
            var passwordBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                CornerRadius = new CornerRadius(8),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 320,

            };

            passwordBorder.Child = EnterPassword;

            var passwordStackPanel = new StackPanel() 
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(24)
            };

            passwordStackPanel.Children.Add(PasswordTextBlock);
            passwordStackPanel.Children.Add(passwordBorder);


            var usernameStackPanel = new StackPanel() 
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(32)
            };

            usernameStackPanel.Children.Add(UsernameTextBlock);
            usernameStackPanel.Children.Add(usernameBorder);

            var middleGrid = new Grid()
            {
                Background = Styles.GhostWhite.HexToBrush(),
            };

            //the column (stackpanel for the login components to be added in)
            var loginStackPanel = new StackPanel()
            {
                Background = Styles.GhostWhite.HexToBrush(),
                Margin = new Thickness(0, -100, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                
            };

            loginStackPanel.Children.Add(AppName);
            loginStackPanel.Children.Add(WelcomeBackText);
            loginStackPanel.Children.Add(usernameStackPanel);
            loginStackPanel.Children.Add(passwordStackPanel);
            loginStackPanel.Children.Add(LoginButton);

            #endregion

            #region LoginPage

            //the LoginPageGrid
            var loginPageGrid = new Grid()
            { 
                Background = DarkBlue.HexToBrush()
            };

            loginPageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });


            loginPageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(640, GridUnitType.Pixel)
            });


            loginPageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            middleGrid.Children.Add(loginStackPanel);

            loginPageGrid.Children.Add(middleGrid);

            Grid.SetColumn(middleGrid, 1);



            Content = loginPageGrid;

            #endregion

        }

        #endregion
    }
}
