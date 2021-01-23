using MaterialDesignThemes.Wpf;

using Microsoft.EntityFrameworkCore;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The login page
    /// </summary>
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

        #region Protected Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

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
            //the LoginPageGrid
            PageGrid = new Grid()
            {
                Background = DarkBlue.HexToBrush()
            };

            AppName = new TextBlock()
            {
                Text = "Cotton-field Workers",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 70,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
            };

            WelcomeBackText = new TextBlock()
            {
                Text = "Welcome Back!",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 50,
                FontWeight = FontWeights.Bold,
                Foreground = DarkPink.HexToBrush(),
                Margin = new Thickness(15)

            };

            UsernameTextBlock = new TextBlock()
            {
                Text = "Username",
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
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(8, 0, 8, 0)
            };

            PasswordTextBlock = new TextBlock()
            {
                Text = "Password",
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = DarkBlue.HexToBrush(),
            };

            EnterPassword = new PasswordBox()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(8, 0, 8, 0)
            };

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
                },
                Command = new RelayCommand(async () => 
                {
                    // Attempt to get the user with the inserted credentials
                    var user = await Services.GetDataStorage.GetUser(EnterUsername.Text, EnterPassword.Password);

                    // If a user isn't found...
                    if (user == null)
                    {
                        // The user entered invalid credentials...
                        var errorDialog = new MessageDialogComponent()
                        {
                            Message = "Invalid credentials! Please try again.",
                            Title = "Error",
                            BrushColor = Red.HexToBrush(),
                            IsDialogOpen = true
                        };
                        // Adds the dialog to the grid
                        PageGrid.Children.Add(errorDialog);

                        // Return
                        return;
                    }

                    // Fire the event
                    UserConnected(this, user);
                })
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
          

            // creates a border hosy the password textbox
            var passwordBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = DarkBlue.HexToBrush(),
                Background = White.HexToBrush(),
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
                Background = GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            PageGrid.Children.Add(middleGrid);

            //the column (stack panel for the login components to be added in)
            var loginStackPanel = new StackPanel()
            {
                Background = GhostWhite.HexToBrush(),
                Margin = new Thickness(32, -100, 32, 0),
                VerticalAlignment = VerticalAlignment.Center,
                
            };

            loginStackPanel.Children.Add(AppName);
            loginStackPanel.Children.Add(WelcomeBackText);
            loginStackPanel.Children.Add(usernameStackPanel);
            loginStackPanel.Children.Add(passwordStackPanel);
            loginStackPanel.Children.Add(LoginButton);

            middleGrid.Children.Add(loginStackPanel);

            Content = PageGrid;

        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fires every time a user connects to the application
        /// </summary>
        public event EventHandler<UserDataModel> UserConnected = (sender, e) => { };

        #endregion
    }
}
