using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a manager and an employee pair
    /// </summary>
    public class UsersJobFilesPairDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related manager
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// The related manager
        /// </summary>
        public UserDataModel Manager { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related evaluator
        /// </summary>
        public int EvaluatorId { get; set; }

        /// <summary>
        /// The related evaluator
        /// </summary>
        public UserDataModel Evaluator { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related employee
        /// </summary>
        public UserDataModel Employee { get; set; }

        public IEnumerable<ReportDataModel> Reports { get; set; }

        public IEnumerable<EvaluationDataModel> Evaluations { get; set; }

        public IEnumerable<JobPositionRequestDataModel> JobPositionRequests { get; set; }


        ///// <summary>
        ///// The <see cref="ReportDataModel.Id"/> of the related <see cref="ReportDataModel"/>
        ///// The report's id
        ///// </summary>
        //public int? ReportId { get; set; }

        ///// <summary>
        ///// The related <see cref="ReportDataModel"/>
        ///// The report
        ///// </summary>
        //public ReportDataModel Report { get; set; }

        ///// <summary>
        ///// The <see cref="EvaluationDataModel.Id"/> of the related <see cref="EvaluationDataModel"/>
        ///// </summary>
        //public int? EvaluationId { get; set; }

        ///// <summary>
        ///// The related <see cref="EvaluationDataModel"/>
        ///// </summary>
        //public EvaluationDataModel Evaluation { get; set; }

        ///// <summary>
        ///// The <see cref="JobPositionRequestDataModel.Id"/> of the related <see cref="JobPositionRequestDataModel"/>
        ///// The job position request's id
        ///// </summary>
        //public int? JobPositionRequestId { get; set; }

        ///// <summary>
        ///// The related <see cref="JobPositionRequestDataModel"/>
        ///// </summary>
        //public JobPositionRequestDataModel JobPositionRequest { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersJobFilesPairDataModel()
        {

        }

        #endregion
    }
}
