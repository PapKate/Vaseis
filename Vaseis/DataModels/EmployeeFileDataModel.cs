using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents an employee file
    /// </summary>
    public class EmployeeFileDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The bio
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// The years of experience
        /// </summary>
        public int YearsOfExpirience { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The <see cref="JobDataModel.Id"/> of the related <see cref="JobDataModel"/>
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// The awards
        /// </summary>
        public IEnumerable<AwardDataModel> Awards { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeFileDataModel()
        {

        }

        #endregion
    }
}
