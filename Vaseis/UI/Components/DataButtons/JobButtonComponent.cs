using System;

namespace Vaseis
{
    public class JobButtonComponent : DataButtonComponent
    {
        #region Public Properties

        /// <summary>
        /// The job
        /// </summary>
        public JobDataModel Job { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="job">The job</param>
        public JobButtonComponent(JobDataModel job)
        {
            Job = job ?? throw new ArgumentNullException(nameof(job));
            Title = Job.JobTitle;
            Text = Job.Department.DepartmentName;

            Background = Job.Department.Color.HexToBrush();
            Height = 200;
        }

        #endregion

    }
}
