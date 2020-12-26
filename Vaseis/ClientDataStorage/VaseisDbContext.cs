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
        /// The users table
        /// </summary>
        public DbSet<UserDataModel> Users { get; set; }

        /// <summary>
        /// The awards table
        /// </summary>
        public DbSet<AwardDataModel> Awards { get; set; }

        /// <summary>
        /// The employee files table
        /// </summary>
        public DbSet<EmployeeFileDataModel> EmployeeFiles { get; set; }

        /// <summary>
        /// The reports table
        /// </summary>
        public DbSet<ReportDataModel> Reports { get; set; }

        /// <summary>
        /// The jobs table
        /// </summary>
        public DbSet<JobDataModel> Jobs { get; set; }

        /// <summary>
        /// The job positions' table
        /// </summary>
        public DbSet<JobPositionDataModel> JobPositions { get; set; }

        /// <summary>
        /// The evaluations table
        /// </summary>
        public DbSet<EvaluationDataModel> Evaluations { get; set; }

        /// <summary>
        /// The subjects table
        /// </summary>
        public DbSet<SubjectDataModel> Subjects { get; set; }

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
            modelBuilder.Entity<EmployeeFileDataModel>()
                .HasMany(x => x.Awards)
                .WithOne(x => x.EmployeeFile)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.EmployeeFileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyDataModel>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SubjectDataModel>()
            .HasMany(x => x.ParentSubjects)
            .WithOne(x => x.Subject)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

           
        }

        #endregion
    }
}
