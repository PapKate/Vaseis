using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class EmployeeJobPositionsDataGridComponent : BaseDataGridComponent
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
        protected EmployeeJobPositionsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageGrid">The page's grid</param>
        /// <param name="employee">The employee</param>
        public EmployeeJobPositionsDataGridComponent(Grid pageGrid, UserDataModel employee)
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
            var jobPositions = await Services.GetDataStorage.GetCompanyJobPositionsAsync(Employee.Department.CompanyId);

            // For each job position in the list...
            foreach (var jobPosition in jobPositions)
            {
                // Create a row of for the employee's job position data grid
                var row = new EmployeeJobPositionsDataGridRowComponent(PageGrid, jobPosition);
                // ( When the plus button is clicked )
                // Create the show dialog command
                row.ShowDialogCommand = new RelayCommand(() => 
                {
                    // Creates an evaluation dialog
                    var requestDialog = new JobPositionRequestDialogComponent(row)
                    {
                        // And opens it
                        IsDialogOpen = true,
                    };

                    // Create the request command
                    requestDialog.RequestCommand = new RelayCommand(async () =>
                    {
                        // If the request's reason is not filled...
                        if (string.IsNullOrEmpty(requestDialog.ParagraphTextBox.Text))
                        {
                            // Creates error dialog
                            var errorDialog = new MessageDialogComponent()
                            {
                                BrushColor = Red.HexToBrush(),
                                Message = "The request was not created as the reason for applying was not filled.",
                                Title = "Error"
                            };
                            // Adds it to the page's grid
                            PageGrid.Children.Add(errorDialog);
                        }
                        // Else...
                        else
                        {
                            // Removes from the data grid's stack panel the row
                            InfoDataStackPanel.Children.Remove(row);
                            // Adds a job position request
                            var request = await Services.GetDataStorage.AddJobPositionRequestAsync(Employee.Id, row.JobPosition.Id, requestDialog.ParagraphTextBox.Text);
                            await Services.GetDataStorage.AddReportAsync(request);
                        }
                    });

                    // Adds it to the page's grid
                    PageGrid.Children.Add(requestDialog);
                });
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
            DataGridHeader = new EmployeeJobPositionsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }

        #endregion
    }
}
