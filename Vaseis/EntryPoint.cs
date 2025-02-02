﻿using Bogus;

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
                    About = "Τελειωμό δεν έχουν τα... βάσανα στις ζωές των ηρώων στις «Άγριες Μέλισσες» με τη Δρόσω να αντιμετωπίζει τον χειρότερο εφιάλτη της, από τον Τάκη που ισχυρίζεται ότι την αγαπάει και θέλει να την κερδίσει ξανά. Ο Τάκης ήρθε στο Διαφάνι και ζητά από τη Δρόσω να φύγουν μαζί εκβιάζοντάς την - από αγάπη όπως λέει - ότι θα αποκαλύψει τα μυστικά της. Σύντομα κάνει τις απειλές του πραγματικότητα, φέρνοντας την καταστροφή για τη Δρόσω Σταμίρη. Η Ασημίνα σε επόμενο επεισόδιο το σκάει με τον μικρό Σέργιο και ο Μπάμπης συλλαμβάνεται για την εξαφάνιση της Ασημίνας, ενώ μια άφιξη στο Διαφάνι «απειλεί» να φανερώσει το μυστικό της Βιολέτας.",
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
                    Name = "Τα σουτζουκάκια της Μαρίας",
                    AFM = "240820001",
                    DOY = "Δ.Ο.Υ. ΚΙΛΚΙΣ",
                    Country = "Canada",
                    City = "Toronto",
                    About = "Ο Τάκης έχει επιβάλλει την παρουσία του στο σπίτι των Σταμίρη στο Διαφάνι και με εκβιασμούς και φτηνούς ηρωισμούς προσπαθεί να κάνει δική του τη Δρόσω. Ο Νικηφόρος έρχεται στα χέρια με τον Τάκη και απαγορεύει στη Δρόσω να ξαναδεί τον μικρό Σέργιο. Κάτι που τη διαλύει!"
                    + "Στο spoiler του Αλέξη Μίχα στην εκπομπή «Το Πρωινό» για τις εξελίξεις στις « «Άγριες Μέλισσες» Δούκας και Μυρσίνη δεν αντέχουν ο ένας τον άλλον και αλληλοκατηγορούνται με αποτέλεσμα να φτάσουν στο διαζύγιο. ",
                    StreetName = "Cocoan",
                    StreetNumber = "24",
                    TelephoneNumber = "(+1) 1501199811",
                    DateCreated = new DateTime(2019, 11, 25),
                    CompanyPicture = "https://beets-me.com/wp-content/uploads/2020/05/Soutzoukakia-smyrneika-fakis-6.jpg"
                },

                new CompanyDataModel()
                {
                    Name = "Caravel",
                    AFM = "101000018",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    City = "Patras",
                    About = "Kατάφερε να γίνει viral για τον λάθος λόγο. Στο χθεσινό επεισόδιο του Survivor η Άννα Μαρία τσακώθηκε με την Ελίζαμπεθ Ελέτσι, την συμπαίκτριά της στην ομάδα των «Διασήμων» και μας χάρισε το μαργαριτάρι της χρονιάς."

                    + "Θέλοντας -και καλά!- να διορθώσει την συμπαίκτριά της, της είπε με ύφος που θα ζήλευε και ο Μπαμπινιώτης: «Επειδή είπες ότι ξέρουμε ελληνικά, το ‘παρά ταύτα’ δεν σημαίνει ‘παρόλα αυτά’, το ‘παρά ταύτα’ σημαίνει ‘αμέσως τώρα’. Είναι λάθος λοιπόν»."

                    + "Μπορεί ο Φατσέας να εκτίμησε το δωρεάν μάθημα ελληνικής, αλλά ένα μικρό θεματάκι με την ερμηνεία το είχαμε. Γιατί το λάθος με το «πάραυτα» εδώ που τα λέμε το κάνει η μισή Ελλάδα."

                    + "Είναι το πιο συνηθισμένο λάθος που κάνουν οι μισοί τουλάχιστον Έλληνες. Χρησιμοποιούν τη λέξη «πάραυτα» νομίζοντας ότι σημαίνει… παρόλα αυτά.",
                    StreetName = "Pantelehmonos",
                    StreetNumber = "12",
                    TelephoneNumber = "(+41) 2612202012",
                    DateCreated = new DateTime(2020, 10, 10),
                    CompanyPicture = "https://www.patrasevents.gr/imgsrv/f/full/1282553.jpg"
                },

                new CompanyDataModel()
                {
                    Name = "BatterButlers",
                    AFM = "101000210",
                    DOY = "Δ.Ο.Υ. ΠΑΤΡΑΣ",
                    Country = "Greece",
                    About =  "Ο Μελέτης πάει να ζητήσει εξηγήσεις από τον Θέμελη που τους κατέδωσε, ενώ ο Κωνσταντής πρέπει να πάρει μια σημαντική απόφαση για την παράνομη επιχείρησή του. Τα νέα του αρραβώνα της Σοφούλας με τον Βόσκαρη σκάνε σα βόμβα στο καφενείο. Πώς θα το πούνε στον Άγγελο; Η Ελένη ζητάει από τον Τάκη να φύγει από το σπίτι τους, αλλά εκείνος είναι αποφασισμένος να ξανακερδίσει τη Δρόσω και παίζει το τελευταίο του χαρτί.",
                    City = "Patras",
                    StreetName = "Pantanashs",
                    StreetNumber = "4",
                    TelephoneNumber = "(+60) 2610202212",
                    DateCreated = new DateTime(2020, 10, 19),
                    CompanyPicture = "https://media-cdn.tripadvisor.com/media/photo-p/18/14/32/bf/batterbutlers-logo.jpg"
                },

            });

            // Add the companies to the database
            await context.SaveChangesAsync();

            // List that contains all the companies
            var companies = await context.Companies.ToListAsync();

            #endregion

            #region Departments

            // Creates a list of departments and fills it with every possible option
            var departmentOptionsList = new Dictionary<string, string>()
                                {
                                    { "Research", "F5D547"},
                                    { "Purchasing", "EF8354"},
                                    { "Production", "8EB8E5"},
                                    { "Marketing", "028090"},
                                    { "Human resource management", "397367"},
                                    { "Finance", "2E2E2E"},
                                    { "Development", "9F1747"},
                                    { "Accounting", "70C1B3"}
                                };

            // For each and every company in the companies list...
            foreach (var company in companies)
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

            #region Jobs

            //Creates a list of Job data model
            var jobs = new Faker<JobDataModel>()
                            .RuleFor(x => x.JobTitle, faker => faker.Name.JobTitle())
                            .RuleFor(x => x.Salary, faker => faker.Random.Int(560, 10000))
                            .RuleFor(x => x.DepartmentId, faker => faker.Random.Int(1, 32))
                            .Generate(200);

            // Adds the generated jobs in the users db set
            context.Jobs.AddRange(jobs);

            // Saves changes
            await context.SaveChangesAsync();

            // Gets the jobs with their departments
            var jobsNO = await context.Jobs.Include(x => x.Department).ToListAsync();
            // For each job...
            foreach(var job in jobsNO)
                // Sets the job's company id to the job's department's company's id
                job.CompanyId = job.Department.CompanyId;
            // Save changes
            await context.SaveChangesAsync();


            #endregion

            #region Job Position

            /// Creates a list of Job Position data model
            var pastJobPositions = new Faker<JobPositionDataModel>()
                            .RuleFor(x => x.JobId, faker => faker.Random.Int(1, 200))
                            .RuleFor(x => x.StartDate, faker => faker.Date.Between(new DateTime(2008, 01, 07), new DateTime(2020, 11, 28)))
                            .Generate(100);

            // Adds the generated jobs in the users db set
            context.JobPositions.AddRange(pastJobPositions);

            //  Saves changes
            await context.SaveChangesAsync();

            var newJobPositions = new Faker<JobPositionDataModel>()
                                .RuleFor(x => x.JobId, faker => faker.Random.Int(1, 200))
                                .RuleFor(x => x.AnnouncementDate, faker => faker.Date.Between(new DateTime(2021, 01, 01), new DateTime(2021, 01, 28)))
                                .RuleFor(x => x.SubmissionDate, faker => faker.Date.Between(new DateTime(2021, 01, 30), new DateTime(2021, 03, 15)))
                                .Generate(60);

            // Adds the generated jobs in the users db set
            context.JobPositions.AddRange(newJobPositions);

            //  Saves changes
            await context.SaveChangesAsync();

            // The job positions
            var jobPositions = await context.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department).ToListAsync();

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
                            // The user type is employee
                            .RuleFor(x => x.Type, faker => UserType.Employee)
                            .RuleFor(x => x.DepartmentId, faker => faker.Random.Int(1, 32))
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(32))
                            .Generate(200);

            // Adds the generated employees in the users db set
            context.Users.AddRange(employeesDm);

            // Saves changes
            await context.SaveChangesAsync();

            // Parses all the users from the db set the are of type employee to a list
            var employees = await context.Users.Include(x => x.Department).Where(x => x.Type == UserType.Employee).ToListAsync();

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
                            .RuleFor(x => x.DepartmentId, department.Id)
                            .RuleFor(x => x.CompanyId, company.Id)
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(32))
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
                            .RuleFor(x => x.DepartmentId, department.Id)
                            .RuleFor(x => x.CompanyId, company.Id)
                            .RuleFor(x => x.Bio, faker => faker.Lorem.Paragraph(32))
                            .Generate(2);
                    // Adds the generated evaluator to the users db set
                    context.Users.AddRange(evaluator);
                }
            }

            // Saves changes
            await context.SaveChangesAsync();

            // Parses all the users from the db set the are of type evaluator to a list
            var evaluators = await context.Users.Include(x => x.Department).Where(x => x.Type == UserType.Evaluator).ToListAsync();

            context.Users.AddRange(new List<UserDataModel>() //in memory
            {
                new UserDataModel()
                {
                    Username = "GewrgikaMantalakia",
                    Password = "wxAmanAman",
                    Email = "vasoulakok@hotmail.com",
                    ProfilePicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRtfl8a3emNH5v8fgYNkyMvnXkcqyGiW_2KLQ&usqp=CAU",
                    FirstName = "Vasiliki",
                    LastName = "Kokkala",
                    YearsOfExperience = 55,
                    Type = UserType.Administrator,
                    Bio = "Τρακτέρ ή γεωργικός ελκυστήρας ονομάζεται το όχημα με μεγάλη δύναμη, ώστε να μπορεί να μετακινεί γεωργικά και άλλα μηχανήματα. Έχει όμως επικρατήσει σε διεθνή κλίμακα, να λέγονται τρακτέρ τα μηχανήματα που προσφέρουν τεράστιες υπηρεσίες στην καλλιέργεια της γης. Κυρίως χρησιμοποιείται για την έλξη διαφόρων γεωργικών μηχανημάτων όπως άροτρα, φρέζες, καλλιεργητές, κ.α. καθώς και για συντήρηση αθλητικών χώρων και πάρκων. Αυτή τη δουλειά παλιότερα την έκαναν τα ζώα, οι ανάγκες όμως αυξήθηκαν και η πρόοδος της τεχνολογίας έδωσε τη δυνατότητα να καλυφθούν αυτές με πολύ καλύτερο τρόπο."
                        +  "Τα τρακτέρ παλιά κινούνταν με ατμό ή βενζίνη, ενώ με την εφεύρεση του ντίζελ επικράτησε ως καύσιμο το πετρέλαιο . Υπάρχουν τρακτέρ τροχοφόρα και ερπυστριοφόρα, τα οποία χρησιμοποιούνται για βαθιά άροση και για τη μετακίνηση σε ανώμαλα εδάφη. Στην Ελλάδα τα πρώτα τρακτέρ κυκλοφόρησαν το 1924."
                },
                new UserDataModel()
                {
                    Username = "0xCAFFEEBABA",
                    Password = "neraki23",
                    Email = "papapap@kaka.com",
                    ProfilePicture = "https://image.freepik.com/free-photo/white-coffee-cup-roasted-coffee-beans-around_35570-794.jpg",
                    FirstName = "Katherine",
                    LastName = "Papa",
                    YearsOfExperience = 5,
                    Type = UserType.Administrator,
                    Bio = "The GRANT statement grants privileges to MySQL user accounts. To grant a privilege with GRANT, you must have the GRANT OPTION privilege, and you must have the privileges that you are granting. (Alternatively, if you have the UPDATE privilege for the grant tables in the mysql system database, you can grant any account any privilege.) When the read_only system variable is enabled, GRANT additionally requires the SUPER privilege."
                        + "The REVOKE statement is related to GRANT and enables administrators to remove account privileges. See Section 13.7.1.6, “REVOKE Statement”."
                }
            });

            await context.SaveChangesAsync();
            var admins = await context.Users.ToListAsync();

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
                        // Get a random number between 0 and 1
                        // ( Every department has 2 evaluators )
                        var i = new Random().Next(0, departmentEvaluators.Count() - 1);
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

            #region Extra find all

            // For each employee...
            foreach(var employee in employees)
            {
                // Returns a list of job positions found with...
                var departmentJobPositions = jobPositions.FindAll(delegate (JobPositionDataModel jobPosition)
                {
                    // The same department id as the employee
                    return jobPosition.Job.DepartmentId == employee.DepartmentId;
                });
                if(departmentJobPositions.Count() > 0)
                {
                    // Gets a random number between 0 and the count of the department's job positions list
                    var i = new Random().Next(0, departmentJobPositions.Count() - 1);
                    // Sets the employee's job position id to the randomly picked job position's id
                    employee.JobPositionId = departmentJobPositions[i].Id;
                    employee.CompanyId = departmentJobPositions[i].Job.Department.CompanyId;
                }
            }

            // Gets all the job positions
            var jobPositionsNO = await context.JobPositions.Include(x => x.Job).ThenInclude(y => y.Department).ToListAsync();

            // For each job position...
            foreach (var jobPosition in jobPositionsNO)
            {
                // Returns a list of evaluators...
                var companyEvaluators = evaluators.FindAll(delegate (UserDataModel evaluator)
                {
                    // Found with the same company id as the job position
                    return evaluator.Department.CompanyId == jobPosition.Job.Department.CompanyId;
                });
                if (companyEvaluators.Count() > 0)
                {
                    // Get a random number between 0 and to last evaluator in evaluators list
                    var i = new Random().Next(0, companyEvaluators.Count() - 1);
                    // Sets the creator's id randomly as one of the ids of the found evaluators
                    jobPosition.CreatorId = companyEvaluators[i].Id;
                }
            }

            await context.SaveChangesAsync();

            #endregion

            #region JobPositionRequests

            // Creates a list of job position requests data model for the job position requests
            var jobPositionsRequests = new Faker<JobPositionRequestDataModel>()
                                    .RuleFor(x => x.JobPositionId, faker => faker.Random.Int(101, 160))
                                    .RuleFor(x => x.RequestsReason, faker => faker.Lorem.Sentences(3))
                                    .Generate(500);

            // Adds the generated job position requests in the job position requests db set
            context.JobPositionRequests.AddRange(jobPositionsRequests);

            // Saves changes
            await context.SaveChangesAsync();
            var jobPositionRequestsNO = await context.JobPositionRequests.Include(x => x.JobPosition).ThenInclude(y => y.Job).ThenInclude(z => z.Department).ToListAsync();
            var userJobPairsNO = await context.UsersJobFilesPairs.Include(x => x.JobPositionRequests)
                                                                 .Include(x => x.Evaluations)
                                                                 .Include(x => x.Reports)
                                                                 .Include(x => x.Employee)
                                                                 .ToListAsync();
            foreach(var jobPositionRequest in jobPositionRequestsNO)
            {
                var pairs = userJobPairsNO.FindAll(delegate (UsersJobFilesPairDataModel pair)
                {
                    return pair.Employee.DepartmentId == jobPositionRequest.JobPosition.Job.DepartmentId;
                });
                if(pairs.Count() > 0)
                {
                    // Gets a random number between 0 and the count of the pairs' list
                    var i = new Random().Next(0, pairs.Count() - 1);
                    jobPositionRequest.UsersJobFilesPairId = pairs[i].Id;
                }
            }

            #endregion

            #region Reports

            foreach (var jobPositionsRequest in jobPositionsRequests)
            {
                if(jobPositionsRequest.UsersJobFilesPairId != null)
                {
                    // Creates a list of report data model for the reports
                    var report = new Faker<ReportDataModel>()
                                .RuleFor(x => x.ReportText, faker => faker.Rant.Review("job"))
                                .RuleFor(x => x.UsersJobFilesPairId, jobPositionsRequest.UsersJobFilesPairId)
                                .RuleFor(x => x.JobPositionRequestId, jobPositionsRequest.Id)
                                .RuleFor(x => x.IsWritten, true)
                                .RuleFor(x => x.IsFinalized, faker => faker.Random.Bool())
                                .Generate(1);

                    // Adds the generated reports in the users db set
                    context.Reports.AddRange(report);
                }
            }

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Evaluations

            foreach (var jobPositionsRequest in jobPositionsRequests)
            {
                if (jobPositionsRequest.UsersJobFilesPairId != null)
                {
                    // Creates a list of evaluation data model for the evaluations
                    var evaluation = new Faker<EvaluationDataModel>()
                             .RuleFor(x => x.InterviewGrade, faker => faker.Random.Int(100, 1000))
                             .RuleFor(x => x.ReportGrade, faker => faker.Random.Int(100, 1000))
                             .RuleFor(x => x.FilesGrade, faker => faker.Random.Int(100, 1000))
                             .RuleFor(x => x.Comments, faker => faker.Rant.Review("Employee"))
                             .RuleFor(x => x.JobPositionRequestId, jobPositionsRequest.Id)
                             .RuleFor(x => x.UsersJobFilesPairId, jobPositionsRequest.UsersJobFilesPairId)
                             .RuleFor(x => x.IsFinalized, faker => faker.Random.Bool())
                             .Generate(1);

                    // Adds the generated evaluations in the evaluations db set
                    context.Evaluations.AddRange(evaluation);
                }
            }

            // Saves changes
            await context.SaveChangesAsync();

            //take all the made evaluations to a list
            var evaluations = await context.Evaluations.ToListAsync();
            float finalGrade = 0;

            //for every evaluaion in the database count the final grade and add it back to the database as FinalGrade
            foreach (var evaluation in evaluations)
            {
                finalGrade = (float)(evaluation.InterviewGrade * 0.4 + evaluation.ReportGrade * 0.4 + evaluation.FilesGrade * 0.2);
                //*100 to become an integer
                evaluation.FinalGrade = (int)finalGrade;
                if(evaluation.IsFinalized == true)
                {
                    var rng = new Random();
                    var randomBool = rng.Next(0, 2) > 0;
                    evaluation.IsAprovedByManager = randomBool;
                }
                if (evaluation.IsAprovedByManager == true)
                { 
                    var rng = new Random();
                    var randomBool = rng.Next(0, 2) > 0;
                    evaluation.Passed = randomBool;
                }
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
                            .Generate(50);

            // Adds the generated degrees in the degrees db set
            context.Degrees.AddRange(degrees);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region AcquiredDegrees

            // Generates the acquired degrees
            var acquiredDegrees = new Faker<AcquiredDegreeDataModel>()
                            .RuleFor(x => x.Grade, faker => faker.Random.Int(5, 10))
                            .RuleFor(x => x.YearEarned, faker => faker.Date.Past(30, DateTime.Now))
                            .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 296))
                            .RuleFor(x => x.DegreeId, faker => faker.Random.Int(1, 50))
                            .Generate(200);

            // Adds the generated acquired degrees in the acquired degrees db set
            context.AcquiredDegrees.AddRange(acquiredDegrees);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region RecommendationPapers

            var recommendationPapers = new Faker<RecommendationPaperDataModel>()
                .RuleFor(x => x.Referee, faker => faker.Person.FullName)
                .RuleFor(x => x.Description, faker => faker.Lorem.Paragraph(25))
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 296))
                .Generate(400);


            // Adds the generated acquired recommendationPapers in the recommendation Papers db set
            context.RecomendationPapers.AddRange(recommendationPapers);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Subjects

            ///Below i have created many different subjects so that i can relate 
            ///Many fathers
            context.Subjects.AddRange(new List<SubjectDataModel>()
            {
                new SubjectDataModel()
                {
                Title = "Arts",
                Description = " graphical components"
                },

                new SubjectDataModel()
                {
                Title = "Maths",
                Description = "Making things Rational"
                },

                new SubjectDataModel()
                {
                Title = "Farts",
                Description = "Au de parfume"
                },

                new SubjectDataModel()
                {
                Title = "Clash of Clans",
                Description = "Ax o Perseas"
                },

            });

            // Add the companies to the database
            await context.SaveChangesAsync();

            var childrenSubjects = new Faker<SubjectDataModel>()
                               .RuleFor(x => x.Title, faker => faker.Commerce.Product())
                               .RuleFor(x => x.Description, faker => faker.Lorem.Paragraph(25))
                               .RuleFor(x => x.SubjectId, faker => faker.Random.Int(1, 4))
                               .Generate(20);

            context.Subjects.AddRange(childrenSubjects);

            await context.SaveChangesAsync();

            // List that contains all the companies
            var subjects = await context.Subjects.ToListAsync();

            #endregion

            #region JobPositionSubjects

            foreach(var jobPosition in jobPositionsNO)
            {
                var random = new Random();

                var index1 = random.Next(1, 24 / 2) * 2;
                var index2 = random.Next(0, 22 / 2) * 2 + 1;

                var jobPositionSubject1 = new JobPositionSubjectDataModel()
                {
                    JobPositionId = jobPosition.Id,
                    SubjectId = index1
                };
                context.JobPositionSubjects.Add(jobPositionSubject1);
                var jobPositionSubject2 = new JobPositionSubjectDataModel()
                {
                    JobPositionId = jobPosition.Id,
                    SubjectId = index2
                };
                context.JobPositionSubjects.Add(jobPositionSubject2);
            }

            await context.SaveChangesAsync();

            #endregion

            #region Certificates

            // Generates the certificates
            var certificates = new Faker<CertificateDataModel>()
                .RuleFor(x => x.Title, faker => faker.Lorem.Sentence(2))
                .RuleFor(x => x.Description, faker => faker.Lorem.Paragraph(25))
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 296))
                .Generate(300);

            // Adds the generated awards in the awards db set
            context.Certificates.AddRange(certificates);

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
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 296))
                .Generate(500);

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
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 296))
                .Generate(700);

            // Adds the generated languages in the languages db set
            context.Languages.AddRange(languages);

            // Saves changes
            await context.SaveChangesAsync();

            #endregion

            #region Projects

            // Generates the projects
            var projects = new Faker<ProjectDataModel>()
                .RuleFor(x => x.Title, faker => faker.Lorem.Sentence(2))
                .RuleFor(x => x.Url, faker => faker.Internet.Url())
                .RuleFor(x => x.MadeForWho, faker => faker.Random.Enum<MadeForWho>())
                .RuleFor(x => x.Description, faker => faker.Lorem.Paragraph())
                .RuleFor(x => x.UserId, faker => faker.Random.Int(1, 296))
                .Generate(600);

            // Adds the generated projects in the projects db set
            context.Projects.AddRange(projects);

            // Saves changes
            await context.SaveChangesAsync();

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

            //var companiesWithDepartments = await context.Companies.Include(x => x.Departments)
            //                        .ToListAsync();

            //var employeesWithJoins = await context.Users.Include(x => x.AcquiredDegrees)
            //                                            .Include(x => x.Certificates)
            //                                            .Include(x => x.RecommendationPapers)
            //                                            .Include(x => x.Languages)
            //                                            .Include(x => x.Projects)
            //                                           // .Where(x => x.Type == UserType.Evaluator)
            //                                            .ToListAsync();


            ////Add to all subjects, the Children Subjetcs that have THIS subject as father
            //var SubjectsWithJoins = await context.Subjects.Include(x => x.ChildrenSubjects)
            //                                               .ToListAsync();

            ////matching every jobPosition with its subject of interest
            //var JobPostitionWithJoins = await context.JobPositions.Include(x => x.Subjects)
            //                                                      .ToListAsync();


            //var JobsWithJoins = await context.Jobs.Include(x => x.JobPositions)
            //                                                 .ToListAsync();


            //var DeprtmentsWithJoins = await context.Departments.Include(x => x.Users)
            //                                                   .Include(x => x.Jobs)
            //                                                   .ToListAsync();

            //var companiiesWithJoins = await context.Companies.Include(x => x.Departments).ToListAsync();


        }
    }
}