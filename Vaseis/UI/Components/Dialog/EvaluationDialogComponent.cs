using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The evaluation report's dialog
    /// </summary>
    public class EvaluationDialogComponent : ReportDialogComponent
    {
        #region Public Properties 

        /// <summary>
        /// the evaluation
        /// </summary>
        public EvaluationDataModel Evaluation { get; }

        /// <summary>
        /// The dialog host
        /// </summary>
        public DialogHost EvaluationReportDialogHost { get; private set; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent ReportGradeInput { get; private set; }

        /// <summary>
        /// The instructions text for the grades
        /// </summary>
        protected TextBlock GradeInstructionsTextBlock { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent QualificationsGradeInput { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent InterviewGradeInput { get; private set; }

        /// <summary>
        /// The border 
        /// </summary>
        protected Border Sellotape { get; private set; }

        #endregion

        #region Constructors

        public EvaluationDialogComponent(EvaluatorDataGridRowComponent evaluatorDataGridRow, EvaluationDataModel evaluation) : base(evaluatorDataGridRow)
        {
            Evaluation = evaluation ?? throw new ArgumentNullException(nameof(evaluation));

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
                JopPositionTextBlock.Text = EvaluatorDataGridRow.JobPositionName;
                QualificationsGradeInput.Text = EvaluatorDataGridRow.FilesGrade;
                DepartmentTextBlock.Text = EvaluatorDataGridRow.DepartmentName;
            }
        }

        /// <summary>
        /// Displays the dialog's values to the data grid
        /// </summary>
        protected override void TemporarySaveOnClick(RoutedEventArgs e)
        {
            base.TemporarySaveOnClick(e);
            // Gets the report's grade value from the dialog and sets it accordingly on the data grid row
            Evaluation.ReportGrade = ControlsFactory.GradeToNullableInt(ReportGradeInput.Text);
            Evaluation.InterviewGrade = ControlsFactory.GradeToNullableInt(InterviewGradeInput.Text);
            Evaluation.FilesGrade = ControlsFactory.GradeToNullableInt(QualificationsGradeInput.Text);
            // Sets the row's values according to the matching input in the dialog
            Evaluation.Comments = ParagraphTextBox.Text;
            Evaluation.FinalGrade = ControlsFactory.CreateFinalGrade( Evaluation.FilesGrade, Evaluation.InterviewGrade, Evaluation.ReportGrade);
            EvaluatorDataGridRow.Update();
        }

        protected override void FinalizedOnClick(RoutedEventArgs e)
        {
            //call the base's virtual method
            base.FinalizedOnClick(e);

            //update the inputs to the memory
            TemporarySaveOnClick(e);       

            //Set the finalized value to true (finalized)
            Evaluation.IsFinalized = true;

            //update the finalized value to true
            EvaluatorDataGridRow.Update();

            EvaluatorDataGridRow.Visibility = Visibility.Collapsed;
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

            Sellotape = new Border()
            {
                Width = 240,

            };
            InputWrapPanel.Children.Add(Sellotape);

            #region Input Data
            
            // Creates the text with the instructions
            GradeInstructionsTextBlock = new TextBlock()
            {
                Margin = new Thickness(24),
                Text = "Values from 0 to 10",
                TextWrapping = TextWrapping.Wrap,
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri
            };

            // The input field for report's grade
            ReportGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "RG",
                Width = 64,
            };

            // The input field for qualifications grade
            QualificationsGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "QG",
                Width = 64,
            };

            // The input field for user
            InterviewGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "IG",
                Width = 64,
            };
            
            // Sets the title text of the paragraph area
            TextTitleBlock.Text = "Interview comments";

            // Adds the input field to the input wrap panel
            InputWrapPanel.Children.Add(GradeInstructionsTextBlock);
            InputWrapPanel.Children.Add(ReportGradeInput);
            InputWrapPanel.Children.Add(QualificationsGradeInput);
            InputWrapPanel.Children.Add(InterviewGradeInput);

            #endregion

        }

        #endregion

    }
}
