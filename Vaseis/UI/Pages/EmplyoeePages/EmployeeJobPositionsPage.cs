using System;

namespace Vaseis
{
    public class EmployeeJobPositionsPage : BaseDataGridPage
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Employee { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The employee's job position's data grid
        /// </summary>
        protected EmployeeJobPositionsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="employee">The employee</param>
        public EmployeeJobPositionsPage(UserDataModel employee)
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
            DataGrid = new EmployeeJobPositionsDataGridComponent(PageGrid, Employee)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion

    }
}
