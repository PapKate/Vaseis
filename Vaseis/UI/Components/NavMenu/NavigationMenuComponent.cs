using MaterialDesignThemes.Wpf;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The navigation menu for profile page
    /// </summary>
    public class NavigationMenuComponent : NavigationButtonComponent 
    {
        #region Protected Properties

        /// <summary>
        /// The grid containing the bars and buttons stack panels
        /// </summary>
        protected Grid NavGrid { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected Border NavBar { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected StackPanel NavBarsStackPanel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected StackPanel NavButtonsStackPanel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected NavigationButtonComponent DegreesButtonAndText { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected NavigationButtonComponent CertificatesButtonAndText { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected NavigationButtonComponent AwardsButtonAndText { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected NavigationButtonComponent RecPappersButtonAndText { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected NavigationButtonComponent LanguagesButtonAndText { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected NavigationButtonComponent ProjectsButtonAndText { get; private set; }

        /// <summary>
        /// Contains the text and icon for each button
        /// </summary>
        protected Dictionary<string, PackIconKind> ButtonData { get; private set; }
        #endregion

        #region Dependency Properties

        #region AddAwardCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand AddAwardCommand
        {
            get { return (ICommand)GetValue(AddAwardCommandProperty); }
            set { SetValue(AddAwardCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AddAwardCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddAwardCommandProperty = DependencyProperty.Register(nameof(AddAwardCommand), typeof(ICommand), typeof(NavigationMenuComponent));

        #endregion

        #region AddCertificateCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand AddCertificateCommand
        {
            get { return (ICommand)GetValue(AddCertificateCommandProperty); }
            set { SetValue(AddCertificateCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AddCertificateCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddCertificateCommandProperty = DependencyProperty.Register(nameof(AddCertificateCommand), typeof(ICommand), typeof(NavigationMenuComponent));

        #endregion

        #region AddLanguageCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand AddLanguageCommand
        {
            get { return (ICommand)GetValue(AddLanguageCommandProperty); }
            set { SetValue(AddLanguageCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AddLanguageCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddLanguageCommandProperty = DependencyProperty.Register(nameof(AddLanguageCommand), typeof(ICommand), typeof(NavigationMenuComponent));

        #endregion

        #region AddDegreeCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand AddDegreeCommand
        {
            get { return (ICommand)GetValue(AddDegreeCommandProperty); }
            set { SetValue(AddDegreeCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AddDegreeCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddDegreeCommandProperty = DependencyProperty.Register(nameof(AddDegreeCommand), typeof(ICommand), typeof(NavigationMenuComponent));

        #endregion

        #region AddProjectCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand AddProjectCommand
        {
            get { return (ICommand)GetValue(AddProjectCommandProperty); }
            set { SetValue(AddProjectCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AddProjectCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddProjectCommandProperty = DependencyProperty.Register(nameof(AddProjectCommand), typeof(ICommand), typeof(NavigationMenuComponent));

        #endregion

        #region AddRecPapperCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand AddRecPapperCommand
        {
            get { return (ICommand)GetValue(AddRecPapperCommandProperty); }
            set { SetValue(AddRecPapperCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="AddRecPapperCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty AddRecPapperCommandProperty = DependencyProperty.Register(nameof(AddRecPapperCommand), typeof(ICommand), typeof(NavigationMenuComponent));

        #endregion

        #endregion

        #region Constructors

        public NavigationMenuComponent()
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
            // Creates and adds the required text and icon for each nav button
            ButtonData = new Dictionary<string, PackIconKind>()
            {
                { "Awards", PackIconKind.TrophyAward },
                { "Certificates", PackIconKind.Certificate },
                { "Recommendation papers", PackIconKind.FileStar },
                { "Languages", PackIconKind.Translate },
                { "Degrees", PackIconKind.FileCertificate },
                { "Projects", PackIconKind.BookAccount }
            };

            // Creates the nav menu's grid
            NavGrid = new Grid()
            {
                VerticalAlignment = VerticalAlignment.Center,
            };

            // The nav button component's width
            var x = 160;
            // The nav button's width
            var y = NavigationButton.Width;
            // The margin for the bar from each button
            var z = 8;
            // Half the button's width plus the bar's margin
            var l = y / 2 + z;
            // The half bar's width 
            var k = (x - y) / 2 - z;
            // Index counting the buttons created 
            var i = 0;

            // Creates the navigation menu's stack panel
            NavButtonsStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Orientation = Orientation.Horizontal,
            };
            // Adds the buttons to the grid
            NavGrid.Children.Add(NavButtonsStackPanel);
            
            // Creates the bars stack panel
            NavBarsStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(x / 2, 0, x / 2, y / 2)
            };
            // Adds the bars to the grid
            NavGrid.Children.Add(NavBarsStackPanel);

            AwardsButtonAndText = new NavigationButtonComponent()
            {
                ButtonText = "Add Award",
                ButtonIcon = PackIconKind.TrophyAward,
                Width = x
            };
            // Adds it to the stack panel
            NavButtonsStackPanel.Children.Add(AwardsButtonAndText);

            AwardsButtonAndText.NavigationButton.SetBinding(Button.CommandProperty, new Binding(nameof(AddAwardCommand))
            { 
                Source = this
            });

            CertificatesButtonAndText = new NavigationButtonComponent()
            {
                ButtonText = "Add Certificate",
                ButtonIcon = PackIconKind.Certificate,
                Width = x
            };
            // Adds it to the stack panel
            NavButtonsStackPanel.Children.Add(CertificatesButtonAndText);

            CertificatesButtonAndText.NavigationButton.SetBinding(Button.CommandProperty, new Binding(nameof(AddCertificateCommand))
            {
                Source = this
            });

            LanguagesButtonAndText = new NavigationButtonComponent()
            {
                ButtonText = "Add Language",
                ButtonIcon = PackIconKind.Translate,
                Width = x
            };
            // Adds it to the stack panel
            NavButtonsStackPanel.Children.Add(LanguagesButtonAndText);

            LanguagesButtonAndText.NavigationButton.SetBinding(Button.CommandProperty, new Binding(nameof(AddLanguageCommand))
            {
                Source = this
            });

            ProjectsButtonAndText = new NavigationButtonComponent()
            {
                ButtonText = "Add Project",
                ButtonIcon = PackIconKind.BookAccount,
                Width = x
            };
            // Adds it to the stack panel
            NavButtonsStackPanel.Children.Add(ProjectsButtonAndText);

            ProjectsButtonAndText.NavigationButton.SetBinding(Button.CommandProperty, new Binding(nameof(AddProjectCommand))
            {
                Source = this
            });

            DegreesButtonAndText = new NavigationButtonComponent()
            {
                ButtonText = "Add Degree",
                ButtonIcon = PackIconKind.FileCertificate,
                Width = x
            };
            // Adds it to the stack panel
            NavButtonsStackPanel.Children.Add(DegreesButtonAndText);

            DegreesButtonAndText.NavigationButton.SetBinding(Button.CommandProperty, new Binding(nameof(AddDegreeCommand))
            {
                Source = this
            });

            RecPappersButtonAndText = new NavigationButtonComponent()
            {
                ButtonText = "Add Recommendation paper",
                ButtonIcon = PackIconKind.FileStar,
                Width = x
            };
            // Adds it to the stack panel
            NavButtonsStackPanel.Children.Add(RecPappersButtonAndText);

            RecPappersButtonAndText.NavigationButton.SetBinding(Button.CommandProperty, new Binding(nameof(AddRecPapperCommand))
            {
                Source = this
            });

            // For each button data in the dictionary...
            foreach (var buttonData in ButtonData)
            {
                // Increments the index by one, declaring one button was created
                i++;

                // If the last button has been created
                if (i == ButtonData.Count)
                    // Leaves the for each.
                    break;

                // Creates a nav bar
                NavBar = new Border()
                {
                    Width = 2 * k,
                    Height = 8,
                    CornerRadius = new CornerRadius(4),
                    Background = White.HexToBrush(),
                    Effect = ControlsFactory.CreateShadow(),
                    Margin = new Thickness(l, 0, l, 0)
                };
                // Adds it to the nav bars stack panel
                NavBarsStackPanel.Children.Add(NavBar);
            }

            // Sets the component's content as the nav grid
            Content = NavGrid;
        }

        

        #endregion

    }
}
