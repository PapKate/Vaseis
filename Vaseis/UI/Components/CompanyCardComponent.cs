
using System;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using static Vaseis.Styles;

namespace Vaseis
{
    //This is a class that creates the row components fo rthe adminidtrator's companies page
    public class CompanyCardComponent : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The clicked Company
        /// </summary>
        public CompanyDataModel Company { get; }

        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid DialogHelperGrid { get; }

        /// <summary>
        /// The connected Admin
        /// </summary>
        public UserDataModel User { get; protected set; }

        #endregion

        #region Protected Properties
        /// <summary>
        /// A list with all the company's departments
        /// </summary>
        protected List<string> DepartmentNames { get; set; }

        /// <summary>
        /// A list with all the company's departments that have no manager
        /// </summary>
        protected List<string> EmptyDepartmentNames { get; set; }

        /// <summary>
        /// The company's grid
        /// </summary>
        protected Grid CompanyGrid { get; private set; }

        /// <summary>
        /// The users' grid
        /// </summary>
        protected UniformGrid UsersGrid { get; private set; }

        /// <summary>
        /// The departments' grid
        /// </summary>
        protected UniformGrid DepartmentsGrid { get; private set; }

        /// <summary>
        /// The jobs' grid
        /// </summary>
        protected UniformGrid JobstsGrid { get; private set; }

        /// <summary>
        /// The new user dialog
        /// </summary>
        protected NewUserDialogComponent AddUser { get; private set; }

        #endregion

        #region Dependency Properties

        #region Employees

