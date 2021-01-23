using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vaseis
{
    /// <summary>
    /// Represents the departments table in the data base
    /// </summary>
    public class DepartmentDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The department's name
        /// </summary>
        public Department DepartmentName { get; set; }

        /// <summary>
        /// The department's color
        /// </summary>
        public string Color { get; set; }

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
        /// The users (employees, evaluators, managers)
        /// </summary>
        public IEnumerable<UserDataModel> Users { get; set; }

        /// <summary>
        /// The jobs of the department
        /// </summary>
        public IEnumerable<JobDataModel> Jobs { get; set; }

        #endregion

        #endregion


    }
}