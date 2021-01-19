using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    public class DataGridRowComponent : BaseDataGridRowComponent
    {
        #region Protected Properties

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

        #endregion

        #region Dependency Properties
       
        #region Evaluation grade

        /// <summary>
        /// The evaluation's grade
        /// </summary>
        public string FinalGrade
        {
            get { return (string)GetValue(FinalGradeProperty); }
            set { SetValue(FinalGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FinalGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FinalGradeProperty = DependencyProperty.Register(nameof(FinalGrade), typeof(string), typeof(DataGridRowComponent));

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

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the evaluator's text block to the row's stack panel
            EvaluationGradeTextBlock = CreateAndAddRowItem(4);
            // Binds the evaluator's text block to the evaluator's name
            EvaluationGradeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(FinalGrade))
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

        }

        #endregion
    }
}
