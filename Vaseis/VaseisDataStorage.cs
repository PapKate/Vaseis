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

        public Task<List<CompanyDataModel>> GetCompanies()
        {
            return DbContext.Companies.ToListAsync();
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
        /// Gets all the company's employees
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public Task<List<UserDataModel>> GetCompanyEmployees(int companyId)
        {
            return DbContext.Users.Include(x => x.Department).ThenInclude(y => y.Company)
                                      .Include(x => x.Awards)
                                      .Include(x => x.Certificates)
                                      .Include(x => x.Projects)
                                      .Include(x => x.RecommendationPapers)
                                      .Include(x => x.AcquiredDegrees)
                                      .Include(x => x.JobPosition).ThenInclude(y => y.Job)
                                      .Where(x => x.Department.CompanyId == companyId)
                                      .Where(x => x.Type == UserType.Employee)
                                      .ToListAsync();
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
                                    .Where(x => x.UsersJobFilesPair.ManagerId == managerId)
                                    .Where(x => x.IsFinalized == false)
                                    .ToListAsync();
        }

        /// <summary>
        /// Updates a report data model
        /// </summary>
        /// <param name="report">The report</param>
        /// <param name="isFinalised">If the report is finalized</param>
        public async Task<ReportDataModel> UpdateReportAsync(ReportDataModel report, bool isFinalised)
        {
            // Get the employee
            var jobFilesPair = await DbContext.UsersJobFilesPairs.FirstAsync(x => x.Id == report.UsersJobFilesPairId);
            // If no pair is found and the report is finalized...
            if (jobFilesPair == null && isFinalised == true)
            {
                // Creates a new pair
                var newUserJobsPair = new UsersJobFilesPairDataModel()
                {
                    EmployeeId = report.UsersJobFilesPair.EmployeeId,
                    EvaluatorId = report.UsersJobFilesPair.EvaluatorId,
                    ManagerId = report.UsersJobFilesPair.ManagerId
                };
                // Add it
                DbContext.UsersJobFilesPairs.Add(newUserJobsPair);
            }
            // Apply the changes to the database
            await DbContext.SaveChangesAsync();

            // Get the existing model
            var model = await DbContext.Reports.FirstAsync(x => x.Id == report.Id);
            // Sets the model's text as the report's text
            model.ReportText = report.ReportText;
            // If the report text if null or empty...
            if (String.IsNullOrEmpty(report.ReportText))
                // Sets the model's is written to false
                model.IsWritten = false;
            // Else...
            else
                // Sets it to true
                model.IsWritten = true;
            // Sets the model's is finalized
            model.IsFinalized = isFinalised;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
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
                                                .Include(x => x.JobPosition).ThenInclude(y => y.Subjects)
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

        /// <summary>
        /// Adds a job position request data model
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="jobPositionId"></param>
        /// <param name="requestReason"></param>
        /// <returns></returns>
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
        public Task<List<JobPositionDataModel>> GetCompanyJobPositionsAsync(int companyId)
        {
            return DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department).ThenInclude(z => z.Company)
                                         .Include(x => x.JobPositionRequests)
                                         .Include(x => x.Subjects)
                                         .Where(x => x.Job.Department.Company.Id == companyId)
                                         .Where(y => y.SubmissionDate > DateTime.Now)
                                         .ToListAsync();
        }

        /// <summary>
        /// Gets a company's departments
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <returns></returns>
        public Task<List<DepartmentDataModel>> GetCompanyDepartmentsAsync(int companyId)
        {
            return DbContext.Departments.Include(x => x.Company)
                                        .Where(x => x.CompanyId == companyId)
                                        .ToListAsync();
        }

        /// <summary>
        /// Gets all the jobs in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public Task<List<JobDataModel>> GetCompanyJobs(int companyId)
        {
            return DbContext.Jobs.Include(y => y.Department).ThenInclude(z => z.Company)
                                         .Where(x => x.Department.Company.Id == companyId)
                                         .ToListAsync();
        }

        /// <summary>
        /// Gets the job positions created by an evaluator
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <returns></returns>
        public Task<List<JobPositionDataModel>> GetEvaluatorJobPositions(int evaluatorId)
        {
            return DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department)
                                         .Include(x => x.JobPositionRequests)
                                         .Include(x => x.Subjects)
                                         .Where(x => x.CreatorId == evaluatorId)
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
        public async Task<JobPositionDataModel> UpdateJobPositionByEvaluatorAsync(JobPositionDataModel jobPosition, string jobTitle, 
                                                                                  int salary, 
                                                                                  DateTime? announcementDate, DateTime? submissionDate,
                                                                                  IEnumerable<SubjectDataModel> subjects)
        {
            // Get the existing model
            var model = await DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department).FirstAsync(x => x.Id == jobPosition.Id);
            var job = await DbContext.Jobs.Include(x => x.Department).FirstAsync(x => x.JobTitle == jobTitle);
            model.JobId = job.Id;
            
            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            model.Job = job;
            model.Job.Department = job.Department;
            // Sets the job position's salary to the salary parameter
            model.Job.Salary = salary;
            model.Subjects = subjects;
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
        /// Adds an evaluation data model
        /// </summary>
        /// <param name="report">The report data model</param>
        /// <returns></returns>
        public async Task<EvaluationDataModel> AddEvaluatorEvaliation(ReportDataModel report)
        {
            // Create the model
            var model = new EvaluationDataModel()
            {
                IsAprovedByManager = false,
                IsFinalized = false,
                JobPositionRequestId = report.JobPositionRequestId,
                UsersJobFilesPairId = report.UsersJobFilesPairId
            };

            // Add it
            DbContext.Evaluations.Add(model);

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        /// <summary>
        /// Add a job position by an evaluator
        /// </summary>
        /// <param name="evaluatorId">The evaluator's id</param>
        /// <param name="job">The job data model</param>
        /// <param name="salary">The salary</param>
        /// <param name="announcementDate">The announcement date</param>
        /// <param name="submissionDate">The submission date</param>
        /// <param name="subjects">The subjects</param>
        /// <returns></returns>
        public async Task<JobPositionDataModel> AddEvaluatorJobPosition(int evaluatorId, JobDataModel job, int salary,
                                                                        DateTime? announcementDate, DateTime? submissionDate,
                                                                        IEnumerable<SubjectDataModel> subjects)
        {
            // Create the model
            var model = new JobPositionDataModel()
            {
                CreatorId = evaluatorId,
                JobId = job.Id,
                AnnouncementDate = announcementDate,
                SubmissionDate = submissionDate,
            };

            // Add it
            DbContext.JobPositions.Add(model);

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();
            var id = model.Id;
            model = await DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department).Where(x => x.Id == id).FirstOrDefaultAsync();

            model.Job.Salary = salary;
            model.Subjects = subjects;

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
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
                                        .Where(x => x.IsAprovedByManager == true)
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
                                        .Where(x => x.UsersJobFilesPair.ManagerId == managerId)
                                        .Where(x => x.IsAprovedByManager == false)
                                        .Where(x => x.IsFinalized == true)
                                        .ToListAsync();
        }

        /// <summary>
        /// Updates an evaluation's values
        /// </summary>
        /// <param name="evaluation">The evaluation data model</param>
        /// <returns></returns>
        public async Task<EvaluationDataModel> UpdateManagerEvaluationAsync(EvaluationDataModel evaluation)
        {
            // Get the existing model
            var model = await DbContext.Evaluations.FirstAsync(x => x.Id == evaluation.Id);
            model.IsAprovedByManager = true;

            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Return the model
            return model;
        }

        /// <summary>
        /// Updates an evaluation's values
        /// </summary>
        /// <param name="evaluation">The evaluation data model</param>
        /// <returns></returns>
        public async Task<EvaluationDataModel> UpdateEvaluatorEvaluationAsync(EvaluationDataModel evaluation, bool isFinalised)
        {
            // Get the existing model
            var model = await DbContext.Evaluations.FirstAsync(x => x.Id == evaluation.Id);
            // Sets the model's values accordingly
            model.FinalGrade = evaluation.FinalGrade;
            model.FilesGrade = evaluation.FilesGrade;
            model.ReportGrade = evaluation.ReportGrade;
            model.InterviewGrade = evaluation.InterviewGrade;
            model.Comments = evaluation.Comments;
            model.IsAprovedByManager = false;
            model.IsFinalized = isFinalised;

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
