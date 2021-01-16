using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests page
    /// </summary>
    public class EvaluatorJobRequestsPage : BaseDataGridPage
    {
        #region Protected Properties

        /// <summary>
        /// The evaluator's job requests' data grid
        /// </summary>
        protected EvaluatorJobRequestsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobRequestsPage()
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
            DataGrid = new EvaluatorJobRequestsDataGridComponent(PageGrid)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
