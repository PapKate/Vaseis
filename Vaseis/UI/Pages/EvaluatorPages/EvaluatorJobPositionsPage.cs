using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class EvaluatorJobPositionsPage : BaseDataGridPage
    {
        #region Protected Properties

        /// <summary>
        /// The add button
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The job position's data grid
        /// </summary>
        protected EvaluatorJobPositionsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobPositionsPage()
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
            DataGrid = new EvaluatorJobPositionsDataGridComponent(PageGrid)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
