using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using static Vaseis.Styles;

namespace Vaseis
{
   //This is a class that creates the row components fo rthe adminidtrator's companies page
    public class CompaniesComponent : ContentControl
    {
        #region Proetcted Properties

        #endregion

        #region Dependency Properties

        #region Image

        /// <summary>
        /// The user's Image
        /// </summary>
        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Image"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(nameof(Image), typeof(string), typeof(CompaniesComponent));

        #endregion

        #region Background Color

        /// <summary>
        /// The path of the image
        /// </summary>
        public string BackgroundColor
        {
            get { return (string)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundColor"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register(nameof(BackgroundColor), typeof(string), typeof(CompaniesComponent), new PropertyMetadata(OnBackgroundChanged));

        /// <summary>
        /// Handles the change of the <see cref="BackgroundColor"/> property
        /// </summary>
        private static void OnBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as UserButtonComponent;

            //sender.OnBackgroundChangedCore(e);
        }

        #endregion

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
        public static readonly DependencyProperty AFMProperty = DependencyProperty.Register(nameof(Afm), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty DOYProperty = DependencyProperty.Register(nameof(Doy), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(nameof(Countryy), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty CityProperty = DependencyProperty.Register(nameof(CITY), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register(nameof(Addresss), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty TelephoneProperty = DependencyProperty.Register(nameof(Tele), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty DateCreatedProperty = DependencyProperty.Register(nameof(DateOfCreation), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty LogoProperty = DependencyProperty.Register(nameof(Logotype), typeof(string), typeof(CompaniesComponent));

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
        public static readonly DependencyProperty AboutTextProperty = DependencyProperty.Register(nameof(About), typeof(string), typeof(CompaniesComponent));

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

            };


            CompanyGrid.SetBinding(Grid.BackgroundProperty, new Binding(nameof(BackgroundColor))
            {
                Source = this
            });


            CompanyGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            CompanyGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            #region First Column

            var CompanyPicAndLogo = new ImageAndNameComponent()
            { 
                ImagePath = "https://assets.sainsburys-groceries.co.uk/gol/7965259/1/640x640.jpg",
                Text = Logotype
            };

            CompanyPicAndLogo.SetBinding(ImageAndNameComponent.TextProperty, new Binding(nameof(Logotype))
            {
                Source = this
            });
            // Binds the imagePath property to the Image dependency property
           CompanyPicAndLogo.SetBinding(ImageAndNameComponent.ImagePathProperty, new Binding(nameof(Image))
           {
               Source = this
           });

            CompanyGrid.Children.Add(CompanyPicAndLogo);
            Grid.SetColumn(CompanyPicAndLogo, 0);

            #endregion

            Grid InfoAboutTheCompanyGrid = new Grid();

            InfoAboutTheCompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            #region second row 

            InfoAboutTheCompanyGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });


            var AboutTileTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 18,
                FontWeight = FontWeights.Normal,
                Text = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by The Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton and was bought out by businessman Asa Griggs Candler, whose marketing tactics led Coca-Cola to its dominance of the world soft-drink market throughout the 20th century.[1] The drink's name refers to two of its original ingredients: coca leaves, and kola nuts (a source of caffeine). The current formula of Coca-Cola remains a trade secret; however, a variety of reported recipes and experimental recreations have been published.",
                Foreground = Styles.DarkGray.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,            
            };
            AboutTileTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(About))
            {
                Source = this
            });

            var AboutTileScroll = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Top,
                // With content the bio's text block
                Content = AboutTileTextBlock,
                MaxHeight = 200
            };

            var AboutTile = new Expander()
            {
                FontSize = 28,
                Header = "About",
                Width = 800,              
                BorderThickness = new Thickness(0, 0, 0, 8),
                Content = AboutTileScroll,
            };

            // Binds the aBOUT property to the aBOUTcOMPANYTEXT dependency property
            //    AboutTile.SetBinding(BioComponent.BioProperty, new Binding(nameof(About)));

            var AboutBar = new Border()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                CornerRadius = new CornerRadius(8),
                BorderThickness = new Thickness(8),
                Margin = new Thickness(24),       
            };

            AboutBar.Child = AboutTile;

            InfoAboutTheCompanyGrid.Children.Add(AboutBar);

            Grid.SetRow(AboutBar, 1);

            #endregion

            var firstRowGrid = new UniformGrid() {
                Columns = 2,
                Margin = new Thickness(28,24,24,0)
            };
      
            #region First Column Stack
           

            //Creates the afm textBlock
            var AFMData = new TitleAndTextComponent()
            {
                Title = "Afm",
                Text = Afm,
            };
            // Binds the AFMData property to the afm dependency property
            AFMData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Afm))
            {
                Source = this
            });
            firstRowGrid.Children.Add(AFMData);

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "Doy",
                Text = Doy,
            };
            // Binds the DoyData property to the Doy dependency property
            DOYData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Doy))
            {
                Source = this
            });
            firstRowGrid.Children.Add(DOYData);


            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = Countryy,
            };
            // Binds the countryData block property to the Country dependency property
            CountryData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Countryy))
            {
                Source = this
            });
            firstRowGrid.Children.Add(CountryData);


            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = CITY,
            };
            // Binds the CityData block property to the City dependency property
            CityData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(CITY))
            {
                Source = this
            });
            firstRowGrid.Children.Add(CityData);

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = Addresss,
            };
            // Binds the AddressData block property to the ImagePath dependency property
            AddressData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Addresss))
            {
                Source = this
            });
            firstRowGrid.Children.Add(AddressData);

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = Tele,
            };
            // Binds the iTelephoneData block property to the ImagePath dependency property
            TelephoneData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Tele))
            {
                Source = this
            });
            firstRowGrid.Children.Add(TelephoneData);

            //Creates the DateCreated textBlock
            var DateCreatedData = new TitleAndTextComponent()
            {
                Title = "Created on",
                Text = DateOfCreation,
            };
            // Binds the DateCreatedData block property to the DateCreated dependency property
            DateCreatedData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(DateOfCreation))
            {
                Source = this
            });
            firstRowGrid.Children.Add(DateCreatedData);

            Grid.SetRow(firstRowGrid, 0);

            InfoAboutTheCompanyGrid.Children.Add(firstRowGrid);
            #endregion


            CompanyGrid.Children.Add(InfoAboutTheCompanyGrid);
            Grid.SetColumn(InfoAboutTheCompanyGrid, 1);

            Content = CompanyGrid;

            #endregion

        }
    }
}

