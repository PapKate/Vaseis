using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents the certifications table in the data base
    /// </summary>
    public class CertificateDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The certificate's name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related employee
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserDataModel"/>
        /// </summary>
        public UserDataModel User { get; set; }

        #endregion

        #endregion

        #region Constructors

        public CertificateDataModel()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Title;

        #endregion
    }
}
