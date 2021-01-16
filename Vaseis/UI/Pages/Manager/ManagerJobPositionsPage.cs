using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    public class ManagerJobPositionsPage : BaseDataGridPage
    {
        #region Protected Properties
        
        /// <summary>
        /// The manager's job positions data grid
        /// </summary>
        protected ManagerJobPositionsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerJobPositionsPage()
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
            DataGrid = new ManagerJobPositionsDataGridComponent(PageGrid)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
