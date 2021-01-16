using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The job position requests data grid
    /// </summary>
    public class EmployeeJobRequestsDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The employee
        /// </summary>
        public UserDataModel Employee { get; }

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EmployeeJobRequestsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobRequestsDataGridComponent(Grid pageGrid, UserDataModel employee)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));

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
            // Query the reports of the manager and add them as rows to the data grid
            var jobPositionRequests = await Services.GetDbContext.JobPositionRequests
                                                                 .Include(x => x.UsersJobFilesPair)
                                                                 .Include(x => x.UsersJobFilesPair.Employee)
                                                                 .Include(x => x.JobPosition)
                                                                 .Include(x => x.JobPosition.Job)
                                                                 .Include(x => x.JobPosition.Job.Department)
                                                                 .Include(x => x.JobPosition.JobPositionRequests)
                                                                 .Where(x => x.UsersJobFilesPair.EmployeeId == 1)
                                                                 .ToListAsync();

            // For each job position in the list...
            foreach (var jobPositionRequest in jobPositionRequests)
            {
                // Create a row of for the employee's job position data grid
                var row = new EmployeeJobRequestsDataGridRowComponent(PageGrid, jobPositionRequest);
                // ( When the plus button is clicked )
                // Create the show dialog command
                row.ShowDialogCommand = new RelayCommand(() => ShowConfirmationDialog(row));
                // Adds the row to the stack panel
                InfoDataStackPanel.Children.Add(row);
            }
        }
        #endregion

        #region Private Methods

        // <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new EmployeeJobRequestsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }

        /// <summary>
        /// On click shows the confirmation dialog
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
                OkCommand = new RelayCommand(() => 
                            {
                                InfoDataStackPanel.Children.Remove(dataGridRow);
                            })
            };
            // Adds it to the page's grid
            PageGrid.Children.Add(confirmationDialog);
        }

        #endregion
    }
}
