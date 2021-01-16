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
        /// Evaluator's temporary interview grade
        /// </summary>
        public int? TempInterviewGrade { get; set; }

        /// <summary>
        /// Evaluator's comments on thew interview
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Evaluator's temporary comments on thew interview
        /// </summary>
        public string TempComments { get; set; }

        /// <summary>
        /// Evaluator's report grade
        /// </summary>
        public int? ReportGrade { get; set; }

        /// <summary>
        /// Evaluator's temporary report grade
        /// </summary>
        public int? TempReportGrade { get; set; }

        /// <summary>
        /// Evaluator's files grade
        /// </summary>
        public int? FilesGrade { get; set; }

        /// <summary>
        /// Evaluator's temporary files grade
        /// </summary>
        public int? TempFilesGrade { get; set; }

        /// <summary>
        /// Evaluator's final grade
        /// </summary>
        public int? FinalGrade { get; set; }

        /// <summary>
        /// Evaluator's final grade
        /// </summary>
        public int? TempFinalGrade { get; set; }
        
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

        ///// <summary>
        ///// The <see cref="ReportDataModel.ReportText"/> of the related <see cref="ReportDataModel"/>
        /////The report Id for this evaluation
        ///// </summary>
        //public int ReportId { get; set; }

        ///// <summary>
        ///// The related <see cref="ReportDataModel"/>
        ///// </summary>
        //public ReportDataModel Report { get; set; }

        ///// <summary>
        ///// The <see cref="UserDataModel.Id"/> of the related evaluator 
        ///// </summary>
        //public int? EvaluatorId { get; set; }

        ///// <summary>
        ///// The evaluator
        ///// </summary>
        //public UserDataModel Evaluator { get; set; }

        ///// <summary>
        ///// The <see cref="UserDataModel.Id"/> of the related employee 
        ///// </summary>
        //public int EmployeeId { get; set; }

        ///// <summary>
        ///// The employee
        ///// </summary>
        //public UserDataModel Employee { get; set; }

        ///// <summary>
        ///// The <see cref="UserDataModel.Id"/> of the related manager 
        ///// </summary>
        //public int ManagerId { get; set; }

        ///// <summary>
        ///// The manager
        ///// </summary>
        //public UserDataModel Manager { get; set; }

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
