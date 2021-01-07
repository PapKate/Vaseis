using MaterialDesignThemes.Wpf;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        protected NavigationButtonComponent NavButtonAndText { get; private set; }

        /// <summary>
        /// Contains the text and icon for each button
        /// </summary>
        protected Dictionary<string, PackIconKind> ButtonData { get; private set; }
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

            // For each button data in the dictionary...
            foreach (var buttonData in ButtonData)
            {
                // Creates a nav button
                NavButtonAndText = new NavigationButtonComponent()
                {
                    ButtonText = buttonData.Key,
                    ButtonIcon = buttonData.Value,
                    Width = x
                };
                // Adds it to the stack panel
                NavButtonsStackPanel.Children.Add(NavButtonAndText);
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
