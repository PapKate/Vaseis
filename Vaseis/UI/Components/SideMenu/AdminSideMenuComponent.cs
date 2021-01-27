
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The administrator's side menu
    /// </summary>
    public class AdminSideMenuComponent : BaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The companies button
        /// </summary>
        protected SideMenuButtonComponent CompaniesButton { get; private set; }

        /// <summary>
        /// The companies button
        /// </summary>
        protected SideMenuButtonComponent SubjectsButton { get; private set; }

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

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Create and add the companies button
            CompaniesButton = CreateAndAddSideMenuButton("Companies", PackIconKind.DomainPlus);

            CompaniesButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Companies",
                    Icon = PackIconKind.DomainPlus,
                    Content = new CompaniesPage(),
                    IsSelected = true
                });
                
            });

            // Create and add the subjects button
            SubjectsButton = CreateAndAddSideMenuButton("Subjects", PackIconKind.Transcribe);

            SubjectsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Subjects",
                    Icon = PackIconKind.Transcribe,
                    Content = new SubjectsPage(),
                    IsSelected = true
                });
            });

        }

        #endregion
    }
}
