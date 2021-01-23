using System;
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
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Manager { get; }

        #endregion

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
        public ManagerEvaluationResultsPage(UserDataModel manager)
        {
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));

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
            DataGrid = new ManagerEvaluationDataGridComponent(PageGrid, Manager)
            {

            };
            // Adds it to the page
            PageScrollViewer.Content = DataGrid;
        }

        #endregion

    }
}
