using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using static Vaseis.Styles;

namespace Vaseis
{

    //The number of the managers and the departments is missing because we have only 8 departments(fixed)
    //and every department has one manager. So number of managers = number of departments = 8
    public class CompanyPage : ContentControl
    {
        
        #region Public Properties

        /// <summary>
        /// The company
        /// </summary>
        public CompanyDataModel Company { get; set; }

        #endregion

        #region Protected Properties
        /// <summary>
        /// The company's Picture
        /// </summary>
        public Image Image { get; protected set; }

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The stack panel for the company data
        /// </summary>
        protected StackPanel CompanyInfoStackPanel { get; private set; }

        /// <summary>
        /// The separator bar
        /// </summary>
        protected Border Bar { get; private set; }

        /// <summary>
        /// The "About the company"
        /// </summary>
        protected BioComponent AboutTile { get; private set; }

        /// <summary>
        /// The helper variable to take given company's data
        /// </summary>
        protected CompanyDataModel CompanyVar { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent AFMData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent DOYData { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent CountryData { get; private set; }
  
        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent CityData { get; private set; }
   
        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent AddressData { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent TelephoneData { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected TitleAndTextComponent DateCreatedData { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected TextBlock LogoBlock { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected DataButtonComponent EmployeeTextBlock { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected DataButtonComponent DepartmentsTextBlock { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        protected DataButtonComponent JobsTextButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyPage(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected async override void OnInitialized(EventArgs e)  
        {
            base.OnInitialized(e);

            CompanyVar = await Services.GetDataStorage.GetCompanyDataAsync(Company.Id);

            Image.Source = new BitmapImage(new Uri(CompanyVar.CompanyPicture));

            AFMData.Text = CompanyVar.AFM;

            DOYData.Text = CompanyVar.DOY;

            CityData.Text = CompanyVar.City;

            CountryData.Text = CompanyVar.Country;

            AddressData.Text = CompanyVar.Location;

            TelephoneData.Text = CompanyVar.TelephoneNumber;

            DateCreatedData.Text = CompanyVar.DateCreated.ToShortDateString();

            LogoBlock.Text = CompanyVar.Name;

            AboutTile.BioText = CompanyVar.About;

            EmployeeTextBlock.Title = CompanyVar.Users.Count().ToString();

            DepartmentsTextBlock.Title = CompanyVar.Departments.Count().ToString();

            JobsTextButton.Title = CompanyVar.Jobs.Count().ToString();
        }

        #endregion

        #region Private Methods

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

            //The Company's image and logotype
            Image = new Image()
            {
                Width = 240,
                Height = 240,
                HorizontalAlignment = HorizontalAlignment.Center,
                // Fills the area it's to
                Stretch = Stretch.Fill,
                // Clips the image to a circle
                Clip = new EllipseGeometry(new Point(120, 120), 120, 120),
            };

            // Adds the stack panel to the page
            CompanyInfoStackPanel.Children.Add(Image);
            // Sets the stack panel to the first grid's column
            PageGrid.Children.Add(CompanyInfoStackPanel);

            #region Company Info

            //Creates the afm textBlock
            AFMData = new TitleAndTextComponent()
            {
                Title = "AFM",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AFMData);

            //Creates the DOY textBlock
            DOYData = new TitleAndTextComponent()
            {
                Title = "DOY",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(DOYData);

            //Creates the Country textBlock
            CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CountryData);

            //Creates the City textBlock
            CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CityData);

            //Creates the Address textBlock
            AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AddressData);

            //Creates the Telephone textBlock
            TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(TelephoneData);

            //Creates the DateCreated textBlock
            DateCreatedData = new TitleAndTextComponent()
            {
                Title = "Created on",
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(DateCreatedData);


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

            //The right Stack Panel( right next to the separating line)
            var TopStackPanel = new StackPanel()
            {
                Margin = new Thickness(32)
            };

            //JustlIKE Bio text
            LogoBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
            };
            TopStackPanel.Children.Add(LogoBlock);

            #region About

            AboutTile = new BioComponent()
            {
                BioTextTitle = "About",
                Margin = new Thickness(32),
            };

            TopStackPanel.Children.Add(AboutTile);

            #endregion

            #region Company has tiles

            //the bottom grid with the colourful tiles (what does the company consist of)
            var CompanyHasDataGrid = new UniformGrid()
            {
                Columns = 3
            };

            EmployeeTextBlock = new DataButtonComponent()
            {
                Text = "Employees",              
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(EmployeeTextBlock);

            DepartmentsTextBlock = new DataButtonComponent()
            {
                Text = "Departments",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(DepartmentsTextBlock);


            JobsTextButton = new DataButtonComponent()
            {
                Text = "Jobs",               
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(JobsTextButton);

            #endregion

            TopStackPanel.Children.Add(CompanyHasDataGrid);

            // Adds the TopStackPanel to the page's grid
            PageGrid.Children.Add(TopStackPanel);
            // Sets the border to the second column of the page's grid
            Grid.SetColumn(TopStackPanel, 2);

            Content = PageGrid;
        }

        #endregion
    }
}
