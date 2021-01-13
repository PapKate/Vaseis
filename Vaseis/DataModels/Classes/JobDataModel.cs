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

        /// <summary>
        /// the job title 
        /// </summary>
        public string JobTitle{ get; set; }

        /// <summary>
        /// the job title 
        /// </summary>
        public int Salary{ get; set; }

        /// <summary>
        /// the job department
        /// </summary>
        public int Department{ get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobDataModel()
        {

        }

        #endregion

        #region Relationships

        /// <summary>
        /// The <see cref="CompanyDataModel.Id"/> of the related <see cref="CompanyDataModel"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// </summary>
        public CompanyDataModel Company { get; set; }


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
