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
        /// The email
        /// </summary>
        public string Email { get; set; }

        ///<summary>
        /// The path to the user's profile picture 
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// The date the user was registered
        /// </summary>
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The full name
        /// </summary>
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// The bio
        /// </summary>
        public string Bio { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="CompanyDataModel.Id"/> of the related <see cref="CompanyDataModel"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// </summary>
        public CompanyDataModel Company { get; set; }

        /// <summary>
        /// The related <see cref="DepartmentDataModel"/>
        /// Null for the administrators
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// The related <see cref="DepartmentDataModel"/>
        /// </summary>
        public DepartmentDataModel Department { get; set; }

        /// <summary>
        /// The <see cref="JobDataModel.Id"/> of the related <see cref="JobDataModel"/>
        /// </summary>
        public int? JobId { get; set; }

        /// <summary>
        /// The related <see cref="Job"/>
        /// </summary>
        public JobDataModel Job { get; set; }

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
        public IEnumerable<RecomendationPaperDataModel> RecommendationPapers { get; set; }

        /// <summary>
        /// The certificates
        /// </summary>
        public IEnumerable<CertificateDataModel> Certificates { get; set; }

        /// <summary>
        /// The languages
        /// </summary>
        public IEnumerable<LanguagesDataModel> Languages { get; set; }



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

    /// <summary>
    /// Represents a manager and an employee pair
    /// </summary>
    public class ManagerEmployeePair
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related manager
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// The related manager
        /// </summary>
        public UserDataModel Manager { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related evaluator
        /// </summary>
        public int EvaluatorId { get; set; }

        /// <summary>
        /// The related evaluator
        /// </summary>
        public UserDataModel Evaluator { get; set; }

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
        public ManagerEmployeePair()
        {

        }

        #endregion
    }
}
