using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// Represents the "users" page of the administrator
    /// </summary>
    public class UsersPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The create user dialog
        /// </summary>
        protected NewUserInputDialogComponent CreateUserDialog { get; private set; }

        protected NewCompanyDialogComponent CreateCompanyDialog { get; private set; }

        /// <summary>
        /// The error dialog
        /// </summary>
        protected ErrorDialogComponent ErrorDialog { get; private set; }

        /// <summary>
        /// The add/open dialog button
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The page's grid - container
        /// </summary>
        protected Grid PageGrid { get; private set; }

        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors

        public UsersPage()
        {
            CreateGUI();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // The page's grid
            PageGrid = new Grid()
            {

            };

            var userButton = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "Test",
            };

            userButton.Click += ShowNewCompanyDialog;
            PageGrid.Children.Add(userButton);

            // Creates the add new user button
            AddButton = ControlsFactory.CreateAddButton(DarkBlue);
            // On click opens the new user dialog
            AddButton.Click += ShowDialogOnClick;
            // Adds the button to the page's grid
            PageGrid.Children.Add(AddButton);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        /// <summary>
        /// On click closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            CreateUserDialog = new NewUserInputDialogComponent();
            // Adds it to the page grid
            PageGrid.Children.Add(CreateUserDialog);

            // Sets the is open property to true
            CreateUserDialog.DialogHost.IsOpen = true;
        }

        /// <summary>
        /// On click closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewCompanyDialog(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            CreateCompanyDialog = new NewCompanyDialogComponent();
            // Adds it to the page grid
            PageGrid.Children.Add(CreateCompanyDialog);

            // Sets the is open property to true
            CreateCompanyDialog.DialogHost.IsOpen = true;
        }


        /// <summary>
        /// On click closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowErrorDialog(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            ErrorDialog = new ErrorDialogComponent()
            {
                ErrorMessage = "Error! Incorrect username or password. Please try again."
            };
            // Adds it to the page grid
            PageGrid.Children.Add(ErrorDialog);

            // Sets the is open property to true
            ErrorDialog.DialogHost.IsOpen = true;
        }

        #endregion

    }
}
