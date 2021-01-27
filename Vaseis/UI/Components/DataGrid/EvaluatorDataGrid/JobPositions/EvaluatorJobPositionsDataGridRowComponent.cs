using System;
using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Windows.Data;
using System.Linq;
using System.Collections.Generic;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job position data grid's row
    /// </summary>
    public class EvaluatorJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The job position
        /// </summary>
        public JobPositionDataModel JobPosition { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The evaluator's text block
        /// </summary>
        protected TextBlock EvaluatorTextBlock { get; private set; }

        /// <summary>
        /// The evaluator's tool tip
        /// </summary>
        protected ToolTipComponent EvaluatorToolTip { get; private set; }

        #endregion

        #region Dependency Properties

        #region Evaluator

        /// <summary>
        /// The evaluator's name
        /// </summary>
        public string EvaluatorText
        {
            get { return (string)GetValue(EvaluatorTextProperty); }
            set { SetValue(EvaluatorTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorTextProperty = DependencyProperty.Register(nameof(EvaluatorText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobPositionsDataGridRowComponent(Grid pageGrid, JobPositionDataModel jobPosition) : base(pageGrid)
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
            var subjectList = new List<SubjectDataModel>();
            JobPosition.JobsAndSubjects.ToList().ForEach(x => subjectList.Add(x.Subject));
            SubjectName = ControlsFactory.CreateSubjectsString(subjectList);
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
            
        }

        #endregion
    }
}
