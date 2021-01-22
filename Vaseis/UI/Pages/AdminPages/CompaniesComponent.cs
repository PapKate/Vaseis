using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using static Vaseis.Styles;

namespace Vaseis
{
    //This is a class that creates the row components fo rthe adminidtrator's companies page
    public class CompaniesComponent : ContentControl
    {
        #region Proetcted Properties

        public CompanyDataModel Company { get; }


        public Grid CompanyGrid { get; private set; }

        #endregion

        #region Dependency Properties

        #region Employees

        /// <summary>
        /// The company's Employees
        /// </summary>
        public IEnumerable<string> Employees
        {
            get { return (IEnumerable<string>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Employees"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeesProperty = DependencyProperty.Register(nameof(Employees), typeof(IEnumerable<string>), typeof(CompaniesComponent));

        #endregion

        #region Department

        /// <summary>
        /// The company's departments
        /// </summary>
        public IEnumerable<string> Departments
        {
            get { return (IEnumerable<string>)GetValue(DepartmentsProperty); }
            set { SetValue(DepartmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Departments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentsProperty = DependencyProperty.Register(nameof(Departments), typeof(IEnumerable<string>), typeof(CompaniesComponent));


        #endregion

        #region Jobs
        /// <summary>
        /// The company's jobs
        /// </summary>
        public IEnumerable<string> JobTitles
        {
            get { return (IEnumerable<string>)GetValue(JobTitlesProperty); }
            set { SetValue(JobTitlesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="JobTitles"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobTitlesProperty = DependencyProperty.Register(nameof(JobTitles), typeof(IEnumerable<string>), typeof(CompaniesComponent));


        #endregion

        #endregion

        #region Constructors
        public CompaniesComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Public Methods

        public void Update()
        {



        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {

            CompanyGrid = new Grid()
            {
                Background = GhostWhite.HexToBrush(),
                VerticalAlignment = VerticalAlignment.Stretch,             
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
                Text = Company.Name
            };

            CompanyGrid.Children.Add(CompanyPicAndLogo);
            Grid.SetColumn(CompanyPicAndLogo, 0);

            #endregion

            Grid InfoAboutTheCompanyGrid = new Grid();

            InfoAboutTheCompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            #region second row 

            InfoAboutTheCompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            Grid employeesAndJobsGrid = new Grid();


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

            var aboutscroll = new ScrollViewer()
            {

                MaxHeight = 1000,
                Content = Company.About,
            };

            var aboutExpander = new Expander()
            {
                Header = "About",
                Width = 1000,
                Foreground = DarkGray.HexToBrush(),
                Content = aboutscroll,
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

            var employeehmmm = new UserButtonsContainerComponent(Company);

            var employeescroll = new ScrollViewer()
            {

                MaxHeight = 1000,
                Content = employeehmmm,
            };

            var employeesExpander = new Expander()
            {
                Header = "Employees",
                Width = 1000,
                Foreground = DarkGray.HexToBrush(),
                Content = employeescroll,
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

            var employeeButton = ControlsFactory.CreateAddButton();
            employeeButton.Margin = new Thickness(24, 0, 0, 0);
            employeeButton.Click += ShowEmployeeDialogComponent;

            emplopyeesGrid.Children.Add(employeeButton);

            Grid.SetColumn(employeeButton, 1);

            employeesAndJobsGrid.Children.Add(emplopyeesGrid);

            Grid.SetRow(emplopyeesGrid, 1);

            #endregion

            #region  Jobs

            //foreach (var company in Companies) { };

            var jobsButtons = new UserButtonsContainerComponent(Company);

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

            var departmentButtons = new UserButtonsContainerComponent(Company);

            var departmentScroll = new ScrollViewer()
            {

                MaxHeight = 1000,
                Content = departmentButtons,
            };

            var departmentExpander = new Expander()
            {
                Header = "Departments",
                Foreground = DarkGray.HexToBrush(),
                Width = 1000,
                Content = departmentScroll,
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
                Text = Company.DateCreated.ToString(),
            };

            firstRowGrid.Children.Add(DateCreatedData);

            InfoAboutTheCompanyGrid.Children.Add(firstRowGrid);

            Grid.SetRow(firstRowGrid, 0);


            #endregion


            CompanyGrid.Children.Add(InfoAboutTheCompanyGrid);
            Grid.SetColumn(InfoAboutTheCompanyGrid, 1);


            var CompanyButton = new Border()
            {
                //Style = MaterialDesignStyles.RaisedButton,
                Height = double.NaN,
                Margin = new Thickness(24),
                Padding = new Thickness(8),
                Background = DarkBlue.HexToBrush(),
                BorderThickness = new Thickness(0),
               //  Content = CompanyGrid,
                CornerRadius = new CornerRadius(8)
            };

            CompanyButton.Child = CompanyGrid;

           // ButtonAssist.SetCornerRadius(CompanyButton, new CornerRadius(8));

            Content = CompanyButton;
        }

        #endregion

        /// <summary>
        /// On click shows the add department dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddDepartmentDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new department dialog
            var AddNewDepartment = new NewDepartmentDialogComponent(Company);
            // Adds it to the page grid
            CompanyGrid.Children.Add(AddNewDepartment);

            // Sets the is open property to true
            AddNewDepartment.IsDialogOpen = true;
        }


        ///// <summary>
        /// On click shows the add department dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddJobDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new department dialog
            var AddNewJob = new NewJobDialogComponent(Company);
            // Adds it to the page grid
            CompanyGrid.Children.Add(AddNewJob);

            // Sets the is open property to true
            AddNewJob.IsDialogOpen = true;
        }

        ///// <summary>
        /// On click shows the add employee dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEmployeeDialogComponent(object sender, RoutedEventArgs e)
        {
            // Creates a new department dialog
            var AdduSER = new NewUserInputDialogComponent(Company);
            // Adds it to the page grid
            CompanyGrid.Children.Add(AdduSER);

            // Sets the is open property to true
            AdduSER.IsDialogOpen = true;
        }

    }
}
