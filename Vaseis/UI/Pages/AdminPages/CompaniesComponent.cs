using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
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


        #region Constructors
        public CompaniesComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {

            CompanyGrid = new Grid()
            {
                Background = Company.CompanyColor.HexToBrush(),
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

            var about = new UserButtonsContainerComponent();

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

            // employeesAndJobsGrid.Children.Add(hmmExpander);

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

            var employeessButton = ControlsFactory.CreateAddButton();
            employeessButton.Margin = new Thickness(24, 0, 0, 0);
            employeessButton.Visibility = Visibility.Collapsed;

            aboutGrid.Children.Add(employeessButton);

            Grid.SetColumn(employeessButton, 1);

            employeesAndJobsGrid.Children.Add(aboutGrid);

            Grid.SetRow(aboutGrid, 0);


            #endregion

            #region Employees

            //foreach (var company in Companies) { };

            var employeehmmm = new UserButtonsContainerComponent();

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

           // employeesAndJobsGrid.Children.Add(hmmExpander);

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

            var aboutButton = ControlsFactory.CreateAddButton();
            aboutButton.Margin = new Thickness(24, 0, 0, 0);
            aboutButton.Click += ShowEmployeeDialogComponent;

            emplopyeesGrid.Children.Add(aboutButton);

            Grid.SetColumn(aboutButton, 1);

            employeesAndJobsGrid.Children.Add(emplopyeesGrid);

            Grid.SetRow(emplopyeesGrid, 1);
   
            #endregion

            #region  Jobs

            //foreach (var company in Companies) { };

            var jobsButtons = new UserButtonsContainerComponent();

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

            //   employeesAndJobsGrid.Children.Add(jobsExpander);

            //     Grid.SetRow(jobsExpander, 2);


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

            var departmentButtons = new UserButtonsContainerComponent();

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


            var CompanyButton = new Button()
            {
                Style = MaterialDesignStyles.RaisedButton,
                Height = double.NaN,
                Margin = new Thickness(24),
                Padding = new Thickness(8),
                BorderThickness = new Thickness(0),
                Content = CompanyGrid,
                Background = Company.CompanyColor.HexToBrush(),
            };


            ButtonAssist.SetCornerRadius(CompanyButton, new CornerRadius(8));


            Content = CompanyButton;

            #endregion
        }

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

