using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// Represents a user's profile page
    /// </summary>
    public class ProfilePage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The stack panel with the user's personal data
        /// </summary>
        protected StackPanel PersonalDataStackPanel { get; private set; }

        /// <summary>
        /// The image and username
        /// </summary>
        protected ImageAndNameComponent ImageAndTitle { get; private set; }

        /// <summary>
        /// The separator bar
        /// </summary>
        protected Border Bar { get; private set; }

        /// <summary>
        /// The stack panel for the user's company data
        /// </summary>
        protected StackPanel CompanyDataStackPanel { get; private set; }

        /// <summary>
        /// The edit buttons
        /// </summary>
        protected EditComponent EditButtons { get; private set; }
        
        /// <summary>
        /// The job title
        /// </summary>
        protected TextBlock JobTitleBlock { get; private set; }

        /// <summary>
        /// The department
        /// </summary>
        protected TextBlock DepartmentTitleBlock { get; private set; }

        /// <summary>
        /// The bio
        /// </summary>
        protected BioComponent BioTile { get; private set; }

        /// <summary>
        /// The grid for the file data
        /// </summary>
        protected UniformGrid FileDataGrid { get; private set; }

        /// <summary>
        /// The user's awards
        /// </summary>
        protected TitleAndListComponent AwardsContainer { get; private set; }

        /// <summary>
        /// The user's certifications
        /// </summary>
        protected TitleAndListComponent CertificatesContainer { get; private set; }

        /// <summary>
        /// The user's rec papers
        /// </summary>
        protected TitleAndListComponent RecommendationPapersContainer { get; private set; }

        #endregion

        #region Dependency Properties


        #region Image

        /// <summary>
        /// The user's Image
        /// </summary>
        public string Image
        {
            get { return GetValue(ImageProperty).ToString(); }
            set { SetValue(ImageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Image"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(nameof(Image), typeof(string), typeof(ProfilePage));

        #endregion

        #region Image

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username
        {
            get { return GetValue(UsernameProperty).ToString(); }
            set { SetValue(UsernameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Username"/> dependency property
        /// </summary>
        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof(Username), typeof(string), typeof(ProfilePage));

        #endregion

        #region List of awards

        /// <summary>
        /// The user's awards for the profile list section
        /// </summary>
        public IEnumerable<string> Awards
        {
            get { return (IEnumerable<string>)GetValue(AwardsProperty); }
            set { SetValue(AwardsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Awards"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AwardsProperty = DependencyProperty.Register(nameof(Awards), typeof(IEnumerable<string>), typeof(ProfilePage));

        #endregion

        #region List of Certificates

        /// <summary>
        /// The user's Certificates for the profile list section
        /// </summary>
        public IEnumerable<string> Certificates
        {
            get { return (IEnumerable<string>)GetValue(CertificatesProperty); }
            set { SetValue(CertificatesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Certificates"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CertificatesProperty = DependencyProperty.Register(nameof(Certificates), typeof(IEnumerable<string>), typeof(ProfilePage));

        #endregion

        #region List of Recommendation Papers

        /// <summary>
        /// The user's recommendation papers for the profile list section
        /// </summary>
        public IEnumerable<string> RecommendationPapers
        {
            get { return (IEnumerable<string>)GetValue(RecommendationPapersProperty); }
            set { SetValue(RecommendationPapersProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="RecommendationPapers"/> dependency property
        /// </summary>
        public static readonly DependencyProperty RecommendationPapersProperty = DependencyProperty.Register(nameof(RecommendationPapers), typeof(IEnumerable<string>), typeof(ProfilePage));

        #endregion


        #region FirstName

        /// <summary>
        /// The user's FirstName
        /// </summary>
        public string FirstName
        {
            get { return GetValue(FirstNameProperty).ToString(); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FirstName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register(nameof(FirstName), typeof(string), typeof(ProfilePage));

        #endregion

        #region LastName

        /// <summary>
        /// The user's LastName
        /// </summary>
        public string LastName
        {
            get { return GetValue(LastNameProperty).ToString(); }
            set { SetValue(LastNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="LastName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register(nameof(LastName), typeof(string), typeof(ProfilePage));

        #endregion

        #region Company

        /// <summary>
        /// The user's Company
        /// </summary>
        public string Company
        {
            get { return GetValue(CompanyProperty).ToString(); }
            set { SetValue(CompanyProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Company"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CompanyProperty = DependencyProperty.Register(nameof(Company), typeof(string), typeof(ProfilePage));

        #endregion

        #region Email

        /// <summary>
        /// The user's Email
        /// </summary>
        public string Email
        {
            get { return GetValue(EmailProperty).ToString(); }
            set { SetValue(EmailProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Email"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register(nameof(Email), typeof(string), typeof(ProfilePage));

        #endregion

        #region Job

        /// <summary>
        /// The user's Job
        /// </summary>
        public string Job
        {
            get { return GetValue(JobProperty).ToString(); }
            set { SetValue(JobProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Job"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobProperty = DependencyProperty.Register(nameof(Job), typeof(string), typeof(ProfilePage));

        #endregion

        #region Department

        /// <summary>
        /// The user's Department
        /// </summary>
        public string Department
        {
            get { return GetValue(DepartmentProperty).ToString(); }
            set { SetValue(DepartmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Department"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentProperty = DependencyProperty.Register(nameof(Department), typeof(string), typeof(ProfilePage));

        #endregion

        #region BioText

        /// <summary>
        /// The user's BioText
        /// </summary>
        public string BioText
        {
            get { return GetValue(BioTextProperty).ToString(); }
            set { SetValue(BioTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BioText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BioTextProperty = DependencyProperty.Register(nameof(BioText), typeof(string), typeof(ProfilePage));

        #endregion

        #region EvaluatorsAverage

        /// <summary>
        /// The user's EvaluatorsAverage
        /// </summary>
        public string? EvaluatorsAverage
        {
            get { return GetValue(EvaluatorsAverageProperty).ToString(); }
            set { SetValue(EvaluatorsAverageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorsAverage"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorsAverageProperty = DependencyProperty.Register(nameof(EvaluatorsAverage), typeof(string), typeof(ProfilePage));

        #endregion



        #endregion

        #region Constructors

        public ProfilePage()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            #region Page Grid

            PageGrid = new Grid()
            {
            };

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            #endregion

            PersonalDataStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(24)
            };

            ImageAndTitle = new ImageAndNameComponent()
            {
                Text = Username,
                ImagePath =  Image,
            };

            // Binds the imagePath property to the Image dependency property
             ImageAndTitle.SetBinding(ImageAndNameComponent.ImagePathProperty, new Binding(nameof(Image)));
            // Binds the Text property to the Username dependency property
             ImageAndTitle.SetBinding(ImageAndNameComponent.TextProperty, new Binding(nameof(Username)));


            PersonalDataStackPanel.Children.Add(ImageAndTitle);

            // Adds the stack panel to the page
            PageGrid.Children.Add(PersonalDataStackPanel);
            // Sets the stack panel to the first grid's column
            Grid.SetColumn(PersonalDataStackPanel, 0);

            #region PersonalData
            
            // Creates the first name text blocks
            var FirstNameData = new TitleAndTextComponent()
            {
                Title = "First name",
                Text =FirstName,
                Margin = new Thickness(24)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(FirstNameData);

            // Binds the FirstNameData.Text property of the text block to the FirstName property
            FirstNameData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(FirstName)));

            // Creates the last name text blocks
            var LastNameData = new TitleAndTextComponent()
            {
                Title = "Last name",
                Text = LastName,
                Margin = new Thickness(24)

            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(LastNameData);

            // Binds the LastName text to the LastName property
            LastNameData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(LastName)));

            // Creates the company text blocks
            var CompanyData = new TitleAndTextComponent()
            {
                Title = Company,
                Text = "EnchantmentLab",
                Margin = new Thickness(24)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(CompanyData);

            // Binds theCompanyData property to the Username property
            CompanyData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Email)));


            // Creates the email text blocks
            var EmailData = new TitleAndTextComponent()
            {
                Title = "Email",
                Text = Email,
                Margin = new Thickness(24)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(EmailData);

            // Binds the text property of the EmailData.Text to the Email property
            EmailData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(Email)));

            #endregion

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

            CompanyDataStackPanel = new StackPanel()
            {
                Margin = new Thickness(32),
            };

            EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };
            CompanyDataStackPanel.Children.Add(EditButtons);

            JobTitleBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = Job,
            };
            CompanyDataStackPanel.Children.Add(JobTitleBlock);

            // Binds the text property of the titleblock to the Job property
            JobTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Job)));

            //The evaluators Average 
            var EvalsAverage = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = EvaluatorsAverage,
            };
            CompanyDataStackPanel.Children.Add(EvalsAverage);

            // Binds the text property of the text block to the Evaluator's Average property
            EvalsAverage.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluatorsAverage)));


            DepartmentTitleBlock = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = Department,
            };
            CompanyDataStackPanel.Children.Add(DepartmentTitleBlock);

            // Binds the text property of the text block to the Department property
            DepartmentTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Email)));

            // Creates a bio tile
            BioTile = new BioComponent()
            {
                Margin = new Thickness(32),
                BioText = BioText
            };
            // Adds to the grid the bio
            CompanyDataStackPanel.Children.Add(BioTile);

            // Binds the text property of the BioComponent to the BioText property
            BioTile.SetBinding(BioComponent.BioProperty, new Binding(nameof(BioText)));


            FileDataGrid = new UniformGrid()
            {
                Columns = 2,
            };
            CompanyDataStackPanel.Children.Add(FileDataGrid);

            AwardsContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Awards",
                DataNames = Awards
            };

            // Binds the list property of the AwardsContainer to the AwardsList property
            AwardsContainer.SetBinding(TitleAndListComponent.DataNamesProperty, new Binding(nameof(Awards)));

            CertificatesContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Certificates",
                DataNames = Certificates
            };


            // Binds the list property of the CertificatesContainer to the CertificatesList property
            CertificatesContainer.SetBinding(TitleAndListComponent.DataNamesProperty, new Binding(nameof(Certificates)));

            RecommendationPapersContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Recommendation papers",
                DataNames = RecommendationPapers
            };

            // Binds the list property of the RecommendationPapersContainer to the RecommendationPapersList property
            RecommendationPapersContainer.SetBinding(TitleAndListComponent.DataNamesProperty, new Binding(nameof(RecommendationPapers)));


            CompanyDataStackPanel.Children.Add(AwardsContainer);
            CompanyDataStackPanel.Children.Add(CertificatesContainer);
            CompanyDataStackPanel.Children.Add(RecommendationPapersContainer);

            var DataScrollViewer = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Content = CompanyDataStackPanel
            };
            // Adds the scroll viewer to the page's grid
            PageGrid.Children.Add(DataScrollViewer);
            // Sets the scroll viewer on the third column
            Grid.SetColumn(DataScrollViewer, 2);

            var NavigationMenu = new NavigationMenuComponent()
            { 
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(24)
            };

            PageGrid.Children.Add(NavigationMenu);
            Grid.SetColumn(NavigationMenu, 2);

            EditButtons.EditButton.Click += EditProfile;
            EditButtons.CancelButton.Click += CanelEditProfile;
            EditButtons.SaveButton.Click += SaveEditProfile;

            Content = PageGrid;
        }

        /// <summary>
        /// Hides the text block and reveals the text box
        /// </summary>
        private void EditProfile(object sender, RoutedEventArgs e)
        {
            BioTile.BioTextBlock.Visibility = Visibility.Collapsed;
            BioTile.BioTextBox.Visibility = Visibility.Visible;

            BioTile.BioTextBox.Text = BioTile.BioTextBlock.Text;
        }

        /// <summary>
        /// Hides the text box and reveals the text block with its old text 
        /// </summary>
        private void CanelEditProfile(object sender, RoutedEventArgs e)
        {
            BioTile.BioTextBlock.Visibility = Visibility.Visible;
            BioTile.BioTextBox.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Hides the text box and reveals the text block with its updated text 
        /// </summary>
        private void SaveEditProfile(object sender, RoutedEventArgs e)
        {
            BioTile.BioTextBlock.Visibility = Visibility.Visible;
            BioTile.BioTextBox.Visibility = Visibility.Collapsed;

            BioTile.BioTextBlock.Text = BioTile.BioTextBox.Text;
        }

        #endregion

    }
}
