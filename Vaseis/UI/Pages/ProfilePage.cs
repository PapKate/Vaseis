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

        protected TitleAndTextComponent FirstNameData { get; private set; }


        protected TitleAndTextComponent LastNameData { get; private set; }

        protected TitleAndTextComponent CompanyData { get; private set; }

        protected TitleAndTextComponent YearsOfXp { get; private set; }




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
        /// The user's email BioComponent (editText - textBlock)
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

        #region EvaluatorsAverage

        /// <summary>
        /// The user's EvaluatorsAverage
        /// </summary>
        public string EvaluatorsAverage
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

            // Creates the page's grid
            PageGrid = new Grid()
            {
            };
            // Adds the required columns
            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });
            
            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });
            // Last column takes remaining space of the page's grid
            PageGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            #endregion

            #region Personal Data 

            // Creates the personal data's stack panel
            PersonalDataStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(16)
            };

            // Creates an image an name component for the user profile image and username
            ImageAndTitle = new ImageAndNameComponent()
            {
                Text = User.Username,

                ImagePath = User.ProfilePicture,
            };
            // Adds it to the stack panel
            PersonalDataStackPanel.Children.Add(ImageAndTitle);

            // Adds the stack panel to the page
            PageGrid.Children.Add(PersonalDataStackPanel);
            // Sets the stack panel to the first grid's column
            Grid.SetColumn(PersonalDataStackPanel, 0);

            #region PersonalData

            // Creates the first name text blocks
            FirstNameData = new TitleAndTextComponent()
            {
                Title = "First name",

                Text = User.FirstName,

                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(FirstNameData);

            // Creates the last name text blocks
            LastNameData = new TitleAndTextComponent()
            {
                Title = "Last name",
                Text = User.LastName,
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(LastNameData);

            // Creates the company text blocks
            CompanyData = new TitleAndTextComponent()
            {
                Title = "Company",

                Text = User.Company.Name,

                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(CompanyData);

            // Creates the years of experience title and text component
            YearsOfXp = new TitleAndTextComponent()
            {
                Title = "Years of experience",

                Text = User.YearsOfExperience.ToString(),

                Margin = new Thickness(16),
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(YearsOfXp);

            // Creates the email BioComponent
            EmailData = new EditableTextComponent()
            {
                Title = "Email",
                Text = User.Email,
                Margin = new Thickness(16)
            };
            // Adds it to the stack panel
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
                    Text = "Change Password"
                },
            };
            // On click calls method
            ChangePassword.Click += ShowChangePasswordDialogOnClick;
            // Adds it to the stack panel
            PersonalDataStackPanel.Children.Add(ChangePassword);

            #endregion

            #endregion

            // Creates the bar
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

            CompanyDataStackPanel = new StackPanel()
            {
                Margin = new Thickness(32),
            };

            #region Edit Buttons

            // Creates the edit buttons
            EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                // Sets the edit command
                EditCommand = new RelayCommand(() => 
                { 
                    // Sets the components' editable properties to true
                    BioTile.IsEditable = true; 
                    EmailData.IsEditable = true; 
                }),
                SaveCommand = new RelayCommand(() => 
                {
                    // Sets the components' editable properties to false
                    BioTile.IsEditable = false; 
                    EmailData.IsEditable = false;
                    // Sets the components' save edit properties to true
                    BioTile.SaveEdit = true; 
                    EmailData.SaveEdit = true; 
                }),
                CancelCommand = new RelayCommand(() => 
                {
                    // Sets the components' editable properties to false
                    BioTile.IsEditable = false; 
                    EmailData.IsEditable = false;
                    // Sets the components' save edit properties to true
                    BioTile.SaveEdit = false;
                    EmailData.SaveEdit = false; 
                })
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(EditButtons);

            #endregion 

            // Creates the job title's text block
            JobTitleBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = User.JobPosition.Job.JobTitle,
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(JobTitleBlock);

            //The evaluators Average (taken after a sum through joins)

            //The evaluators Average 
            // Creates the evaluator's average text block
            var EvalsAverage = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = EvaluatorsAverage,
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(EvalsAverage);
            // Binds the text property of the text block to the Evaluator's Average property
            EvalsAverage.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluatorsAverage))
            {
                Source = this
            });

            // Creates the department's text block
            DepartmentTitleBlock = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = User.Department.DepartmentName.ToString(),
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(DepartmentTitleBlock);

            // Creates a bio tile
            BioTile = new BioComponent()
            {
                BioTextTitle = "Bio",
                Margin = new Thickness(32),
                BioText = User.Bio
            };
            // Adds to the grid the bio
            CompanyDataStackPanel.Children.Add(BioTile);

            FileDataGrid = new UniformGrid()
            {
                Columns = 2,
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(FileDataGrid);

            #region Awards

            //Did this to dd the awards into the awardsContainer because, the User.Awards returns AwardDataModel List
            var awards = new List<string>();

            foreach (var award in User.Awards)
            {
                awards.Add(award.AwardData);
            };
            
            AwardsContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Awards",
                DataNames = awards
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(AwardsContainer);

            #endregion

            #region Certificates

            //Did this to dd the awards into the awardsContainer because, the User.Certificates returns CertificatesDataModel List
            var certificates = new List<string>();

            foreach (var certificate in User.Certificates)
            {
                certificates.Add(certificate.Title);
            };

            CertificatesContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Certificates",
                DataNames = certificates
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(CertificatesContainer);

            #endregion

            #region Recommendation Papers

            //Did this to dd the awards into the awardsContainer because, the User.Certificates returns CertificatesDataModel List
            var recommendationPapers = new List<string>();

            foreach (var recommendationPaper in User.RecommendationPapers)
            {
                recommendationPapers.Add(recommendationPaper.Description);
            };

            RecommendationPapersContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Recommendation papers",
                DataNames = recommendationPapers
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(RecommendationPapersContainer);

            #endregion


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

        /// <summary>
        /// On click shows the change password dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowChangePasswordDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            ChangePasswordDialog = new ChangePasswordDialog(User);
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
