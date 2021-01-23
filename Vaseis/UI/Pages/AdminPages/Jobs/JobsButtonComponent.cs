using System;
using System.Collections.Generic;
using System.Text;

namespace Vaseis
{
    public class JobsButtonComponent : JobsDataButton
    {
        #region Public Properties

        /// <summary>
        /// The Job
        /// </summary>
        public JobDataModel Job { get; }

        #endregion

        #region Constructors

        /// <param name="user">The user</param>
        public JobsButtonComponent(JobDataModel job)
        {
            Job = job ?? throw new ArgumentNullException(nameof(job));
            Department = Job.Department.DepartmentName.ToString();
            JobTitle = Job.JobTitle.ToString();
            Background = Job.Department.Color.HexToBrush();
            Height = 150;
        }

        #endregion
    }

}