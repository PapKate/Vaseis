
using MaterialDesignThemes.Wpf;

using Microsoft.EntityFrameworkCore;

using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            CreateGUI();
        }

        #endregion

        protected TabControl appTabControl { get; private set; }

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private async void CreateGUI()
        {
            // The grid for the entire app's window
            var windowGrid = new Grid();

            // Set's a row with height auto
            windowGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            // Set's a row with height the remaining height left in the grid
            windowGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            // The header component
            var header = new HeaderComponent(this)
            {
                Title = "username",
                ImagePath = @"pack://application:,,,/UI/Images/logo.png",
            };

            // Adds to the window grid the header
            windowGrid.Children.Add(header);

            // Defines the row the header is set to in the parent grid
            Grid.SetRow(header, 0);

            // A grid for the app that contains all the GUI elements except for the header
            var appGrid = new Grid()
            {
                // Sets the background to white
                Background = White.HexToBrush()
            };

            // Adds the app's grid to the window's grid
            windowGrid.Children.Add(appGrid);

            // Defines the row the app grind is set to in the parent grid
            Grid.SetRow(appGrid, 1);

            
            //var evaluatorMyEvaluationsPage = new TabItemComponent()
            //{
            //    Text = "My evaluations",
            //    Icon = PackIconKind.ClipboardEdit,
            //    Content = new EvaluatorMyEvaluationsPage()
            //};

            //appTabControl.Items.Add(evaluatorMyEvaluationsPage);

            //var empMyEvPage = new TabItemComponent()
            //{
            //    Text = "My evaluations",
            //    Icon = PackIconKind.ClipboardAccount,
            //    Content = new EmplyoeeMyEvaluationsPage()
            //};

            //appTabControl.Items.Add(empMyEvPage);

            //var companyPage = new TabItemComponent()
            //{
            //    Text = "Company",
            //    Icon = PackIconKind.Domain,
            //    Content = new CompanyPage()
            //};

            //appTabControl.Items.Add(companyPage);

            //var companiesPage = new TabItemComponent()
            //{
            //    Text = "Companies",
            //    Icon = PackIconKind.Domain,
            //    Content = new CompaniesPage()
            //};

            //appTabControl.Items.Add(companiesPage);

            //var UserComponent = new TabItemComponent()
            //{
            //    Text = "UserCompoent",
            //    Icon = PackIconKind.ClipboardAccount,
            //    Content = new AdminsUsersPage()
            //};

            //appTabControl.Items.Add(UserComponent);


            //var reports = new TabItemComponent()
            //{
            //    Text = "Reports",
            //    Icon = PackIconKind.FileChart,
            //    Content = new ManagerReportsPage()
            //};
            //appTabControl.Items.Add(reports);

            //var logInPage = new LoginPage();

            //logInPage.UserConnected += new EventHandler<UserDataModel>((sender, e) =>
            //{
            //    if (e.Type == UserType.Administrator)
            //    {

            //    }
            //    else if (e.Type == UserType.Evaluator)
            //    {
            //        var sideMenuComponent = new EvaluatorSideMenuComponent(appTabControl, e);

            //        // Adds to the app's grid the side menu
            //        appGrid.Children.Add(sideMenuComponent);
            //    }
            //    else if (e.Type == UserType.Manager)
            //    {
            //        var sideMenuComponent = new ManagerSideMenuComponent(appTabControl, e);

            //        // Adds to the app's grid the side menu
            //        appGrid.Children.Add(sideMenuComponent);
            //    }

            //    windowGrid.Children.Remove(logInPage);
            //});

            //windowGrid.Children.Add(logInPage);

            //Grid.SetRow(logInPage, 1);

            var user = await Services.GetDbContext.Users.FirstOrDefaultAsync(x => x.Type == UserType.Employee);

            var view = new EmployeeView(user);

            appGrid.Children.Add(view);

            // Sets the content as the window's grid
            Content = windowGrid;
        }

        #endregion

    }
}
