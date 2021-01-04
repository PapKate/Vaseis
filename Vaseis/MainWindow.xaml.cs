using MaterialDesignThemes.Wpf;

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

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
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
                // Sets the background to ghost white
                Background = GhostWhite.HexToBrush()
            };

            // Adds the app's grid to the window's grid
            windowGrid.Children.Add(appGrid);

            // Defines the row the app grind is set to in the parent grid
            Grid.SetRow(appGrid, 1);


            // Set's a column with width 
            // kTODO: Set column's width to auto
            appGrid.ColumnDefinitions.Add(new ColumnDefinition()
           {

            // Set's a column with width 
            appGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {

                Width = new GridLength(280, GridUnitType.Pixel)
            });

            // Set's a column with width the remaining width left in the grid
            appGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)

            });

            var sideMenuComponent = new SideMenuComponent();

            // Adds to the app's grid the side menu
            appGrid.Children.Add(sideMenuComponent);
            // Defines the column the side menu's grid is set to in the parent grid
            Grid.SetColumn(sideMenuComponent, 0);


            //var employeesPage = new EmployeesPage();



            var input = new TextInputComponent();
            var test = new AddDialogComponent();
            appGrid.Children.Add(test);
            Grid.SetColumn(test, 1);

            //appGrid.Children.Add(employeesPage);

            //Grid.SetColumn(employeesPage, 1);

            var myEvaluationsPage = new MyEvaluationsPage();

            //appGrid.Children.Add(myEvaluationsPage);

            //Grid.SetColumn(myEvaluationsPage, 1);

            var users = new UsersPage();

            appGrid.Children.Add(users);

            Grid.SetColumn(users, 1);



            //appGrid.Children.Add(employeesPage);

            ////Grid.SetColumn(employeesPage, 1);

            //// Sets the content as the window's grid
            //Content = windowGrid;

            //Giatiiiiiiiiiiiiiiiiiiii den trexei?

            var evaluationPage = new EvaluationResults();

            appGrid.Children.Add(evaluationPage);
            Grid.SetColumn(evaluationPage, 1);

            Content = windowGrid;

            #endregion

        }
    }
}
