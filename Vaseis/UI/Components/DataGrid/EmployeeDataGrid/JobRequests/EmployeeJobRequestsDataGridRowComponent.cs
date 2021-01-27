using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The job position requests data grid
    /// </summary>
    public class EmployeeJobRequestsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The job request
        /// </summary>
        public JobPositionRequestDataModel JobPositionRequest { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The request evaluation button
        /// </summary>
        protected Button RemoveRequestButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobRequestsDataGridRowComponent(Grid pageGrid, JobPositionRequestDataModel jobPositionRequest) : base(pageGrid)
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
            var subjectList = new List<SubjectDataModel>();
            JobPositionRequest.JobPosition.JobsAndSubjects.ToList().ForEach(x => subjectList.Add(x.Subject));
            SubjectName = ControlsFactory.CreateSubjectsString(subjectList);
            JobPositionName = JobPositionRequest.JobPosition.Job.JobTitle;
            DepartmentName = JobPositionRequest.JobPosition.Job.Department.DepartmentName.ToString();
            SalaryText = ControlsFactory.CreateSalaryFormat(JobPositionRequest.JobPosition.Job.Salary);
            NumberOfRequestsText = JobPositionRequest.JobPosition.JobPositionRequests.Count().ToString();
            DeadlineName = $"{JobPositionRequest.JobPosition.AnnouncementDate.Value.ToShortDateString()} - {JobPositionRequest.JobPosition.SubmissionDate.Value.ToShortDateString()}";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the edit button
            RemoveRequestButton = ControlsFactory.CreateControlButton(PackIconKind.Minus, Red);
            // Adds a tool tip to it
            RemoveRequestButton.ToolTip = new ToolTipComponent() { Text = "Remove evaluation request"};
            // Binds the command property of the button to the remove row command
            RemoveRequestButton.SetBinding(Button.CommandProperty, new Binding(nameof(ShowDialogCommand))
            { 
                Source = this
            });

            // Add it to the grid
            RowDataGrid.Children.Add(RemoveRequestButton);
            // On the ninth column
            Grid.SetColumn(RemoveRequestButton, 9);
            Grid.SetColumnSpan(RemoveRequestButton, 2);
        }

        #endregion

    }
}
