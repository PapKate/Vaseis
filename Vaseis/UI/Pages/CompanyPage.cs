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

    class CompanyPage : ContentControl
    {

        #region Protected Properties
        /// <summary>
        /// The company's Picture
        /// </summary>
        public Image Image { get; private set; }

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

        #region AFM 

        /// <summary>
        /// The Company's AFM
        /// </summary>
        public string AFM
        {
            get { return (string)GetValue(AFMProperty); }
            set { SetValue(AFMProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AFM"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AFMProperty = DependencyProperty.Register(nameof(AFM), typeof(string), typeof(CompanyPage));

        #endregion

        #region DOY 

        /// <summary>
        /// The Company's DOY
        /// </summary>
        public string DOY
        {
            get { return (string)GetValue(DOYProperty); }
            set { SetValue(DOYProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DOY"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DOYProperty = DependencyProperty.Register(nameof(DOY), typeof(string), typeof(CompanyPage));

        #endregion

        #region Country
        /// <summary>
        /// The Company's Country
        /// </summary>
        public string Country
        {
            get { return (string)GetValue(CountryProperty); }
            set { SetValue(CountryProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Country"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(nameof(Country), typeof(string), typeof(CompanyPage));

        #endregion

        #region City 

        /// <summary>
        /// The Company's City
        /// </summary>
        public string City
        {
            get { return (string)GetValue(CityProperty); }
            set { SetValue(CityProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AFM"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CityProperty = DependencyProperty.Register(nameof(City), typeof(string), typeof(CompanyPage));

        #endregion

        #region Address 

        /// <summary>
        /// The Company's Address
        /// </summary>
        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Address"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddressProperty = DependencyProperty.Register(nameof(Address), typeof(string), typeof(CompanyPage));

        #endregion

        #region Telephone 

        /// <summary>
        /// The Company's Telephone
        /// </summary>
        public string Telephone
        {
            get { return (string)GetValue(TelephoneProperty); }
            set { SetValue(TelephoneProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Telephone"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TelephoneProperty = DependencyProperty.Register(nameof(Telephone), typeof(string), typeof(CompanyPage));

        #endregion

        #region Date pf Creation 

        /// <summary>
        /// The Company's Date of Creation
        /// </summary>
        public string DateCreated
        {
            get { return (string)GetValue(DateCreatedProperty); }
            set { SetValue(DateCreatedProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DateCreated"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DateCreatedProperty = DependencyProperty.Register(nameof(DateCreated), typeof(string), typeof(CompanyPage));

        #endregion

        #region Logo 

        /// <summary>
        /// The Company's Logo(name-title)
        /// </summary>
        public string Logo
        {
            get { return (string)GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Logo"/> dependency property
        /// </summary>
        public static readonly DependencyProperty LogoProperty = DependencyProperty.Register(nameof(Logo), typeof(string), typeof(CompanyPage));

        #endregion

        #region AboutText 

        /// <summary>
        /// The Company's AboutText (just like Bio)
        /// </summary>
        public string AboutText
        {
            get { return (string)GetValue(AboutTextProperty); }
            set { SetValue(AboutTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AboutText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AboutTextProperty = DependencyProperty.Register(nameof(AboutText), typeof(string), typeof(CompanyPage));

        #endregion

        #region Number of Employees 

        /// <summary>
        /// How many Employeess a Comnpany has
        /// </summary>
        public string NumberOfEmployees
        {
            get { return (string)GetValue(NumberOfEmployeesProperty); }
            set { SetValue(NumberOfEmployeesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NumberOfEmployees"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NumberOfEmployeesProperty = DependencyProperty.Register(nameof(NumberOfEmployees), typeof(string), typeof(CompanyPage));

        #endregion


        #region Number of Evaluators 

        /// <summary>
        /// How many Evaluators a Comnpany has
        /// </summary>
        public string NumberOfEvaluators
        {
            get { return (string)GetValue(NumberOfEvaluatorsProperty); }
            set { SetValue(NumberOfEvaluatorsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NumberOfEvaluators"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NumberOfEvaluatorsProperty = DependencyProperty.Register(nameof(NumberOfEvaluators), typeof(string), typeof(CompanyPage));

        #endregion

        #region Number of Jobs 

        /// <summary>
        /// How many Jobs a Comnpany has
        /// </summary>
        public string NumberOfJobs
        {
            get { return (string)GetValue(NumberOfJobsProperty); }
            set { SetValue(NumberOfJobsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NumberOfJobs"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NumberOfJobsProperty = DependencyProperty.Register(nameof(NumberOfJobs), typeof(string), typeof(CompanyPage));

        #endregion

        #region Number of Job Positions 

        /// <summary>
        ///  How many availavle Job Positions a Comnpany has
        /// </summary>
        public string NumberOfJobPositions
        {
            get { return (string)GetValue(NumberOfJobPositionsProperty); }
            set { SetValue(NumberOfJobPositionsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NumberOfJobPositions"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NumberOfJobPositionsProperty = DependencyProperty.Register(nameof(NumberOfJobPositions), typeof(string), typeof(CompanyPage));

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

#       endregion


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
             var Image = new Image()
            {
                 Margin = new Thickness(8),
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
                Text = AFM,
                Margin = new Thickness(8)
            };
            // Binds the AFMData property to the afm dependency property
            AFMData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(AFM)));


            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AFMData);

            //Creates the DOY textBlock
            var DOYData = new TitleAndTextComponent()
            {
                Title = "DOY",
                Text = DOY,
                Margin = new Thickness(8)
            };
            // Binds the DoyData property to the Doy dependency property
            DOYData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(DOY)));

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(DOYData);

            //Creates the Country textBlock
            var CountryData = new TitleAndTextComponent()
            {
                Title = "Country",
                Text = Country,
                Margin = new Thickness(8)
            };
            // Binds the countryData block property to the Country dependency property
            CountryData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Country)));

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CountryData);

            //Creates the City textBlock
            var CityData = new TitleAndTextComponent()
            {
                Title = "City",
                Text = City,
                Margin = new Thickness(8)
            };
            // Binds the CityData block property to the City dependency property
            CityData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(City)));

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(CityData);

            //Creates the Address textBlock
            var AddressData = new TitleAndTextComponent()
            {
                Title = "Address",
                Text = Address,
                Margin = new Thickness(8)
            };
            // Binds the AddressData block property to the ImagePath dependency property
            AddressData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Address)));

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(AddressData);

            //Creates the Telephone textBlock
            var TelephoneData = new TitleAndTextComponent()
            {
                Title = "Telephone",
                Text = Telephone,
                Margin = new Thickness(8)
            };
            // Binds the iTelephoneData block property to the ImagePath dependency property
            TelephoneData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Telephone)));

            //adds it to the info column
            CompanyInfoStackPanel.Children.Add(TelephoneData);

            //Creates the DateCreated textBlock
            var DateCreatedData = new TitleAndTextComponent()
            {
                Title = "Created on",
                Text = Telephone,
                Margin = new Thickness(8)
            };
            // Binds the DateCreatedData block property to the DateCreated dependency property
            DateCreatedData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(DateCreated)));

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
            // Binds the Logo block property to the Logo dependency property
            LogoBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Logo)));


            #region About

            AboutTile = new BioComponent() 
            { 
               BioTextTitle = "About",
               Margin = new Thickness(32),
               BioText =AboutText
            };
            // Binds the aBOUT property to the aBOUTcOMPANYTEXT dependency property
            AboutTile.SetBinding(BioComponent.BioProperty, new Binding(nameof(AboutText)));


            TopStackPanel.Children.Add(AboutTile);

            #endregion


            #region Company has tiles

            //the bottom grid with the colourful tiles (what does the company consist of)
            var CompanyHasDataGrid = new UniformGrid()
            {
                Columns = 3
            };

            var employeeTextBlock = new UserButtonComponent() { 
               FullName = "Employees",
               Username = NumberOfEmployees,
               Background = "ff4455".HexToBrush()
            };
            // Binds the JobsTextBlock property to the NumberOfJobs dependency property
            employeeTextBlock.SetBinding(UserButtonComponent.UsernameProperty, new Binding(nameof(NumberOfEmployees)));

            CompanyHasDataGrid.Children.Add(employeeTextBlock);

            var managersTextBlock = new UserButtonComponent()
            {
                FullName = "Managers",
                Username = "8",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(managersTextBlock);

            var evaluatorsTextBlock = new UserButtonComponent()
            {
                FullName = "Evaluators",
                Username = NumberOfEvaluators,
                Background = "ff4455".HexToBrush()
            };
            // Binds the EvaluatorsBlock property to the NumberOfEvaluators dependency property
            evaluatorsTextBlock.SetBinding(UserButtonComponent.UsernameProperty, new Binding(nameof(NumberOfEvaluators)));

            CompanyHasDataGrid.Children.Add(evaluatorsTextBlock);

            var departmentsTextBlock = new UserButtonComponent()
            {
                FullName = "Departments",
                Username = "8",
                Background = "ff4455".HexToBrush()
            };

            CompanyHasDataGrid.Children.Add(departmentsTextBlock);


            var jobsTextBlock = new UserButtonComponent()
            {
                FullName = "Jobs",
                Username = NumberOfJobs,
                Background = "ff4455".HexToBrush()
            };
            // Binds the JobsTextBlock property to the NumberOfJobs dependency property
            jobsTextBlock.SetBinding(UserButtonComponent.UsernameProperty, new Binding(nameof(NumberOfJobs)));
           
            CompanyHasDataGrid.Children.Add(jobsTextBlock);


            var jobPositionsTextBlock = new UserButtonComponent()
            {
                FullName = "Open Job Positions",
                Username = NumberOfJobPositions,
                Background = "ff4455".HexToBrush()
            };
            // Binds the Jobpositions property to the NumberOfJobPositions dependency property
            jobPositionsTextBlock.SetBinding(UserButtonComponent.UsernameProperty, new Binding(nameof(NumberOfJobPositions)));

            CompanyHasDataGrid.Children.Add(jobPositionsTextBlock);

            #endregion

            TopStackPanel.Children.Add(CompanyHasDataGrid);

            // Adds the TopStackPanel to the page's grid
            PageGrid.Children.Add(TopStackPanel);
            // Sets the border to the second column of the page's grid
            Grid.SetColumn(TopStackPanel, 2);


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

        #region onImagePathChangedCore

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnImagePathChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (string)e.NewValue;

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
