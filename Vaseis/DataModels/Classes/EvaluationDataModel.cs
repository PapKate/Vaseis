using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents the evaluation package
    /// </summary>
    public class EvaluationDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Evaluator's interview grade
        /// </summary>
        public int? InterviewGrade { get; set; }

        /// <summary>
        ///is evaluator's evaluation grades finalized 
        /// </summary>
        public bool IsFinalized { get; set; } = false;

        /// <summary>
        /// Evaluator's comments on thew interview
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Evaluator's report grade
        /// </summary>
        public int? ReportGrade { get; set; }

        /// <summary>
        /// Evaluator's files grade
        /// </summary>
        public int? FilesGrade { get; set; }

        /// <summary>
        /// Evaluator's final grade
        /// </summary>
        public int? FinalGrade { get; set; }

        ///<summary>
        ///The stupid phase done
        /// </summary>
        public bool IsAprovedByManager { get; set; } = false;

        /// <summary>
        /// The bool for whether an employee has passed the evaluation
        /// </summary>
        public bool? Passed { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="JobPositionRequestDataModel.Id"/> of the related <see cref="JobPositionRequestDataModel"/>
        /// The job position's request Id
        /// </summary>
        public int JobPositionRequestId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionRequestDataModel"/>
        /// </summary>
        public JobPositionRequestDataModel JobPositionRequest { get; set; }

        /// <summary>
        /// The <see cref="UsersJobFilesPairDataModel.Id"/> of the related <see cref="UsersJobFilesPairDataModel"/>
        /// </summary>
        public int UsersJobFilesPairId { get; set; }

        /// <summary>
        /// The related <see cref="UsersJobFilesPairDataModel"/>
        /// </summary>
        public UsersJobFilesPairDataModel UsersJobFilesPair { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluationDataModel()
        {

        }

        #endregion
    }
}
