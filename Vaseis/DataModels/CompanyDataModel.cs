using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a company
    /// </summary>
    public class CompanyDataModel
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

        /// <summary>
        /// The date the company was created
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;

        #region Relationships

        /// <summary>
        /// The related users
        /// </summary>
        public IEnumerable<UserDataModel> Users { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyDataModel()
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
