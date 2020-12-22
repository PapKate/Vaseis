using Bogus;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Vaseis
{
    /// <summary>
    /// The app's true entry point used for defining a custom main method
    /// </summary>
    public class EntryPoint
    {
        public async static Task Main()
        {
            await SetUpAsync();

            var thread = new Thread(() =>
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
            });

            // Set the thread department to STA
            thread.SetApartmentState(ApartmentState.STA);

            // Start the application
            thread.Start();
        }

        public static readonly LoggerFactory mLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        private static async Task SetUpAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<VaseisDbContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=Vaseis;Uid=root;Pwd=12345678;");
            optionsBuilder.UseLoggerFactory(mLoggerFactory);

            var context = new VaseisDbContext(optionsBuilder.Options);

            // I implemented the users GUI

            // Make sure that the database exists
            // If the database doesn't exist, it gets created.
            var result = await context.Database.EnsureCreatedAsync();

            // If a database was not created...
            if (!result)
                // Return
                return;

            #region Companies

            // Create the company data model
            var company = new CompanyDataModel();

            // Add the company to the database context (In memory)
            context.Companies.AddRange(new List<CompanyDataModel>() 
            {
                new CompanyDataModel()
                {
                    Name = "Company 1",
                },
                new CompanyDataModel()
                {
                    Name = "Company 2"
                }
            });

            // Add the company to the database
            await context.SaveChangesAsync();

            #endregion

            #region Users

            var users = new Faker<UserDataModel>()
                .RuleFor(x => x.Username, faker => faker.Person.UserName)
                .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                .RuleFor(x => x.Type, faker => faker.Random.Enum<UserType>())
                .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(1, DateTime.Now))
                .RuleFor(x => x.Password, faker => faker.Random.String2(10, 20))
                .RuleFor(x => x.Email, faker => faker.Person.Email)
                .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1, 2))
                .Generate(1000);

            context.Users.AddRange(users);

            await context.SaveChangesAsync();

            #endregion

            //// Create the company data model
            //var company = new CompanyDataModel();

            //// Add the company to the database context (In memory)
            //context.Companies.Add(company);

            //// Add the company to the database
            //await context.SaveChangesAsync();

            //// Create the user
            //context.Users.AddRange(new List<UserDataModel>()
            //{ 
            //    new UserDataModel()
            //    {
            //        FirstName = "Vaso",
            //        LastName = "Kokkala",
            //        Type = UserType.Administrator,
            //        CompanyId = company.Id,
            //        Password = "12345678",
            //        Username = "Vaso"
            //    },
            //    new UserDataModel()
            //    {
            //        FirstName = "Katerina",
            //        LastName = "Papadopoulou",
            //        Type = UserType.Manager,
            //        CompanyId = company.Id,
            //        Password = "12345678",
            //        Username = "PapKate"
            //    }
            //});

            //// Add the user to the data base
            //await context.SaveChangesAsync();

            #region Update

            //// Get the first user
            //var user = await context.Users.FirstAsync();

            //user.Email = "paplabros@gmail.com";
            //user.Type = UserType.Employee;

            //// Save the changes
            //await context.SaveChangesAsync();

            #endregion

            #region Remove

            //// Remove the user
            //context.Users.Remove(user);

            //await context.SaveChangesAsync();

            #endregion

            var companiesWithUsers = await context.Companies.Include(x => x.Users).ToListAsync();

        }
    }
}
