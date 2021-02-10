using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a relationship between a job position and a subject
    /// </summary>
    public class JobPositionSubjectDataModel
    {
        #region Public Properties

        #region Relationships

        /// <summary>
        /// The <see cref="SubjectDataModel.Id"/> of the related <see cref="SubjectDataModel"/>
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// The related <see cref="SubjectDataModel"/>
        /// </summary>
        public SubjectDataModel Subject { get; set; }

        /// <summary>
        /// The <see cref="JobPositionDataModel.Id"/> of the related <see cref="JobPositionDataModel"/>
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionDataModel"/>
        /// </summary>
        public JobPositionDataModel JobPosition { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionSubjectDataModel() : base()
        {

        }

        #endregion

    }
}
