using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents an award
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
        /// The <see cref="EmployeeFileDataModel.Id"/> of the related <see cref="EmployeeFile"/>
        /// </summary>
        public int EmployeeFileId { get; set; }

        /// <summary>
        /// The related <see cref="EmployeeFile"/>
        /// </summary>
        public EmployeeFileDataModel EmployeeFile { get; set; }

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
    }
}
