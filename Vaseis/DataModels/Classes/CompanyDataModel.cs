using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    /// <summary>
    /// Represents a company
    /// </summary>
    public class CompanyDataModel
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

        /// <summary>
        /// Just for the ui one color
        /// </summary>
        public string CompanyColor { get; set; }

        /// <summary>
        /// The date the company was created
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// The name of the company's DOY
        /// </summary>
        public string DOY { get; set; }

        /// <summary>
        /// The name of the company's AFM
        /// </summary>
        public string AFM { get; set; }

        /// <summary>
        /// The company's telephone number
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// The name of the city the company is located
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The name of the country the company is located
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The number of the street the company is located
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// The name of the street the company is located
        /// </summary>
        public string StreetName { get; set; }

        ///<summary>
        /// The path to the company's  picture 
        /// </summary>
        public string CompanyPicture { get; set; }

        /// <summary>
        /// The complete company's location
        /// </summary>
        [NotMapped]
        public string Location => StreetName + " " + StreetNumber + ", " + City + " " + Country;  

        #region Relationships

        /// <summary>
        /// The related departments
        /// </summary>
        public IEnumerable<DepartmentDataModel> Departments { get; set; }

        /// <summary>
        /// The related users
        /// </summary>
        public IEnumerable<UserDataModel> Users { get; set; }

        /// <summary>
        /// The related Jobs
        /// </summary>
        public IEnumerable<JobDataModel> Jobs { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyDataModel()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        #endregion
    }
}
