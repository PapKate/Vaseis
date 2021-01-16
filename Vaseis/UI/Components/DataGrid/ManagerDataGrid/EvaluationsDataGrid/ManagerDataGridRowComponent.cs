using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// A row of the manager's data grid component
    /// </summary>
    public class ManagerDataGridRowComponent : EvaluationBaseDataGridRowComponent
    {
        #region Protected Properties

        /// <summary>
        /// The finalize and send button
        /// </summary>
        protected Button ConfirmButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerDataGridRowComponent()
        {
            CreateGUI();
        }

        public ManagerDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the finalize and send button
            ConfirmButton = ControlsFactory.CreateFinalizeButton();
            // Creates and adds a tool tip
            ConfirmButton.ToolTip = new ToolTipComponent() { Text = "Confirm and send evaluation" };
            // Add it to the grid
            RowDataGrid.Children.Add(ConfirmButton);
            // On the tenth column
            Grid.SetColumn(ConfirmButton, 9);

            ConfirmButton.Click += ShowConfirmationDialogOnClick;
            
            // Sets the component's content as the details' expander
            Content = DetailsExpander;
        }

        /// <summary>
        /// Opens a dialog notifying the evaluator the evaluation has been sent to a manager
        /// </summary>
        private void ShowConfirmationDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new finalized dialog
            var confirmationDialog = new MessageDialogComponent()
            {
                Message = "The evaluation has been confirmed and sent to the employee",
                Title = "Success",
                BrushColor = HookersGreen.HexToBrush(),
                IsDialogOpen = true
            };
            // Adds it to the page's grid
            PageGrid.Children.Add(confirmationDialog);
        }

        #endregion


    }
}
