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
        /// Evaluatrorr's interview grade
        /// </summary>
        public float? InterviewGrade { get; set; }

        /// <summary>
        /// Evaluatrorr's comments on thew interview
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// Evaluatrorr's report grade
        /// </summary>
        public float? ReportGrade { get; set; }

        /// <summary>
        /// Evaluatrorr's files grade
        /// </summary>
        public float? FilesGrade { get; set; }

        /// <summary>
        /// Evaluatrorr's final grade
        /// </summary>
        public float? FinalGrade { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related evaluator 
        /// </summary>
        public int? EvaluatorId { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee 
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// The <see cref="JobPostionDataModel.Id"/> of the open job position
        /// </summary>
        public int? JobPositionId { get; set; }

        #region Relationships
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
