using System;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class EvaluatorJobPositionsPage : BaseDataGridPage
    {
        #region Public Properties

        /// <summary>
        /// The evaluator
        /// </summary>
        public UserDataModel Evaluator { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The job position's data grid
        /// </summary>
        protected EvaluatorJobPositionsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobPositionsPage(UserDataModel evaluator)
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
            DataGrid = new EvaluatorJobPositionsDataGridComponent(PageGrid, Evaluator)
            {

            };
            // Adds it to the page
            PageScrollViewer.Content = DataGrid;
        }

        #endregion

    }
}
