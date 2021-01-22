using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Vaseis
{
    /// <summary>
    /// The services of our application
    /// </summary>
    public static class Services
    {
        public static readonly LoggerFactory mLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        /// <summary>
        /// Gets the database context used for accessing and manipulating the database
        /// </summary>
        public static VaseisDbContext GetDbContext
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder<VaseisDbContext>();
                optionsBuilder.UseMySql("Server=localhost;Database=Vaseis;Uid=root;Pwd=12345678;");
                optionsBuilder.UseLoggerFactory(mLoggerFactory);

                return new VaseisDbContext(optionsBuilder.Options);
            }
        }

        public static VaseisDataStorage GetDataStorage => new VaseisDataStorage(GetDbContext);
    }
}
