using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The manager's reports page
    /// </summary>
    public class ManagerReportsPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The new evaluation dialog
        /// </summary>
        protected ReportDialogComponent ReportDialog { get; private set; }

        /// <summary>
        /// The add/open dialog button
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        protected ReportsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        public ManagerReportsPage()
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
            // The page's grid
            PageGrid = new Grid()
            {
            };

            DataGrid = new ReportsDataGridComponent(PageGrid)
            {

            };
            PageGrid.Children.Add(DataGrid);

           
            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        #endregion

    }
}
