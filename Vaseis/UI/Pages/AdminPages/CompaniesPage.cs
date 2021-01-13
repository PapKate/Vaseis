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
            var scrollViewer = new ScrollViewer();
  
            var testStackPanel = new StackPanel();

            //foreach (var company in Companies) { };

            var eh = new CompaniesComponent()
            {
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSY3utSbC6mOgwUqi05dtGp-btsnCG4lbkjFQ&usqp=CAU",
                BackgroundColor = "#F5D547",
                Logotype = "Coca Cola Light",
                About = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by The Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton and was bought out by businessman Asa Griggs Candler, whose marketing tactics led Coca-Cola to its dominance of the world soft-drink market throughout the 20th century.[1] The drink's name refers to two of its original ingredients: coca leaves, and kola nuts (a source of caffeine). The current formula of Coca-Cola remains a trade secret; however, a variety of reported recipes and experimental recreations have been published.",
                Afm = "6149633580325",
                Doy = "ΔΟΥ ΑΜΑΛΙΑΔΑΣ",
                Countryy = "Greece",
                CITY = "Amaliada",
                Addresss = "gamw ta info sas",
                Tele = "2229037751",
                DateOfCreation = "121854"
            };
            testStackPanel.Children.Add(eh);


            var ehh = new CompaniesComponent()
            {
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaTNkUnPkAKLDJt6bdUAFheFGj-5VlT-wuLQ&usqp=CAU",
                BackgroundColor = "#8EB8E5",
                Logotype = "Coca Cola Light",
                About = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by The Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton and was bought out by businessman Asa Griggs Candler, whose marketing tactics led Coca-Cola to its dominance of the world soft-drink market throughout the 20th century.[1] The drink's name refers to two of its original ingredients: coca leaves, and kola nuts (a source of caffeine). The current formula of Coca-Cola remains a trade secret; however, a variety of reported recipes and experimental recreations have been published.",
                Afm = "6149633580325",
                Doy = "ΔΟΥ ΑΜΑΛΙΑΔΑΣ",
                Countryy = "Greece",
                CITY = "Amaliada",
                Addresss = "gamw ta info sas",
                Tele = "2229037751",
                DateOfCreation = "121854"
            };
            testStackPanel.Children.Add(ehh);


            var ehhh = new CompaniesComponent()
            {
                Image = "https://www.upatras.gr/sites/www.upatras.gr/files/posters/01f1a05053c6242fcfa23075e5b963c1_xl.jpg",
                BackgroundColor = "#028090",
                Logotype = "Coca Cola Light",
                About = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by The Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton and was bought out by businessman Asa Griggs Candler, whose marketing tactics led Coca-Cola to its dominance of the world soft-drink market throughout the 20th century.[1] The drink's name refers to two of its original ingredients: coca leaves, and kola nuts (a source of caffeine). The current formula of Coca-Cola remains a trade secret; however, a variety of reported recipes and experimental recreations have been published.",
                Afm = "6149633580325",
                Doy = "ΔΟΥ ΑΜΑΛΙΑΔΑΣ",
                Countryy = "Greece",
                CITY = "Amaliada",
                Addresss = "gamw ta info sas",
                Tele = "2229037751",
                DateOfCreation = "121854"
            };
            testStackPanel.Children.Add(ehhh);


            var ehhhh = new CompaniesComponent()
            {
                Image = "https://www.google.gr/images/branding/googlelogo/2x/googlelogo_color_160x56dp.png",
                BackgroundColor = "#9F1747",
                Logotype = "Coca Cola Light",
                About = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by The Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton and was bought out by businessman Asa Griggs Candler, whose marketing tactics led Coca-Cola to its dominance of the world soft-drink market throughout the 20th century.[1] The drink's name refers to two of its original ingredients: coca leaves, and kola nuts (a source of caffeine). The current formula of Coca-Cola remains a trade secret; however, a variety of reported recipes and experimental recreations have been published.",
                Afm = "6149633580325",
                Doy = "ΔΟΥ ΑΜΑΛΙΑΔΑΣ",
                Countryy = "Greece",
                CITY = "Amaliada",
                Addresss = "gamw ta info sas",
                Tele = "2229037751",
                DateOfCreation = "121854"
            };
            testStackPanel.Children.Add(ehhhh);

            scrollViewer.Content = testStackPanel;

            Content = scrollViewer;

        }

        #endregion

    }
}
