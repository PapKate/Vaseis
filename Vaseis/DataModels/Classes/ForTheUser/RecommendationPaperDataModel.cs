﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// The recommendation papers
    /// </summary>
    public class RecommendationPaperDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The name of the person who made the recommendation
        /// </summary>
        public string Referee { get; set; }

        /// <summary>
        /// The recommendation's text
        /// </summary>
        public string Description { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The related <see cref="UserDataModel"/>
        /// </summary>
        public UserDataModel User { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecommendationPaperDataModel()
        {

        }

        #endregion
    }
}
