using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's side menu
    /// </summary>
    public class EvaluatorSideMenuComponent : CompanyBaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The job requests button
        /// </summary>
        protected SideMenuButtonComponent JobRequestsButton { get; private set; }

        /// <summary>
        /// The my evaluations button
        /// </summary>
        protected SideMenuButtonComponent MyEvaluationsButton { get; private set; }

        /// <summary>
        /// The my job positions button
        /// </summary>
        protected SideMenuButtonComponent MyJobPositionsButton { get; private set; }

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
        public EvaluatorSideMenuComponent(TabControl tabControl, UserDataModel user) : base(tabControl, user)
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
            // Create and add the my job requests button
            JobRequestsButton = CreateAndAddSideMenuButton("Job requests", PackIconKind.ClipboardArrowDown);
            // On click opens in a tab the job positions page
            JobRequestsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Job requests",
                    Icon = PackIconKind.ClipboardArrowDown,
                    Content = new EvaluatorJobRequestsPage()
                });
            });

            // Create and add the my evaluations button
            MyEvaluationsButton = CreateAndAddSideMenuButton("My evaluations", PackIconKind.ClipboardEdit);
            // On click opens in a tab the job positions page
            MyEvaluationsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "My evaluations",
                    Icon = PackIconKind.ClipboardEdit,
                    Content = new EvaluatorMyEvaluationsPage()
                });
            });

            // Create and add the job positions button
            MyJobPositionsButton = CreateAndAddSideMenuButton("My job positions", PackIconKind.FolderEdit);
            // On click opens in a tab the job positions page
            MyJobPositionsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "My job positions",
                    Icon = PackIconKind.FolderEdit,
                    Content = new EvaluatorMyJobPositionsPage()
                });
            });

            // Create and add the job positions button
            JobPositionsButton = CreateAndAddSideMenuButton("Job positions", PackIconKind.FolderInformation);
            // On click opens in a tab the evaluator's job positions' page
            JobPositionsButton.SideMenuButton.Click += new RoutedEventHandler((sender, e) =>
            {
                TabControl.Items.Add(new TabItemComponent(TabControl)
                {
                    Text = "Job positions",
                    Icon = PackIconKind.FolderInformation,
                    Content = new EvaluatorJobPositionsPage()
                });
            });
        }

        #endregion
    }
}
