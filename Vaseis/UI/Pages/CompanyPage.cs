using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using static Vaseis.Styles;

namespace Vaseis
{
    class CompanyPage : ContentControl
    {
        #region Protected Properties


        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The stack panel for the company data
        /// </summary>
        protected StackPanel CompanyInfoStackPanel { get; private set; }

        /// <summary>
        /// The image and logo of the company
        /// </summary>
        protected ImageAndNameComponent ImageAndLogo { get; private set; }

        /// <summary>
        /// The separator bar
        /// </summary>
        protected Border Bar { get; private set; }

        /// <summary>
        /// The "About thw company"
        /// </summary>
        protected BioComponent AboutTile { get; private set; }


        #endregion

        #region Constructors

        public CompanyPage()
        {
            CreateGUI();
        }

        #endregion

        #region Dependency Properties

        #region Image


        /// <summary>
        /// The path of the image

        #endregion

        #endregion

        #region Protected Methods

        #endregion


        #region private Methods

        private void CreateGUI()
        {

            #region Page Grid

            PageGrid = new Grid();

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            { 
            Width = new System.Windows.GridLength(1, GridUnitType.Auto)
            });

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new System.Windows.GridLength(1, GridUnitType.Auto)
            });

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new System.Windows.GridLength(1, GridUnitType.Star)
            });
            #endregion


            //The column that contains some details and the image & logo of the com pany (left)
             CompanyInfoStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(32),
            };

            //The Companby's image and logotype
             var Image = new ImageAndNameComponent()
            {
                ImagePath = "https://images.unsplash.com/photo-1578439231583-9eca0a363860?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=1080&fit=max"
            };

            // Adds the stack panel to the page
            CompanyInfoStackPanel.Children.Add(Image);
            // Sets the stack panel to the first grid's column
            PageGrid.Children.Add(CompanyInfoStackPanel);

            #region Company Info

            //Creates the afm textBlock
            var AFMData = new TitleAndTextComponent()
            {
                Title = "AFM",
                Text = "2487146329",
                Margin = new Thickness(8)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AFMData);

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "DOY",
                Text = "DOY AMALIADAS",
                Margin = new Thickness(8)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(DOYData);

            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = "Greece",
                Margin = new Thickness(8)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CountryData);

            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = "Eretria",
                Margin = new Thickness(8)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CityData);

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = "Filoippimenos 8 ",
                Margin = new Thickness(8)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AddressData);

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = "2229037706",
                Margin = new Thickness(8)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(TelephoneData);

            #endregion

            //The line that separates the CompanyPage
            Bar = new Border()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = DarkBlue.HexToBrush(),
                CornerRadius = new CornerRadius(4),
                Width = 8,
                Margin = new Thickness(0, 24, 0, 24)
            };

            // Adds the border to the page's grid
            PageGrid.Children.Add(Bar);
            // Sets the border to the second column of the page's grid
            Grid.SetColumn(Bar, 1);

           //tHE right Stack Panel( right next to the separating line)
            var TopStackPanel = new StackPanel()
            { 
            Margin = new Thickness(32)

            };

            var EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };
            TopStackPanel.Children.Add(EditButtons);

            EditButtons.EditButton.Click += EditProfile;
            EditButtons.CancelButton.Click += CanelEditProfile;
            EditButtons.SaveButton.Click += SaveEditProfile;



            //JustlIKE Bio text
            var LogoBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = "Logo",
            };
            TopStackPanel.Children.Add(LogoBlock);


            #region About

             AboutTile = new BioComponent() 
            { 
               BioTextTitle = "About",
               Margin = new Thickness(32),
               BioText = "Space Exploration Technologies Corp. (SpaceX) is an American aerospace manufacturer and space transportation services company headquartered in Hawthorne, California. It was founded in 2002 by Elon Musk with the goal of reducing space transportation costs to enable the colonization of Mars.[9][10][11] SpaceX has developed several launch vehicles, as well as the Dragon cargo spacecraft and the Starlink satellite constellation (providing internet access), and has flown humans to the International Space Station on the SpaceX Dragon 2."

            + "SpaceX's achievements include the first privately funded liquid-propellant rocket to reach orbit (Falcon 1 in 2008,[12] the first private company to successfully launch, orbit, and recover a spacecraft (Dragon in 2010), the first private company to send a spacecraft to the International Space Station (Dragon in 2012),[13] the first vertical take-off and vertical propulsive landing for an orbital rocket (Falcon 9 in 2015), the first reuse of an orbital rocket (Falcon 9 in 2017), the first to launch a private spacecraft into orbit around the Sun (Falcon Heavy's payload of a Tesla Roadster in 2018), and the first private company to send astronauts to orbit and to the International Space Station(SpaceX Crew Dragon Demo-2 and SpaceX Crew-1 missions in 2020).[14] As of 31 December 2020, SpaceX has flown 20 [15] [16] cargo resupply missions to the International Space Station(ISS) under a partnership with NASA,[17] as well as an uncrewed demonstration flight of the human-rated Dragon 2 spacecraft(Crew Dragon Demo-1) on 2 March 2019, and the first crewed Dragon 2 flight on 30 May 2020.[14]"

            + "In December 2015, a Falcon 9 accomplished a propulsive vertical landing.This was the first such achievement by a rocket for orbital spaceflight.[18] In April 2016, with the launch of SpaceX CRS-8, SpaceX successfully vertically landed the first stage on an ocean drone ship landing platform.[19] In May 2016, in another first, SpaceX again landed the first stage, but during a significantly more energetic geostationary transfer orbit (GTO) mission.[20] In March 2017, SpaceX became the first to successfully re-launch and land the first stage of an orbital rocket.[21] In January 2020, with the third launch of the Starlink project, SpaceX became the largest commercial satellite constellation operator in the world.[22][23]"

            + " In September 2016, Musk unveiled the Interplanetary Transport System — subsequently renamed Starship — a privately funded launch system to develop spaceflight technology for use in crewed interplanetary spaceflight.In 2017, Musk unveiled an updated configuration of the system which is intended to handle interplanetary missions plus become the primary SpaceX orbital vehicle after the early 2020s, as SpaceX has announced it intends to eventually replace its existing Falcon 9 launch vehicles and Dragon space capsule fleet with Starship, even in the Earth-orbit satellite delivery market.[24][25][26]:24:50–27:05 Starship is planned to be fully reusable and will be the largest rocket ever on its debut, scheduled for the early 2020s."
           
            };

        

            TopStackPanel.Children.Add(AboutTile);

            #endregion


            #region Company has tiles

            //the bottom grid with the colourful tiles
            var CompanyHasDataGrid = new UniformGrid()
            {
                Columns = 3
            };



            var employeeTextBlock = new UserButtonComponent() { 
               FullName = "Employees",
               Username = "1000",
               Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(employeeTextBlock);

            var managersTextBlock = new UserButtonComponent()
            {
                FullName = "Managers",
                Username = "40",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(managersTextBlock);

            var evaluatorsTextBlock = new UserButtonComponent()
            {
                FullName = "Evaluators",
                Username = "120",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(evaluatorsTextBlock);

            var departmentsTextBlock = new UserButtonComponent()
            {
                FullName = "Departments",
                Username = "40",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(departmentsTextBlock);


            var jobsTextBlock = new UserButtonComponent()
            {
                FullName = "Jobs",
                Username = "211",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(jobsTextBlock);


            var jobPositionsTextBlock = new UserButtonComponent()
            {
                FullName = "Open Job Positions",
                Username = "18",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(jobPositionsTextBlock);

            #endregion

            TopStackPanel.Children.Add(CompanyHasDataGrid);

            // Adds the TopStackPanel to the page's grid
            PageGrid.Children.Add(TopStackPanel);
            // Sets the border to the second column of the page's grid
            Grid.SetColumn(TopStackPanel, 2);


            //  Grid.SetColumn(TopStackPanel, 2);

            Content = PageGrid;


        }

        #region Button'S Listeners

        /// <summary>
        /// Hides the text block and reveals the text box
        /// </summary>
        private void EditProfile(object sender, RoutedEventArgs e)
        {
            AboutTile.BioTextBlock.Visibility = Visibility.Collapsed;
            AboutTile.BioTextBox.Visibility = Visibility.Visible;

            AboutTile.BioTextBox.Text = AboutTile.BioTextBlock.Text;
        }

        /// <summary>
        /// Hides the text box and reveals the text block with its old text 
        /// </summary>
        private void CanelEditProfile(object sender, RoutedEventArgs e)
        {
            AboutTile.BioTextBlock.Visibility = Visibility.Visible;
            AboutTile.BioTextBox.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Hides the text box and reveals the text block with its updated text 
        /// </summary>
        private void SaveEditProfile(object sender, RoutedEventArgs e)
        {
            AboutTile.BioTextBlock.Visibility = Visibility.Visible;
            AboutTile.BioTextBox.Visibility = Visibility.Collapsed;

            AboutTile.BioTextBlock.Text = AboutTile.BioTextBox.Text;
        }

        #endregion



        #endregion
    }
}
