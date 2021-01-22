using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents an available job position
    /// </summary>
    public class JobPositionDataModel 
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// the announcement date
        /// </summary>
        public DateTime? AnnouncementDate { get; set; }

        /// <summary>
        /// the submission date
        /// </summary>
        public DateTime? SubmissionDate { get; set; }

        /// <summary>
        /// the start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the evaluator who created the position
        /// </summary>
        public int? CreatorId { get; set; }

        /// <summary>
        /// The <see cref="JobDataModel.Id"/> the Job supplied
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// The related <see cref="JobDataModel"/>
        /// </summary>
        public JobDataModel Job { get; set; }

        /// <summary>
        /// The job position subjects
        /// </summary>
        public IEnumerable<SubjectDataModel> Subjects { get; set; }

        /// <summary>
        /// The job position's requests
        /// </summary>
        public IEnumerable<JobPositionRequestDataModel> JobPositionRequests { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionDataModel() : base()
        { 

        }

        #endregion

    }

    /// <summary>
    /// Represents a job
    /// </summary>



}
