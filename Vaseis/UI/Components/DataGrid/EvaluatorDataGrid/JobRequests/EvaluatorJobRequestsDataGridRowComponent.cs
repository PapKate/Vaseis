using System;
using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Windows.Data;
using System.Linq;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests data grid row
    /// </summary>
    public class EvaluatorJobRequestsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The job position
        /// </summary>
        public JobPositionRequestDataModel JobPositionRequest { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The employee's text block
        /// </summary>
        protected TextBlock EmployeeTextBlock { get; private set; }

        /// <summary>
        /// The tool tip for the employee
        /// </summary>
        protected ToolTipComponent EmployeeToolTip { get; private set; }

        #endregion

        #region Dependency Properties

        #region Evaluator

        /// <summary>
        /// The evaluator's name
        /// </summary>
        public string EmployeeText
        {
            get { return (string)GetValue(EmployeeTextProperty); }
            set { SetValue(EmployeeTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmployeeText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeeTextProperty = DependencyProperty.Register(nameof(EmployeeText), typeof(string), typeof(EvaluatorJobRequestsDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobRequestsDataGridRowComponent(Grid pageGrid, JobPositionRequestDataModel jobPositionRequest) : base(pageGrid)
        {
            JobPositionRequest = jobPositionRequest ?? throw new ArgumentNullException(nameof(jobPositionRequest));

            CreateGUI();
            Update();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates the UI based on the values of the <see cref="JobPosition"/>
        /// </summary>
        public void Update()
        {
            SubjectName = JobPositionRequest.JobPosition.Subjects.FirstOrDefault().Title;
            EmployeeText = JobPositionRequest.UsersJobFilesPair.Employee.Username;
            JobPositionName = JobPositionRequest.JobPosition.Job.JobTitle;
            DepartmentName = JobPositionRequest.JobPosition.Job.Department.DepartmentName.ToString();
            SalaryText = ControlsFactory.CreateSalaryFormat(JobPositionRequest.JobPosition.Job.Salary);
            var jobRequest = JobPositionRequest.JobPosition.JobPositionRequests.FirstOrDefault(y => y.Id == JobPositionRequest.Id);
            var index = 1;
            foreach (var request in JobPositionRequest.JobPosition.JobPositionRequests)
            {
                index++;
                if (request.Id == jobRequest.Id)
                    break;
            }
            NumberOfRequestsText = index.ToString();
            DeadlineName = $"{JobPositionRequest.JobPosition.AnnouncementDate.Value.ToShortDateString()} - {JobPositionRequest.JobPosition.SubmissionDate.Value.ToShortDateString()}";
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the evaluators text block
            EmployeeTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            // Adds it to the grid's header
            RowDataGrid.Children.Add(EmployeeTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(EmployeeTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(EmployeeTextBlock, 2);
            // Binds the evaluator's text block to the evaluator's name
            EmployeeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EmployeeText))
            {
                Source = this
            });

            // Creates a tool tip
            EmployeeToolTip = new ToolTipComponent();
            // Binds its text property to the text
            EmployeeToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(EmployeeText))
            {
                Source = this
            });
            // Adds it to the text block
            EmployeeTextBlock.ToolTip = EmployeeToolTip;
        }

        #endregion
    }
}
