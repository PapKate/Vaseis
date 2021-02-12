using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using static Vaseis.Styles;
using static Vaseis.MaterialDesignStyles;
using System;
using System.Linq;

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
        public UserDataModel User { get; set; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The change password dialog component
        /// </summary>
        protected ChangePasswordDialog ChangePasswordDialog { get; private set; }

        /// <summary>
        /// The add award dialog component
        /// </summary>
        protected AddAwardDialog AddAwardDialog { get; private set; }


        /// <summary>
        /// The add certificate dialog component
        /// </summary>
        protected AddCertificateDialog AddCertificateDialog { get; private set; }


        /// <summary>
        /// The add language dialog component
        /// </summary>
        protected AddLanguageDialog AddLanguageDialog { get; private set; }



        /// <summary>
        /// The add language dialog component
        /// </summary>
        protected AddProjectDialog AddProjectDialog { get; private set; }

        /// <summary>
        /// The add award dialog component
        /// </summary>
        protected AddRecommendationPaperDialog AddRecommendationPaperDialog { get; private set; }


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
        /// The stack panel for the user's awards
        /// </summary>
        protected StackPanel AwardsStackPanel { get; private set; }

        /// <summary>
        /// The stack panel for the user's rec
        /// </summary>
        protected StackPanel RecommendationPapersStackPanel { get; private set; }

        /// <summary>
        /// The stack panel for the user's languages
        /// </summary>
        protected StackPanel LanguagesStackPanel { get; private set; }


        /// <summary>
        /// The stack panel for the user's projects
        /// </summary>
        protected StackPanel ProjectsStackPanel { get; private set; }


        /// <summary>
        /// The stack panel for the user's certificates
        /// </summary>
        protected StackPanel CertificatesStackPanel { get; private set; }

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
        /// The user's languages
        /// </summary>
        protected TitleAndListComponent LanguagesContainer { get; private set; }

        /// <summary>
        /// The user's rec papers
        /// </summary>
        protected TitleAndListComponent RecommendationPapersContainer { get; private set; }

        /// <summary>
        /// The user's projects
        /// </summary>
        protected TitleAndListComponent ProjectsContainer { get; private set; }

        /// <summary>
        /// The Change Password Button that opens a dialogue button
        /// </summary>
        protected Button ChangePassword { get; private set; }

        /// <summary>
        /// The manager's add award button
        /// </summary>
        protected Button AddAward { get; private set; }

        /// <summary>
        /// The manager's add certificate button
        /// </summary>
        protected Button AddCertificate { get; private set; }

        /// <summary>
        /// The manager's add language button
        /// </summary>
        protected Button AddLanguage{ get; private set; }

        /// <summary>
        /// The manager's add recPaper button
        /// </summary>
        protected Button AddRecommendationPaper { get; private set; }

        /// <summary>
        /// The manager's add project button
        /// </summary>
        protected Button AddProject { get; private set; }

        /// <summary>
        /// The evaluator's average grade
        /// </summary>
        protected TextBlock EvalsAverage { get; private set; }

        #endregion

        #region Dependency Properties

        #region Awards

        /// <summary>
        /// The User's Awards
        /// </summary>
        public IEnumerable<AwardDataModel> Awards
        {
            get { return (IEnumerable<AwardDataModel>)GetValue(AwardsProperty); }
            set { SetValue(AwardsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Awards"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AwardsProperty = DependencyProperty.Register(nameof(Awards), typeof(IEnumerable<AwardDataModel>), typeof(ProfilePage), new PropertyMetadata(OnAwardsChanged));

        /// <summary>
        /// Handles the change of the <see cref="Awards"/> property
        /// </summary>
        private static void OnAwardsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ProfilePage;

            sender.OnAwardsChangedCore(e);
        }

        #endregion

        #region Recommendation Papers

        /// <summary>
        /// The User's Recommendation Papers
        /// </summary>
        public IEnumerable<RecommendationPaperDataModel> RecommendationPapers
        {
            get { return (IEnumerable<RecommendationPaperDataModel>)GetValue(RecommendationPapersProperty); }
            set { SetValue(RecommendationPapersProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="RecommendationPapers"/> dependency property
        /// </summary>
        public static readonly DependencyProperty RecommendationPapersProperty = DependencyProperty.Register(nameof(RecommendationPapers), typeof(IEnumerable<RecommendationPaperDataModel>), typeof(ProfilePage), new PropertyMetadata(OnRecommendationPapersChanged));

        /// <summary>
        /// Handles the change of the <see cref="Awards"/> property
        /// </summary>
        private static void OnRecommendationPapersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ProfilePage;

            sender.OnRecommendationPapersChangedCore(e);
        }

        #endregion

        #region Certificates

        /// <summary>
        /// The User's Certificates
        /// </summary>
        public IEnumerable<CertificateDataModel> Certificates
        {
            get { return (IEnumerable<CertificateDataModel>)GetValue(CertificatesProperty); }
            set { SetValue(CertificatesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Certificates"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CertificatesProperty = DependencyProperty.Register(nameof(Certificates), typeof(IEnumerable<CertificateDataModel>), typeof(ProfilePage), new PropertyMetadata(OnCertificatesChanged));

        /// <summary>
        /// Handles the change of the <see cref="Certificates"/> property
        /// </summary>
        private static void OnCertificatesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ProfilePage;

            sender.OnCertificatesChangedCore(e);
        }

        #endregion


        #region  Languages

        /// <summary>
        /// The User's Recommendation Papers
        /// </summary>
        public IEnumerable<LanguagesDataModel> Languages
        {
            get { return (IEnumerable<LanguagesDataModel>)GetValue(LanguagesProperty); }
            set { SetValue(LanguagesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Languages"/> dependency property
        /// </summary>
        public static readonly DependencyProperty LanguagesProperty = DependencyProperty.Register(nameof(Languages), typeof(IEnumerable<LanguagesDataModel>), typeof(ProfilePage), new PropertyMetadata(OnLanguagesChanged));

        /// <summary>
        /// Handles the change of the <see cref="Languages"/> property
        /// </summary>
        private static void OnLanguagesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ProfilePage;

            sender.OnLanguagesChangedCore(e);
        }

        #endregion

        #region Projects

        /// <summary>
        /// The User's Recommendation Papers
        /// </summary>
        public IEnumerable<ProjectDataModel> Projects
        {
            get { return (IEnumerable<ProjectDataModel>)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Projects"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ProjectsProperty = DependencyProperty.Register(nameof(Projects), typeof(IEnumerable<ProjectDataModel>), typeof(ProfilePage), new PropertyMetadata(OnProjectsChanged));

        /// <summary>
        /// Handles the change of the <see cref="Projects"/> property
        /// </summary>
        private static void OnProjectsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ProfilePage;

            sender.OnProjectsChangedCore(e);
        }

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
            Update();
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            Awards = User.Awards;
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

        #region OnChanged

        protected async void UpdateEdits(object sender, RoutedEventArgs e)
        {
            await Services.GetDataStorage.UpdateBioAndEmail(User, BioTile.BioText, EmailData.InputText);
        }

        /// <summary>
        /// Handles the change of the <see cref="ProfilePage.Awards"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnAwardsChanged(DependencyPropertyChangedEventArgs e)
        {

        }


        /// <summary>
        /// Handles the change of the <see cref="ProfilePage.RecommendationPapers"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnRecommendationPapersChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the change of the <see cref="ProfilePage.Certificates"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnCertificatesChanged(DependencyPropertyChangedEventArgs e)
        {

        }


        /// <summary>
        /// Handles the change of the <see cref="ProfilePage.Languages"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnLanguagesChanged(DependencyPropertyChangedEventArgs e)
        {

        }


        /// <summary>
        /// Handles the change of the <see cref="ProfilePage.Projects"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnProjectsChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

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

                // Creates the years of experience title and text component
                YearsOfXp = new TitleAndTextComponent()
                {
                    Title = "Years of experience",

                    Text = User.YearsOfExperience.ToString(),

                    Margin = new Thickness(16),
                };
                // Adds them to the stack panel
                PersonalDataStackPanel.Children.Add(YearsOfXp);
            }

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
                EditCommand = new RelayCommand(()=>
                {           
                    // Sets the components' editable properties to true
                    BioTile.IsEditable = true;
                    EmailData.IsEditable = true;
                }),
                SaveCommand = new RelayCommand(async () =>
                {
                    await Services.GetDataStorage.UpdateBioAndEmail(User, BioTile.BioTextBox.Text, EmailData.InputTextBox.Text);
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

            var jobPosition = User.Type.ToString();

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
      

            //if he ain't evaluator we don't want his evaluator average to be shown
            if (User.Type != UserType.Evaluator)
                 EvalsAverage.Visibility = Visibility.Collapsed;

            if (User.Type != UserType.Administrator)
            {
                // Creates the department's text block
                DepartmentTitleBlock = new TextBlock()
                {
                    FontSize = 32,
                    FontFamily = Calibri,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Foreground = DarkGray.HexToBrush(),
                    Text = User.Department.DepartmentName,
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

            AwardsStackPanel = new StackPanel();

            List<String> awards = new List<string>();

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

            AwardsStackPanel.Children.Add(AwardsContainer);

            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(AwardsStackPanel);

            #endregion

            #region Certificates

            CertificatesStackPanel = new StackPanel();

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

            CertificatesStackPanel.Children.Add(CertificatesContainer);

            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(CertificatesStackPanel);

            #endregion

            #region Languages


            LanguagesStackPanel = new StackPanel();

            var languages = new List<string>();

            if (User.Languages != null)
            {
                foreach (var language in User.Languages)
                {
                    languages.Add(language.Name.ToString());
                };
            }

            LanguagesContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Title = "Languages",
                DataNames = languages
            };

            LanguagesStackPanel.Children.Add(LanguagesContainer);

            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(LanguagesStackPanel);

            #endregion

            #region Projects

            ProjectsStackPanel = new StackPanel();

            var projects = new List<string>();
            if(User.Projects != null)
            {
                foreach (var project in User.Projects)
                {
                    projects.Add(project.Title);
                };

            }
            
            ProjectsContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Title = "Projects",
                DataNames = projects
            };

            ProjectsStackPanel.Children.Add(ProjectsContainer);

            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(ProjectsStackPanel);

            #endregion

            #region Recommendation Papers

            RecommendationPapersStackPanel = new StackPanel();

            //Did this to dd the awards into the awardsContainer because, the User.Certificates returns CertificatesDataModel List
            var recommendationPapers = new List<string>();

            foreach (var recommendationPaper in User.RecommendationPapers)
            {
                recommendationPapers.Add($"{recommendationPaper.Referee}\n{recommendationPaper.Description}");
            };

            RecommendationPapersContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Title = "Recommendation papers",
                DataNames = recommendationPapers
            };

            RecommendationPapersStackPanel.Children.Add(RecommendationPapersContainer);

            // Adds it to the stack panel
            CompanyDataStackPanel.Children.Add(RecommendationPapersStackPanel);

            #endregion

            #region Buttons

            var buttonsGrid = new UniformGrid()
            {
                Columns = 5
            };

            //The add awardButton
            AddAward = new Button()
            {
                Style = FlatButton,
                Background = GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = DarkBlue.HexToBrush(),
                    FontSize = 18,
                    Margin = new Thickness(8),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "Add award"
                },
            };
            // On click calls method
            AddAward.Click += ShowAddAwardOnClick;

            //The add awardButton
            AddCertificate = new Button()
            {
                Style = FlatButton,
                Background = GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = DarkBlue.HexToBrush(),
                    FontSize = 18,
                    Margin = new Thickness(8),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "Add certificate"
                },
            };
            // On click calls method
            AddCertificate.Click += ShowAddCertificateOnClick;

            //The add awardButton
            AddLanguage = new Button()
            {
                Style = FlatButton,
                Background = GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = DarkBlue.HexToBrush(),
                    FontSize = 18,
                    Margin = new Thickness(8),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "Add language"
                },
            };
            // On click calls method
            AddLanguage.Click += ShowAddLanguageOnClick;

            //The add awardButton
            AddProject = new Button()
            {
                Style = FlatButton,
                Background = DarkBlue.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = DarkBlue.HexToBrush(),
                    FontSize = 18,
                    Margin = new Thickness(8),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "Add project"
                },
            };
            // On click calls method
            AddProject.Click += ShowAddProjectOnClick;

            //The add awardButton
            AddRecommendationPaper = new Button()
            {
                Style = FlatButton,
                Background = GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = DarkBlue.HexToBrush(),
                    FontSize = 18,
                    Margin = new Thickness(8),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "Add recommendation paper"
                },
            };
            // On click calls method
            AddRecommendationPaper.Click += ShowAddRecommendationPaperOnClick;

            buttonsGrid.Children.Add(AddAward);
            buttonsGrid.Children.Add(AddCertificate);
            buttonsGrid.Children.Add(AddLanguage);
            buttonsGrid.Children.Add(AddProject);
            buttonsGrid.Children.Add(AddRecommendationPaper);

            if (User.Type != UserType.Manager)
            {
                AddAward.Visibility = Visibility.Hidden;
                AddCertificate.Visibility = Visibility.Hidden;
                AddLanguage.Visibility = Visibility.Hidden;
                AddProject.Visibility = Visibility.Hidden;
                AddRecommendationPaper.Visibility = Visibility.Hidden;
            }

            CompanyDataStackPanel.Children.Add(buttonsGrid);

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
            ChangePasswordDialog = new ChangePasswordDialog(User,PageGrid);
            // Adds it to the page grid
            PageGrid.Children.Add(ChangePasswordDialog);
            Grid.SetColumnSpan(ChangePasswordDialog, 3);

            // Sets the is open property to true
            ChangePasswordDialog.IsDialogOpen = true;
        }

        #endregion

        #region OnClick

        /// <summary>
        /// Add Award
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddAwardOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            AddAwardDialog = new AddAwardDialog(User, PageGrid, this);
            // Adds it to the page grid
            PageGrid.Children.Add(AddAwardDialog);
            Grid.SetColumnSpan(AddAwardDialog, 3);

            // Sets the is open property to true
            AddAwardDialog.IsDialogOpen = true;
        }


        /// <summary>
        /// Add Certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddCertificateOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            AddCertificateDialog = new AddCertificateDialog(User, PageGrid, this);
            // Adds it to the page grid
            PageGrid.Children.Add(AddCertificateDialog);
            Grid.SetColumnSpan(AddCertificateDialog, 3);

            // Sets the is open property to true
            AddCertificateDialog.IsDialogOpen = true;
        }

        /// <summary>
        /// Add Certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddLanguageOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            AddLanguageDialog = new AddLanguageDialog(User, PageGrid, this);
            // Adds it to the page grid
            PageGrid.Children.Add(AddLanguageDialog);
            Grid.SetColumnSpan(AddLanguageDialog, 3);

            // Sets the is open property to true
            AddLanguageDialog.IsDialogOpen = true;
        }

        /// <summary>
        /// Add Certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddProjectOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            AddProjectDialog = new AddProjectDialog(User, PageGrid, this);
            // Adds it to the page grid
            PageGrid.Children.Add(AddProjectDialog);
            Grid.SetColumnSpan(AddProjectDialog, 3);

            // Sets the is open property to true
            AddProjectDialog.IsDialogOpen = true;
        }

        /// <summary>
        /// Add Certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddRecommendationPaperOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            AddRecommendationPaperDialog = new AddRecommendationPaperDialog(User, PageGrid, this);
            // Adds it to the page grid
            PageGrid.Children.Add(AddRecommendationPaperDialog);
            Grid.SetColumnSpan(AddRecommendationPaperDialog, 3);

            // Sets the is open property to true
            AddRecommendationPaperDialog.IsDialogOpen = true;
        }

        #endregion

        #region Core


        /// <summary>
        /// Handles the change of the <see cref="Awards"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnAwardsChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<AwardDataModel>)e.NewValue;

            if (newValue == null)
            { 
            }
            else
            { // For each award...

                AwardsStackPanel.Children.Clear();

                List<String> awards = new List<string>();

                foreach (var award in Awards)
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
                AwardsStackPanel.Children.Add(AwardsContainer);

            }

            // Further handle the change
            OnAwardsChanged(e);
        }

        /// <summary>
        /// Handles the change of the <see cref="Certificates"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnCertificatesChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<CertificateDataModel>)e.NewValue;

            if (newValue == null)
            {
            }
            else
            { // For each award...

                CertificatesStackPanel.Children.Clear();

                List<String> certificates = new List<string>();

                foreach (var certificate in Certificates)
                {
                    // Add to the awards list a string with the award's name and its acquired date
                    certificates.Add($"{certificate.Title}, {certificate.Title}");
                };

                CertificatesContainer = new TitleAndListComponent()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Title = "Certificates",
                    DataNames = certificates
                };
                // Adds it to the stack panel
                AwardsStackPanel.Children.Add(CertificatesContainer);

            }

            // Further handle the change
            OnAwardsChanged(e);
        }


        /// <summary>
        /// Handles the change of the <see cref="Languages"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnLanguagesChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<LanguagesDataModel>)e.NewValue;

            if (newValue == null)
            {
            }
            else
            { // For each award...

                LanguagesStackPanel.Children.Clear();

                List<String> languages = new List<string>();

                foreach (var language in Languages)
                {
                    // Add to the awards list a string with the award's name and its acquired date
                    languages.Add(language.Name);
                };

                LanguagesContainer = new TitleAndListComponent()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Title = "Languages",
                    DataNames = languages
                };
                // Adds it to the stack panel
                LanguagesStackPanel.Children.Add(LanguagesContainer);

            }

            // Further handle the change
            OnAwardsChanged(e);
        }


        /// <summary>
        /// Handles the change of the <see cref="Projects"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnProjectsChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<ProjectDataModel>)e.NewValue;

            if (newValue == null)
            {
            }
            else
            { // For each award...

                ProjectsStackPanel.Children.Clear();

                List<String> projects = new List<string>();

                foreach (var project in Projects)
                {
                    // Add to the awards list a string with the award's name and its acquired date
                    projects.Add(project.Title);
                };

                ProjectsContainer = new TitleAndListComponent()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Title = "Project",
                    DataNames = projects
                };
                // Adds it to the stack panel
                ProjectsStackPanel.Children.Add(ProjectsContainer);

            }

            // Further handle the change
            OnProjectsChanged(e);
        }


        /// <summary>
        /// Handles the change of the <see cref="RecommendationPapers"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnRecommendationPapersChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<RecommendationPaperDataModel>)e.NewValue;

            if (newValue == null)
            {
            }
            else
            { // For each award...

                RecommendationPapersStackPanel.Children.Clear();

                List<String> recommendationPapers = new List<string>();

                foreach (var recommendationPaper in RecommendationPapers)
                {
                    // Add to the awards list a string with the award's name and its acquired date
                    recommendationPapers.Add($"{recommendationPaper.Referee}@\n, {recommendationPaper.Description}");
                };

                RecommendationPapersContainer = new TitleAndListComponent()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Title = "Recommendation Papers",
                    DataNames = recommendationPapers
                };
                // Adds it to the stack panel
                AwardsStackPanel.Children.Add(RecommendationPapersContainer);

            }

            // Further handle the change
            OnRecommendationPapersChanged(e);
        }


        #endregion

    }
}
