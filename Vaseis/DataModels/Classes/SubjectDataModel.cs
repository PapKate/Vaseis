using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents the subject of a job position
    /// </summary>
    public class SubjectDataModel
    { 
        #region Public Properties
  
        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The subject's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The  subject's decription
        /// </summary>
        public string Description { get; set; }

        #region Relationships

        #region recursion

        /// <summary>
        /// The <see cref="SubjectDataModel.Id"/> of the related <see cref="SubjectDataModel"/>
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// The related <see cref="SubjectDataModel"/>
        /// </summary>+
        public SubjectDataModel Subject{ get; set; }

        /// <summary>
        /// The more specific subjects that belong to this subject
        /// </summary>
        public IEnumerable<SubjectDataModel> ChildrenSubjects { get; set; }

        #endregion

        /// <summary>
        /// The job position and subjects
        /// </summary>
        public IEnumerable<JobPositionSubjectDataModel> JobsAndSubjects { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubjectDataModel()
        {

        }

        #endregion
    }
}
