
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents the hasDegree in the database
    /// </summary>
    public class AcquiredDegreeDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The grade
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// THe year it was earned
        /// </summary>
        public DateTime YearEarned { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related employee
        /// </summary>
        public UserDataModel User { get; set; }

        /// <summary>
        /// The <see cref="DegreeDataModel.Id"/> of the related <see cref="DegreeDataModel"/>
        /// </summary>
        public int DegreeId { get; set; }

        /// <summary>
        /// The related <see cref="DegreeDataModel"/>
        /// </summary>
        public DegreeDataModel Degree { get; set; }

        #endregion

        #endregion

        #region Constructors

        public AcquiredDegreeDataModel()
        {

        }

        #endregion

        #region Public Methods

        #endregion

    }
}
