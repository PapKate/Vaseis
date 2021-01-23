using MaterialDesignThemes.Wpf;

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The job positions data grid of the employee
    /// </summary>
    public class EmployeeJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The job position
        /// </summary>
        public JobPositionDataModel JobPosition { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The request evaluation button
        /// </summary>
        protected Button RequestButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobPositionsDataGridRowComponent(Grid pageGrid, JobPositionDataModel jobPosition) : base(pageGrid)
        {
            JobPosition = jobPosition ?? throw new ArgumentNullException(nameof(jobPosition));

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
            SubjectName = ControlsFactory.CreateSubjectsString(JobPosition.Subjects);
            JobPositionName = JobPosition.Job.JobTitle;
            DepartmentName = JobPosition.Job.Department.DepartmentName.ToString();
            SalaryText = ControlsFactory.CreateSalaryFormat(JobPosition.Job.Salary);
            NumberOfRequestsText = JobPosition.JobPositionRequests.Count().ToString();
            DeadlineName = $"{JobPosition.AnnouncementDate.Value.ToShortDateString()} - {JobPosition.SubmissionDate.Value.ToShortDateString()}";
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the edit button
            RequestButton = ControlsFactory.CreateControlButton(PackIconKind.PlusThick, GreenBlue);
            // Adds a tool tip to it
            RequestButton.ToolTip = new ToolTipComponent() { Text = "Request evaluation for job position" };
            // Binds the remove row command to the button
            RequestButton.SetBinding(Button.CommandProperty, new Binding(nameof(ShowDialogCommand))
            {
                Source = this
            });

            // Add it to the grid
            RowDataGrid.Children.Add(RequestButton);
            // On the ninth column
            Grid.SetColumn(RequestButton, 9);
            Grid.SetColumnSpan(RequestButton, 2);
        }

        #endregion

    }
}
