using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    class CompaniesPage : ContentControl
    {
        private ScrollViewer scrollViewer;

        private StackPanel testStackPanel;

        #region Proetcted Properties

        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors
        public CompaniesPage()
        {
            CreateGUI();
        }

        #endregion


        /// <summary>
        /// Creates and adds the required GUI elements for the administrator's companies page
        /// </summary>
        #region Private Methods

        private void CreateGUI()
        {
            scrollViewer = new ScrollViewer();
  
            testStackPanel = new StackPanel();

            //foreach (var company in Companies) { };

            CompanyDataModel comp1 = new CompanyDataModel()
            {
                Name = "SGFSG",
                CompanyColor = "321456",
                DOY = "DOY AMALIADAS",
                AFM = "AFMK",
                About = "megalo about hfwsfgowshuofs",
                TelephoneNumber = "2229037704",
                City = "Patras",
                Country = "gamww",
                StreetNumber = "38",
                StreetName = "Koutroulh",
                CompanyPicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmloPgpVspV4e3ZZYC6PoC59_3mbxX0RdZsg&usqp=CAU",
            };


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
            testStackPanel.Children.Add(addCompany);


            var eh = new CompaniesComponent(comp1) ;
            testStackPanel.Children.Add(eh);


            var ehh = new CompaniesComponent(comp1);
            testStackPanel.Children.Add(ehh);


            var ehhh = new CompaniesComponent(comp1);
            testStackPanel.Children.Add(ehhh);


            var ehhhh = new CompaniesComponent(comp1);
            testStackPanel.Children.Add(ehhhh);

            scrollViewer.Content = testStackPanel;

            Content = scrollViewer;

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
            testStackPanel.Children.Add(newCompany);

            // Sets the is open property to true
            newCompany.IsDialogOpen = true;
        }


        #endregion

    }
}
