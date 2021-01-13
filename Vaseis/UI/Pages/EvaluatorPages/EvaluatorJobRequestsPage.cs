using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests page
    /// </summary>
    public class EvaluatorJobRequestsPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

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
            // The page's grid
            PageGrid = new Grid()
            {
            };

            DataGrid = new EvaluatorJobRequestsDataGridComponent(PageGrid)
            {

            };
            PageGrid.Children.Add(DataGrid);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        #endregion

    }
}
