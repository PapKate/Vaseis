using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// Represents the "my evaluations" page of the evaluator
    /// </summary>
    public class EvaluatorMyEvaluationsPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The new evaluation dialog
        /// </summary>
        protected EvaluationDialogComponent EvaluationDialog { get; private set; }

        /// <summary>
        /// The add/open dialog button
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        protected EvaluatorDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        public EvaluatorMyEvaluationsPage()
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

            DataGrid = new EvaluatorDataGridComponent(PageGrid)
            {
                
            };
            PageGrid.Children.Add(DataGrid);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        #endregion

    }
}
