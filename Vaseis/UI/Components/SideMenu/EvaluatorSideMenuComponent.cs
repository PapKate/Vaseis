using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
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
        public EvaluatorSideMenuComponent(TabControl tabControl) : base(tabControl)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Create and add the my job requests button
            JobRequestsButton = CreateAndAddSideMenuButton("Job requests", PackIconKind.ClipboardArrowDown);

            // Create and add the my evaluations button
            MyEvaluationsButton = CreateAndAddSideMenuButton("My evaluations", PackIconKind.ClipboardEdit);

            // Create and add the job positions button
            MyJobPositionsButton = CreateAndAddSideMenuButton("My job positions", PackIconKind.FolderEdit);
            

            // Create and add the job positions button
            JobPositionsButton = CreateAndAddSideMenuButton("Job positions", PackIconKind.FolderInformation);
        }


        #endregion
    }
}
