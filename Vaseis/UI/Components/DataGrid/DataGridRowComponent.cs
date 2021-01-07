using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    public class DataGridRowComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The stack panel for a row
        /// </summary>
        protected Grid RowDataGrid { get; private set; }

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
        /// The interview's info area
        /// </summary>
        protected StackPanel InterviewAreaStackPanel { get; private set; }

        /// <summary>
        /// The interview's title text
        /// </summary>
        protected TextBlock InterviewTitleTextBlock { get; private set; }

        /// <summary>
        /// The interview's comments
        /// </summary>
        protected TextBlock InterviewCommentsTextBlock { get; private set; }

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock MoreDetailsTextBlock { get; private set; }

        /// <summary>
        /// The expander for the extra info
        /// </summary>
        protected Expander DetailsExpander { get; private set; }

        /// <summary>
        /// The detail's grin in the expander
        /// </summary>
        protected Grid DetailsGrid { get; private set; }

        #endregion

        #region Dependency Properties
       
        #region Employee name

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string EmployeeName
        {
            get { return (string)GetValue(EmployeeNameProperty); }
            set { SetValue(EmployeeNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmployeeName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeeNameProperty = DependencyProperty.Register(nameof(EmployeeName), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region Evaluator name

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string EvaluatorName
        {
            get { return (string)GetValue(EvaluatorNameProperty); }
            set { SetValue(EvaluatorNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorNameProperty = DependencyProperty.Register(nameof(EvaluatorName), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region Job name

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string JobName
        {
            get { return (string)GetValue(JobNameProperty); }
            set { SetValue(JobNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="JobName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobNameProperty = DependencyProperty.Register(nameof(JobName), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region Department name

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string DepartmentName
        {
            get { return (string)GetValue(DepartmentNameProperty); }
            set { SetValue(DepartmentNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmployeeName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentNameProperty = DependencyProperty.Register(nameof(DepartmentName), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region Evaluation grade

        /// <summary>
        /// The evaluation's grade
        /// </summary>
        public string EvaluationGrade
        {
            get { return (string)GetValue(EvaluationGradeProperty); }
            set { SetValue(EvaluationGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluationGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluationGradeProperty = DependencyProperty.Register(nameof(EvaluationGrade), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region Interview grade

        /// <summary>
        /// The interview's grade
        /// </summary>
        public string InterviewGrade
        {
            get { return (string)GetValue(InterviewGradeProperty); }
            set { SetValue(InterviewGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="InterviewGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty InterviewGradeProperty = DependencyProperty.Register(nameof(InterviewGrade), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region ReportGrade

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string ReportGrade
        {
            get { return (string)GetValue(ReportGradeProperty); }
            set { SetValue(ReportGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ReportGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ReportGradeProperty = DependencyProperty.Register(nameof(ReportGrade), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region FilesGrade

        /// <summary>
        /// The file's grade
        /// </summary>
        public string FilesGrade
        {
            get { return (string)GetValue(FilesGradeProperty); }
            set { SetValue(FilesGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FilesGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FilesGradeProperty = DependencyProperty.Register(nameof(FilesGrade), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #region Interview comments

        /// <summary>
        /// The interview's comments
        /// </summary>
        public string InterviewComments
        {
            get { return (string)GetValue(InterviewCommentsProperty); }
            set { SetValue(InterviewCommentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="InterviewComments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty InterviewCommentsProperty = DependencyProperty.Register(nameof(InterviewComments), typeof(string), typeof(DataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataGridRowComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a <see cref="TextBlock"/> to the <see cref="RowStackPanel"/>
        /// </summary>
        /// <param name="rowIndex">The row's index</param>
        protected TextBlock CreateAndAddRowItem(int columnIndex)
        {
            // Creates the text block
            var textBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Adds it to the stack panel
            RowDataGrid.Children.Add(textBlock);
            Grid.SetColumn(textBlock, columnIndex);
            // Returns the text block
            return textBlock;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            RowDataGrid = ControlsFactory.CreateDataGridRowGrid();

            #region RowData

            // Creates and adds the evaluator's text block to the row's stack panel
            EvaluatorTextBlock = CreateAndAddRowItem(0);
            // Binds the evaluator's text block to the evaluator's name
            EvaluatorTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluatorName))
            { 
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            EmployeeTextBlock = CreateAndAddRowItem(1);
            // Binds the evaluator's text block to the evaluator's name
            EmployeeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EmployeeName))
            {
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            JobTextBlock = CreateAndAddRowItem(2);
            // Binds the evaluator's text block to the evaluator's name
            JobTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(JobName))
            {
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            DepartmentTextBlock = CreateAndAddRowItem(3);
            // Binds the evaluator's text block to the evaluator's name
            DepartmentTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(DepartmentName))
            {
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            EvaluationGradeTextBlock = CreateAndAddRowItem(4);
            // Binds the evaluator's text block to the evaluator's name
            EvaluationGradeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluationGrade))
            {
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            ReportGradeTextBlock = CreateAndAddRowItem(5);
            // Binds the evaluator's text block to the evaluator's name
            ReportGradeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(ReportGrade))
            {
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            FilesGradeTextBlock = CreateAndAddRowItem(6);
            // Binds the evaluator's text block to the evaluator's name
            FilesGradeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(FilesGrade))
            {
                Source = this
            });

            // Creates and adds the evaluator's text block to the row's stack panel
            InterviewGradeTextBlock = CreateAndAddRowItem(7);
            // Binds the evaluator's text block to the evaluator's name
            InterviewGradeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(InterviewGrade))
            {
                Source = this
            });

            #endregion

            MoreDetailsTextBlock = new TextBlock()
            {
                Text = "Details",
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            RowDataGrid.Children.Add(MoreDetailsTextBlock);
            Grid.SetColumn(MoreDetailsTextBlock, 8);


            DetailsExpander = new Expander()
            {
                Header = RowDataGrid,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush()
            };

            DetailsGrid = new Grid() { Margin = new Thickness(64, 0, 0, 0)};

            InterviewAreaStackPanel = new StackPanel();
            DetailsGrid.Children.Add(InterviewAreaStackPanel);

            InterviewTitleTextBlock = new TextBlock()
            {
                Text = "Interview comments",
                FontSize = 30,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.SemiBold
            };
            InterviewAreaStackPanel.Children.Add(InterviewTitleTextBlock);

            // Creates and adds the evaluator's text block to the row's stack panel
            InterviewCommentsTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            // Binds the evaluator's text block to the evaluator's name
            InterviewCommentsTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(InterviewComments))
            {
                Source = this
            });
            InterviewAreaStackPanel.Children.Add(InterviewCommentsTextBlock);

            DetailsExpander.Content = DetailsGrid;

            Content = DetailsExpander;
        }

        #endregion
    }
}
