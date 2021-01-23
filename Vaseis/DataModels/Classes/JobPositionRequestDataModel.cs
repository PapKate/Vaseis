using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    public class JobPositionRequestDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The request's reason for applying for the job position
        /// </summary>
        public string RequestsReason { get; set; }

        #region Relationship

        /// <summary>
        /// The <see cref="JobPositionDataModel.Id"/> of the related <see cref="JobPositionDataModel"/>
        /// The job position id
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionDataModel"/>
        /// The job position
        /// </summary>
        public JobPositionDataModel JobPosition { get; set; }

        /// <summary>
        /// The <see cref="UsersJobFilesPairDataModel.Id"/> of the related <see cref="UsersJobFilesPairDataModel"/>
        /// </summary>
        public int? UsersJobFilesPairId { get; set; }

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
        public JobPositionRequestDataModel()
        {

        }

        #endregion
    }
}
