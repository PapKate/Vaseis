using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The my job positions data grid
    /// </summary>
    public class EvaluatorMyJobPositionsDataGridComponent : BaseDataGridComponent
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorMyJobPositionsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion
        
        #region Dependency Properties

        #region NewRow

        /// <summary>
        /// The open dialog command
        /// </summary>
        public bool NewRow
        {
            get { return (bool)GetValue(NewRowProperty); }
            set { SetValue(NewRowProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NewRow"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NewRowProperty = DependencyProperty.Register(nameof(NewRow), typeof(bool), typeof(EvaluatorMyJobPositionsDataGridComponent), new PropertyMetadata(OnNewRowChanged));

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        private static void OnNewRowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EvaluatorMyJobPositionsDataGridComponent;

            sender.OnNewRowChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        public EvaluatorMyJobPositionsDataGridComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnNewRowChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        // <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new EvaluatorMyJobPositionsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            var startDate = DateTime.Now.ToShortDateString();
            var subDate = new DateTime(21, 1, 24).ToShortDateString();

            // Creates and adds a row to the data grid
            var row = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid)
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
            var row2 = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid)
            {
                JobPositionText = "Chocolate",
                DepartmentText = "Cookies",
                SalaryText = "1.878$",
                SubjectText = "Pastry",
                DeadlineText = $"{startDate} - {subDate}",
                NumberOfRequestsText = "7",
            };

            InfoDataStackPanel.Children.Add(row2);

        }

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnNewRowChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                var newRow = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid);

                InfoDataStackPanel.Children.Add(newRow);
                // Creates a new evaluation dialog
                var jobPositionDialog = new JobPositionDialogComponent(newRow)
                {
                    // Sets the dialog is open to true
                    IsDialogOpen = true,
                    // Close button on click removes the new row from the data grid
                    CancelCommand = new RelayCommand(() => InfoDataStackPanel.Children.Remove(newRow))
                };
                // Adds it to the page grid
                PageGrid.Children.Add(jobPositionDialog);
                // Sets the new row value to false
                NewRow = false;
            }
        }

        #endregion

    }
}
