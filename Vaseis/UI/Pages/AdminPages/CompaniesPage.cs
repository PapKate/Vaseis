using MaterialDesignThemes.Wpf;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The companies page for the administrator's side menu
    /// </summary>
    public class CompaniesPage : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// the connected admin
        /// </summary>
        public UserDataModel User { get; private set; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The page's ScrollViewer
        /// </summary>
        protected ScrollViewer ScrollViewer { get; private set; }

        /// <summary>
        /// The Page's stack panel
        /// </summary>
        protected StackPanel CompaniesStackPanel { get; private set; }

        /// <summary>
        /// THe page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The extra grid for error dialogs
        /// </summary>
        protected Grid DialogHelperGrid { get; private set; }

        /// <summary>
        /// The connected Admin
        /// </summary>
        public UserDataModel User { get; protected set; }

        #endregion

        #region Dependency Properties

        #region New card

        /// <summary>
        /// The new card bool
        /// </summary>
        public bool NewCard
        {
            get { return (bool)GetValue(NewCardProperty); }
            set { SetValue(NewCardProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NewCard"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NewCardProperty = DependencyProperty.Register(nameof(NewCard), typeof(bool), typeof(CompaniesPage), new PropertyMetadata(OnNewCardChanged));

        /// <summary>
        /// Handles the change of the <see cref="NewCard"/> property
        /// </summary>
        private static void OnNewCardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as CompaniesPage;

            sender.OnNewCardChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompaniesPage(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Gets all the companies
            var companies = await Services.GetDataStorage.GetCompaniesWithDataAsync();
            // For each company
            foreach (var company in companies)
            {
                // Creates a card component with...
                var companyCard = new CompanyCardComponent(User,company, PageGrid);
                // Adds the card to the stack panel
                CompaniesStackPanel.Children.Add(companyCard);
            }
        }

        /// <summary>
        /// Handles the change of the <see cref="NewCard"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnNewCardChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            PageGrid = new Grid();
            DialogHelperGrid = new Grid();
            DialogHelperGrid.Children.Add(PageGrid);
            ScrollViewer = new ScrollViewer();

            CompaniesStackPanel = new StackPanel();

            PageGrid.Children.Add(ScrollViewer);

            var addCompanyButton = StyleHelpers.CreateDataButton(DarkBlue, "Add company");
            addCompanyButton.HorizontalAlignment = HorizontalAlignment.Right;
            addCompanyButton.Click += ShowCompanyDialogComponentOnClick;
            CompaniesStackPanel.Children.Add(addCompanyButton);

            ScrollViewer.Content = CompaniesStackPanel;

            Content = DialogHelperGrid;
        }

        /// <summary>
        /// On click shows the new company dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCompanyDialogComponentOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            var newCompanyDialog = new NewCompanyDialogComponent(User)
            {
                CreateCommand = new RelayCommand(() =>
                {
                    NewCard = true;

                })
            };
            // Adds it to the page grid
            PageGrid.Children.Add(newCompanyDialog);

            // Sets the is open property to true
            newCompanyDialog.IsDialogOpen = true;
        }

        /// <summary>
        /// Handles the change of the <see cref="NewCard"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private async void OnNewCardChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the new card is true...
            if (newValue == true)
            {
                // For the new company to be created first
                await Task.Delay(200);
                // Gets all the companies
                var companies = await Services.GetDataStorage.GetCompaniesWithDataAsync();
                // Gets the last created
                var latestCompany = companies[companies.Count() - 1];
                // Creates a card component with...
                var companyCard = new CompanyCardComponent(User, latestCompany, PageGrid);
                // Adds the card to the stack panel
                CompaniesStackPanel.Children.Add(companyCard);
            }
        }

        #endregion

    }
}
