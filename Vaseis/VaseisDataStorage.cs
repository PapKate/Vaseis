using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaseis
{
    public class VaseisDataStorage
    {
        #region Public Properties

        /// <summary>
        /// The db context
        /// </summary>
        public VaseisDbContext DbContext { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public VaseisDataStorage(VaseisDbContext dbContext)
        {
            // Sets the db context if not null
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all subjects
        /// </summary>
        public Task<List<SubjectDataModel>> GetSubjects()
        {
            return DbContext.Subjects.ToListAsync();
        }

        /// <summary>
        /// Gets the company's data
        /// </summary>
        /// <param name="companyId">The company's id</param>
        public Task<CompanyDataModel> GetCompanyData(int companyId)
        {
            return DbContext.Companies.Include(x => x.Users)
                                      .Include(x => x.Departments)
                                      .Include(x => x.Jobs)
                                      .Where(x => x.Id == companyId)
                                      .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates the user's password
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="newPassword">The new password</param>
        public async Task<UserDataModel> UpdatePassWord(UserDataModel user, string newPassword)
        {
            // Get the existing model
            var model = await DbContext.Users.FirstAsync(x => x.Id == user.Id);

            // Sets the new password
            model.Password = newPassword;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        /// <summary>
        /// Gets all the evaluators the have the same company id as the manager
        /// </summary>
        /// <param name="Manager">The manager</param>
        public Task<List<UserDataModel>> GetEvaluatorsAsync(UserDataModel Manager)
        {
            return DbContext.Users.Where(x => x.Type == UserType.Evaluator)
                                  .Where(y => y.Department.Id == Manager.Department.Id)
                                  .ToListAsync();
        }

        #region Manager Reports

        /// <summary>
        /// Creates a task of a list of report data models that have the given manager id
        /// </summary>
        /// <param name="managerId">The manager's id</param>
        /// <returns></returns>
        public Task<List<ReportDataModel>> GetManagerReportsAsync(int managerId)
        {
            // Returns from the db context a list with the reports that belong to a manager with id the given id
            return DbContext.Reports.Include(x => x.UsersJobFilesPair)
                                    .Include(x => x.UsersJobFilesPair.Manager)
                                    .Include(x => x.UsersJobFilesPair.Evaluator)
                                    .Include(x => x.UsersJobFilesPair.Employee)
                                    .Include(x => x.UsersJobFilesPair.JobPositionRequests)
                                    .Include(x => x.JobPositionRequest.JobPosition)
                                    .Include(x => x.JobPositionRequest)
                                    .Include(x => x.JobPositionRequest.JobPosition.Job)
                                    .Include(x => x.JobPositionRequest.JobPosition.Job.Department)
                                    .Where(x => x.UsersJobFilesPair.ManagerId == managerId).ToListAsync();
        }

        #endregion

        #region Employee My Job Position Requests

        /// <summary>
        /// Gets the employees job positions requests
        /// </summary>
        /// <param name="employeeId">The employee's id</param>
        /// <returns></returns>
        public Task<List<JobPositionRequestDataModel>> GetEmployeeJobPositionRequestsAsync(int employeeId)
        {
            return DbContext.JobPositionRequests.Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Employee)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.Job)
                                                                            .ThenInclude(z => z.Department)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.JobPositionRequests)
                                                .Where(x => x.UsersJobFilesPair.EmployeeId == employeeId)
                                                .ToListAsync();
        }

        /// <summary>
        /// Gets the employees job positions requests
        /// </summary>
        /// <param name="employeeId">The employee's id</param>
        /// <returns></returns>
        public Task<List<JobPositionRequestDataModel>> GetEvaluatorJobPositionRequestsAsync(int evaluatorId)
        {
            return DbContext.JobPositionRequests.Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Employee)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.Job)
                                                                            .ThenInclude(z => z.Department)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.JobPositionRequests)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.Subjects)
                                                .Where(x => x.UsersJobFilesPair.EvaluatorId == evaluatorId)
                                                .ToListAsync();
        }

        /// <summary>
        /// Removes the specified request
        /// </summary>
        /// <param name="requestId">The request's id</param>
        /// <returns>The request data model</returns>
        public async Task<JobPositionRequestDataModel> DeleteJobPositionRequestAsync(int requestId)
        {
            // Get the existing model
            var model = await DbContext.JobPositionRequests.FirstAsync(x => x.Id == requestId);

            // Remove it
            DbContext.JobPositionRequests.Remove(model);

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        /// <summary>
        /// Updates the employee's job position when acquired
        /// </summary>
        /// <param name="employee">The employee</param>
        /// <param name="jobPosition">The job position data model</param>
        /// <returns></returns>
        public async Task<UserDataModel> UpdateEmployeeJobPositionAsync(int employeeId, JobPositionDataModel jobPosition)
        {
            // Get the existing model
            var model = await DbContext.Users.FirstAsync(x => x.Id == employeeId);

            model.JobPositionId = jobPosition.Id;
            model.DepartmentId = jobPosition.Job.Department.Id;
            model.JobPosition = null;
            model.Department = null;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            model.JobPosition = jobPosition;
            model.Department = jobPosition.Job.Department;

            // Return the model
            return model;

        }

        #endregion

        #region Job Positions

        public async Task<JobPositionRequestDataModel> AddJobPositionRequestAsync(int employeeId, int jobPositionId, string requestReason)
        {
            // Get the employee
            var jobFilesPair = await DbContext.UsersJobFilesPairs.FirstAsync(x => x.EmployeeId == employeeId);

            // Create the model
            var model = new JobPositionRequestDataModel()
            {
                JobPositionId = jobPositionId,
                RequestsReason = requestReason,
                UsersJobFilesPairId = jobFilesPair.Id
            };

            // Add it
            DbContext.JobPositionRequests.Add(model);

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        /// <summary>
        /// Gets a company's job positions
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <returns></returns>
        public Task<List<JobPositionDataModel>> GetCompanyJobPositions(int companyId)
        {
            return DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department).ThenInclude(z => z.Company)
                                         .Include(x => x.JobPositionRequests)
                                         .Include(x => x.Subjects)
                                         .Where(x => x.Job.Department.Company.Id == companyId)
                                         .Where(y => y.AnnouncementDate != null)
                                         .ToListAsync();
        }

        /// <summary>
        /// Gets a company's departments
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <returns></returns>
        public Task<List<DepartmentDataModel>> GetCompanyDepartments(int companyId)
        {
            return DbContext.Departments.Include(x => x.Company)
                                        .Where(x => x.CompanyId == companyId)
                                        .ToListAsync();
        }

       

        /// <summary>
        /// Gets the job positions created by an evaluator
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <returns></returns>
        public Task<List<JobPositionDataModel>> GetEvaluatorJobPositions()
        {
            return DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department)
                                         .Include(x => x.JobPositionRequests)
                                         .Include(x => x.Subjects)
                                         //.Where(x => x.CreatorId == evaluatorId)
                                         .Where(y => y.AnnouncementDate != null)
                                         .ToListAsync();
        }

        /// <summary>
        /// Updates the job position's salary if a manager changes
        /// </summary>
        /// <param name="job">The job position</param>
        /// <param name="salary">The salary</param>
        /// <returns></returns>
        public async Task<JobDataModel> UpdateJobPositionByManager(JobDataModel job, int salary)
        {
            // Get the existing model
            var model = await DbContext.Jobs.FirstAsync(x => x.Id == job.Id);
            // Sets the job's salary to the salary parameter
            model.Salary = salary;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        /// <summary>
        /// Updates the job position's salary if a manager changes
        /// </summary>
        /// <param name="jobPosition">The job position</param>
        /// <param name="salary">The salary</param>
        /// <returns></returns>
        public async Task<JobPositionDataModel> UpdateJobPositionByEvaluator(JobPositionDataModel jobPosition, string jobPositionName, 
                                                                             Department departmentName, int salary, 
                                                                             DateTime announcementDate, DateTime submissionDate)
        {
            // Get the existing model
            var model = await DbContext.JobPositions.FirstAsync(x => x.Id == jobPosition.Id);

            model.Job.JobTitle = jobPositionName;
            model.Job.Department.DepartmentName = departmentName;
            // Sets the job position's salary to the salary parameter
            model.Job.Salary = salary;

            model.AnnouncementDate = announcementDate;
            model.SubmissionDate = submissionDate;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        #endregion

        #region Evaluations
        /// <summary>
        /// Get all the evaluations for a specific evaluator 
        /// </summary>
        /// <param name="evaluatorId">The evaluator's id</param>
        /// <param name="isFinalized">This boolean value is used for us to choose whether we want the past or the pending evaluations</param>
        /// <returns></returns>
        public Task<List<EvaluationDataModel>> GetEvaluatorEvaluations(int evaluatorId, bool isFinalized)
        {
            return DbContext.Evaluations.Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Evaluator)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Employee)
                                        .Include(x => x.JobPositionRequest).ThenInclude(y => y.JobPosition)
                                                                           .ThenInclude(z => z.Job)
                                                                           .ThenInclude(w => w.Department)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Reports)
                                        .Where(x => x.UsersJobFilesPair.EvaluatorId == evaluatorId)
                                        .Where(x => x.IsFinalized == isFinalized)
                                        .ToListAsync();       
        }

        /// <summary>
        /// Gets the evaluations of a user
        /// </summary>
        /// <param name="employee">A user</param>
        /// <returns></returns>
        public Task<List<EvaluationDataModel>> GetEmloyeeEvaluationsAsync(UserDataModel employee)
        {
            return DbContext.Evaluations.Include(x => x.UsersJobFilesPair)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Employee)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Evaluator)
                                        .Include(x => x.JobPositionRequest)
                                        .Include(x => x.JobPositionRequest).ThenInclude(y => y.JobPosition)
                                                                            .ThenInclude(z => z.Job)
                                                                            .ThenInclude(w => w.Department)
                                        .Where(x => x.UsersJobFilesPair.EmployeeId == employee.Id)
                                        .ToListAsync();
        }

        public async Task<List<EvaluationDataModel>> GetEmployeeEvaluationResults(int employeeId)
        {
            // Get the approved from manager evaluation results of an employee 
            var evaluationResults = await DbContext.Evaluations.Include(x => x.JobPositionRequest).ThenInclude(y => y.JobPosition)
                                                                                                  .ThenInclude(z => z.Job)
                                                                                                  .ThenInclude(w => w.Department)
                                                                .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Employee)
                                                                .ToListAsync();
            return evaluationResults;
        }

        /// <summary>
        /// Gets all the evaluation results that a manager sees in order to approve them
        /// </summary>
        /// <param name="manager">The manager</param>
        /// <returns></returns>
        public Task<List<EvaluationDataModel>> GetManagerEvaluationsAsync(int managerId)
        {
            return DbContext.Evaluations.Include(x => x.UsersJobFilesPair)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Employee)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Evaluator)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Manager)
                                        .Include(x => x.UsersJobFilesPair).ThenInclude(y => y.Reports)
                                        .Include(x => x.JobPositionRequest)
                                        .Include(x => x.JobPositionRequest).ThenInclude(y => y.JobPosition)
                                                                            .ThenInclude(z => z.Job)
                                                                            .ThenInclude(w => w.Department)
                                        .Where(x => x.UsersJobFilesPair.ManagerId == managerId) // && x => x.IsApproved == false
                                        .ToListAsync();
        }

        /// <summary>
        /// Updates an evaluation's values
        /// </summary>
        /// <param name="evaluation">The evaluation data model</param>
        /// <returns></returns>
        public async Task<EvaluationDataModel> UpdateEvaluationAsync(EvaluationDataModel evaluation)
        {
            // Get the existing model
            var model = await DbContext.Evaluations.FirstAsync(x => x.Id == evaluation.Id);

            model.InterviewGrade = evaluation.InterviewGrade;
            model.Comments = evaluation.Comments;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        public async Task<EvaluationDataModel> DeleteEvaluationAsync(int evaluationId)
        {
            // Get the existing model
            var model = await DbContext.Evaluations.FirstAsync(x => x.Id == evaluationId);

            // Remove it
            DbContext.Evaluations.Remove(model);

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        #endregion

        #endregion
    }
}
