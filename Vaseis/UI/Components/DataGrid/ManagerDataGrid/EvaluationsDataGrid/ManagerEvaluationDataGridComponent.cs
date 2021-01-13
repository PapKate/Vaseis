using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    public class ManagerEvaluationDataGridComponent: ContentControl
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluattionBaseDataGridHeaderComponent DataGridHeader { get; private set; }

        /// <summary>
        /// The data grid's stack panel
        /// </summary>
        protected StackPanel InfoDataStackPanel { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerEvaluationDataGridComponent()
        {

        }

        public ManagerEvaluationDataGridComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            InfoDataStackPanel = new StackPanel();

            // Creates and adds the header's row
            DataGridHeader = new EvaluattionBaseDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            // Creates and adds a row to the data grid
            var row = new ManagerDataGridRowComponent(PageGrid)
            {
                EvaluatorName = "PapLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                InterviewComments = "oooofffff",

            };

            InfoDataStackPanel.Children.Add(row);

            // Creates and adds a row to the data grid
            var row2 = new ManagerDataGridRowComponent(PageGrid)
            {
                EvaluatorName = "PapBoomBommLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                InterviewComments = "oooofffff axxxxx vahhhhhhn The ICommand interface is the code contract for commands that are written in .NET for Windows Runtime apps. These commands provide the commanding behavior for UI elements such as a Windows Runtime XAML Button and in particular an AppBarButton. If you're defining commands for Windows Runtime apps you use basically the same techniques you'd use for defining commands for a .NET app. Implement the command by defining a class that implements ICommand and specifically implement the Execute method."
                                + "XAML for Windows Runtime does not support x:Static, so don't attempt to use the x:Static markup extension if the command is used from Windows Runtime XAML. Also, the Windows Runtime does not have any predefined command libraries, so the XAML syntax shown here doesn't really apply for the case where you're implementing the interface and defining the command for Windows Runtime usage. "
            };

            InfoDataStackPanel.Children.Add(row2);

            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
        }

        #endregion
    }
}
