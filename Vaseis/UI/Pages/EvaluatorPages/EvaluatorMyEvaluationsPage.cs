using System;
using System.Windows.Controls;


namespace Vaseis
{
    /// <summary>
    /// Represents the "my evaluations" page of the evaluator
    /// </summary>
    public class EvaluatorMyEvaluationsPage : BaseDataGridPage
    {
        #region Public Properties
        /// <summary>
        /// The evaluator connected
        /// </summary>
        public UserDataModel Evaluator { get; }

        #endregion

        #region Protected Properties
        
        /// <summary>
        /// The my evaluation data grid 
        /// </summary>
        protected EvaluatorDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="evaluator"></param>
        public EvaluatorMyEvaluationsPage(UserDataModel evaluator)
        {
            Evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator)); 

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
            DataGrid = new EvaluatorDataGridComponent(PageGrid, Evaluator)
            {

            };
            // Adds the data grid to the scroll viewer
            PageScrollViewer.Content = DataGrid;
        }

        #endregion

    }
}
