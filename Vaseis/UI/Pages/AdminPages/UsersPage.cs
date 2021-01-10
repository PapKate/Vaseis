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

        /// <summary>
        /// The create new company dialog
        /// </summary>
        protected NewCompanyDialogComponent CreateCompanyDialog { get; private set; }

        /// <summary>
        /// The error dialog
        /// </summary>
        protected MessageDialogComponent ErrorDialog { get; private set; }

        /// <summary>
        /// The finalized dialog
        /// </summary>
        protected MessageDialogComponent FinalizedDialog { get; private set; }

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
            var testStackPanel = new StackPanel() { VerticalAlignment = VerticalAlignment.Center };
            PageGrid.Children.Add(testStackPanel);

            var userButton = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "User",
            };

            //userButton.Click += ShowUserDialogOnClick;
            testStackPanel.Children.Add(userButton);

            var companyButton = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "Company",
                Margin = new Thickness(60)

            };

            //companyButton.Click += ShowNewCompanyDialog;
            testStackPanel.Children.Add(companyButton);

            var epevaluation = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "Evaluation",
            };

            //epevaluation.Click += ShowEvaluationDialog;
            testStackPanel.Children.Add(epevaluation);

            var report = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "Report",
                Margin = new Thickness(60)
            };

            //report.Click += ShowReportDialog;
            testStackPanel.Children.Add(report);

            var fianlButton = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "Finalized",
            };

            //fianlButton.Click += ShowFinalizedDialog;
            testStackPanel.Children.Add(fianlButton);

            var error = new Button()
            {
                Width = 240,
                Height = 40,
                Content = "Error",
                Margin = new Thickness(60)
            };

            //error.Click += ShowErrorDialog;
            testStackPanel.Children.Add(error);

            // Creates the add new user button
            AddButton = ControlsFactory.CreateAddButton(DarkBlue);
            // On click opens the new user dialog
            //AddButton.Click += ShowUserDialogOnClick;
            // Adds the button to the page's grid
            PageGrid.Children.Add(AddButton);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        ///// <summary>
        ///// On click shows the new user dialog
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowUserDialogOnClick(object sender, RoutedEventArgs e)
        //{
        //    // Creates a new user dialog
        //    CreateUserDialog = new NewUserInputDialogComponent();
        //    // Adds it to the page grid
        //    PageGrid.Children.Add(CreateUserDialog);

        //    // Sets the is open property to true
        //    CreateUserDialog.DialogHost.IsOpen = true;
        //}

        ///// <summary>
        ///// On click closes the dialog
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowNewCompanyDialog(object sender, RoutedEventArgs e)
        //{
        //    // Creates a new user dialog
        //    CreateCompanyDialog = new NewCompanyDialogComponent();
        //    // Adds it to the page grid
        //    PageGrid.Children.Add(CreateCompanyDialog);

        //    // Sets the is open property to true
        //    CreateCompanyDialog.DialogHost.IsOpen = true;
        //}

        ///// <summary>
        ///// On click shows the error dialog
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowErrorDialog(object sender, RoutedEventArgs e)
        //{
        //    // Creates a new user dialog
        //    ErrorDialog = new MessageDialogComponent()
        //    {
        //        Message = "Error! Incorrect username or password. Please try again.",
        //        BrushColor = Red.HexToBrush(),
        //        Title = "Error"
        //    };
        //    // Adds it to the page grid
        //    PageGrid.Children.Add(ErrorDialog);

        //    // Sets the is open property to true
        //    ErrorDialog.DialogHost.IsOpen = true;
        //}

        ///// <summary>
        ///// On click shows the finalized and sent dialog the dialog
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowFinalizedDialog(object sender, RoutedEventArgs e)
        //{
        //    // Creates a new user dialog
        //    FinalizedDialog = new MessageDialogComponent()
        //    {
        //        Message = "Your evaluation has been finalized and sent to a manager.",
        //        BrushColor = HookersGreen.HexToBrush(),
        //        Title = "Success"
        //    };
        //    // Adds it to the page grid
        //    PageGrid.Children.Add(FinalizedDialog);

        //    // Sets the is open property to true
        //    FinalizedDialog.DialogHost.IsOpen = true;
        //}

        ///// <summary>
        ///// On click shows the finalized and sent dialog the dialog
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowEvaluationDialog(object sender, RoutedEventArgs e)
        //{
        //    // Creates a new user dialog
        //    var evaluationDialog = new EvaluationDialogComponent();
        //    // Adds it to the page grid
        //    PageGrid.Children.Add(evaluationDialog);

        //    // Sets the is open property to true
        //    evaluationDialog.DialogHost.IsOpen = true;
        //}

        ///// <summary>
        ///// On click shows the finalized and sent dialog the dialog
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ShowReportDialog(object sender, RoutedEventArgs e)
        //{
        //    // Creates a new user dialog
        //    var reportDialog = new ReportDialog();
        //    // Adds it to the page grid
        //    PageGrid.Children.Add(reportDialog);

        //    // Sets the is open property to true
        //    reportDialog.DialogHost.IsOpen = true;
        //}

        #endregion

    }
}
