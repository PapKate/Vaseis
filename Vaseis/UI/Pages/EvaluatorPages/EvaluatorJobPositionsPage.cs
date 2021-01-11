using System.Windows.Controls;

namespace Vaseis
{
    public class EvaluatorJobPositionsPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        protected JobPositionsDataGridComponent DataGrid { get; private set; }

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
            // The page's grid
            PageGrid = new Grid()
            {
            };

            DataGrid = new JobPositionsDataGridComponent(PageGrid)
            {

            };
            PageGrid.Children.Add(DataGrid);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        #endregion

    }
}
