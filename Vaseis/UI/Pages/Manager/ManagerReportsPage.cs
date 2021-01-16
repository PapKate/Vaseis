using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System;

namespace Vaseis
{
    /// <summary>
    /// The manager's reports page
    /// </summary>
    public class ManagerReportsPage : BaseDataGridPage
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Manager { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The manager's report data grid
        /// </summary>
        protected ReportsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        public ManagerReportsPage(UserDataModel manager)
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
            DataGrid = new ReportsDataGridComponent(PageGrid, Manager)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
