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
                ImagePath = User.ProfilePicture,
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
                Text = User.FirstName,
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(FirstNameData);

            // Creates the last name text blocks
            var LastNameData = new TitleAndTextComponent()
            {
                Title = "Last name",
                Text = User.LastName,
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(LastNameData);

            // Creates the company text blocks
            var CompanyData = new TitleAndTextComponent()
            {
                Title = "Company",
                Text = User.Company.Name,
                Margin = new Thickness(16)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(CompanyData);

            var YearsOfXp = new TitleAndTextComponent()
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

            PersonalDataStackPanel.Children.Add(EmailData);


            #region Change Password

            //The changepassword Button 
            ChangePassword = new Button()
            {
                Style = FlatButton,
                Background = Styles.GhostWhite.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = new TextBlock()
                {
                    Foreground = Styles.DarkBlue.HexToBrush(),
                    FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Styles.Calibri,
                    Text = "Change Password"
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

            CompanyDataStackPanel = new StackPanel()
            {
                Margin = new Thickness(32),
            };

            #region Edit Buttons

            EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                EditCommand = new RelayCommand(() => { BioTile.IsEditable = true; }),
                SaveCommand = new RelayCommand(() => { BioTile.IsEditable = false; BioTile.SaveEdit = true; }),
                CancelCommand = new RelayCommand(() => { BioTile.IsEditable = false; BioTile.SaveEdit = false; }),
            };
            CompanyDataStackPanel.Children.Add(EditButtons);

            #endregion 

            JobTitleBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = User.Job.JobTitle,
            };
            CompanyDataStackPanel.Children.Add(JobTitleBlock);

           //The evaluators Average (taken after a sum through joins)
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
                Text = User.Department.DepartmentName.ToString(),
            };
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
            CompanyDataStackPanel.Children.Add(FileDataGrid);

            #region Awards

            //Did this to dd the awards into the awardsContainer becasuse, the User.Awards returns AwardDataModel List
            List<string> awards = new List<string>();

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

            #endregion

            #region Certificates

            //Did this to dd the awards into the awardsContainer becasuse, the User.Certificates returns CertificatesDataModel List
            List<string> certificates = new List<string>();

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

            #endregion

            #region Recommenadtion Papers

            //Did this to dd the awards into the awardsContainer becasuse, the User.Certificates returns CertificatesDataModel List
            List<string> recommendationPapers = new List<string>();

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

            #endregion


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
