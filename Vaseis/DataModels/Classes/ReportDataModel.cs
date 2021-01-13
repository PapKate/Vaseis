using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a report
    /// </summary>
    public class ReportDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The report information
        /// </summary>
        public string ReportText { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related manager
        /// </summary>
        public int ManagerId { get; set; }

        public UserDataModel Manager { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related employee
        /// </summary>
        public UserDataModel Employee { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related evaluator
        /// </summary>
        public int EvaluatorId { get; set; }

        /// <summary>
        /// The related evaluator
        /// </summary>
        public UserDataModel Evaluator { get; set; }

        /// <summary>
        /// The <see cref="UsersJobFilesPairDataModel.Id"/> of the related <see cref="UsersJobFilesPairDataModel"/>
        /// </summary>
        public int UsersJobFilePairId { get; set; }

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
        public ReportDataModel()
        {

        }

        #endregion
    }
}
