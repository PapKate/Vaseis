using Microsoft.EntityFrameworkCore;

namespace Vaseis
{
    /// <summary>
    /// Represents the database structure
    /// </summary>
    public class VaseisDbContext : DbContext
    {
        #region Public Properties

        /// <summary>
        /// The companies
        /// </summary>
        public DbSet<CompanyDataModel> Companies { get; set; }

        /// <summary>
        /// The departments
        /// </summary>
        public DbSet<DepartmentDataModel> Departments { get; set; }

        /// <summary>
        /// The users table
        /// </summary>
        public DbSet<UserDataModel> Users { get; set; }

        /// <summary>
        /// The users and job files pairs table
        /// </summary>
        public DbSet<UsersJobFilesPairDataModel> UsersJobFilesPairs { get; set; }

        /// <summary>
        /// The jobs table
        /// </summary>
        public DbSet<JobDataModel> Jobs { get; set; }

        /// <summary>
        /// The job positions table
        /// </summary>
        public DbSet<JobPositionDataModel> JobPositions { get; set; }

        /// <summary>
        /// The reports table
        /// </summary>
        public DbSet<ReportDataModel> Reports { get; set; }

        /// <summary>
        /// The evaluations table
        /// </summary>
        public DbSet<EvaluationDataModel> Evaluations { get; set; }

        /// <summary>
        /// The job position requests table
        /// </summary>
        public DbSet<JobPositionRequestDataModel> JobPositionRequests { get; set; }

        /// <summary>
        /// The subjects table
        /// </summary>
        public DbSet<SubjectDataModel> Subjects { get; set; }

        /// <summary>
        /// The degrees table
        /// </summary>
        public DbSet<DegreeDataModel> Degrees { get; set; }

        /// <summary>
        /// The hasDegrees table
        /// </summary>
        public DbSet<AcquiredDegreeDataModel> AcquiredDegrees { get; set; }

        /// <summary>
        /// THe certificates table
        /// </summary>
        public DbSet<CertificateDataModel> Certificates { get; set; }

        /// <summary>
        /// The recommendations table
        /// </summary>
        public DbSet<RecommendationPaperDataModel> RecomendationPapers { get; set; }
        
        /// <summary>
        /// The awards table
        /// </summary>
        public DbSet<AwardDataModel> Awards { get; set; }
        
        /// <summary>
        /// The languages table
        /// </summary>
        public DbSet<LanguagesDataModel> Languages { get; set; }

        /// <summary>
        /// The projects table
        /// </summary>
        public DbSet<ProjectDataModel> Projects { get; set; }

        /// <summary>
        /// The relationship between job positions and subjects
        /// </summary>
        public DbSet<JobPositionSubjectDataModel> JobPositionSubjects { get; set; }


        public DbSet<LogDataModel> Logs { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The options</param>
        public VaseisDbContext(DbContextOptions<VaseisDbContext> options) : base(options)
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in <see cref="DbSet{TEntity}"/> properties
        /// on your derived context. The resulting model may be cached and re-used for subsequent
        /// instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User

            // For the awards of a user...
            modelBuilder.Entity<UserDataModel>()
                // One user has many awards 
                .HasMany(x => x.Awards)
                // Each award has one user
                .WithOne(x => x.User)
                // The principal key of the join is the User.Id
                .HasPrincipalKey(x => x.Id)
                // The foreign key of the join is the Award.UserId
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the certificates of a user...
            modelBuilder.Entity<UserDataModel>()
                .HasMany(x => x.Certificates)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the recommendation papers of a user...
            modelBuilder.Entity<UserDataModel>()
                .HasMany(x => x.RecommendationPapers)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the languages of a user...
            modelBuilder.Entity<UserDataModel>()
                .HasMany(x => x.Languages)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the projects of a user...
            modelBuilder.Entity<UserDataModel>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the acquired degrees of a user...
            modelBuilder.Entity<UserDataModel>()
                .HasMany(x => x.AcquiredDegrees)
                .WithOne(x => x.User)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region UsersJobFilesPair

            // For the acquired degrees of a user...
            modelBuilder.Entity<UsersJobFilesPairDataModel>()
                .HasMany(x => x.Reports)
                .WithOne(x => x.UsersJobFilesPair)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UsersJobFilesPairId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the acquired degrees of a user...
            modelBuilder.Entity<UsersJobFilesPairDataModel>()
                .HasMany(x => x.Evaluations)
                .WithOne(x => x.UsersJobFilesPair)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UsersJobFilesPairId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the acquired degrees of a user...
            modelBuilder.Entity<UsersJobFilesPairDataModel>()
                .HasMany(x => x.JobPositionRequests)
                .WithOne(x => x.UsersJobFilesPair)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UsersJobFilesPairId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Degree

            modelBuilder.Entity<DegreeDataModel>()
                .HasMany(x => x.AcquiredDegrees)
                .WithOne(x => x.Degree)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.DegreeId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Company

            // For the departments in a company
            modelBuilder.Entity<CompanyDataModel>()
                .HasMany(x => x.Departments)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Department

            // For the users in a department
            modelBuilder.Entity<DepartmentDataModel>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Department)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the jobs in a department
            modelBuilder.Entity<DepartmentDataModel>()
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Department)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Job

            // For the subjects related to a JobPosition
            modelBuilder.Entity<JobDataModel>()
                .HasMany(x => x.JobPositions)
                .WithOne(x => x.Job)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region JobPosiion

            // For the job position requests related to a JobPosition
            modelBuilder.Entity<JobPositionDataModel>()
                .HasMany(x => x.JobPositionRequests)
                .WithOne(x => x.JobPosition)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.JobPositionId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Subject

            modelBuilder.Entity<SubjectDataModel>()
                .HasMany(x => x.ChildrenSubjects)
                .WithOne(x => x.Subject)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region JobPositionSubject

            modelBuilder.Entity<JobPositionSubjectDataModel>()
                .HasKey(x => new { x.JobPositionId, x.SubjectId });

            modelBuilder.Entity<JobPositionSubjectDataModel>()
                .HasOne(x => x.JobPosition)
                .WithMany(x => x.JobsAndSubjects)
                .HasForeignKey(x => x.JobPositionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobPositionSubjectDataModel>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.JobsAndSubjects)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
            
            #endregion



        }

        #endregion
    }
}