        /// <summary>
        /// The company's Employees
        /// </summary>
        public IEnumerable<UserDataModel> Employees
        {
            get { return (IEnumerable<UserDataModel>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Employees"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeesProperty = DependencyProperty.Register(nameof(Employees), typeof(IEnumerable<UserDataModel>), typeof(CompanyCardComponent), new PropertyMetadata(OnEmployeesChanged));

        /// <summary>
        /// Handles the change of the <see cref="Employees"/> property
        /// </summary>
        private static void OnEmployeesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as CompanyCardComponent;

            sender.OnEmployeesChangedCore(e);
        }

        #endregion

        #region Department

        /// <summary>
        /// The company's departments
        /// </summary>
        public IEnumerable<DepartmentDataModel> Departments
        {
            get { return (IEnumerable<DepartmentDataModel>)GetValue(DepartmentsProperty); }
            set { SetValue(DepartmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Departments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentsProperty = DependencyProperty.Register(nameof(Departments), typeof(IEnumerable<DepartmentDataModel>), typeof(CompanyCardComponent), new PropertyMetadata(OnDepartmentsChanged));

        /// <summary>
        /// Handles the change of the <see cref="Departments"/> property
        /// </summary>
        private static void OnDepartmentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as CompanyCardComponent;

            sender.OnDepartmentsChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="company">The company data model</param>
        /// <param name="pageGrid">The page's grid</param>
        public CompanyCardComponent(UserDataModel user, CompanyDataModel company, Grid pageGrid)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Company = company ?? throw new ArgumentNullException(nameof(company));
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
            Update();
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            Employees = Company.Users;
            Departments = Company.Departments;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="CompanyCardComponent.Employees"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnEmployeesChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the change of the <see cref="CompanyCardComponent.Departments"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnDepartmentsChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the change of the <see cref="CompanyCardComponent.Jobs"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnJobsChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            DepartmentNames = new List<string>();
            EmptyDepartmentNames = new List<string>();

            CompanyGrid = new Grid()
            {
                Background = White.HexToBrush(),
            };
            CompanyGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            CompanyGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            #region First Column

            var CompanyPicAndLogo = new ImageAndNameComponent()
            {
                ImagePath = Company.CompanyPicture,
                Text = Company.Name,
                Width = 400
            };

            CompanyGrid.Children.Add(CompanyPicAndLogo);
            Grid.SetColumn(CompanyPicAndLogo, 0);

            #endregion

            var InfoAboutTheCompanyGrid = new Grid() { Margin = new Thickness(0,24,0,0) };

            InfoAboutTheCompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            #region second row 

            InfoAboutTheCompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            var employeesAndJobsGrid = new Grid() { Margin = new Thickness(0,0,0,24) };


            #region Expanders Region

            employeesAndJobsGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });
            employeesAndJobsGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });
            employeesAndJobsGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });
            employeesAndJobsGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            #region About

            var AboutTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                Text = Company.About
            };

            var aboutscroll = new ScrollViewer()
            {
                MaxWidth = 800,
                MaxHeight = 1000,
                CanContentScroll = true,
                Content = AboutTextBlock,
            };

            var aboutExpander = new Expander()
            {
                Header = "About",
                Width = 1000,
                Foreground = DarkGray.HexToBrush(),
                Content = aboutscroll,
                Background = White.HexToBrush()
            };

            var aboutGrid = new Grid();

            aboutGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            aboutGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            aboutGrid.Children.Add(aboutExpander);

            Grid.SetColumn(aboutExpander, 0);

            var aboutButton = ControlsFactory.CreateAddButton();
            aboutButton.Margin = new Thickness(24, 0, 0, 0);
            aboutButton.Visibility = Visibility.Collapsed;

            aboutGrid.Children.Add(aboutButton);

            Grid.SetColumn(aboutButton, 1);

            employeesAndJobsGrid.Children.Add(aboutGrid);

            Grid.SetRow(aboutGrid, 0);

            #endregion

            #region Employees

            UsersGrid = new UniformGrid()
            { 
                Margin = new Thickness(24),
                Columns = 3
            };

            var employeescroll = new ScrollViewer()
            {

                MaxHeight = 400,
                Content = UsersGrid,
            };

            var employeesExpander = new Expander()
            {
                Header = "Employees",
                Width = 1000,
                Foreground = DarkGray.HexToBrush(),
                Content = employeescroll,
                Background = White.HexToBrush()
            };

            var emplopyeesGrid = new Grid();

            emplopyeesGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            emplopyeesGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            emplopyeesGrid.Children.Add(employeesExpander);

            Grid.SetColumn(employeesExpander, 0);

            var addEmployeeButton = ControlsFactory.CreateAddButton();
            addEmployeeButton.Background = HookersGreen.HexToBrush();
            addEmployeeButton.Margin = new Thickness(24, 0, 0, 0);
            addEmployeeButton.Click += ShowEmployeeDialogComponent;

            emplopyeesGrid.Children.Add(addEmployeeButton);

            Grid.SetColumn(addEmployeeButton, 1);

            employeesAndJobsGrid.Children.Add(emplopyeesGrid);

            Grid.SetRow(emplopyeesGrid, 1);

            #endregion

            #region  Jobs

            var jobsButtons = new JobsContainerComponent(Company);

            var JobsScroll = new ScrollViewer()
            {
                MaxHeight = 1000,
                Content = jobsButtons,
            };

            var jobsExpander = new Expander()
            {
                Header = "Jobs",
                Width = 1000,
                Foreground = DarkGray.HexToBrush(),
                Content = JobsScroll,
                Background = White.HexToBrush()
            };

            var jobsGrid = new Grid();

            jobsGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            jobsGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            jobsGrid.Children.Add(jobsExpander);

            Grid.SetColumn(jobsExpander, 0);

            var addJobsButton = ControlsFactory.CreateAddButton();
            addJobsButton.Margin = new Thickness(24, 0, 0, 0);
            addJobsButton.Click += ShowAddJobDialogOnClick;

            jobsGrid.Children.Add(addJobsButton);

            Grid.SetColumn(addJobsButton, 1);

            employeesAndJobsGrid.Children.Add(jobsGrid);

            Grid.SetRow(jobsGrid, 2);

            #endregion

            #region  Departments

            //foreach (var company in Companies) { };

            DepartmentsGrid = new UniformGrid()
            {
                Margin = new Thickness(24),
                Columns = 2
            };

            var departmentScroll = new ScrollViewer()
            {
                MaxHeight = 400,
                Content = DepartmentsGrid,
            };

            var departmentExpander = new Expander()
            {
                Header = "Departments",
                Foreground = DarkGray.HexToBrush(),
                Width = 1000,
                Content = departmentScroll,
                Background = White.HexToBrush()
            };

            var departmentsGrid = new Grid();

            departmentsGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            departmentsGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            departmentsGrid.Children.Add(departmentExpander);

            Grid.SetColumn(departmentExpander, 0);

            var addDepartmentButton = ControlsFactory.CreateAddButton();
            addDepartmentButton.Background = DarkPink.HexToBrush();
            addDepartmentButton.Margin = new Thickness(24, 0, 0, 0);

            addDepartmentButton.Click += ShowAddDepartmentDialogOnClick;

            departmentsGrid.Children.Add(addDepartmentButton);

            Grid.SetColumn(addDepartmentButton, 1);

            employeesAndJobsGrid.Children.Add(departmentsGrid);

            Grid.SetRow(departmentsGrid, 3);

            var stackPanel = new StackPanel();

            stackPanel.Children.Add(employeesAndJobsGrid);

            InfoAboutTheCompanyGrid.Children.Add(stackPanel);

            Grid.SetRow(stackPanel, 1);

            #endregion

            #endregion

            #endregion

            #region About The Company

            var firstRowGrid = new UniformGrid()
            {
                Columns = 2,
                Margin = new Thickness(40, 12, 24, 0)
            };

            #region First Column Stack

            //Creates the afm textBlock
            var AFMData = new TitleAndTextComponent()
            {
                Title = "Afm",
                Text = Company.AFM,
            };

            firstRowGrid.Children.Add(AFMData);

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "Doy",
                Text = Company.DOY,
            };

            firstRowGrid.Children.Add(DOYData);


            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = Company.Country,
            };

            firstRowGrid.Children.Add(CountryData);


            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = Company.City,
            };

            firstRowGrid.Children.Add(CityData);

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = Company.Location,
            };

            firstRowGrid.Children.Add(AddressData);

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = Company.TelephoneNumber,
            };

            firstRowGrid.Children.Add(TelephoneData);

            //Creates the DateCreated textBlock
            var DateCreatedData = new TitleAndTextComponent()
            {
                Title = "Created on",
                Text = Company.DateCreated.ToShortDateString(),
            };

            firstRowGrid.Children.Add(DateCreatedData);

            InfoAboutTheCompanyGrid.Children.Add(firstRowGrid);

            Grid.SetRow(firstRowGrid, 0);

            #endregion

            #endregion

            CompanyGrid.Children.Add(InfoAboutTheCompanyGrid);
            Grid.SetColumn(InfoAboutTheCompanyGrid, 1);

            var CompanyBorder = new Border()
            {
                Margin = new Thickness(32),
                BorderThickness = new Thickness(12),
                BorderBrush = DarkBlue.HexToBrush(),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(24),
                Background = White.HexToBrush(),
                Effect = ControlsFactory.CreateShadow()
            };
            CompanyBorder.Child = CompanyGrid;

            Content = CompanyBorder;
        }

        #region Events

        /// <summary>
        /// On click shows the add department dialog
        /// </summary>
        private void ShowAddDepartmentDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new department dialog
            var AddNewDepartment = new NewDepartmentDialogComponent(User,Company, this);
            // Adds it to the page grid
            PageGrid.Children.Add(AddNewDepartment);

            // Sets the is open property to true
            AddNewDepartment.IsDialogOpen = true;
        }

        /// <summary>
        /// On click shows the add department dialog
        /// </summary>
        private void ShowAddJobDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new job dialog
            var AddNewJob = new NewJobDialogComponent(Company, this)
            {
                DepartmentsOption = DepartmentNames,
            };
            // Adds it to the page grid
            PageGrid.Children.Add(AddNewJob);

            // Sets the is open property to true
            AddNewJob.IsDialogOpen = true;
        }
        
        /// <summary>
        /// On click shows the add employee dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEmployeeDialogComponent(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            AddUser = new NewUserDialogComponent(Company, this, PageGrid)
            {
                JobPositionOptions = new List<string> { "Ax", "Koula", "Polu", "Kwlopaido", "o", "Kuriakos" },
                DepartmentOptions = DepartmentNames,
                EmptyDepartmentOptions = EmptyDepartmentNames,
                UserTypeOptions = new List<string> { "Evaluator", "Manager", "Employee" } 
            };
            // Adds it to the page grid
            PageGrid.Children.Add(AddUser);

            // Sets the is open property to true
            AddUser.IsDialogOpen = true;
        }

        #endregion

        #region Core

        /// <summary>
        /// Handles the change of the <see cref="Employees"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnEmployeesChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<UserDataModel>)e.NewValue;

            if (newValue == null)
            {
                
            }
            else
            {
                UsersGrid.Children.Clear();

                foreach (var employee in newValue)
                    UsersGrid.Children.Add(new UserButtonComponent(employee));
            }

            // Further handle the change
            OnEmployeesChanged(e);
        }

        private void OnDepartmentsChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<DepartmentDataModel>)e.NewValue;

            if (newValue == null)
            {

            }
            else
            {
                // Deletes all the grid's children 
                DepartmentsGrid.Children.Clear();
                // For each department
                foreach (var department in newValue)
                {
                    // Add to the grid a new department button representing the department
                    DepartmentsGrid.Children.Add(new DepartmentButtonComponent(department));
                    // Adds to the list the department's name
                    DepartmentNames.Add(department.DepartmentName);
                    if(department.Users != null)
                    {
                        // If there is no manager in a department...
                        if (department.Users.ToList().Any(x => x.Type == UserType.Manager) == false)
                            // Adds the department's name to the empty list
                            EmptyDepartmentNames.Add(department.DepartmentName);
                        // If all departments have a manager...
                        if (EmptyDepartmentNames.Count == 0)
                            // Add the message to the picker
                            EmptyDepartmentNames.Add("All have a manager");
                    }
                }
            }

            // Further handle the change
            OnEmployeesChanged(e);
        }

        #endregion

        #endregion
    }
}
