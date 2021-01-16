using MaterialDesignThemes.Wpf;

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
        /// The sideMenu container
        /// </summary>
        protected StackPanel SideMenuContainer { get; private set; }

        /// <summary>
        /// The side menu's border
        /// </summary>
        protected Border SideMenuBorder { get; private set; }
        
        /// <summary>
        /// The profile button
        /// </summary>
        protected SideMenuButtonComponent ProfileButton { get; private set; }

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
        /// Creates and adds a <see cref="SideMenuButtonComponent"/> to the <see cref="SideMenuContainer"/>
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
            SideMenuContainer.Children.Add(button);

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
            // Create the side menu border
            SideMenuBorder = new Border()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                
                //BorderBrush = DarkGray.HexToBrush(),
                //BorderThickness = new Thickness(0, 0, 1, 0)
                Effect = ControlsFactory.CreateShadow()
            };

            // Create the buttons container
            SideMenuContainer = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = White.HexToBrush(),

            };

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

                TabControl.Items.Add(tabItem);
            });

            // Add the container to the border
            SideMenuBorder.Child = SideMenuContainer;

            Content = SideMenuBorder;
        }

        #endregion

    }
}
