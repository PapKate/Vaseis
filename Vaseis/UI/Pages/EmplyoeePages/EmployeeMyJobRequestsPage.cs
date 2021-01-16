using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// the my job position requests of an employee
    /// </summary>
    public class EmployeeMyJobRequestsPage : BaseDataGridPage
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Employee { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The employee's job requests' data grid
        /// </summary>
        protected EmployeeJobRequestsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeMyJobRequestsPage(UserDataModel employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
            
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
            DataGrid = new EmployeeJobRequestsDataGridComponent(PageGrid, Employee);
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
