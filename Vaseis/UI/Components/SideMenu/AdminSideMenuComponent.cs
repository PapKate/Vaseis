
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class AdminSideMenuComponent : BaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The companies button
        /// </summary>
        protected SideMenuButtonComponent CompaniesButton { get; private set; }

        /// <summary>
        /// The admin's profile button
        /// </summary>
        protected SideMenuButtonComponent AdminProfileButton { get; private set; }

        /// <summary>
        /// The companies button
        /// </summary>
        protected SideMenuButtonComponent AddSubject { get; private set; }

        /// <summary>
        /// The admin User
        /// </summary>
        protected UserDataModel User { get; private set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public AdminSideMenuComponent(TabControl tabControl, UserDataModel user) : base(tabControl, user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {

            AdminProfileButton = CreateAndAddSideMenuButton("Profile", PackIconKind.Account);

            AdminProfileButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Profile",
                    Icon = PackIconKind.Account,
                    Content = new ProfilePage(User)
                });
            });

       
            // Create and add the my job requests button
            CompaniesButton = CreateAndAddSideMenuButton("Companies", PackIconKind.DomainPlus);

            CompaniesButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Companies",
                    Icon = PackIconKind.DomainPlus,
                    Content = new CompaniesPage()
                });
            });

            AddSubject = CreateAndAddSideMenuButton("Add Subject", PackIconKind.Account);

            AddSubject.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Subjects",
                    Icon = PackIconKind.DomainPlus,
                   // Content = new CompaniesPage()
                });
            });

        }


        #endregion
    }
}
