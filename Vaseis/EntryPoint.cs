﻿using Bogus;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

using Bogus.Distributions.Gaussian;
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

            // Adds to the companies db context a list of company data models
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
                },
               
                new CompanyDataModel()
                {
                    Name = "cEID",
                    AFM = "101090018",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    StreetName = "Filippimenos",
                    StreetNumber = "2",
                    TelephoneNumber = "(+41) 2612202012",
                    DateCreated = new DateTime(19, 2, 62)
                },

                   new CompanyDataModel()
                {
                    Name = "Caravel",
                    AFM = "101000018",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    StreetName = "Pantelehmonos",
                    StreetNumber = "12",
                    TelephoneNumber = "(+41) 2612202012",
                    DateCreated = new DateTime(20, 10, 10)
                },

                    new CompanyDataModel()
                {
                    Name = "Blossom",
                    AFM = "101000218",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    StreetName = "Apollonws",
                    StreetNumber = "8",
                    TelephoneNumber = "(+30) 2612202212",
                    DateCreated = new DateTime(20, 10, 20)
                },
                  
                new CompanyDataModel()
                {
                    Name = "BatterButlers",
                    AFM = "101000210",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    StreetName = "Pantanashs",
                    StreetNumber = "4",
                    TelephoneNumber = "(+60) 2610202212",
                    DateCreated = new DateTime(20, 10, 19)
                },

                   new CompanyDataModel()
                {
                    Name = "ToSpitiTouLaou",
                    AFM = "101000238",
                    DOY = "Δ.Ο.Υ. ΧΑΛΚΙΔΑΣ",
                    Country = "Greece",
                    City = "Chalkis",
                    StreetName = "Menedhmou",
                    StreetNumber = "20",
                    TelephoneNumber = "(+41) 2229002212",
                    DateCreated = new DateTime(18, 5, 4)
                },

                     new CompanyDataModel()
                {
                    Name = "YardTalesAndFlavours",
                    AFM = "101000408",
                    DOY = "Δ.Ο.Υ. ΕΡΕΤΡΙΑΣ",
                    Country = "Greece",
                    City = "Eretria",
                    StreetName = "Zacharia",
                    StreetNumber = "2",
                    TelephoneNumber = "(+41) 2229034008",
                    DateCreated = new DateTime(18, 5, 6)
                },

                   new CompanyDataModel()
                {
                    Name = "Google",
                    AFM = "101008408",
                    DOY = "Δ.Ο.Υ. ΚΑΡΔΙΤΣΑΣ ",
                    Country = "Malta",
                    City = "Oslo",
                    StreetName = "Queen Elizabeta's",
                    StreetNumber = "666",
                    TelephoneNumber = "(+30) 2229035208",
                    DateCreated = new DateTime(4, 5, 8)
                },




            });

            // Add the companies to the database
            await context.SaveChangesAsync();

            // List that contains all the companies
            var companies = await context.Companies.ToListAsync();

            #endregion

            #region Departments

            // Creates a list of departments and fills it with every possible option
            var departmentOptionsList = new Dictionary<Department, string>()
                                {
                                    { Department.Research, "F5D547"},
                                    { Department.Sales, "EF8354"},
                                    { Department.Production, "8EB8E5"},
                                    { Department.Marketing, "028090"},
                                    { Department.HumanResourceManagement, "397367"},
                                    { Department.Finance, "2E2E2E"},
                                    { Department.Development, "9F1747"},
                                    { Department.Sales, "70C1B3"},
                                    { Department.Promotion, "70F1B3"},
                                    { Department.AppDevelopment, "70A1B3"},
                                    { Department.CyberSecurity, "7SC1B3"},
                                    { Department.WebsiteDevelopment, "70C1N3"},
                                    { Department.Accounnting, "70POB3"},
                                    { Department.SocialMedia, "70PAB3"},
                                    { Department.Accounnting, "PAO1B3"},
                                    { Department.Payment, "70C1POA"},
                                    { Department.Secretary, "70CEJW3"},
                                    { Department.Promo, "XOC1B3"},
                                    { Department.Design, "XAC1B3"},
                                    { Department.Search, "XIC1B3"},
                                    { Department.Branch, "9290bb" },
                                    { Department.Lawyer, "00C1B3"},
                                    { Department.Informatics, "70CXA3"}
                                };

            // For each and every company in the companies list...
            foreach(var company in companies)
            {
                // For each department in the list with every possible option for a department's name...
                foreach (var dep in departmentOptionsList)
                {
                    // Creates a department data model that has as department the department and the company from the according lists
                    var department = new DepartmentDataModel() { Department = dep.Key, Company = company, Color = dep.Value };
                    // Adds the data model in the departments data model
                    context.Departments.Add(department);
                }
            }

            // Save changes
            await context.SaveChangesAsync();

            // Parses the db set of departments to a list
            var departments = await context.Departments.ToListAsync();

            #endregion

            #region Users

            // Creates a list of user data model for the employees
            var employees = new Faker<UserDataModel>()
                            .RuleFor(x => x.Username, faker => faker.Person.UserName)
                            .RuleFor(x => x.Password, faker => faker.Random.String2(7, 10))
                            .RuleFor(x => x.Email, faker => faker.Person.Email)
                            .RuleFor(x => x.ProfilePicture, faker => faker.Internet.Avatar())
                            .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                            .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                            .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(5, DateTime.Now))
                            // The user type is employee
                            .RuleFor(x => x.Type, faker => UserType.Employee)
                            .RuleFor(x => x.DepartmentId, faker => faker.Random.Int(1, 8))
                            .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1, 3))
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(3))
                            .Generate(100);

            // Adds the generated employees in the users db set
            context.Users.AddRange(employees);

            // Saves changes
            await context.SaveChangesAsync();

            // Add data to managers
            // For each company in the companies list...
            foreach (var company in companies)
            {
                // For each department in a company
                foreach (var department in company.Departments)
                {
                    // Creates a manager
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
                    // Adds the generated manager to the users db set
                    context.Users.AddRange(manager);
                }
            }

            // Saves changes
            await context.SaveChangesAsync();

            // Parses all the users from the db set the are of type evaluator to a list
            var managers = await context.Users.Where(x => x.Type == UserType.Manager).ToListAsync();

            // Add data to evaluators
            // For each company in the companies list...
            foreach (var company in companies)
            {
                // For each department in a company
                foreach (var department in company.Departments)
                {
                    // Creates a evaluator
                    var evaluator = new Faker<UserDataModel>()
                            .RuleFor(x => x.Username, faker => faker.Person.UserName)
                            .RuleFor(x => x.Password, faker => faker.Random.String2(7, 10))
                            .RuleFor(x => x.Email, faker => faker.Person.Email)
                            .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                            .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                            .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(5, DateTime.Now))
                            .RuleFor(x => x.Type, faker => UserType.Evaluator)
                            .RuleFor(x => x.Company, faker => company)
                            .RuleFor(x => x.Department, faker => department)
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(3))
                            .Generate(5);
                    // Adds the generated evaluator to the users db set
                    context.Users.AddRange(evaluator);
                }
            }

            // Saves changes
            await context.SaveChangesAsync();

            // Parses all the users from the db set the are of type evaluator to a list
            var evaluators = await context.Users.Where(x => x.Type == UserType.Evaluator).ToListAsync();

            var employeesWithOutJoins = await context.Users.Where(x => x.Type == UserType.Employee).ToListAsync();

            var employeesWithJoins = await context.Users.Include(x => x.AcquiredDegrees)
                                                        .Include(x => x.Certificates)
                                                        .Include(x => x.RecommendationPapers)
                                                        .Include(x => x.Languages)
                                                        .Where(x => x.Type == UserType.Employee)
                                                        .ToListAsync();


            #endregion

            #region Evaluations

            // Creates a list of user data model for the evaluations
            var evaluation = new Faker<EvaluationDataModel>()
                          .RuleFor(x => x.InterviewGrade, faker => faker.Random.Float())
                          .RuleFor(x => x.ReportGrade, faker => faker.Random.Float())
                          .RuleFor(x => x.FilesGrade, faker => faker.Random.Float())
                          .RuleFor(x => x.FinalGrade, faker => faker.Random.Float())
                          .RuleFor(x => x.Comments, faker => faker.Rant.Review())
                          .Generate(100);

            // Adds the generated employees in the users db set
            context.Evaluations.AddRange(evaluation);

            // Saves changes
            await context.SaveChangesAsync();

            //edw 8elei mia sunarthsh opou analoga me to department 8a vazei kai ta analoga IDs sotus managers, evaluators klp



            #endregion

            #region Jobs

            ///Either all companies will have the same deprtments or ?

            // Creates a list of Job data model 
            var jobs = new Faker<JobDataModel>()
                            .RuleFor(x => x.JobTitle, faker => faker.Name.JobTitle())
                            .RuleFor(x => x.Salary, faker => faker.Random.Int(560, 10000))
                            .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1,10))
                            .RuleFor(x => x.Department, faker => faker.Random.Int(1,21))
                            .Generate(100);

            // Adds the generated jobs in the users db set
            context.Jobs.AddRange(jobs);

            // Saves changes
            await context.SaveChangesAsync();


            #endregion

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
