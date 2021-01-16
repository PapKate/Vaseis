using MaterialDesignThemes.Wpf;

using System.Windows;

namespace Vaseis
{
    /// <summary>
    /// The evaluation report's dialog
    /// </summary>
    public class EvaluationDialogComponent : ReportDialogComponent
    {
        /// <summary>
        /// The dialog host
        /// </summary>
        public DialogHost EvaluationReportDialogHost { get; private set; }

        #region Protected Properties

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent ReportGradeInput { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent QualificationsGradeInput { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent InterviewGradeInput { get; private set; }


        #endregion

        #region Constructors

        public EvaluationDialogComponent(EvaluatorDataGridRowComponent evaluatorDataGridRow) : base(evaluatorDataGridRow)
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Displays the data grid's values in the report
        /// </summary>
        protected override void DialogVisibilityChanged(DependencyPropertyChangedEventArgs e)
        {
            // The virtual method
            base.DialogVisibilityChanged(e);
            // If the row is not null...
            if (EvaluatorDataGridRow != null)
            {
                // Add the text from the row to the input text in the dialog accordingly
                ReportGradeInput.Text = EvaluatorDataGridRow.ReportGrade;
                InterviewGradeInput.Text = EvaluatorDataGridRow.InterviewGrade;
                ParagraphTextBox.Text = EvaluatorDataGridRow.InterviewComments;
                UserNameTextBlock.Text = EvaluatorDataGridRow.EmployeeName;
                JopPositionTextBlock.Text = EvaluatorDataGridRow.JobName;
                QualificationsGradeInput.Text = EvaluatorDataGridRow.FilesGrade;
                DepartmentTextBlock.Text = EvaluatorDataGridRow.DepartmentName;
            }
        }

        /// <summary>
        /// Displays the dialog's values to the data grid
        /// </summary>
        protected override void TemporarySaveOnClick(RoutedEventArgs e)
        {
            // The virtual method
            base.TemporarySaveOnClick(e);
            // Gets the report's grade value from the dialog and sets it accordingly on the data grid row
            EvaluatorDataGridRow.ReportGrade = ReportGradeInput.Text;
            EvaluatorDataGridRow.InterviewGrade = InterviewGradeInput.Text;
            EvaluatorDataGridRow.FilesGrade = QualificationsGradeInput.Text;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // The title of the dialog
            DialogTitle.Text = "Evaluation report";

            #region Input Data

            // The input field for report's grade
            ReportGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Report's grade",
                Width = 240,
            };

            // The input field for qualifications grade
            QualificationsGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Qualification's grade",
                Width = 240,
            };

            // The input field for user
            InterviewGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Interview's grade",
                Width = 240,
            };
            
            // Sets the title text of the paragraph area
            TextTitleBlock.Text = "Interview comments";

            // Adds the input field to the input wrap panel
            InputWrapPanel.Children.Add(ReportGradeInput);
            InputWrapPanel.Children.Add(QualificationsGradeInput);
            InputWrapPanel.Children.Add(InterviewGradeInput);

            #endregion

        }

        #endregion

    }
}
