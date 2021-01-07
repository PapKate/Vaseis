using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The data grid
    /// </summary>
    public class DataGridComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected Grid DataGridHeader { get; private set; }

        /// <summary>
        /// The evaluator's name
        /// </summary>
        protected TextBlock EvaluatorTextBlock { get; private set; }

        /// <summary>
        /// The employee's name
        /// </summary>
        protected TextBlock EmployeeTextBlock { get; private set; }

        /// <summary>
        /// The job's name
        /// </summary>
        protected TextBlock JobTextBlock { get; private set; }

        /// <summary>
        /// The department's name
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The evaluation's final grade
        /// </summary>
        protected TextBlock EvaluationGradeTextBlock { get; private set; }

        /// <summary>
        /// The report's grade
        /// </summary>
        protected TextBlock ReportGradeTextBlock { get; private set; }

        /// <summary>
        /// The file's grade
        /// </summary>
        protected TextBlock FilesGradeTextBlock { get; private set; }

        /// <summary>
        /// The interview's grade
        /// </summary>
        protected TextBlock InterviewGradeTextBlock { get; private set; }

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock MoreDetailsTextBlock { get; private set; }

        /// <summary>
        /// The tool tip's border
        /// </summary>
        protected Border ToolTipBorder { get; private set; }

        /// <summary>
        /// The tool tip's text
        /// </summary>
        protected TextBlock ToolTipTextBlock { get; private set; }

        protected TextBlock HeaderTextBlock { get; private set; }


        #endregion

        #region Dependency Properties

        #region Employee Name

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string EmployeeName
        {
            get { return GetValue(EmployeeNameProperty).ToString(); }
            set { SetValue(EmployeeNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmployeeName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeeNameProperty = DependencyProperty.Register(nameof(EmployeeName), typeof(string), typeof(DataGridComponent));


        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataGridComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected TextBlock CreateHeaderTextBlock(int columnIndex, string text, string toolTipText)
        {
            // Creates the tool tip's border
            ToolTipBorder = new Border()
            {
                CornerRadius = new CornerRadius(8),
                Background = White.HexToBrush(),
                BorderThickness = new Thickness(4),
                Effect = ControlsFactory.CreateShadow()
            };

            // Creates the tool tip's text
            ToolTipTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontFamily = Calibri,
                FontSize = 20,
                Background = White.HexToBrush(),
                Foreground = DarkPink.HexToBrush(),
                Margin = new Thickness(8),
                Text = toolTipText
            };

            ToolTipBorder.Child = ToolTipTextBlock;

            // Creates the text block
            HeaderTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = text,
                ToolTip = ToolTipBorder
            };

            // Adds it to the stack panel
            DataGridHeader.Children.Add(HeaderTextBlock);
            Grid.SetColumn(HeaderTextBlock, columnIndex);
            // Returns the text block
            return HeaderTextBlock;
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            var InfoDataGrid = new StackPanel(); 
            
            DataGridHeader = ControlsFactory.CreateDataGridRowGrid();
            DataGridHeader.Margin = new Thickness(24);

            var HeaderBorder = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 2),
                BorderBrush = DarkPink.HexToBrush()
            };
            HeaderBorder.Child = DataGridHeader;
            InfoDataGrid.Children.Add(HeaderBorder);

            EvaluatorTextBlock = CreateHeaderTextBlock(0, "Evaluator", "Evaluator");
            EmployeeTextBlock = CreateHeaderTextBlock(1, "Employee", "Employee");
            JobTextBlock = CreateHeaderTextBlock(2, "Job", "Job");
            DepartmentTextBlock = CreateHeaderTextBlock(3, "Department", "Department");
            EvaluationGradeTextBlock = CreateHeaderTextBlock(4, "E.G.", "Evaluations grade");
            ReportGradeTextBlock = CreateHeaderTextBlock(5, "R.G.", "Report's grade");
            FilesGradeTextBlock = CreateHeaderTextBlock(6, "F.G.", "File's grade");
            InterviewGradeTextBlock = CreateHeaderTextBlock(7, "I.G.", "Interview's grade");
            MoreDetailsTextBlock = CreateHeaderTextBlock(8, "More", "Interview comments");



            var row = new DataGridRowComponent()
            {
                EvaluatorName = "PapLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                InterviewComments = "oooofffff"
            };

            InfoDataGrid.Children.Add(row);

            var row2 = new DataGridRowComponent()
            {
                EvaluatorName = "PapLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                InterviewComments = "oooofffff"
            };

            InfoDataGrid.Children.Add(row2);



            Content = InfoDataGrid;
        }

       

        #endregion

    }

    
}
