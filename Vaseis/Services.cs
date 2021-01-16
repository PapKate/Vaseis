using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaseis
{
    /// <summary>
    /// The services of our application
    /// </summary>
    public static class Services
    {
        //public static readonly LoggerFactory mLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        /// <summary>
        /// Gets the database context used for accessing and manipulating the database
        /// </summary>
        public static VaseisDbContext GetDbContext
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder<VaseisDbContext>();
                optionsBuilder.UseMySql("Server=localhost;Database=Vaseis;Uid=root;Pwd=12345678;");
                //optionsBuilder.UseLoggerFactory(mLoggerFactory);

                return new VaseisDbContext(optionsBuilder.Options);
            }
        }

        public static VaseisDataStorage GetDataStorage => new VaseisDataStorage(GetDbContext);
    }

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

        #endregion

        #region Evaluations

        public async Task<EvaluationDataModel> UpdateEvaluationAsync(EvaluationDataModel evaluation)
        {
            // Get the existing model
            var model = await DbContext.Evaluations.FirstAsync(x => x.Id == evaluation.Id);

            model.InterviewGrade = evaluation.InterviewGrade;
            model.TempInterviewGrade = evaluation.TempInterviewGrade;
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
