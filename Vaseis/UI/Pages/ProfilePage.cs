using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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
                Text = "username",
                ImagePath = @"pack://application:,,,/UI/Images/employee.png",
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
                Text = "Marika",
                Margin = new Thickness(24)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(FirstNameData);

            // Creates the last name text blocks
            var LastNameData = new TitleAndTextComponent()
            {
                Title = "Last name",
                Text = "Pentayiotissa",
                Margin = new Thickness(24)

            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(LastNameData);

            // Creates the company text blocks
            var CompanyData = new TitleAndTextComponent()
            {
                Title = "Company",
                Text = "EnchantmentLab",
                Margin = new Thickness(24)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(CompanyData);

            // Creates the email text blocks
            var EmailData = new TitleAndTextComponent()
            {
                Title = "Email",
                Text = "maria@mario.com",
                Margin = new Thickness(24)
            };
            // Adds them to the stack panel
            PersonalDataStackPanel.Children.Add(EmailData);
           
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
                Text = "Software Engineer",
            };
            CompanyDataStackPanel.Children.Add(JobTitleBlock);

            DepartmentTitleBlock = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = DarkGray.HexToBrush(),
                Text = "Department of: Development",
            };
            CompanyDataStackPanel.Children.Add(DepartmentTitleBlock);

            // Creates a bio tile
            BioTile = new BioComponent()
            {
                Margin = new Thickness(32),
                BioText = "Tutankhamun, colloquially known as King Tut, was the 12th pharaoh of the 18th Egyptian dynasty, in power from approximately 1332 to 1323 B.C.E. "
                        + "\n\nDuring his reign, Tutankhamun accomplished little. However, his powerful advisers restored the traditional Egyptian religion, which had been set aside by his father, Akhenaten, who led the \"Amarna Revolution.\" "
                        + "\n\nAfter his death at age 19, King Tut disappeared from history until the discovery of his tomb in 1922. Since then, studies of his tomb and remains have revealed much information about his life and times, making Tutankhamun one of the best known ancient Egyptian kings."
            };
            // Adds to the grid the bio
            CompanyDataStackPanel.Children.Add(BioTile);


            FileDataGrid = new UniformGrid()
            {
                Columns = 2,
            };
            CompanyDataStackPanel.Children.Add(FileDataGrid);

            AwardsContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Awards",
                DataNames = new List<string> { "Employee of the year, 2020", "Employee of the year, 2019", "The face of marketing department, 2019" }
            };

            CertificatesContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Certificates",
                DataNames = new List<string> { "Employee of the year, 2020", "Employee of the year, 2019", "The face of markerdrgrdggrdgdr rpgjdrpg prdojgdropgj pojgrd gp drgjodg ting department, 2019" }
            };

            RecommendationPapersContainer = new TitleAndListComponent()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Title = "Recommendation papers",
                DataNames = new List<string> { "Employee of the year, 2020", "Employee of the year, 2019", "The face of marketing department, 2019" }
            };

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
