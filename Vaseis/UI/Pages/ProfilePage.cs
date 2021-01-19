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
        /// /The user
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
        /// The employees first name
        /// </summary>
        protected TitleAndTextComponent FirstNameData { get; private set; }

        /// <summary>
        /// The employees last name
        /// </summary>
        protected TitleAndTextComponent LastNameData { get; private set; }
        
        /// <summary>
        /// The employee's company name
        /// </summary>
        protected TitleAndTextComponent CompanyData { get; private set; }

        /// <summary>
        /// The employees years of experience
        /// </summary>
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

        /// <summary>
        /// The evaluator's average grade
        /// </summary>
        protected TextBlock EvalsAverage { get; private set; }

        #endregion

        #region Dependency Properties

       
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

        #region Protected Methods

        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (User.Type == UserType.Evaluator)
            {
                var evaluations = await Services.GetDataStorage.GetEvaluatorEvaluations(User.Id, true);
                var count = evaluations.Count;
                var sum = 0.0;
                // For each evaluation...
                foreach (var evaluation in evaluations)
                {
                    // Add their final grade
                    sum = sum + (float)evaluation.FinalGrade/100;
                }
                
                EvalsAverage.Text = "Evaluator's Average : " + (sum / count).ToString();             
            }
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
                Width = 360,
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


            if (User.Type != UserType.Administrator)
            {
                // Creates the company text blocks
                CompanyData = new TitleAndTextComponent()
                {
                    Title = "Company",

                    Text = User.Department.Company.Name,

                    Margin = new Thickness(16)
                };
                // Adds them to the stack panel
                PersonalDataStackPanel.Children.Add(CompanyData);
            }

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

            string jobPosition = User.Type.ToString();

            if (User.Type == UserType.Employee)
                jobPosition = User.JobPosition.Job.JobTitle;

            // Creates the job title's text block
            JobTitleBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = jobPosition,
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(JobTitleBlock);

            //The evaluators Average (taken after a sum through joins)

            //The evaluators Average 
            // Creates the evaluator's average text block
            EvalsAverage = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
               
            };
            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(EvalsAverage);
      

            //if he aint evaluator we dont want his evaluator average to be shown
            if (User.Type == UserType.Evaluator) { }
            else { EvalsAverage.Visibility = Visibility.Collapsed; }

            if (User.Type != UserType.Administrator)
            {
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
            }

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

            // For each award...
            foreach (var award in User.Awards)
            {
                // Add to the awards list a string with the award's name and its acquired date
                awards.Add($"{award.Name}, {award.AcquiredDate.ToShortDateString()}");
            };

            AwardsContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
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
                HorizontalAlignment = HorizontalAlignment.Left,
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
                HorizontalAlignment = HorizontalAlignment.Left,
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
