using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The base for all the side menus
    /// </summary>
    public abstract class BaseSideMenuComponent : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The tab control
        /// </summary>
        public TabControl TabControl { get; }

        /// <summary>
        /// The user
        /// </summary>
        public UserDataModel User { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The side menu's grid
        /// </summary>
        protected Grid SideMenuGrid { get; private set; }

        /// <summary>
        /// The sideMenu buttons' container
        /// </summary>
        protected StackPanel SideMenuButtonsContainer { get; private set; }

        /// <summary>
        /// The side menu's border
        /// </summary>
        protected Border SideMenuBorder { get; private set; }
        
        /// <summary>
        /// The profile button
        /// </summary>
        protected SideMenuButtonComponent ProfileButton { get; private set; }

        /// <summary>
        /// The log out button
        /// </summary>
        protected SideMenuButtonComponent LogOutButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public BaseSideMenuComponent(TabControl tabControl, UserDataModel user)
        {
            User = user ?? throw new System.ArgumentNullException(nameof(user));
            TabControl = tabControl ?? throw new System.ArgumentNullException(nameof(tabControl));
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a <see cref="SideMenuButtonComponent"/> to the <see cref="SideMenuButtonsContainer"/>
        /// </summary>
        /// <param name="text">The text of the button</param>
        /// <param name="icon">The icon of the button</param>
        /// <returns></returns>
        protected SideMenuButtonComponent CreateAndAddSideMenuButton(string text, PackIconKind icon)
        {
            // Create the button
            var button = new SideMenuButtonComponent()
            {
                Text = text,
                Icon = icon
            };

            // Add it to the container
            SideMenuButtonsContainer.Children.Add(button);

            // Create the button
            return button;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            SideMenuGrid = new Grid();

            // Create the side menu border
            SideMenuBorder = new Border()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                
                Effect = ControlsFactory.CreateShadow()
            };

            // Create the buttons container
            SideMenuButtonsContainer = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = White.HexToBrush(),

            };
            SideMenuGrid.Children.Add(SideMenuButtonsContainer);
            // Create the profile button
            ProfileButton = CreateAndAddSideMenuButton("Profile", PackIconKind.AccountCircle);
            // On click opens in a tab the profile page
            ProfileButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                var tabItem = new TabItemComponent(TabControl)
                {
                    Text = "Profile",
                    Icon = PackIconKind.AccountCircle,
                    Content = new ProfilePage(User),
                };
                // Adds it to the tab control items
                TabControl.Items.Add(tabItem);

                tabItem.IsSelected = true;
            });

            // Creates the log out button
            LogOutButton = new SideMenuButtonComponent() 
            { 
                Text = "Log out", 
                Icon = PackIconKind.ExitRun 
            };
            // Adds it to the grid
            SideMenuGrid.Children.Add(LogOutButton);
            // Sets it at the bottom
            LogOutButton.VerticalAlignment = VerticalAlignment.Bottom;
            // On click fires the event
            LogOutButton.SideMenuButton.Click += DisconnectUserOnClick;

            // Add the container to the border
            SideMenuBorder.Child = SideMenuGrid;

            Content = SideMenuBorder;
        }

        /// <summary>
        /// Disconnects a user on click
        /// Fires the event in the main window
        /// </summary>
        private void DisconnectUserOnClick(object sender, RoutedEventArgs e)
        {
            // Calls the event
            UserDisconnected(this, User);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fires every time a user connects to the application
        /// </summary>
        public event EventHandler<UserDataModel> UserDisconnected = (sender, e) => { };

        #endregion

    }
}
