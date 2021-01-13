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
        /// The <see cref="UserDataModel.Id"/> of the related manager
        /// </summary>
        public int ManagerId { get; set; }

        public UserDataModel Manager { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee
        /// </summary>
        public int EmployeeId { get; set; }

        public UserDataModel Employee { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related evaluator
        /// </summary>
        public int EvaluatorId { get; set; }

        public UserDataModel Evaluator { get; set; }

        /// <summary>
        /// The report information
        /// </summary>
        public string Report { get; set; }

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
