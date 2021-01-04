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

            var imageAndTitle = new ImageAndNameComponent()
            {
                Text = "username",
                ImagePath = @"pack://application:,,,/UI/Images/employee.png",
            };

            PersonalDataStackPanel.Children.Add(imageAndTitle);

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

            var Bar = new Border()
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

            var CompanyDataStackPanel = new StackPanel()
            {
                Margin = new Thickness(32),
            };

            var EditButtons = new EditComponent
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };
            CompanyDataStackPanel.Children.Add(EditButtons);

            var JobTitleBlock = new TextBlock()
            {
                FontSize = 60,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = "Software Engineer",
            };
            CompanyDataStackPanel.Children.Add(JobTitleBlock);

            // Creates a bio tile
            var BioTile = new BioComponent()
            {
                Margin = new Thickness(32),
                BioText = "Tutankhamun, colloquially known as King Tut, was the 12th pharaoh of the 18th Egyptian dynasty, in power from approximately 1332 to 1323 B.C.E. "
                        + "\n\nDuring his reign, Tutankhamun accomplished little. However, his powerful advisers restored the traditional Egyptian religion, which had been set aside by his father, Akhenaten, who led the \"Amarna Revolution.\" "
                        + "\n\nAfter his death at age 19, King Tut disappeared from history until the discovery of his tomb in 1922. Since then, studies of his tomb and remains have revealed much information about his life and times, making Tutankhamun one of the best known ancient Egyptian kings."
            };
            // Adds to the grid the bio
            CompanyDataStackPanel.Children.Add(BioTile);

            var DataButtonsGrid = new UniformGrid()
            {
                Columns = 3,
            };
            CompanyDataStackPanel.Children.Add(DataButtonsGrid);

            var DataButton = StyleHelpers.CreateDataButton(White, "Awards");
            var DataButton2 = StyleHelpers.CreateDataButton(White, "Certificates");
            var DataButton3 = StyleHelpers.CreateDataButton(White, "Recommendations");
            var DataButton4 = StyleHelpers.CreateDataButton(White, "Languages");
            var DataButton5 = StyleHelpers.CreateDataButton(White, "Projects");
            var DataButton6 = StyleHelpers.CreateDataButton(White, "Degrees");


            DataButtonsGrid.Children.Add(DataButton);
            DataButtonsGrid.Children.Add(DataButton2);
            DataButtonsGrid.Children.Add(DataButton3);
            DataButtonsGrid.Children.Add(DataButton4);
            DataButtonsGrid.Children.Add(DataButton5);
            DataButtonsGrid.Children.Add(DataButton6);

            var DataScrollViewer = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Content = CompanyDataStackPanel
            };
            // Adds the scroll viewer to the page's grid
            PageGrid.Children.Add(DataScrollViewer);
            // Sets the scroll viewer on the third column
            Grid.SetColumn(DataScrollViewer, 2);

            Content = PageGrid;
        }

        #endregion

    }
}
