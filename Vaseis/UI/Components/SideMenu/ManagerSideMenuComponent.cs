
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class ManagerSideMenuComponent : CompanyBaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The admin's profile button
        /// </summary>
        protected SideMenuButtonComponent ProfileButton { get; private set; }

        /// <summary>
        /// The employees button
        /// </summary>
        protected SideMenuButtonComponent JobPositionsButton { get; private set; }

        /// <summary>
        /// The reports button
        /// </summary>
        protected SideMenuButtonComponent ReportsButton { get; private set; }

        /// <summary>
        /// The evaluation results button
        /// </summary>
        protected SideMenuButtonComponent EvaluationResultsButton { get; private set; }

        /// <summary>
        /// The employees button
        /// </summary>
        protected SideMenuButtonComponent EmployeesButton { get; private set; }

        /// <summary>
        /// The Manager User
        /// </summary>
        protected UserDataModel User { get; private set; }



        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public ManagerSideMenuComponent(TabControl tabControl, UserDataModel user) : base(tabControl, user)
        {

            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {

            ProfileButton = CreateAndAddSideMenuButton("Profile", PackIconKind.Account);

            ProfileButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Profile",
                    Icon = PackIconKind.Account,
                    Content = new ProfilePage(User)
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
                    Content = new ManagerJobPositionsPage()
                });
            });

            // Create and add the my job requests button
            ReportsButton = CreateAndAddSideMenuButton("Reports", PackIconKind.ClipboardFlow);
            // On click opens in a tab the reports page
            ReportsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Reports",
                    Icon = PackIconKind.ClipboardFlow,
                    Content = new ManagerReportsPage(User)
                });
            });

            // Create and add the my evaluations button
            EvaluationResultsButton = CreateAndAddSideMenuButton("Evaluation results", PackIconKind.ClipboardList);
            // On click opens in a tab the evaluation results' page
            EvaluationResultsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Evaluation results",
                    Icon = PackIconKind.ClipboardList,
                    Content = new ManagerEvaluationResultsPage()
                });
            });

            // Create and add the job positions button
            EmployeesButton = CreateAndAddSideMenuButton("Employees", PackIconKind.AccountGroup);
            // On click opens in a tab the employees page
            EmployeesButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Employees",
                    Icon = PackIconKind.AccountGroup,
                    Content = new EmployeesPage(User)
                });
            });
        }

        #endregion

    }
}
