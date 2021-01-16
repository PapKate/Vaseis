using System;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The employee's my evaluations page
    /// </summary>
    public class EmplyoeeMyEvaluationsPage : BaseDataGridPage
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Employee { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The manager's evaluation's data grid
        /// </summary>
        protected EmployeeMyEvaluationsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmplyoeeMyEvaluationsPage(UserDataModel employee) : base()
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
            DataGrid = new EmployeeMyEvaluationsDataGridComponent(PageGrid, Employee);

            // Adds it to the page
            PageGrid.Children.Add(DataGrid);
        }

        #endregion
    }
}
