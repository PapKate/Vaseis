using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents the awards table in the data base
    /// </summary>
    public class AwardDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related employee
        /// </summary>
        public UserDataModel Employee { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AwardDataModel()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        #endregion
    }
}
