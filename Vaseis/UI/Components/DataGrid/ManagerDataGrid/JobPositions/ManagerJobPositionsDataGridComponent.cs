using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The manager's job positions data grid
    /// </summary>
    public class ManagerJobPositionsDataGridComponent : ContentControl
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }
        
        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected ManagerJobPositionsDataGridHeaderComponent DataGridHeader { get; private set; }

        /// <summary>
        /// The data grid's stack panel
        /// </summary>
        protected StackPanel InfoDataStackPanel { get; private set; }

        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerJobPositionsDataGridComponent()
        {
            CreateGUI();
        }

        public ManagerJobPositionsDataGridComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        // <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            InfoDataStackPanel = new StackPanel();

            // Creates and adds the header's row
            DataGridHeader = new ManagerJobPositionsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            var startDate = DateTime.Now.ToShortDateString();
            var subDate = new DateTime(21, 1, 24).ToShortDateString();

            // Creates and adds a row to the data grid
            var row = new ManagerJobPositionsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Potato",
                DepartmentText = "Tomato",
                SalaryText = "2.500$",
                SubjectText = "Agriculture",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "12",
            };

            InfoDataStackPanel.Children.Add(row);

            // Creates and adds a row to the data grid
            var row2 = new ManagerJobPositionsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Chocolate",
                DepartmentText = "Cookies",
                SalaryText = "1.878$",
                SubjectText = "Pastry",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "7",
            };

            InfoDataStackPanel.Children.Add(row2);

            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
        }
        #endregion

    }
}
