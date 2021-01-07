

using MaterialDesignThemes.Wpf;

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
        public EmployeeSideMenuComponent(TabControl tabControl) : base(tabControl)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Create and add the my job requests button
            MyJobRequestsButton = CreateAndAddSideMenuButton("My job requests", PackIconKind.ClipboardArrowUp);

            // Create and add the my evaluations button
            MyEvaluationsButton = CreateAndAddSideMenuButton("My evaluations", PackIconKind.ClipboardAccount);

            // Create and add the job positions button
            JobPositionsButton = CreateAndAddSideMenuButton("Job positions", PackIconKind.FolderSearch);
        }


        #endregion
    }
}
