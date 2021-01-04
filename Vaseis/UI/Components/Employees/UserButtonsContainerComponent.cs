using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The area filled with the employee buttons in the Employees page
    /// </summary>
    public class UserButtonsContainerComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        ///  The grid container of all the user buttons
        /// </summary>
        protected Grid UserButtonsGrid { get; private set; }

        #endregion

        #region Constructors

        public UserButtonsContainerComponent()
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
            // The grid containing the buttons
            var UserButtonsGrid = new Grid()
            {
                Margin = new Thickness(32),
            };
            
            // For four times...
            for(var i  = 0; i <= 4 - 1; i++)
            {
                // Adds to the buttons' grid a column
                UserButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
            }

            // Test list with users
            var users = new List<UserButtonComponent>()
            {
                new UserButtonComponent(){ Username = "PapLA", FullName = "Labros Papadopoulos", Background = "ff4455".HexToBrush() },
                new UserButtonComponent(){ Username = "PapLA", FullName = "Labros Papadopoulos", Background = "ff4455".HexToBrush() },
                new UserButtonComponent(){ Username = "XxMariaxX", FullName = "Maria Tsavea", Background = HookersGreen.HexToBrush() },
                new UserButtonComponent(){ Username = "XxMariaxX", FullName = "Maria Tsavea", Background = HookersGreen.HexToBrush() },
                new UserButtonComponent(){ Username = "PapAI", FullName = "Aikaterini Papadopoulou", Background = DarkBlue.HexToBrush()},
                new UserButtonComponent(){ Username = "PapAI", FullName = "Aikaterini Papadopoulou", Background = DarkBlue.HexToBrush()},
                new UserButtonComponent(){ Username = "Kwstakiss", FullName = "Kwstantina Robot", Background = DarkGray.HexToBrush() },
                new UserButtonComponent(){ Username = "Kwstakiss", FullName = "Kwstantina Robot", Background = DarkGray.HexToBrush() },
                new UserButtonComponent(){ Username = "vKokkala", FullName = "Vasiliki Kokkala", Background = DarkPink.HexToBrush() },
                new UserButtonComponent(){ Username = "vKokkala", FullName = "Vasiliki Kokkala", Background = DarkPink.HexToBrush() },
                new UserButtonComponent(){ Username = "XxMariaxX", FullName = "Maria Tsavea", Background = HookersGreen.HexToBrush() },
                new UserButtonComponent(){ Username = "XxMariaxX", FullName = "Maria Tsavea", Background = HookersGreen.HexToBrush() },
                new UserButtonComponent(){ Username = "Fwtoula77", FullName = "Fwteini Aggelaki", Background = LightBlue.HexToBrush() },
                new UserButtonComponent(){ Username = "Fwtoula77", FullName = "Fwteini Aggelaki", Background = LightBlue.HexToBrush() },
                new UserButtonComponent(){ Username = "SpamSoundMess", FullName = "Aikaterina Mitropoulou", Background = Yellow.HexToBrush() },
                new UserButtonComponent(){ Username = "SpamSoundMess", FullName = "Aikaterina Mitropoulou", Background = Yellow.HexToBrush() },
                new UserButtonComponent(){ Username = "kKMitsosKk", FullName = "Dimitris Kostorizos", Background = GreenBlue.HexToBrush() },
                new UserButtonComponent(){ Username = "kKMitsosKk", FullName = "Dimitris Kostorizos", Background = GreenBlue.HexToBrush() },
                new UserButtonComponent(){ Username = "Lime", FullName = "Trianafillos Papathanasopoulos", Background = Orange.HexToBrush() },
                new UserButtonComponent(){ Username = "Lime", FullName = "Trianafillos Papathanasopoulos", Background = Orange.HexToBrush() },
                new UserButtonComponent(){ Username = "Matakia", FullName = "Tsomaros Vlachogiannis", Background = LightBlue.HexToBrush() },
                new UserButtonComponent(){ Username = "Matakia", FullName = "Tsomaros Vlachogiannis", Background = LightBlue.HexToBrush() },
            };

            // Sets the column index to 0
            var columnIndex = 0;
            // Sets the row index to 0
            var rowIndex = 0;

            // For each user in the users list...
            foreach (var user in users)
            {
                // Adds the user button to the grid
                UserButtonsGrid.Children.Add(user);

                // If it is the first column...
                if(columnIndex == 0)
                {
                    // Adds a new row with fixed height
                    UserButtonsGrid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(180, GridUnitType.Pixel)
                    });
                }

                // Sets the user to the according column index
                Grid.SetColumn(user, columnIndex);
                // Sets the user to the according row index
                Grid.SetRow(user, rowIndex);
                // Increments the column's index by 1
                columnIndex++;

                // If the column index is 4...
                if (columnIndex == 4)
                {
                    // Sets column index to 0
                    columnIndex = 0;
                    // Increments the row's index by 1
                    rowIndex++;
                }
            }

            // The component's content is the grid
            Content = UserButtonsGrid;
        }

        #endregion

    }
}
