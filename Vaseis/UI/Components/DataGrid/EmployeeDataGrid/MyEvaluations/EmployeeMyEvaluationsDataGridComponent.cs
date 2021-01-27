using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The my evaluations data grid of an employee
    /// </summary>
    public class EmployeeMyEvaluationsDataGridComponent : BaseDataGridComponent
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
        protected EmployeeMyEvaluationsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageGrid">The page's grid</param>
        /// <param name="employee">The employee</param>
        public EmployeeMyEvaluationsDataGridComponent(Grid pageGrid, UserDataModel employee) : base()
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

            // Query the evaluations of the employee and add them as rows to the data grid
            var evaluationsResults = await Services.GetDataStorage.GetEmloyeeEvaluationsAsync(Employee);

            // For each job position in the list...
            foreach (var result in evaluationsResults)
            {
                // Create a row of for the employee's job position data grid
                var row = new EmployeeMyEvaluationsDataGridRowComponent(PageGrid, result);
                // ( When the plus button is clicked )
                // Create the show dialog command
                row.ShowDialogCommand = new RelayCommand(() =>
                {
                    // Creates an evaluation dialog
                    var confirmationDialog = new MessageDialogComponent()
                    {
                        // And opens it
                        IsDialogOpen = true,
                        BrushColor = Green.HexToBrush(),
                        Message = "Congratulations!!\nAre you sure you want to acquire this position? Once you do, it will be your new job and you will be excused from your previous one.",
                        Title = "Acquire job position",
                        OkCommand = new RelayCommand(async () =>
                        {
                            InfoDataStackPanel.Children.Remove(row);
                            await Services.GetDataStorage.UpdateEmployeeJobPositionAsync(Employee.Id, row.Evaluation.JobPositionRequest.JobPosition);
                        })
                    };
                    // Adds it to the page's grid
                    PageGrid.Children.Add(confirmationDialog);
                });
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
            DataGridHeader = new EmployeeMyEvaluationsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }

        #endregion

    }
}
