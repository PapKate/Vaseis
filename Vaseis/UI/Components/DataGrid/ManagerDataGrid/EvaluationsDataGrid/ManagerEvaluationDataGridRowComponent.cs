using MaterialDesignThemes.Wpf;

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A row of the manager's data grid component
    /// </summary>
    public class ManagerEvaluationDataGridRowComponent : EvaluationBaseDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The completed evaluation of an employee
        /// </summary>
        public EvaluationDataModel Evaluation { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The finalize and send button
        /// </summary>
        protected Button ConfirmButton { get; private set; }

        /// <summary>
        /// The remove button
        /// </summary>
        protected Button FailButton { get; private set; }

        /// <summary>
        /// The remaining evaluation's number text block
        /// </summary>
        protected TextBlock RemainingEvaluationsNumberTextBlock { get; private set; }

        #endregion

        #region Dependency Properties

        #region SendEvaluationCommand

        /// <summary>
        /// The open dialog command
        /// </summary>
        public ICommand SendEvaluationCommand
        {
            get { return (ICommand)GetValue(SendEvaluationCommandProperty); }
            set { SetValue(SendEvaluationCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SendEvaluationCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SendEvaluationCommandProperty = DependencyProperty.Register(nameof(SendEvaluationCommand), typeof(ICommand), typeof(ManagerEvaluationDataGridRowComponent));

        #endregion

        #region Remaining Evaluations Number

        /// <summary>
        /// The remaining evaluation's property
        /// </summary>
        public string NumOfRemainingEvaluations
        {
            get { return (string)GetValue(NumOfRemainingEvaluationsProperty); }
            set { SetValue(NumOfRemainingEvaluationsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NumOfRemainingEvaluations"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NumOfRemainingEvaluationsProperty = DependencyProperty.Register(nameof(NumOfRemainingEvaluations), typeof(string), typeof(ManagerEvaluationDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerEvaluationDataGridRowComponent(Grid pageGrid, EvaluationDataModel evaluationResult) : base(pageGrid)
        {
            Evaluation = evaluationResult ?? throw new ArgumentNullException(nameof(evaluationResult));
           
            CreateGUI();

            Update();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates the UI based on the values of the <see cref="Evaluation"/>
        /// </summary>
        public void Update()
        {
            EvaluatorName = Evaluation.UsersJobFilesPair.Evaluator.ToString();
            EmployeeName = Evaluation.UsersJobFilesPair.Employee.ToString();
            JobPositionName = Evaluation.JobPositionRequest.JobPosition.Job.JobTitle.ToString();
            DepartmentName = Evaluation.JobPositionRequest.JobPosition.Job.Department.DepartmentName.ToString();
            FinalGrade = ControlsFactory.GetGrade(Evaluation.FinalGrade).ToString("F", CultureInfo.InvariantCulture);
            InterviewGrade = ControlsFactory.GetGrade(Evaluation.InterviewGrade).ToString("F", CultureInfo.InvariantCulture);
            ReportGrade = ControlsFactory.GetGrade(Evaluation.ReportGrade).ToString("F", CultureInfo.InvariantCulture);
            FilesGrade = ControlsFactory.GetGrade(Evaluation.FilesGrade).ToString("F", CultureInfo.InvariantCulture);
            InterviewComments = Evaluation.Comments;
            ReportParagraph = Evaluation.UsersJobFilesPair.Reports.Where(x => x.JobPositionRequestId == Evaluation.JobPositionRequestId).FirstOrDefault().ReportText;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            //Creates the more details text
            RemainingEvaluationsNumberTextBlock = new TextBlock()
            {
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            // Adds it to the grid
            RowDataGrid.Children.Add(RemainingEvaluationsNumberTextBlock);
            // On the eighth column
            Grid.SetColumn(RemainingEvaluationsNumberTextBlock, 8);
            // Bind the text block's text property to the remaining evaluation's number string
            RemainingEvaluationsNumberTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(NumOfRemainingEvaluations))
            { 
                Source = this
            });

            // Hides the more details block from the parent
            MoreDetailsTextBlock.Visibility = Visibility.Collapsed;

            // Creates the finalize and send button
            ConfirmButton = ControlsFactory.CreateFinalizeButton();
            // Creates and adds a tool tip
            ConfirmButton.ToolTip = new ToolTipComponent() { Text = "Confirm and send promotion" };
            // Add it to the grid
            RowDataGrid.Children.Add(ConfirmButton);
            // On the tenth column
            Grid.SetColumn(ConfirmButton, 9);
            ConfirmButton.SetBinding(Button.CommandProperty, new Binding(nameof(ShowDialogCommand))
            { 
                Source = this
            });

            // Creates the failed button
            FailButton = ControlsFactory.CreateControlButton(PackIconKind.ArrowUpBold, DarkPink);
            // Creates and adds a tool tip
            FailButton.ToolTip = new ToolTipComponent() { Text = "Confirm and send evaluation" };
            // Add it to the grid
            RowDataGrid.Children.Add(FailButton);
            // On the tenth column
            Grid.SetColumn(FailButton, 10);
            FailButton.SetBinding(Button.CommandProperty, new Binding(nameof(SendEvaluationCommand))
            {
                Source = this
            });

            // Sets the component's content as the details' expander
            Content = DetailsExpander;
        }

        #endregion
    }
}
