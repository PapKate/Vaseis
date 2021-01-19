using System.Windows.Controls;
using System.Windows;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// The side menu with the profile and company buttons
    /// </summary>
    public abstract class CompanyBaseSideMenuComponent : BaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The company button
        /// </summary>
        protected SideMenuButtonComponent CompanyButton { get; private set; }

        /// <summary>
        /// The evaluations button
        /// </summary>
        protected SideMenuButtonComponent EvaluationsButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public CompanyBaseSideMenuComponent(TabControl tabControl, UserDataModel user) : base(tabControl, user)
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
            // Create and add the company button
            CompanyButton = CreateAndAddSideMenuButton("Company", PackIconKind.Domain);

            // On click opens in a tab the company profile page
            CompanyButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                var tabItem = new TabItemComponent(TabControl)
                {
                    Text = "Company",
                    Icon = PackIconKind.Domain,
                    Content = new CompanyPage(User.Department.Company)
                };

                TabControl.Items.Add(tabItem);
            });

            Content = SideMenuBorder;
        }

        #endregion
    }
}
