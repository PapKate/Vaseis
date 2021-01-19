using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class ManagerEvaluationDataGridComponent: BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Manager { get; }

        #endregion


        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluattionBaseDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        public ManagerEvaluationDataGridComponent(Grid pageGrid, UserDataModel manager)
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
            // Query the reports of the manager and add them as rows to the data grid
            var evaluationResults = await Services.GetDataStorage.GetManagerEvaluationsAsync(Manager.Id);

            // For each job position in the list...
            foreach (var result in evaluationResults)
            {
                // Create a row of for the employee's job position data grid
                var row = new ManagerEvaluationDataGridRowComponent(PageGrid, result);
                // ( When the plus button is clicked )
                // Create the show dialog command
                row.ShowDialogCommand = new RelayCommand(() => ShowConfirmationDialog(row));
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
            DataGridHeader = new EvaluattionBaseDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }

        /// <summary>
        /// Opens a dialog notifying the evaluator the evaluation has been sent to a manager
        /// </summary>
        private void ShowConfirmationDialog(ManagerEvaluationDataGridRowComponent dataGridRow)
        {
            // Creates a new finalized dialog
            var confirmationDialog = new MessageDialogComponent()
            {
                Message = "The evaluation has been confirmed and sent to the employee",
                Title = "Success",
                BrushColor = HookersGreen.HexToBrush(),
                IsDialogOpen = true,
                OkCommand = new RelayCommand(async() => 
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
