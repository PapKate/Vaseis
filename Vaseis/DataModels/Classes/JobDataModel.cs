using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a job
    /// </summary>
    public class JobDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobDataModel()
        {

        }

        #endregion
    }

    public class UserJobRequests
    {
        #region Public Properties

        public int Id { get; set; }

        #region Relationship

        public int UserId { get; set; }

        public UserDataModel User { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserJobRequests()
        {

        }

        #endregion
    }
}
