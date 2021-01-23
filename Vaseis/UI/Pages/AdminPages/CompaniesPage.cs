using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{

    //The companies page for the admin's side menu
    public class CompaniesPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The page's ScrollViewer
        /// </summary>
        protected ScrollViewer scrollViewer { get; private set; }

        /// <summary>
        /// The Page's stackpanel
        /// </summary>
        protected StackPanel companiesStackPanel { get; private set; }

        /// <summary>
        /// THe page's grid
        /// </summary>
        protected Grid pageGrid { get; private set; }

        #endregion

        #region Dependency Properties
        #endregion

        #region Constructors


        public CompaniesPage()
        {


            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //update sta companies (afou mporei na prose8ei)
            var companies = await Services.GetDataStorage.GetCompanies();

            foreach (var company in companies)
            {
                var companyComponent = new CompaniesComponent(company);

                companiesStackPanel.Children.Add(companyComponent);
            }

        }
        #endregion



        /// <summary>
        /// Creates and adds the required GUI elements for the administrator's companies page
        /// </summary>
        #region Private Methods

        private void CreateGUI()
        {
            pageGrid = new Grid();

            scrollViewer = new ScrollViewer();

            companiesStackPanel = new StackPanel();

            pageGrid.Children.Add(scrollViewer);

            var addCompany = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                FontSize = 18,
                FontWeight = FontWeights.Normal,
                Content = "Add Company",
                Margin = new Thickness(0, 24, 24, 12),
                Foreground = Styles.DarkGray.HexToBrush(),
                Background = Styles.White.HexToBrush(),
            };

            addCompany.Click += ShowCompanyDialogComponentOnClick;
            companiesStackPanel.Children.Add(addCompany);

            scrollViewer.Content = companiesStackPanel;

            Content = pageGrid;

        }

        /// <summary>
        /// On click shows the change password dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCompanyDialogComponentOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            var newCompany = new NewCompanyDialogComponent();
            // Adds it to the page grid

            //gia na mhn kollaei sto ena column to prwto 
            companiesStackPanel.Children.Add(newCompany);

            // Sets the is open property to true
            newCompany.IsDialogOpen = true;
        }


        #endregion

    }
}
