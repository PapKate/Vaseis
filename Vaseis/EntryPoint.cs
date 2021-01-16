using Bogus;

using Microsoft.EntityFrameworkCore;

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

        private static async Task SetUpAsync()
        {
            var context = Services.GetDbContext;

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
                    DateCreated = new DateTime(2018, 1, 1),
                    CompanyPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmloPgpVspV4e3ZZYC6PoC59_3mbxX0RdZsg&usqp=CAU"
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
                    DateCreated = new DateTime(2019, 11, 25),
                    CompanyPicture = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/bunch-of-roses-as-a-bed-royalty-free-image-964650398-1554826447.jpg?crop=1xw:1xh;center,top&resize=480:*"
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
                    DateCreated = new DateTime(2020, 1, 11),
                    CompanyPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSY3utSbC6mOgwUqi05dtGp-btsnCG4lbkjFQ&usqp=CAU"
                },

                new CompanyDataModel()
                {
                    Name = "CEID",
                    AFM = "101090018",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    StreetName = "Filippimenos",
                    StreetNumber = "2",
                    TelephoneNumber = "(+41) 2612202012",
                    DateCreated = new DateTime(2019, 2, 2),
                    CompanyPicture = "https://www.upatras.gr/sites/www.upatras.gr/files/posters/01f1a05053c6242fcfa23075e5b963c1_xl.jpg"
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
                    DateCreated = new DateTime(2020, 10, 10),
                    CompanyPicture = ""
                },

                new CompanyDataModel()
                {
                    Name = "Ta Soutzoukakia Ths Marias",
                    AFM = "101000218",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    StreetName = "Apollonws",
                    StreetNumber = "8",
                    TelephoneNumber = "(+30) 2612202212",
                    DateCreated = new DateTime(2020, 10, 20),
                    CompanyPicture = ""
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
                    DateCreated = new DateTime(2020, 10, 19),
                    CompanyPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTzDpT-yPy_tvXc6k7_vq7HMmgULZZ6snw1A&usqp=CAU"
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
                    DateCreated = new DateTime(2018, 5, 6),
                    CompanyPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaTNkUnPkAKLDJt6bdUAFheFGj-5VlT-wuLQ&usqp=CAU"
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
                    DateCreated = new DateTime(2018, 5, 6),
                    CompanyPicture = "https://www.google.gr/images/branding/googlelogo/2x/googlelogo_color_160x56dp.png"
                }

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
                                    { Department.Purchasing, "EF8354"},
                                    { Department.Production, "8EB8E5"},
                                    { Department.Marketing, "028090"},
                                    { Department.HumanResourceManagement, "397367"},
                                    { Department.Finance, "2E2E2E"},
                                    { Department.Development, "9F1747"},
                                    { Department.Accounting, "70C1B3"}
                                };

            // For each and every company in the companies list...
            foreach(var company in companies)
            {
                // For each department in the list with every possible option for a department's name...
                foreach (var dep in departmentOptionsList)
                {
                    // Creates a department data model that has as department the department and the company from the according lists
                    var department = new DepartmentDataModel() { DepartmentName = dep.Key, Company = company, Color = dep.Value };
                    // Adds the data model in the departments data model
                    context.Departments.Add(department);
                }
            }

            // Save changes
            await context.SaveChangesAsync();

            // Parses the db set of departments to a list
            var departments = await context.Departments.ToListAsync();

            #endregion

            #region Subjects

            #endregion

            #region Jobs

            //Creates a list of Job data model
            var jobs = new Faker<JobDataModel>()
                           .RuleFor(x => x.JobTitle, faker => faker.Name.JobTitle())
                           .RuleFor(x => x.Salary, faker => faker.Random.Int(560, 10000))
                           .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1, 9))
                           .RuleFor(x => x.DepartmentId, faker => faker.Random.Int(1, 72))
                           .Generate(40);

           // Adds the generated jobs in the users db set
            context.Jobs.AddRange(jobs);

           // Saves changes
           await context.SaveChangesAsync();

            #endregion

            #region Job Position

            /// Creates a list of Job Position data model
            var pastJobPositions = new Faker<JobPositionDataModel>()
                            .RuleFor(x => x.JobId, faker => faker.Random.Int(1, 40))
                            .RuleFor(x => x.StartDate, faker => faker.Date.Between(new DateTime(2008, 01, 07), new DateTime(2020, 11, 28)))
                            .Generate(100);

            // Adds the generated jobs in the users db set
            context.JobPositions.AddRange(pastJobPositions);

            //  Saves changes
            await context.SaveChangesAsync();

            var newJobPositions = new Faker<JobPositionDataModel>()
                                .RuleFor(x => x.JobId, faker => faker.Random.Int(1, 40))
                                .RuleFor(x => x.AnnouncementDate, faker => faker.Date.Between(new DateTime(2021, 01, 01), new DateTime(2021, 01, 28)))
                                .RuleFor(x => x.SubmissionDate, faker => faker.Date.Between(new DateTime(2021, 01, 30), new DateTime(2021, 03, 15)))
                                .Generate(20);

            // Adds the generated jobs in the users db set
            context.JobPositions.AddRange(newJobPositions);

            //  Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Users

            // Creates a list of user data model for the employees
            var employeesDm = new Faker<UserDataModel>()
                            .RuleFor(x => x.Username, faker => faker.Person.UserName)
                            .RuleFor(x => x.Password, faker => faker.Random.String2(7, 10))
                            .RuleFor(x => x.Email, faker => faker.Person.Email)
                            .RuleFor(x => x.ProfilePicture, faker => faker.Internet.Avatar())
                            .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
                            .RuleFor(x => x.LastName, faker => faker.Person.LastName)
                            .RuleFor(x => x.YearsOfExperience, faker => faker.Random.Int(1, 50))
                            .RuleFor(x => x.JobPositionId, faker => faker.Random.Int(1, 100))
                            // The user type is employee
                            .RuleFor(x => x.Type, faker => UserType.Employee)
                            .RuleFor(x => x.DepartmentId, faker => faker.Random.Int(1, 72))
                            .RuleFor(x => x.CompanyId, faker => faker.Random.Int(1, 9))
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(3))
                            .Generate(400);

            // Adds the generated employees in the users db set
            context.Users.AddRange(employeesDm);

            // Saves changes
            await context.SaveChangesAsync();

            // Parses all the users from the db set the are of type employee to a list
            var employees = await context.Users.Where(x => x.Type == UserType.Employee).ToListAsync();

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
                            .RuleFor(x => x.YearsOfExperience, faker => faker.Random.Int(1, 50))
                            .RuleFor(x => x.ProfilePicture, faker => faker.Internet.Avatar())
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

            // Parses all the users from the db set the are of type manager to a list
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
                            .RuleFor(x => x.YearsOfExperience, faker => faker.Random.Int(1, 50))
                            .RuleFor(x => x.ProfilePicture, faker => faker.Internet.Avatar())
                            .RuleFor(x => x.RegistrationDate, faker => faker.Date.Past(5, DateTime.Now))
                            .RuleFor(x => x.Type, faker => UserType.Evaluator)
                            .RuleFor(x => x.Company, faker => company)
                            .RuleFor(x => x.Department, faker => department)
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(3))
                            .Generate(3);
                    // Adds the generated evaluator to the users db set
                    context.Users.AddRange(evaluator);
                }
            }

            // Saves changes
            await context.SaveChangesAsync();

            // Parses all the users from the db set the are of type evaluator to a list
            var evaluators = await context.Users.Where(x => x.Type == UserType.Evaluator).ToListAsync();

            #endregion

            #region UsersJobFilesPair

            // For each manager in the managers list...
            foreach (var manager in managers)
            {  
                // For each employee in the employees list...
                foreach (var employee in employees)
                {
                    // If the employee has the same department id with the manager...
                    if (employee.DepartmentId == manager.DepartmentId)
                    {
                        // Get all the evaluators of that department
                        // Finds all the evaluators in the evaluators list that...
                        var departmentEvaluators = evaluators.FindAll(delegate (UserDataModel evaluator) 
                        {
                            // Have the same department id as the manager
                            return evaluator.DepartmentId == manager.DepartmentId;
                        });
                        // Get a random number between 0 and 2
                        // ( Every department has 3 evaluators )
                        var i = new Random().Next(0,2);
                        // Create an new users and job files pair
                        var pair = new UsersJobFilesPairDataModel()
                        {
                            // Sets the employee's id to the current id of the employee from the employees list
                            EmployeeId = employee.Id,
                            // Sets the manager's id to the current id of the manager from the manager list
                            ManagerId = manager.Id,
                            // Sets the evaluator's id to id of the randomly chosen evaluator from the department evaluators list
                            EvaluatorId = departmentEvaluators[i].Id
                        };
                        // Adds the pair the pair context             
                        context.UsersJobFilesPairs.Add(pair);
                    }
                }
            }

            await context.SaveChangesAsync();

            #endregion

            #region JobPositionRequests

            // Creates a list of job position requests data model for the job position requests
            var jobPositionsRequests = new Faker<JobPositionRequestDataModel>()
                                    .RuleFor(x => x.JobPositionId, faker => faker.Random.Int(101, 120))
                                    .RuleFor(x => x.RequestsReason, faker => faker.Lorem.Sentences(3))
                                    .RuleFor(x => x.UsersJobFilesPairId, faker => faker.Random.Int(1, 400))
                                    .Generate(500);

            // Adds the generated job position requests in the job position requests db set
            context.JobPositionRequests.AddRange(jobPositionsRequests);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Reports

            foreach (var jobPositionsRequest in jobPositionsRequests)
            {
                // Creates a list of report data model for the reports
                var report = new Faker<ReportDataModel>()
                            .RuleFor(x => x.ReportText, faker => faker.Rant.Review("job"))
                            .RuleFor(x => x.UsersJobFilesPairId, jobPositionsRequest.UsersJobFilesPairId)
                            .RuleFor(x => x.JobPositionRequestId, jobPositionsRequest.Id)
                            .RuleFor(x => x.IsWritten, true)
                            .Generate(1);

                // Adds the generated reports in the users db set
                context.Reports.AddRange(report);
            }

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Evaluations

            foreach (var jobPositionsRequest in jobPositionsRequests)
            {
                // Creates a list of evaluation data model for the evaluations
                var evaluation = new Faker<EvaluationDataModel>()
                             .RuleFor(x => x.InterviewGrade, faker => faker.Random.Int(100, 1000))
                             .RuleFor(x => x.ReportGrade, faker => faker.Random.Int(100, 1000))
                             .RuleFor(x => x.FilesGrade, faker => faker.Random.Int(100, 1000))
                             .RuleFor(x => x.Comments, faker => faker.Rant.Review("Employee"))
                             .RuleFor(x => x.JobPositionRequestId, jobPositionsRequest.Id)
                             .RuleFor(x => x.UsersJobFilesPairId, jobPositionsRequest.UsersJobFilesPairId)
                             .Generate(1);

                // Adds the generated evaluations in the evaluations db set
                context.Evaluations.AddRange(evaluation);
            }

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Degrees

            // Generates the degrees
            var degrees = new Faker<DegreeDataModel>()
                            .RuleFor(x => x.Title, faker => faker.Random.Enum<DegreeTitle>())
                            .RuleFor(x => x.School, faker => faker.Random.Enum<School>())
                            .RuleFor(x => x.LevelOfEducation, faker => faker.Random.Enum<LevelOfEducation>())
                            .Generate(100);

            // Adds the generated degrees in the degrees db set
            context.Degrees.AddRange(degrees);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region AcquiredDegrees

            // Generates the acquired degrees
            var acquiredDegrees = new Faker<AcquiredDegreeDataModel>()
                            .RuleFor(x => x.Grade, faker => faker.Random.Int(5,10))
                            .RuleFor(x => x.YearEarned, faker => faker.Date.Past(30, DateTime.Now))
                            .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 688))
                            .RuleFor(x => x.DegreeId, faker => faker.Random.Int(1, 40))
                            .Generate(60);

            // Adds the generated acquired degrees in the acquired degrees db set
            context.AcquiredDegrees.AddRange(acquiredDegrees);

            // Saves changes
            await context.SaveChangesAsync();
            
            #endregion

            #region Awards

            // A list of award names
            var awardsList = new List<string>()
            {
                "Rookie of the Year",
                "Fresh Skills",
                "New Kid on the Block",
                "Exceptional Hire",
                "Above & Beyond",
                "Lead Helping Hand",
                "Ultimate Team Player",
                "Difference Maker",
                "Outstanding Dependability",
                "Mountain Mover",
                "Power of One",
                "Always at 110%",
                "Role Model of the Year",
                "Positivity Queen/King",
                "Quality Enforcer",
                "Culture Champion",
                "The Iron Man",
                "The Brainiac",
                "The Holy Heart",
                "Lets Grow Old Together",
                "To The Moon and Back"
            };

            // Generates the awards
            var awards = new Faker<AwardDataModel>()
                .RuleFor(x => x.Name, faker => faker.Random.ListItem(awardsList))
                .RuleFor(x => x.AcquiredDate, faker => faker.Date.Past(5, DateTime.Now))
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 688))
                .Generate(1000);

            // Adds the generated awards in the awards db set
            context.Awards.AddRange(awards);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Languages

            // A list of languages names
            var languagesList = new List<string>()
            {
                "Chinese ",
                "Spanish ",
                "English ",
                "Hindi ",
                "Arabic ",
                "Russian ",
                "Japanese ",
                "French",
                "Korean",
                "Italian",
                "Greek",
                "Dutch",
                "Chhattisgarhi",
                "Serbian",
                "Portuguese"
            };

            // Generates the languages
            var languages = new Faker<LanguagesDataModel>()
                .RuleFor(x => x.Name, faker => faker.Random.ListItem(languagesList))
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 688))
                .Generate(2000);

            // Adds the generated languages in the languages db set
            context.Languages.AddRange(languages);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Projects

            // Generates the projects
            var projects = new Faker<ProjectDataModel>()
                .RuleFor(x => x.Title, faker => faker.Lorem.Sentence(2))
                .RuleFor (x => x.Url, faker => faker.Internet.Url())
                .RuleFor(x => x.MadeForWho, faker => faker.Random.Enum<MadeForWho>())
                .RuleFor(x => x.Description, faker => faker.Lorem.Paragraph())
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 688))
                .Generate(3000);

            // Adds the generated projects in the projects db set
            context.Projects.AddRange(projects);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region RecommendationPapers



            #endregion

            #region Update

            //// Get the first user
            //var user = await context.Users.FirstAsync();

            //user.Email = "paplabros@gmail.com";
            //user.Type = UserType.User;

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

            var employeesWithJoins = await context.Users.Include(x => x.AcquiredDegrees)
                                                        .Include(x => x.Certificates)
                                                        .Include(x => x.RecommendationPapers)
                                                        .Include(x => x.Languages)
                                                        .Where(x => x.Type == UserType.Evaluator)
                                                        .ToListAsync();

        }
    }
}
