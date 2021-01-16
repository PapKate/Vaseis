using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The manager's evaluation results page
    /// </summary>
    public class ManagerEvaluationResultsPage : BaseDataGridPage
    {

        #region Protected Properties

        /// <summary>
        /// The manager's evaluation's data grid
        /// </summary>
        protected ManagerEvaluationDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerEvaluationResultsPage()
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
            // Creates the data grid
            DataGrid = new ManagerEvaluationDataGridComponent(PageGrid)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
