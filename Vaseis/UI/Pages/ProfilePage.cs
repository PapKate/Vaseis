using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using static Vaseis.Styles;
using static Vaseis.MaterialDesignStyles;
using System;

namespace Vaseis
{
    /// <summary>
    /// Represents a user's profile page
    /// </summary>
    public class ProfilePage : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The user
        /// </summary>
        public UserDataModel User { get; }

        #endregion


        #region Protected Properties

        /// <summary>
        /// The change password dialog component
        /// </summary>
        protected ChangePasswordDialog ChangePasswordDialog { get; private set; }

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
        /// The user's department TextBlock
        /// </summary>
        protected TextBlock DepartmentTitleBlock { get; private set; }

        /// <summary>
        /// The bioComponent (TextBlock- TextBox)
        /// </summary>
        protected BioComponent BioTile { get; private set; }

        /// <summary>
        /// The user's eail BioComponent (editText - textBlock)
        /// </summary>
        protected EditableTextComponent EmailData { get; private set; }

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

        /// <summary>
        /// The Change Password Button that opens a dialogue button
        /// </summary>
        protected Button ChangePassword { get; private set; }

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
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(nameof(Image), typeof(string), typeof(ProfilePage));

        #endregion

        #region Username

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
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
            get { return (string)GetValue(FirstNameProperty); }
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
            get { return (string)GetValue(LastNameProperty); }
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
            get { return (string)GetValue(CompanyProperty); }
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
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Email"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register(nameof(Email), typeof(string), typeof(ProfilePage));

        #endregion

        #region YearsOfExperiece

