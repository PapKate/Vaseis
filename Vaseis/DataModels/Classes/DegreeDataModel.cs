using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a degree in the database
    /// </summary>
    public class DegreeDataModel
    {
        #region Public Properties

        /// <summary>
        /// The company's id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The degree's name
        /// </summary>
        public DegreeTitle Title { get; set; }

        /// <summary>
        /// The name of the institution
        /// </summary>
        public School School { get; set; }

        /// <summary>
        /// The level of education 
        /// </summary>
        public LevelOfEducation LevelOfEducation { get; set; }

        #region Relationships

        /// <summary>
        /// The related users that have the degree
        /// </summary>
        public IEnumerable<AcquiredDegreeDataModel> AcquiredDegrees { get; set; }

        #endregion

        #endregion

        #region Constructors
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public DegreeDataModel()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Title.ToString();

        #endregion
    }
}
