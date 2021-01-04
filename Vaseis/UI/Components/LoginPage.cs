using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    class LoginPage : ContentControl   
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
        public Button Login { get; private set; }

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
        /// Identifies the <see cref="Username"/> dependency property
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

        private void CreateGUI()
        {


           // Wrong alignment & size
           //Misses X or wrong button & listeners?


            //on eof thew three colums in login screen (the central one)
            #region Login Column

            AppName = new TextBlock()
            {
                Text = "Courabiedes",
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 38,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
            };


            WelcomeBackText = new TextBlock()
            {
                Text = "Welcome Back",
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkPink.HexToBrush(),
            };


            UsernameTextBlock = new TextBlock()
            {
                Text = "Courabiedes",
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
            };

            EnterUsername = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
            };

            PasswordTextBlock = new TextBlock()
            {
                Text = "Password",
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
            };

            EnterPassword = new PasswordBox()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
            };

            Login = new Button()
            {
                Style = MaterialDesignStyles.RaisedButton,
                Content = "Login",
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = Styles.DarkPink.HexToBrush(),
                Height = double.NaN,
                Margin = new Thickness(15),
                Padding = new Thickness(8),
                BorderThickness = new Thickness(0),
            };

            //creates a border hosy the username textbox
            var usernameBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                CornerRadius = new CornerRadius(10),
            };

            //creates a border hosy the password textbox
            var passwordBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                CornerRadius = new CornerRadius(10),
            };

            usernameBorder.Child = EnterUsername;
            passwordBorder.Child = EnterPassword;

           
            //the column (stackpanel for the login components to be added in)
            var loginStackPanel = new StackPanel()
            {
                Background = Styles.GhostWhite.HexToBrush(),
                Width = 180,
            };

            loginStackPanel.Children.Add(AppName);
            loginStackPanel.Children.Add(WelcomeBackText);
            loginStackPanel.Children.Add(UsernameTextBlock);
            loginStackPanel.Children.Add(usernameBorder);
            loginStackPanel.Children.Add(PasswordTextBlock);
            loginStackPanel.Children.Add(passwordBorder);
            loginStackPanel.Children.Add(Login);

            #endregion

            #region LoginPage

            //the LoginPageGrid
            var loginPageGrid = new Grid();

            for (var i = 0; i <= 2; i++)
            {
                loginPageGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
            }

            //ColumnDefinition firstColumn = new ColumnDefinition();
            //ColumnDefinition loginColumn = new ColumnDefinition();
            //ColumnDefinition thirdColumn = new ColumnDefinition();

            //loginPageGrid.ColumnDefinitions.Add(firstColumn);

            //how?

            //loginColumn.Children.Add(loginStackPanel);

            //loginPageGrid.set

            var firstColumn = new StackPanel() {
                Background = Styles.DarkBlue.HexToBrush()

        };
            var secondColumn = new StackPanel() { };

            loginPageGrid.Children.Add(firstColumn);
            loginPageGrid.Children.Add(loginStackPanel);
            loginPageGrid.Children.Add(secondColumn);

            Content = loginPageGrid;

            #endregion



        }

        #endregion



    }
}
