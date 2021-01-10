
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

        protected TabControl appTabControl { get; private set; }

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
                // Sets the background to white
                Background = White.HexToBrush()
            };

            // Adds the app's grid to the window's grid
            windowGrid.Children.Add(appGrid);

            // Defines the row the app grind is set to in the parent grid
            Grid.SetRow(appGrid, 1);

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

            var pagesGrid = new Grid();
            appGrid.Children.Add(pagesGrid);
            Grid.SetColumn(pagesGrid, 1);

            appTabControl = new TabControl()
            {
                Background = GhostWhite.HexToBrush(),
                BorderThickness = new Thickness(0, 8, 0, 0),
                BorderBrush = DarkPink.HexToBrush()
            };
            pagesGrid.Children.Add(appTabControl);

            var profilePage = new TabItemComponent()
            {
                Text = "Profile",
                Icon = PackIconKind.AccountCircle,
                Content = new ProfilePage()
            };

            appTabControl.Items.Add(profilePage);

            var evaluatorMyEvaluationsPage = new TabItemComponent()
            {
                Text = "My evaluations",
                Icon = PackIconKind.ClipboardEdit,
                Content = new EvaluatorMyEvaluationsPage()
            };

            appTabControl.Items.Add(evaluatorMyEvaluationsPage);

            var managerEvaluationResults = new TabItemComponent()
            {
                Text = "EvaluationResults",
                Icon = PackIconKind.ClipboardList,
                Content = new ManagerEvaluationResultsPage()
            };

            appTabControl.Items.Add(managerEvaluationResults);

            var usersPage = new TabItemComponent()
            {
                Text = "Users",
                Icon = PackIconKind.AccountMultipleAdd,
                Content = new UsersPage()
            };

            appTabControl.Items.Add(usersPage);

            var empMyEvPage = new TabItemComponent()
            {
                Text = "My evaluations",
                Icon = PackIconKind.ClipboardAccount,
                Content = new EmplyoeeMyEvaluationsPage()
            };

            appTabControl.Items.Add(empMyEvPage);

            var reportsPage = new TabItemComponent()
            {
                Text = "Reports",
                Icon = PackIconKind.ClipboardFlow,
                Content = new ManagerReportsPage()
            };

            appTabControl.Items.Add(reportsPage);

            var jobPositionDialogue = new TabItemComponent()
            {
                Text = "Job positions",
                Icon = PackIconKind.FolderEdit,
                Content = new EvaluatorJobPosition()
            };

            appTabControl.Items.Add(jobPositionDialogue);

            var sideMenuComponent = new ManagerSideMenuComponent(appTabControl);

            // Adds to the app's grid the side menu
            appGrid.Children.Add(sideMenuComponent);
            // Defines the column the side menu's grid is set to in the parent grid
            Grid.SetColumn(sideMenuComponent, 0);

            // Sets the content as the window's grid
            Content = windowGrid;
        }

        #endregion

    }
}
