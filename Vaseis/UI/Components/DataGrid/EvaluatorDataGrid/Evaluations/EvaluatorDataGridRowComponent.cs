using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The evaluator's evaluation data grid row
    /// </summary>
    public class EvaluatorDataGridRowComponent : EvaluationBaseDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The evaluation
        /// </summary>
        public EvaluationDataModel Evaluation { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The edit button
        /// </summary>
        protected Button EditButton { get; private set; }

        /// <summary>
        /// The finalize and send button
        /// </summary>
        protected Button FinalizeButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region OpenDialogCommand

        /// <summary>
        /// The open dialog command
        /// </summary>
        public ICommand OpenDialogCommand
        {
            get { return (ICommand)GetValue(OpenDialogCommandProperty); }
            set { SetValue(OpenDialogCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OpenDialogCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OpenDialogCommandProperty = DependencyProperty.Register(nameof(OpenDialogCommand), typeof(ICommand), typeof(EvaluatorDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorDataGridRowComponent(Grid pageGrid, EvaluationDataModel evaluation) : base(pageGrid)
        {
            Evaluation = evaluation ?? throw new ArgumentNullException(nameof(evaluation));

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
            EvaluatorName = Evaluation.UsersJobFilesPair.Evaluator.Username;
            EmployeeName = Evaluation.UsersJobFilesPair.Employee.Username;
            JobPositionName = Evaluation.JobPositionRequest.JobPosition.Job.JobTitle;
            DepartmentName = Evaluation.JobPositionRequest.JobPosition.Job.Department.DepartmentName.ToString();
            FilesGrade = ControlsFactory.GetGrade(Evaluation.FilesGrade).ToString();
            InterviewGrade = ControlsFactory.GetGrade(Evaluation.InterviewGrade).ToString();
            ReportGrade = ControlsFactory.GetGrade(Evaluation.ReportGrade).ToString();
            FinalGrade = ControlsFactory.GetGrade(Evaluation.FinalGrade).ToString();
            InterviewComments = Evaluation.Comments;
            ReportParagraph = Evaluation.JobPositionRequest.UsersJobFilesPair.Reports.Where(x => x.JobPositionRequestId == Evaluation.JobPositionRequest.Id).FirstOrDefault().ReportText; 
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the edit button
            EditButton = ControlsFactory.CreateEditButton();
            // Creates and adds a tool tip
            EditButton.ToolTip = new ToolTipComponent() { Text = "Edit evaluation" };

            EditButton.Click += ShowEditEvaluationDialog;

            // Add it to the grid
            RowDataGrid.Children.Add(EditButton);
            // On the ninth column
            Grid.SetColumn(EditButton, 9);

            // Creates the finalize and send button
            FinalizeButton = ControlsFactory.CreateFinalizeButton();
            // Creates and adds a tool tip
            FinalizeButton.ToolTip = new ToolTipComponent() { Text = "Finalize and send evaluation" };
            // Add it to the grid
            RowDataGrid.Children.Add(FinalizeButton);
            // On the tenth column
            Grid.SetColumn(FinalizeButton, 10);
            // When clicked shows the finalized dialog
            FinalizeButton.Click += ShowFinalizedDialogOnClick;
            // Bonds the open dialog command to the finalized button's command property
            FinalizeButton.SetBinding(Button.CommandProperty, new Binding(nameof(OpenDialogCommand))
            {
                Source = this
            });

            // Sets the component's content as the details' expander
            Content = DetailsExpander;
        }

        /// <summary>
        /// On click shows the evaluation dialog
        /// </summary>
        private void ShowEditEvaluationDialog(object sender, RoutedEventArgs e)
        {
            // Creates an evaluation dialog
            var evaluationDialog = new EvaluationDialogComponent(this, Evaluation)
            {
                // And opens it
                IsDialogOpen = true,
            };
            evaluationDialog.FinalizedCommand = new RelayCommand(async () =>
            {
                await Task.Delay(1000);
                // Creates a new finalized dialog
                var finalizedDialog = new MessageDialogComponent()
                {
                    Message = "Your evaluation has been successfully sent to a manager",
                    Title = "Success",
                    BrushColor = HookersGreen.HexToBrush(),
                    IsDialogOpen = true,
                    OkCommand = new RelayCommand(() =>
                    {
                        evaluationDialog.IsDialogOpen = false; 
                        this.Visibility = Visibility.Collapsed;
                    })
                };
                
                // Updates the evaluation data model in the data base
                await Services.GetDataStorage.UpdateEvaluatorEvaluationAsync(Evaluation, true);

                // Adds it to the page's grid
                PageGrid.Children.Add(finalizedDialog);
            });
            // Adds it to the page's grid
            PageGrid.Children.Add(evaluationDialog);
        }

        /// <summary>
        /// Opens a dialog notifying the evaluator the evaluation has been sent to a manager
        /// </summary>
        private async void ShowFinalizedDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new finalized dialog
            var finalizedDialog = new MessageDialogComponent()
            {
                Message = "Your evaluation has been successfully sent to a manager",
                Title = "Success",
                BrushColor = HookersGreen.HexToBrush(),
                IsDialogOpen = true,
                OkCommand = new RelayCommand(() => this.Visibility = Visibility.Collapsed)
            };

            // Updates the evaluation data model in the data base
            await Services.GetDataStorage.UpdateEvaluatorEvaluationAsync(Evaluation, true);

            // Adds it to the page's grid
            PageGrid.Children.Add(finalizedDialog);
        }

        #endregion

    }
}
