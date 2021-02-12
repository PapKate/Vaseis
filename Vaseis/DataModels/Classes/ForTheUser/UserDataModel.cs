using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a user in the database
    /// </summary>
    public class UserDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The type
        /// </summary>
        public UserType Type { get; set; } = UserType.Employee;

        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The full name
        /// </summary>
        public string FullName
        {

            get => FirstName + " " + LastName;

            set { }
        }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        ///<summary>
        /// The path to the user's profile picture 
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// The date the user registered to the system
        /// </summary>
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The date the user was registered
        /// </summary>
        public int YearsOfExperience { get; set; } 

        /// <summary>
        /// The bio
        /// </summary>
        public string Bio { get; set; }

        #region Relationships

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// Null for the administrators
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// </summary>
        public DepartmentDataModel Department { get; set; }

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// </summary>
        public CompanyDataModel Company { get; set; }

        /// <summary>
        /// The <see cref="JobPositionDataModel.Id"/> of the related <see cref="JobPositionDataModel"/>
        /// </summary>
        public int? JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionDataModel"/>
        /// </summary>
        public JobPositionDataModel JobPosition { get; set; }

        /// <summary>
        /// The user's degrees
        /// </summary>
        public IEnumerable<AcquiredDegreeDataModel> AcquiredDegrees { get; set; }

        /// <summary>
        /// The user's projects
        /// </summary>
        public IEnumerable<ProjectDataModel> Projects { get; set; }

        /// <summary>
        /// The awards
        /// </summary>
        public IEnumerable<AwardDataModel> Awards { get; set; }

        /// <summary>
        /// The recommendation papers
        /// </summary>
        public IEnumerable<RecommendationPaperDataModel> RecommendationPapers { get; set; }

        /// <summary>
        /// The certificates
        /// </summary>
        public IEnumerable<CertificateDataModel> Certificates { get; set; }

        /// <summary>
        /// The languages
        /// </summary>
        public IEnumerable<LanguagesDataModel> Languages { get; set; }

        /// <summary>
        /// The job position requests of a user
        /// </summary>
        public IEnumerable<JobPositionRequestDataModel> JobPositionRequests { get; set; }

        /// <summary>
        /// That an evaluator makes
        /// </summary>
        public IEnumerable<EvaluationDataModel> Evaluations { get; set; }

        /// <summary>
        /// The reports written by a manager
        /// </summary>
        public IEnumerable<ReportDataModel> Reports { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserDataModel()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Username;

        #endregion
    }
}
