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

        #region Get 

        /// <summary>
        /// Gets the logged in user
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <param name="password">The user's password</param>
        /// <returns></returns>
        public Task<UserDataModel> GetUser(string username, string password)
        {
            return DbContext.Users.Include(x => x.JobPosition).ThenInclude(y => y.Job)
                                                       .Include(x => x.Department).ThenInclude(y => y.Company)
                                                       .Include(x => x.AcquiredDegrees)
                                                       .Include(x => x.Awards)
                                                       .Include(x => x.Certificates)
                                                       .Include(x => x.Languages)
                                                       .Include(x => x.RecommendationPapers)
                                                       .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        /// <summary>
        /// Gets all subjects
        /// </summary>
        public Task<List<SubjectDataModel>> GetSubjects()
        {
            return DbContext.Subjects.Include(x => x.ChildrenSubjects).ToListAsync();
        }


        /// <summary>
        /// Get all the Companies
        /// </summary>
        /// <returns></returns>
        public Task<List<CompanyDataModel>> GetCompaniesWithDataAsync()
        {
            return DbContext.Companies.Include(x => x.Departments).ThenInclude(y => y.Users)
                                      .Include(x => x.Jobs)
                                      .ToListAsync();
        }

        /// <summary>
        /// Gets the company's users emmesaaaaa yoah
        /// </summary>
        /// <param name="companyId">The company's id</param>
        public Task<List<DepartmentDataModel>> GetDepartmentUsers(int companyId)
        {
            return DbContext.Departments.Include(x => x.Users)
                                        .Include(x => x.Jobs)
                                        .Where(x => x.CompanyId == companyId)
                                        .ToListAsync();
        }                               

        /// <summary>
        /// Gets the company's departments
        /// </summary>
        /// <param name="companyId">The company's id</param>
        public Task<List<DepartmentDataModel>> GetDepartments(int companyId)
        {
            return DbContext.Departments.Where(x => x.CompanyId == companyId)
                                        .ToListAsync();
        }

        /// <summary>
        /// Gets the company's data
        /// </summary>
        /// <param name="companyId">The company's id</param>
        public Task<CompanyDataModel> GetCompanyDataAsync(int companyId)
        {
            return DbContext.Companies.Include(x => x.Users)
                                      .Include(x => x.Departments)
                                      .Include(x => x.Jobs)
                                      .Where(x => x.Id == companyId)
                                      .FirstOrDefaultAsync();
        } 

        #endregion

        #region Update 

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
        ///Just updating the user's edited components 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="bio"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserDataModel> UpdateBioAndEmail(UserDataModel user, string bio, string email)
        { 
           var model = await DbContext.Users.FirstAsync(x => x.Id == user.Id);

            model.Bio = bio;

            model.Email = email;

            return model;
        
        }

        /// <summary>
        ///Just updating the user's edited components 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="bio"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserDataModel> UpdateInfoByManager(UserDataModel user, string bio, string email)
        {
            var model = await DbContext.Users.FirstAsync(x => x.Id == user.Id);

            model.Bio = bio;

            model.Email = email;

            return model;
        }

        #endregion

        #region Create New DataModel

        public async Task<CompanyDataModel> CreateCompanyAsync(string name, string doy, string afm, 
                                                               string About, string Telephone, string City, 
                                                               string Country, string streetNumber, string streetName, 
                                                               string CompanyPicsture, Dictionary<string, string> departments)
        {
            // Creates a new company data model
            var model = new CompanyDataModel()
            {
                Name = name,
                DateCreated = DateTime.Now,
                DOY = doy,
                AFM = afm,
                About = About,
                TelephoneNumber = Telephone,
                City = City,
                Country = Country,
                StreetName = streetName,
                StreetNumber = streetNumber,
                CompanyPicture = CompanyPicsture,
            };
            // Add it
            DbContext.Companies.Add(model);

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();
            // Gets the updated id
            var companyId = model.Id;
            
            // For each department...
            foreach(var department in departments)
            {
                // Creates a department data model
                var departmentDM = new DepartmentDataModel()
                {
                    CompanyId = companyId,
                    DepartmentName = department.Key,
                    Color = department.Value
                };
                // Adds it (in memory)
                DbContext.Departments.Add(departmentDM);
            }

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();
            
            // Gets the updated company
            var updatedCompanyData = await GetCompanyDataAsync(companyId);

            // Return the model
            return updatedCompanyData;
        }

        /// <summary>
        /// Creates and adds a new department in a company
        /// </summary>
        /// <param name="company">The company data model</param>
        /// <param name="departmentName">The department's name</param>
        /// <param name="colour">The department's representative color</param>
        /// <returns></returns>
        public async Task<CompanyDataModel> AddNewDepartmentAsync(int companyId, string departmentName, string colour) 
        {
            // Creates a new department data model
            var model = new DepartmentDataModel() 
            {
                CompanyId = companyId,
                DepartmentName = departmentName,
                Color = colour
            };

            // Add it
            DbContext.Departments.Add(model);

            // Apply the changes to the database
            await DbContext.SaveChangesAsync();

            // Gets the updated company
            var updatedCompanyData = await GetCompanyDataAsync(companyId);

            // Return the model
            return updatedCompanyData;
        }

        /// <summary>
        /// Creates a new job for the specified company
        /// </summary>
        /// <param name="companyId">The company's id</param>
        /// <param name="salary">The salary</param>
        /// <param name="jobTitle">The job's title</param>
        /// <returns></returns>
        public async Task<CompanyDataModel> AddNewJobAsync(int companyId, string jobTitle, int salary, string departmentName)
        {
            var department = await DbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentName == departmentName);
            // Creates a new job
            var model = new JobDataModel()
            { 
                JobTitle = jobTitle,
                Salary = salary,
                CompanyId = companyId,
                DepartmentId = department.Id
            };
            // Applies the changes in memory
            DbContext.Jobs.Add(model);
            // Applies the changes to the database
            await DbContext.SaveChangesAsync();
            // Gets the updated company
            var updatedCompanyData = await GetCompanyDataAsync(companyId);
            // Returns it
            return updatedCompanyData;
        }


        /// <summary>
        /// Creates and adds a new user to the specified company
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="username"></param>
        /// <param name="firstname"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="jobTitle"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public async Task<CompanyDataModel> AddNewUserAsync(int companyId, string username, string password,
                                                            string firstname, string lastName, string email, 
                                                            int yearsOfExp, string profilePicUrl,
                                                            string jobTitle, string departmentName, UserType userType)
        {
            // Creates a new user data model
            var model = new UserDataModel()
            {
                CompanyId = companyId,
                Username = username,
                FirstName = firstname,
                LastName = lastName,
                Email = email,
                Password = password,
                YearsOfExperience = yearsOfExp,
                ProfilePicture = profilePicUrl,
                Type = userType,
            };

            // If the user's type is employee...
            if (userType == UserType.Employee)
            {
                // Finds the first open job position with the specified job title
                var jobPosition = await DbContext.JobPositions.Include(x => x.Job)
                                            .Where(x => x.SubmissionDate > DateTime.Now)
                                            .Where(x => x.Job.CompanyId == companyId)
                                            .FirstOrDefaultAsync(x => x.Job.JobTitle == jobTitle);
                // Sets the model's job position id as the id that the found job position has
                model.JobPositionId = jobPosition.Id;
            }
            // Else...
            else
            {
                // Finds the first department with the specified name 
                var department = await DbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentName == departmentName && x.CompanyId == companyId);
                // Sets the model's department id as the id of the found department
                model.DepartmentId = department.Id;
            }

            // Adds the user in memory
            DbContext.Users.Add(model);

            // Save changes in the database
            await DbContext.SaveChangesAsync();
            
            // Gets the updated company
            var updatedCompany = await GetCompanyDataAsync(companyId);
            
            // Returns it
            return updatedCompany;
        }

        /// <summary>
        /// Creates a new subject
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public async Task<SubjectDataModel> CreateNewSubject(string title, string description, string parent)
        {
            // Creates a new subject data model
            var model = new SubjectDataModel()
            {
                Title = title,
                Description = description,
            };

            // If a parent is not set...
            if (string.IsNullOrEmpty(parent))
                model.Subject = null;
            // Else...
            else
                // Sets the parent subject as the subject that has the specified title
                model.Subject = await DbContext.Subjects.FirstAsync(x => x.Title == parent);
            
            // Add it
            DbContext.Subjects.Add(model);

            // Apply the changes to the database
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

        #endregion

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
                                                .Include(x => x.JobPosition).ThenInclude(y => y.JobsAndSubjects).ThenInclude(x => x.Subject)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.JobsAndSubjects).ThenInclude(x => x.JobPosition)
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
                                                .Include(x => x.JobPosition).ThenInclude(y => y.JobsAndSubjects).ThenInclude(x => x.Subject)
                                                .Include(x => x.JobPosition).ThenInclude(y => y.JobsAndSubjects).ThenInclude(x => x.JobPosition)
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

        public async Task<ReportDataModel> AddReportAsync(JobPositionRequestDataModel jobPositionRequest)
        {
            var model = new ReportDataModel()
            {
                IsFinalized = false,
                IsWritten = false,
                JobPositionRequestId = jobPositionRequest.Id,
                UsersJobFilesPairId = (int)jobPositionRequest.UsersJobFilesPairId
            };

            // Add it
            DbContext.Reports.Add(model);

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
                                         .Include(x => x.JobsAndSubjects).ThenInclude(y => y.Subject)
                                         .Include(x => x.JobsAndSubjects).ThenInclude(y => y.JobPosition)
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
        /// Gets all the evaluations in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public Task<List<EvaluationDataModel>> GetJobPositionOpenEvaluation(int jobPositionId)
        {
            return DbContext.Evaluations.Include(x => x.JobPositionRequest)
                                        .ThenInclude(y => y.JobPosition)
                                        .ThenInclude(z => z.Job)
                                        .ThenInclude(w => w.Department)
                                        .Where(x => x.JobPositionRequest.JobPositionId == jobPositionId)
                                        .Where(x => x.IsFinalized == false)
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
                                         .Include(x => x.JobsAndSubjects).ThenInclude(y => y.Subject)
                                         .Include(x => x.JobsAndSubjects).ThenInclude(y => y.JobPosition)
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
            // Find the job with the specified job title
            var job = await DbContext.Jobs.Include(x => x.Department).FirstAsync(x => x.JobTitle == jobTitle);
            // Sets the model's job it as the found job's id
            model.JobId = job.Id;
            
            // Push the changes to the database
            await DbContext.SaveChangesAsync();

            // Gets the existing pairs
            var existringJobPositionAndSubjectsPairs = await DbContext.JobPositionSubjects.Include(x => x.Subject).Where(x => x.JobPositionId == jobPosition.Id).ToListAsync();

            var oldSubjects = new List<SubjectDataModel>();

            // Creates a new list for the job position and subject pair
            var jobPositionAndSubjectsList = new List<JobPositionSubjectDataModel>();
            // For each pair...
            foreach (var existringPair in existringJobPositionAndSubjectsPairs) 
            {
                oldSubjects.Add(existringPair.Subject);
                //If in the new subjects the old one is not in...
                if(subjects.Contains(existringPair.Subject) == false)
                {
                    // Remove it
                    DbContext.JobPositionSubjects.Remove(existringPair);
                }
                else
                    jobPositionAndSubjectsList.Add(existringPair);
            }
            // For each subject...
            foreach (var subject in subjects)
            {
                // If this is a new subject...
                if (oldSubjects.Contains(subject) == false)
                {
                    // Creates a new JobPositionSubjectDataModel
                    var jobPositionAndSubject = new JobPositionSubjectDataModel()
                    {
                        SubjectId = subject.Id,
                        JobPositionId = model.Id
                    };
                    // Add it (in memory)
                    DbContext.JobPositionSubjects.Add(jobPositionAndSubject);
                    // Adds it to the list of pairs
                    jobPositionAndSubjectsList.Add(jobPositionAndSubject);
                }
            }
            
            // Save the changes to the data base
            await DbContext.SaveChangesAsync();
            // Get the updated model
            model = await DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department)
                                                .Include(x => x.JobsAndSubjects).ThenInclude(y => y.Subject)
                                                .Include(x => x.JobsAndSubjects).ThenInclude(y => y.JobPosition)
                                                .Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            // Sets the model's job as the found job
            model.Job = job;
            // Sets the model's jobs department as the found job's department
            model.Job.Department = job.Department;
            // Sets the job position's salary to the salary parameter
            model.Job.Salary = salary;
            model.JobsAndSubjects = jobPositionAndSubjectsList;
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
            // Gets the updated model's id
            var id = model.Id;
           
            // Creates a list for the pairs
            var jobPositionAndSubjectsList = new List<JobPositionSubjectDataModel>();
            // For each subject
            foreach (var subject in subjects)
            {
                // Creates a new pair data model
                var jobPositionAndSubject = new JobPositionSubjectDataModel()
                {
                    SubjectId = subject.Id,
                    JobPositionId = id
                };
                // Add it (in memory)
                DbContext.JobPositionSubjects.Add(jobPositionAndSubject);
                // Adds it to the pairs list
                jobPositionAndSubjectsList.Add(jobPositionAndSubject);
            }
            // Saves the changes to the data base
            await DbContext.SaveChangesAsync();
            // Gets the updated model
            model = await DbContext.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department)
                                                .Include(x => x.JobsAndSubjects).ThenInclude(y => y.Subject)
                                                .Include(x => x.JobsAndSubjects).ThenInclude(y => y.JobPosition)
                                                .Where(x => x.Id == id).FirstOrDefaultAsync();
            model.Job.Salary = salary;
            model.JobsAndSubjects = jobPositionAndSubjectsList;

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
                                        .OrderByDescending(x =>x.FinalGrade)
                                        .ToListAsync();
        }

        /// <summary>
        /// Updates an evaluation's values
        /// </summary>
        /// <param name="evaluation">The evaluation data model</param>
        /// <returns></returns>
        public async Task<EvaluationDataModel> UpdateManagerEvaluationAsync(EvaluationDataModel evaluation, bool hasPassed)
        {
            // Get the existing model
            var model = await DbContext.Evaluations.FirstAsync(x => x.Id == evaluation.Id);
            model.IsAprovedByManager = true;
            model.Passed = hasPassed;

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