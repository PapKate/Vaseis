using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public abstract class BaseView : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The user
        /// </summary>
        public UserDataModel User { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The view's grid
        /// </summary>
        protected Grid ViewGrid { get; private set; }

        /// <summary>
        /// The tab control
        /// </summary>
        protected TabControl TabControl { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseView(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Adds the side menu to the view grid
        /// </summary>
        /// <param name="sideMenu">The side menu</param>
        protected void CreateView(BaseSideMenuComponent sideMenu)
        {
            // Adds the side menu to the grid
            ViewGrid.Children.Add(sideMenu);
            // Sets it on its first column
            Grid.SetColumn(sideMenu, 0);
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // A grid for the side menu and the tab control
            ViewGrid = new Grid()
            {
                // Sets the background to white
                Background = White.HexToBrush()
            };

            // Set's a column with width 
            ViewGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(280, GridUnitType.Pixel)
            });

            // Set's a column with width the remaining width left in the grid
            ViewGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)

            });

            // Creates a tab control
            TabControl = new TabControl()
            {
                Background = GhostWhite.HexToBrush(),
                BorderThickness = new Thickness(0, 8, 0, 0),
                BorderBrush = DarkPink.HexToBrush()
            };
            // Adds it to the grid
            ViewGrid.Children.Add(TabControl);
            // On its second column
            Grid.SetColumn(TabControl, 1);

            // Sets the component's content as the view grid
            Content = ViewGrid;
        }

        #endregion

    }
}
