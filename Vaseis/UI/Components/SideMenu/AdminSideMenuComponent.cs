
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public AdminSideMenuComponent(TabControl tabControl, UserDataModel user) : base(tabControl, user)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
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

            AddSubject = CreateAndAddSideMenuButton("Add Subject", PackIconKind.Transcribe);

        }

        #endregion
    }
}
