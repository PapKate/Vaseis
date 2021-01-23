
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
        #region Private Properties

        /// <summary>
        /// The header
        /// </summary>
        private HeaderComponent Header { get; set; }

        /// <summary>
        /// The view
        /// </summary>
        private BaseView View { get; set; }

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            CreateGUI();
        }

        #endregion

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
            Header = new HeaderComponent(this)
            {
                Title = "",
                ImagePath = @"pack://application:,,,/UI/Images/vaseis.png",
            };

            // Adds to the window grid the header
            windowGrid.Children.Add(Header);

            // Defines the row the header is set to in the parent grid
            Grid.SetRow(Header, 0);

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

            var logInPage = new LoginPage();

            logInPage.UserConnected += new EventHandler<UserDataModel>((sender, e) =>
            {
                // Sets the header's image as the user's profile picture
                Header.ImagePath = e.ProfilePicture;
                // Sets the header's title as the user's username
                Header.Title = e.Username;
                // If the user is an administrator...
                if (e.Type == UserType.Administrator)
                {
                    // Creates the administrator's view
                    View = new AdminView(e);
                }
                // If the user is an evaluator...
                else if (e.Type == UserType.Evaluator)
                {
                    // Creates the evaluator's view
                    View = new EvaluatorView(e);
                }
                // If the user is a manager...
                else if (e.Type == UserType.Manager)
                {
                    // Creates the manager's view
                    View = new ManagerView(e);
                }
                else
                {
                    // By default creates the employee's view
                    View = new EmployeeView(e);
                }
                appGrid.Children.Add(View);

                windowGrid.Children.Remove(logInPage);
            });

            windowGrid.Children.Add(logInPage);

            Grid.SetRow(logInPage, 1);

            //var user = await Services.GetDbContext.Users.Include(x => x.JobPosition).ThenInclude(y => y.Job)
            //                                           .Include(x => x.Department).ThenInclude(y => y.Company)
            //                                           .Include(x => x.AcquiredDegrees)
            //                                           .Include(x => x.Awards)
            //                                           .Include(x => x.Certificates)
            //                                           .Include(x => x.Languages)
            //                                           .Include(x => x.RecommendationPapers)
            //                                           .FirstOrDefaultAsync(x => x.Type == UserType.Employee && x.Id == 22);

            //var view = new EmployeeView(user);

            //appGrid.Children.Add(view);

            // Sets the content as the window's grid
            Content = windowGrid;
        }

        #endregion

    }
}