        /// <summary>
        /// The user's YearsOfExperiece
        /// </summary>
        public string YearsOfExperiece
        {
            get { return (string)GetValue(YearsOfExperieceProperty); }
            set { SetValue(YearsOfExperieceProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="YearsOfExperiece"/> dependency property
        /// </summary>
        public static readonly DependencyProperty YearsOfExperieceProperty = DependencyProperty.Register(nameof(YearsOfExperiece), typeof(string), typeof(ProfilePage));

        #endregion

        #region Job

        /// <summary>
        /// The user's Job
        /// </summary>
        public string Job
        {
            get { return (string)GetValue(JobProperty); }
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
            get { return (string)GetValue(DepartmentProperty); }
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
            get { return (string)GetValue(BioTextProperty); }
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
            get { return (string)GetValue(EvaluatorsAverageProperty); }
            set { SetValue(EvaluatorsAverageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorsAverage"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorsAverageProperty = DependencyProperty.Register(nameof(EvaluatorsAverage), typeof(string), typeof(ProfilePage));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        public ProfilePage(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

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

            #region Personal Data 

            PersonalDataStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(16)
            };

            ImageAndTitle = new ImageAndNameComponent()
            {
                Text = User.Username,
                ImagePath =  Image,
            };

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
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(FirstNameData);

            // Binds the FirstNameData.Text property of the text block to the FirstName property
            FirstNameData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(FirstName))
            {
                Source = this
            });

            // Creates the last name text blocks
            var LastNameData = new TitleAndTextComponent()
            {
                Title = "Last name",
                Text = LastName,
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(LastNameData);

            // Binds the LastName text to the LastName property
            LastNameData.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(LastName))
            {
                Source = this
            });

            // Creates the company text blocks
            var CompanyData = new TitleAndTextComponent()
            {
                Title = "Company",
                Text = Company,
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(CompanyData);

            // Creates the users years of exp data
            var YearsOfXp = new TitleAndTextComponent()
            {
                Title = "Years of experience",
                Text = Company,
                Margin = new Thickness(16),
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(YearsOfXp);

            // Binds theCompanyData property to the Company property
            YearsOfXp.SetBinding(TitleAndTextComponent.TextProperty, new Binding(nameof(YearsOfExperiece))
            {
                Source = this
            });

            // Creates the email BioComponent

            EmailData = new EditableTextComponent()
            { 
                Text = User.Email,
                Title = "Email",
                Margin = new Thickness(16)
            };

            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(EmailData);

            #region Change Password

            //The change password Button 
            ChangePassword = new Button()
            {
                Style = FlatButton,
                Background = GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = DarkBlue.HexToBrush(),
                    FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "Change password"
                },
            };

            ChangePassword.Click += ShowChangePasswordDialogOnClick;
            PersonalDataStackPanel.Children.Add(ChangePassword);

            #endregion

            #endregion

            Bar = new Border()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = DarkBlue.HexToBrush(),
                CornerRadius = new CornerRadius(4),
                Width = 8,
                Margin = new Thickness(16)
            };
            // Adds the border to the page's grid
            PageGrid.Children.Add(Bar);
            // Sets the border to the second column of the page's grid
            Grid.SetColumn(Bar, 1);

            #endregion

            #region Bio and Employee File

            CompanyDataStackPanel = new  StackPanel()
            {
                Margin = new Thickness(32),
            };

            EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                EditCommand = new RelayCommand(() => { BioTile.IsEditable = true; }),
                SaveCommand = new RelayCommand(() => { BioTile.IsEditable = false; BioTile.SaveEdit = true; }),
                CancelCommand = new RelayCommand(() => { BioTile.IsEditable = false; BioTile.SaveEdit = false; }),
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
            JobTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Job))
            {
                Source = this
            });

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
            EvalsAverage.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluatorsAverage))
            {
                Source = this
            });


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
            DepartmentTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Email))
            {
                Source = this
            });

            // Creates a bio tile
            BioTile = new BioComponent()
            {
                BioTextTitle = "Bio",
                Margin = new Thickness(32),
                BioText = BioText
            };
            // Adds to the grid the bio
            CompanyDataStackPanel.Children.Add(BioTile);

            // Binds the text property of the BioComponent to the BioText property
            BioTile.SetBinding(BioComponent.BioProperty, new Binding(nameof(BioText))
            {
                Source = this
            });


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
            AwardsContainer.SetBinding(TitleAndListComponent.DataNamesProperty, new Binding(nameof(Awards))
            {
                Source = this
            });

            CertificatesContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Certificates",
                DataNames = Certificates
            };


            // Binds the list property of the CertificatesContainer to the CertificatesList property
            CertificatesContainer.SetBinding(TitleAndListComponent.DataNamesProperty, new Binding(nameof(Certificates))
            {
                Source = this
            });

            RecommendationPapersContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Recommendation papers",
                DataNames = RecommendationPapers
            };

            // Binds the list property of the RecommendationPapersContainer to the RecommendationPapersList property
            RecommendationPapersContainer.SetBinding(TitleAndListComponent.DataNamesProperty, new Binding(nameof(RecommendationPapers))
            {
                Source = this
            });

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

            #endregion

            var NavigationMenu = new NavigationMenuComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(24)
            };

            PageGrid.Children.Add(NavigationMenu);
            Grid.SetColumn(NavigationMenu, 2);

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

            EmailData.EmailTextBlock.Visibility = Visibility.Collapsed;
            EmailData.EmailTextBox.Visibility = Visibility.Visible;
            EmailData.EmailTextBox.Text = EmailData.EmailTextBlock.Text;
        }

        /// <summary>
        /// Hides the text box and reveals the text block with its old text 
        /// </summary>
        private void CanelEditProfile(object sender, RoutedEventArgs e)
        {
            BioTile.BioTextBlock.Visibility = Visibility.Visible;
            BioTile.BioTextBox.Visibility = Visibility.Collapsed;

            EmailData.EmailTextBlock.Visibility = Visibility.Visible;
            EmailData.EmailTextBox.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Hides the text box and reveals the text block with its updated text 
        /// </summary>
        private void SaveEditProfile(object sender, RoutedEventArgs e)
        {
            BioTile.BioTextBlock.Visibility = Visibility.Visible;
            BioTile.BioTextBox.Visibility = Visibility.Collapsed;
            BioTile.BioTextBlock.Text = BioTile.BioTextBox.Text;

            EmailData.EmailTextBlock.Visibility = Visibility.Visible;
            EmailData.EmailTextBox.Visibility = Visibility.Collapsed;
            EmailData.EmailTextBlock.Text = EmailData.EmailTextBox.Text;

        }

        /// <summary>
        /// On click shows the change password dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowChangePasswordDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            ChangePasswordDialog = new ChangePasswordDialog();
            // Adds it to the page grid

           //gia na mhn kollaei sto ena column to prwto 
            Grid.SetColumnSpan(ChangePasswordDialog, 3);
            PageGrid.Children.Add(ChangePasswordDialog);

            // Sets the is open property to true
            ChangePasswordDialog.IsDialogOpen = true;
        }

        #endregion

    }
}
