

using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class EmployeeSideMenuComponent : CompanyBaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The job requests button
        /// </summary>
        protected SideMenuButtonComponent MyJobRequestsButton { get; private set; }

        /// <summary>
        /// The my evaluations button
        /// </summary>
        protected SideMenuButtonComponent MyEvaluationsButton { get; private set; }

        /// <summary>
        /// The job positions button
        /// </summary>
        protected SideMenuButtonComponent JobPositionsButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public EmployeeSideMenuComponent(TabControl tabControl, UserDataModel user) : base(tabControl, user)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Create and add the my job requests button
            MyJobRequestsButton = CreateAndAddSideMenuButton("My job requests", PackIconKind.ClipboardArrowUp);
            // On click opens in a tab the my job requests page
            MyJobRequestsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "My job requests",
                    Icon = PackIconKind.ClipboardArrowUp,
                    Content = new EmployeeMyJobRequestsPage()
                });
            });

            // Create and add the my evaluations button
            MyEvaluationsButton = CreateAndAddSideMenuButton("My evaluations", PackIconKind.ClipboardAccount);
            // On click opens in a tab the my evaluations page
            MyEvaluationsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "My evaluations",
                    Icon = PackIconKind.ClipboardAccount,
                    Content = new EmplyoeeMyEvaluationsPage()
                });
            });

            // Create and add the job positions button
            JobPositionsButton = CreateAndAddSideMenuButton("Job positions", PackIconKind.FolderSearch);
            // On click opens in a tab the job positions page
            JobPositionsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Job positions",
                    Icon = PackIconKind.FolderSearch,
                    Content = new EmployeeJobPositionsPage()
                });
            });
        }


        #endregion
    }
}
