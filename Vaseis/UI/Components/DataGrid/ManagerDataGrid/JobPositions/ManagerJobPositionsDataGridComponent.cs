using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The manager's job positions data grid
    /// </summary>
    public class ManagerJobPositionsDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Manager { get; }

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected ManagerJobPositionsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageGrid">The page's grid</param>
        /// <param name="manager">the user data model representing a manager</param>
        public ManagerJobPositionsDataGridComponent(Grid pageGrid, UserDataModel manager)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected async override void OnInitialized()
        {
            base.OnInitialized();
            // Query the job positions of the manager's company and add them as rows to the data grid
            var jobPositions = await Services.GetDataStorage.GetCompanyJobPositions(Manager.Department.CompanyId);

            // For each job position in the list...
            foreach (var jobPosition in jobPositions)
            {
                // Create a row of for the employee's job position data grid
                var row = new ManagerJobPositionsDataGridRowComponent(PageGrid, jobPosition);
                // Updates the salary in the data base
                
                // Adds the row to the stack panel
                InfoDataStackPanel.Children.Add(row);
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new ManagerJobPositionsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }
        #endregion

    }
}
