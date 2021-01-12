using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
   //This is a class that creates the row components fo rthe adminidtrator's companies page
    public class CompaniesComponent : ContentControl
    {
        #region Proetcted Properties



        #endregion

        #region Dependency Properties

        #region AFM 

        /// <summary>
        /// The Company's AFM
        /// </summary>
        public string Afm
        {
            get { return (string)GetValue(AFMProperty); }
            set { SetValue(AFMProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Afm"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AFMProperty = DependencyProperty.Register(nameof(Afm), typeof(string), typeof(CompanyPage));

        #endregion

        #region DOY 

        /// <summary>
        /// The Company's DOY
        /// </summary>
        public string Doy
        {
            get { return (string)GetValue(DOYProperty); }
            set { SetValue(DOYProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Doy"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DOYProperty = DependencyProperty.Register(nameof(Doy), typeof(string), typeof(CompanyPage));

        #endregion

        #region Country
        /// <summary>
        /// The Company's Country
        /// </summary>
        public string Countryy
        {
            get { return (string)GetValue(CountryProperty); }
            set { SetValue(CountryProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Countryy"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(nameof(Countryy), typeof(string), typeof(CompanyPage));

        #endregion

        #region City 

        /// <summary>
        /// The Company's City
        /// </summary>
        public string CITY
        {
            get { return (string)GetValue(CityProperty); }
            set { SetValue(CityProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Afm"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CityProperty = DependencyProperty.Register(nameof(CITY), typeof(string), typeof(CompanyPage));

        #endregion

        #region Address 

        /// <summary>
        /// The Company's Address
        /// </summary>
        public string Addresss
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Addresss"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register(nameof(Addresss), typeof(string), typeof(CompanyPage));

        #endregion

        #region Telephone 

        /// <summary>
        /// The Company's Telephone
        /// </summary>
        public string Tele
        {
            get { return (string)GetValue(TelephoneProperty); }
            set { SetValue(TelephoneProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Tele"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TelephoneProperty = DependencyProperty.Register(nameof(Tele), typeof(string), typeof(CompanyPage));

        #endregion

        #region Date pf Creation 

        /// <summary>
        /// The Company's Date of Creation
        /// </summary>
        public string DateOfCreation
        {
            get { return (string)GetValue(DateCreatedProperty); }
            set { SetValue(DateCreatedProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DateOfCreation"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DateCreatedProperty = DependencyProperty.Register(nameof(DateOfCreation), typeof(string), typeof(CompanyPage));

        #endregion

        #region Logo 

        /// <summary>
        /// The Company's Logo(name-title)
        /// </summary>
        public string Logotype
        {
            get { return (string)GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Logotype"/> dependency property
        /// </summary>
        public static readonly DependencyProperty LogoProperty = DependencyProperty.Register(nameof(Logotype), typeof(string), typeof(CompanyPage));

        #endregion

        #region AboutText 

        /// <summary>
        /// The Company's AboutText (just like Bio)
        /// </summary>
        public string About
        {
            get { return (string)GetValue(AboutTextProperty); }
            set { SetValue(AboutTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="About"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AboutTextProperty = DependencyProperty.Register(nameof(About), typeof(string), typeof(CompanyPage));

        #endregion


        #endregion

        #region Constructors
        public CompaniesComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {

            var CompanyGrid = new Grid()
            { 
            Height = 400,
                Background = Styles.Green.HexToBrush()
            };
            
            CompanyGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
               Width = new GridLength(400, GridUnitType.Pixel)
            });

            CompanyGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            #region First Column

            var CompanyPicAndLogo = new ImageAndNameComponent()
            {
               // ImagePath = "https://assets.sainsburys-groceries.co.uk/gol/7965259/1/640x640.jpg",
               // Text = "Coca Cola Light"    
               
                ImagePath = "https://assets.sainsburys-groceries.co.uk/gol/7965259/1/640x640.jpg",
                Text = Logotype
            };
         
            CompanyPicAndLogo.SetBinding(ImageAndNameComponent.TextProperty, new Binding(nameof(Logotype)));


            CompanyGrid.Children.Add(CompanyPicAndLogo);
            Grid.SetColumn(CompanyPicAndLogo, 0);

            #endregion

            var giatiGamw = new TextBlock() { Text = "gamwww", Background = Styles.Green.HexToBrush() };
            CompanyGrid.Children.Add(giatiGamw);


            Grid InfoAboutTheCompanyGrid = new Grid();

            CompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

          #region second row 

            CompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            var AboutTile = new BioComponent()
            {
                BioTextTitle = "About",
                Margin = new Thickness(32),
                BioText = About
            };
            // Binds the aBOUT property to the aBOUTcOMPANYTEXT dependency property
            AboutTile.SetBinding(BioComponent.BioProperty, new Binding(nameof(About)));

            CompanyGrid.Children.Add(AboutTile);

            Grid.SetColumn(AboutTile, 1);

            #endregion

            var firstRowGrid = new Grid();

            firstRowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            firstRowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });


            #region First Column Stack
            var companyInfoStack1 = new StackPanel();

            //Creates the afm textBlock
            var AFMData = new TitleAndTextComponent()
            {
                Title = "AFM",
                Text = Afm,
            };
            // Binds the AFMData property to the afm dependency property
            AFMData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Afm)));

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "DOY",
                Text = Doy,
            };
            // Binds the DoyData property to the Doy dependency property
            DOYData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Doy)));

            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = Countryy,
            };
            // Binds the countryData block property to the Country dependency property
            CountryData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Countryy)));

            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = CITY,
            };
            // Binds the CityData block property to the City dependency property
            CityData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(CITY)));

            companyInfoStack1.Children.Add(AFMData);
            companyInfoStack1.Children.Add(DOYData);
            companyInfoStack1.Children.Add(CountryData);
            companyInfoStack1.Children.Add(CityData);

            firstRowGrid.Children.Add(companyInfoStack1);
            Grid.SetColumn(companyInfoStack1, 0);

            #endregion


            #region Second row

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = Addresss,
            };
            // Binds the AddressData block property to the ImagePath dependency property
            AddressData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Addresss)));

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = Tele,
            };
            // Binds the iTelephoneData block property to the ImagePath dependency property
            TelephoneData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Tele)));

            //Creates the DateCreated textBlock
            var DateCreatedData = new TitleAndTextComponent()
            {
                Title = "Created on",
                Text = DateOfCreation,
            };
            // Binds the DateCreatedData block property to the DateCreated dependency property
            DateCreatedData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(DateOfCreation)));

            var secondColumn = new StackPanel();

            secondColumn.Children.Add(AddressData);
            secondColumn.Children.Add(TelephoneData);
            secondColumn.Children.Add(DateCreatedData);

            firstRowGrid.Children.Add(secondColumn);

            Grid.SetColumn(secondColumn, 1);
            #endregion


            Content = CompanyGrid;

            #endregion

        }
    }
}

