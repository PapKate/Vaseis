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
                Width = new System.Windows.GridLength(1, GridUnitType.Auto)
            });

            #endregion


            //The column that contains some details and the image & logo of the com pany (left)
             CompanyInfoStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(24)
            };

            //The Companby's image and logotype
             ImageAndLogo = new ImageAndNameComponent()
            {
                Text = "",
                ImagePath = "https://images.unsplash.com/photo-1578439231583-9eca0a363860?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=1080&fit=max"
            };

            // Adds the stack panel to the page
            CompanyInfoStackPanel.Children.Add(ImageAndLogo);
            // Sets the stack panel to the first grid's column
            PageGrid.Children.Add(CompanyInfoStackPanel);

            #region Company Info

            //Creates the afm textBlock
            var AFMData = new TitleAndTextComponent()
            {
                Title = "AFM",
                Text = "2487146329",
                Margin = new Thickness(24)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AFMData);

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "DOY",
                Text = "DOY AMALIADAS",
                Margin = new Thickness(24)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(DOYData);

            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = "Greece",
                Margin = new Thickness(24)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CountryData);

            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = "Eretria",
                Margin = new Thickness(24)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CityData);

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = "Filoippimenos 8 ",
                Margin = new Thickness(24)
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AddressData);

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = "2229037706",
                Margin = new Thickness(24)
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

            var TopStackPanel = new StackPanel()
            { 
            Margin = new Thickness(32)
            };

            var EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };
            TopStackPanel.Children.Add(EditButtons);

            var LogoBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = "Logo",
            };
            TopStackPanel.Children.Add(LogoBlock);

            var InfoTile = new TextBlock()
            {
                Text = "AboutKaiMpourdes",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush(),
                Margin = new Thickness(0, 0, 0, 12)
            };
            TopStackPanel.Children.Add(InfoTile);

            var CompanyHasDataGrid = new UniformGrid()
            {
                Columns = 3
            };

            TopStackPanel.Children.Add(CompanyHasDataGrid);

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

            Content = PageGrid;

        }




        #endregion
    }
}
