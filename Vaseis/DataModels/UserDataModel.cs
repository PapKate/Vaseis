using System;
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

        /// <summary>
        /// The date the user was registered
        /// </summary>
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        ///<summary>
        /// The path to the user's profile picture 
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// The years of experience
        /// </summary>
        public int YearsOfExpirience { get; set; }


        /// <summary>
        /// The full name
        /// </summary>
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        #region Relationships

        /// <summary>
        /// The <see cref="CompanyDataModel.Id"/> of the related <see cref="CompanyDataModel"/>
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The related <see cref="CompanyDataModel"/>
        /// </summary>
        public CompanyDataModel Company { get; set; }


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
