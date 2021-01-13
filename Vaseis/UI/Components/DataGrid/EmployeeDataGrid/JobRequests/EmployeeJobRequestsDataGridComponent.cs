using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    public class EmployeeJobRequestsDataGridComponent : ContentControl
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EmployeeJobRequestsDataGridHeaderComponent DataGridHeader { get; private set; }

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
        public EmployeeJobRequestsDataGridComponent()
        {
            CreateGUI();
        }

        public EmployeeJobRequestsDataGridComponent(Grid pageGrid)
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
            DataGridHeader = new EmployeeJobRequestsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            var startDate = DateTime.Now.ToShortDateString();
            var subDate = new DateTime(2021, 1, 24).ToShortDateString();

            // Creates and adds a row to the data grid
            var row = new EmployeeJobRequestsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Potato",
                DepartmentText = "Tomato",
                SalaryText = "2.500$",
                SubjectText = "Agriculture",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "12",
            };
            row.RemoveRowCommand = new RelayCommand(() => { ShowConfirmationDialog(row); });

            InfoDataStackPanel.Children.Add(row);

            // Creates and adds a row to the data grid
            var row2 = new EmployeeJobRequestsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Chocolate",
                DepartmentText = "Cookies",
                SalaryText = "1.878$",
                SubjectText = "Pastry",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "7",
            };
            row2.RemoveRowCommand = new RelayCommand(() => { ShowConfirmationDialog(row2); });

            InfoDataStackPanel.Children.Add(row2);
            
            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
        }

        /// <summary>
        /// On click shows the evaluation dialog
        /// </summary>
        private void ShowConfirmationDialog(EmployeeJobRequestsDataGridRowComponent dataGridRow)
        {
            // Creates an evaluation dialog
            var confirmationDialog = new MessageDialogComponent()
            {
                // And opens it
                IsDialogOpen = true,
                BrushColor = Red.HexToBrush(),
                Message = "Are you sure you want to remove your evaluation request?",
                Title = "Remove request",
                OkCommand = new RelayCommand(() => InfoDataStackPanel.Children.Remove(dataGridRow))
            };
            // Adds it to the page's grid
            PageGrid.Children.Add(confirmationDialog);
        }
        #endregion
    }
}
