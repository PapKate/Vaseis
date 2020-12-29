
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                ImagePath = @"pack://application:,,,/UI/Images/logo.png"
            };

            // Adds to the window grid the header
            windowGrid.Children.Add(header);

            // Defines the row the header is set to in the parent grid
            Grid.SetRow(header, 0);

            // A grid for the app that contains all the GUI elements except for the header
            var appGrid = new Grid()
            {
                // Sets the background to ghost white
                Background = StyleHelpers.HexToBrush(Styles.GhostWhite)
            };

            // Adds the app's grid to the window's grid
            windowGrid.Children.Add(appGrid);

            // Defines the row the app grind is set to in the parent grid
            Grid.SetRow(appGrid, 1);

            // Set's a column with width 
            // kTODO: Set column's width to auto
            appGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {

                //Width = new GridLength(1, GridUnitType.Auto)
                Width = new GridLength(320, GridUnitType.Pixel)
            });

            // Set's a column with width the remaining width left in the grid
            appGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)

            });

            // kTODO: Initialize the side menu component
            var sideMenuGrid = new Grid()
            {
                Background = StyleHelpers.HexToBrush(Styles.DarkGray),
            };

            // Adds to the app's grid the side menu
            appGrid.Children.Add(sideMenuGrid);
            // Defines the column the side menu's grid is set to in the parent grid
            Grid.SetColumn(sideMenuGrid, 0);

            var stackPanel2 = new StackPanel()
            {
                Margin = new Thickness(24)
            };

            var editButton = ControlsFactory.CreateEditButton();

            stackPanel2.Children.Add(editButton);

            var closeButton2 = ControlsFactory.CreateCloseButton();

            stackPanel2.Children.Add(closeButton2);

            appGrid.Children.Add(stackPanel2);
            Grid.SetColumn(stackPanel2, 1);
           
            // Sets the content as the window's grid
            Content = windowGrid;
        }

        #endregion

    }
}
