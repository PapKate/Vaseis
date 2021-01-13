using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class EmployeeJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The request evaluation button
        /// </summary>
        protected Button RequestButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobPositionsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the edit button
            RequestButton = ControlsFactory.CreateControlButton(PackIconKind.PlusThick, GreenBlue);
            RequestButton.ToolTip = new ToolTipComponent() { Text = "Request evaluation for job position" };

            RequestButton.Click += ShowJobPositionRequestDialog;

            // Add it to the grid
            RowDataGrid.Children.Add(RequestButton);
            // On the ninth column
            Grid.SetColumn(RequestButton, 9);
            Grid.SetColumnSpan(RequestButton, 2);
        }

        /// <summary>
        /// On click shows the evaluation dialog
        /// </summary>
        private void ShowJobPositionRequestDialog(object sender, RoutedEventArgs e)
        {
            // Creates an evaluation dialog
            var requestDialog = new JobPositionRequestDialogComponent(this)
            {
                // And opens it
                IsDialogOpen = true
            };
            // Adds it to the page's grid
            PageGrid.Children.Add(requestDialog);
        }

        #endregion

    }
}
