using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vaseis
{
    public class JobPositionRequestDataModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The request's reason for applying for the job position
        /// </summary>
        public string RequestsReason { get; set; }

        #region Relationship

        /// <summary>
        /// The <see cref="JobPositionDataModel.Id"/> of the related <see cref="JobPositionDataModel"/>
        /// The job position id
        /// </summary>
        public int JobPositionId { get; set; }

        /// <summary>
        /// The related <see cref="JobPositionDataModel"/>
        /// The job position
        /// </summary>
        public JobPositionDataModel JobPosition { get; set; }

        /// <summary>
        /// The <see cref="UsersJobFilesPairDataModel.Id"/> of the related <see cref="UsersJobFilesPairDataModel"/>
        /// </summary>
        public int UsersJobFilesPairId { get; set; }

        /// <summary>
        /// The related <see cref="UsersJobFilesPairDataModel"/>
        /// </summary>
        public UsersJobFilesPairDataModel UsersJobFilesPair { get; set; }

        ///// <summary>
        ///// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        ///// The employee's id
        ///// </summary>
        //public int EmployeeId { get; set; }

        ///// <summary>
        ///// The related <see cref="UserDataModel"/>
        ///// The employee that creates the request
        ///// </summary>
        //public UserDataModel Employee { get; set; }

        ///// <summary>
        ///// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        ///// The evaluator's id
        ///// </summary>
        //public int EvaluatorId { get; set; }

        ///// <summary>
        ///// The related <see cref="UserDataModel"/>
        ///// The evaluator that evaluates the request
        ///// </summary>
        //public UserDataModel Evaluator { get; set; }

        ///// <summary>
        ///// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        ///// The manager's id
        ///// </summary>
        //public int ManagerId { get; set; }

        ///// <summary>
        ///// The related <see cref="UserDataModel"/>
        ///// The manager that creates the report
        ///// </summary>
        //public UserDataModel Manager { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionRequestDataModel()
        {

        }

        #endregion
    }
}
