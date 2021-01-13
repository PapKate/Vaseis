using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class EmployeeMyEvaluationsDataGridComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EmployeeMyEvaluationsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeMyEvaluationsDataGridComponent()
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
            var InfoDataGrid = new StackPanel();

            // Creates and adds the header's row
            DataGridHeader = new EmployeeMyEvaluationsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataGrid.Children.Add(DataGridHeader);

            var row = new EmployeeMyEvaluationsDataGridRowComponent()
            {
                EvaluatorName = "PapLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                Result = "Pass"
            };

            InfoDataGrid.Children.Add(row);

            var row2 = new EmployeeMyEvaluationsDataGridRowComponent()
            {
                EvaluatorName = "PapBoomBommLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                Result = "Fail"
            };

            InfoDataGrid.Children.Add(row2);

            Content = InfoDataGrid;
        }


        #endregion

    }
}
