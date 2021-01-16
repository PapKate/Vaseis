using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Vaseis.Styles;

namespace Vaseis
{

    //The number of the managers and the departments is missing because we have only 8 departments(fixed)
    //and every deprtment has one manager. So number of managers = number of departments = 8

    public class CompanyPage : ContentControl
    {

        #region Public Properties

        public CompanyDataModel Company { get; }

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
        /// The "About thw company"
        /// </summary>
        protected BioComponent AboutTile { get; private set; }


        #endregion

        #region Constructors

        public CompanyPage(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Dependency Properties

        #region Image

        /// <summary>
        ///Company image Path
        /// </summary>
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ImagePath"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(nameof(ImagePath), typeof(string), typeof(CompanyPage), new PropertyMetadata(OnImagePathChanged));

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property
        /// </summary>
        private static void OnImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as CompanyPage;

            sender.OnImagePathChangedCore(e);
        }

        #endregion

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="HeaderImageAndTitleComponent.ImagePath"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnImagePathChanged(DependencyPropertyChangedEventArgs e)
        {

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
            var Image = new Image()
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
            var AFMData = new TitleAndTextComponent()
            {
                Title = "AFM",
                Text = Company.AFM,
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AFMData);

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "DOY",
                Text = Company.DOY,
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(DOYData);

            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = Company.Country,
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CountryData);

            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = Company.City,
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CityData);

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = Company.Location,
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AddressData);

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = Company.TelephoneNumber,
                Margin = new Thickness(12),
            };

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(TelephoneData);

            //Creates the DateCreated textBlock
            var DateCreatedData = new TitleAndTextComponent()
            {
                Title = "Created on",
                Text = Company.DateCreated.ToString(),
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

            //tHE right Stack Panel( right next to the separating line)
            var TopStackPanel = new StackPanel()
            {
                Margin = new Thickness(32)

            };

            //JustlIKE Bio text
            var LogoBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = Company.Name,
            };
            TopStackPanel.Children.Add(LogoBlock);

            #region About

            AboutTile = new BioComponent()
            {
                BioTextTitle = "About",
                Margin = new Thickness(32),
                BioText = Company.About
            };

            TopStackPanel.Children.Add(AboutTile);

            #endregion

            #region Company has tiles

            //the bottom grid with the colourful tiles (what does the company consist of)
            var CompanyHasDataGrid = new UniformGrid()
            {
                Columns = 3
            };

            var employeeTextBlock = new DataButtonComponent()
            {
                FullName = "Employees",
                Username = Company.Users.GetEnumerator().ToString(),
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(employeeTextBlock);

            var departmentsTextBlock = new DataButtonComponent()
            {
                FullName = "Departments",
                Username = Company.Departments.GetEnumerator().ToString(),
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(departmentsTextBlock);


            var jobsTextBlock = new DataButtonComponent()
            {
                FullName = "Jobs",
                Username = Company.Jobs.GetEnumerator().ToString(),
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(jobsTextBlock);

            #endregion

            TopStackPanel.Children.Add(CompanyHasDataGrid);

            // Adds the TopStackPanel to the page's grid
            PageGrid.Children.Add(TopStackPanel);
            // Sets the border to the second column of the page's grid
            Grid.SetColumn(TopStackPanel, 2);

            Content = PageGrid;
        }


        #region onImagePathChangedCore

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnImagePathChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = Company.CompanyPicture;

            if (newValue == null)
            {
                Image.Source = null;
            }
            else
            {
                // Create the bitmap image
                var bitmapImage = new BitmapImage(new Uri(newValue));

                // Set it to the image
                Image.Source = bitmapImage;
            }

            // Further handle the change
            OnImagePathChanged(e);
        }

        #endregion

        #endregion
    }
}
