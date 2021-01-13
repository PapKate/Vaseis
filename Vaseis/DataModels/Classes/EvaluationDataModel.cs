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
        public float? InterviewGrade { get; set; }

        /// <summary>
        /// Evaluator's temporary interview grade
        /// </summary>
        public float? TempInterviewGrade { get; set; }

        /// <summary>
        /// Evaluator's comments on thew interview
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// Evaluator's temporary comments on thew interview
        /// </summary>
        public string? TempComments { get; set; }

        /// <summary>
        /// Evaluator's report grade
        /// </summary>
        public float? ReportGrade { get; set; }

        /// <summary>
        /// Evaluator's temporary report grade
        /// </summary>
        public float? TempReportGrade { get; set; }

        /// <summary>
        /// Evaluator's files grade
        /// </summary>
        public float? FilesGrade { get; set; }

        /// <summary>
        /// Evaluator's temporary files grade
        /// </summary>
        public float? TempFilesGrade { get; set; }

        /// <summary>
        /// Evaluator's final grade
        /// </summary>
        public float? FinalGrade { get; set; }

        /// <summary>
        /// Evaluator's final grade
        /// </summary>
        public float? TempFinalGrade { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="ReportDataModel.ReportText"/> of the related <see cref="ReportDataModel"/>
        ///The report Id for this evaluation
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// The related <see cref="ReportDataModel"/>
        /// </summary>
        public ReportDataModel Report { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related evaluator 
        /// </summary>
        public int? EvaluatorId { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee 
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The employee
        /// </summary>
        public UserDataModel Employee { get; set; }

        /// <summary>
        /// The <see cref="JobPositionDataModel.Id"/> of the related <see cref="JobPositionDataModel"/> open job position
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionDataModel"/>
        /// </summary>
        public JobPositionDataModel JobPosition { get; set; }

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
