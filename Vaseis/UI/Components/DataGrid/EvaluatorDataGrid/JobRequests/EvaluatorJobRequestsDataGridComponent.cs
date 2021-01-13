using System;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests data grid
    /// </summary>
    public class EvaluatorJobRequestsDataGridComponent : ContentControl
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorJobRequestsDataGridHeaderComponent DataGridHeader { get; private set; }

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
        public EvaluatorJobRequestsDataGridComponent()
        {
            CreateGUI();
        }

        public EvaluatorJobRequestsDataGridComponent(Grid pageGrid)
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
            DataGridHeader = new EvaluatorJobRequestsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            var startDate = DateTime.Now.ToShortDateString();
            var subDate = new DateTime(21, 1, 24).ToShortDateString();

            // Creates and adds a row to the data grid
            var row = new EvaluatorJobRequestsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Potato",
                DepartmentText = "Tomato",
                SalaryText = "2.500$",
                SubjectText = "Agriculture",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "12",
                EmployeeText = "PapKate",
            };

            InfoDataStackPanel.Children.Add(row);

            // Creates and adds a row to the data grid
            var row2 = new EvaluatorJobRequestsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Chocolate",
                DepartmentText = "Cookies",
                SalaryText = "1.878$",
                SubjectText = "Pastry",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "7",
                EmployeeText = "0xCAFFEEBABA"
            };

            InfoDataStackPanel.Children.Add(row2);

            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
        }

        #endregion
    }
}
