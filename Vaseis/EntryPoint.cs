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

            context.Companies.AddRange(new List<CompanyDataModel>() // in memory
            {
                new CompanyDataModel()
                {
                    Name = "EnchantmentLab",
                    AFM = "010220002",
                    DOY = "Δ.Ο.Υ. ΑΜΑΛΙΑΔΑΣ",
                    Country = "Greece",
                    City = "Athens",
                    StreetName = "Chocolaty",
                    StreetNumber = "4",
                    TelephoneNumber = "(+30) 2130564876",
                    DateCreated = new DateTime(2018, 1, 1)
                },

                new CompanyDataModel()
                {
                    Name = "CoffeeMesh",
                    AFM = "240820001",
                    DOY = "Δ.Ο.Υ. ΚΙΛΚΙΣ",
                    Country = "Canada",
                    City = "Toronto",
                    StreetName = "Cocoan",
                    StreetNumber = "24",
                    TelephoneNumber = "(+1) 1501199811",
                    DateCreated = new DateTime(19, 11, 25)
                },

                new CompanyDataModel()
                {
                    Name = "YeetBoom",
                    AFM = "101022018",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Serbia",
                    City = "Belgrade",
                    StreetName = "Lidl",
                    StreetNumber = "27",
                    TelephoneNumber = "(+41) 2412202012",
                    DateCreated = new DateTime(20, 1, 11)
                }
            });

            // Add the companies to the database
            await context.SaveChangesAsync();

            // List that contains all the companies
            var companies = await context.Companies.ToListAsync();

            #endregion

            #region Departments

            var departmentOptionsList = new List<Department>() 
                                { 
                                    Department.Research, 
                                    Department.Purchasing, 
                                    Department.Production, 
                                    Department.Marketing, 
                                    Department.HumanResourceManagement, 
                                    Department.Finance, 
                                    Department.Development, 
                                    Department.Accounting
                                };

            foreach(var company in companies)
            {
                foreach (var dep in departmentOptionsList)
                {
                    var department = new DepartmentDataModel() { Department = dep, Company = company };
                    context.Departments.Add(department);
                }
            }

            await context.SaveChangesAsync();

            var departments = await context.Departments.ToListAsync();

            #endregion

            #region Users

            //var users = new Faker<UserDataModel>()
            //    .RuleFor(x => x.Username, faker => faker.Person.UserName)
            //    .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
            //    .RuleFor(x => x.LastName, faker => faker.Person.LastName)
            //    .RuleFor(x => x.Type, faker => faker.Random.Enum<UserType>())
            //    .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(1, DateTime.Now))
            //    .RuleFor(x => x.Password, faker => faker.Random.String2(10, 20))
            //    .RuleFor(x => x.Email, faker => faker.Person.Email)
            //    .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1, 2))
            //    .Generate(1000);

            //context.Users.AddRange(users);


            var employees = new Faker<UserDataModel>()
                            .RuleFor(x => x.Username, faker => faker.Person.UserName)
                            .RuleFor(x => x.Password, faker => faker.Random.String2(7, 10))
                            .RuleFor(x => x.Email, faker => faker.Person.Email)
                            .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                            .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                            .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(5, DateTime.Now))
                            .RuleFor(x => x.Type, faker => UserType.Employee)
                            .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1, 3))
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(3))
                            .Generate(50);

            context.Users.AddRange(employees);

            await context.SaveChangesAsync();

            // Add data to managers
            foreach (var company in companies)
            {
                foreach (var department in company.Departments)
                {
                    var manager = new Faker<UserDataModel>()
                            .RuleFor(x => x.Username, faker => faker.Person.UserName)
                            .RuleFor(x => x.Password, faker => faker.Random.String2(7, 10))
                            .RuleFor(x => x.Email, faker => faker.Person.Email)
                            .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                            .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                            .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(5, DateTime.Now))
                            .RuleFor(x => x.Type, faker => UserType.Manager)
                            .RuleFor(x => x.Company, faker => company)
                            .RuleFor(x => x.Department, faker => department)
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(3))
                            .Generate(1);
                    context.Users.AddRange(manager);
                }
            }

            await context.SaveChangesAsync();


            var managers = await context.Users.Where(x => x.Type == UserType.Manager).ToListAsync();

            //var employeesWithOutJoins = await context.Users.Where(x => x.Type == UserType.Employee).ToListAsync();

            //var employeesWithJoins = await context.Users.Include(x => x.AcquiredDegrees)
            //                                            .Include(x => x.Certificates)
            //                                            .Include(x => x.RecommendationPapers)
            //                                            .Include(x => x.Languages)
            //                                            .Where(x => x.Type == UserType.Employee)
            //                                            .ToListAsync();

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

            //var companiesWithUsers = await context.Companies.Include(x => x.ParentSubjects).ToListAsync();

            var companiesWithDepartments = await context.Companies.Include(x => x.Departments)
                                    .ToListAsync();
        }
    }
}
