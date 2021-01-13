namespace Vaseis
{
    public class JobPositionRequestDataModel
    {
        #region Public Properties

        public int Id { get; set; }

        #region Relationship

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        /// The employee's id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The related <see cref="UserDataModel"/>
        /// The employee that creates the request
        /// </summary>
        public UserDataModel Employee { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        /// The evaluator's id
        /// </summary>
        public int? EvaluatorId { get; set; }

        /// <summary>
        /// The related <see cref="UserDataModel"/>
        /// The evaluator that evaluates the request
        /// </summary>
        public UserDataModel Evaluator { get; set; }

        /// <summary>
        /// The <see cref="UserDataModel.Id"/> of the related <see cref="UserDataModel"/>
        /// The manager's id
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// The related <see cref="UserDataModel"/>
        /// The manager that creates the report
        /// </summary>
        public UserDataModel Manager { get; set; }

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
        /// The <see cref="EvaluationDataModel.Id"/> of the related <see cref="EvaluationDataModel"/>
        /// The evaluation's id
        /// </summary>
        public int? EvaluationId { get; set; }

        /// <summary>
        /// The related <see cref="EvaluationDataModel"/>
        /// The evaluation
        /// </summary>
        public EvaluationDataModel Evaluation { get; set; }

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
