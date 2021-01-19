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

        /// <summary>
        /// Bool that indicates whether a report is written or not
        /// By default it is not
        /// </summary>
        public bool IsWritten { get; set; } = false;

        /// <summary>
        /// if the manager's report is finalized
        /// </summary>
        public bool IsFinalized { get; set; } = false;

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
        public ReportDataModel()
        {

        }

        #endregion
    }
}
