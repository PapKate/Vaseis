using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a project in the database
    /// </summary>
    public class ProjectDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The project's name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        public MadeForWho MadeForWho { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id" /> of the related <see cref="UserDataModel"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserDataModel"/>
        /// </summary>
        public UserDataModel User { get; set; }

        #endregion

        #endregion

        #region Constructors

        public ProjectDataModel()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        public override string ToString() => Title;

        #endregion

    }
}
