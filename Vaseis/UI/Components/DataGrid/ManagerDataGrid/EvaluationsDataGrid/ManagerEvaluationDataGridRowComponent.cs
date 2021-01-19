using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;



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
            FinalGrade = Evaluation.FinalGrade.ToString();
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
            // Creates the finalize and send button
            ConfirmButton = ControlsFactory.CreateFinalizeButton();
            // Creates and adds a tool tip
            ConfirmButton.ToolTip = new ToolTipComponent() { Text = "Confirm and send evaluation" };
            // Add it to the grid
            RowDataGrid.Children.Add(ConfirmButton);
            // On the tenth column
            Grid.SetColumn(ConfirmButton, 9);
            ConfirmButton.SetBinding(Button.CommandProperty, new Binding(nameof(ShowDialogCommand))
            { 
                Source = this
            });
            
            // Sets the component's content as the details' expander
            Content = DetailsExpander;
        }

        #endregion
    }
}
