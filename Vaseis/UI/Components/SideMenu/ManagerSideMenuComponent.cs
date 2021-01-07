
using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class ManagerSideMenuComponent : CompanyBaseSideMenuComponent
    {
        #region Protected Properties

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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public ManagerSideMenuComponent(TabControl tabControl) : base(tabControl)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Create and add the my job requests button
            ReportsButton = CreateAndAddSideMenuButton("Reports", PackIconKind.ClipboardFlow);

            // Create and add the my evaluations button
            EvaluationResultsButton = CreateAndAddSideMenuButton("Evaluation results", PackIconKind.ClipboardList);

            // Create and add the job positions button
            EmployeesButton = CreateAndAddSideMenuButton("Employees", PackIconKind.AccountGroup);
            // On click opens in a tab the employees page
            EmployeesButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent()
                {
                    Text = "Employees",
                    Icon = PackIconKind.AccountGroup,
                    Content = new EmployeesPage()
                });
            });
        }


        #endregion


    }
}
