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
    public class EmployeeButtonsContainerComponent : ContentControl
    {

        #region Constructors

        public EmployeeButtonsContainerComponent()
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
            var employeeButtonsGrid = new Grid()
            {
                Margin = new Thickness(32),
            };
            
            for(var i  = 0; i <= 4 - 1; i++)
            {
                employeeButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
            }

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

            var columnIndex = 0;
            var rowIndex = 0;

            foreach (var user in users)
            {
                employeeButtonsGrid.Children.Add(user);

                if(columnIndex == 0)
                {
                    employeeButtonsGrid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(180, GridUnitType.Pixel)
                    });
                }

                Grid.SetColumn(user, columnIndex);

                Grid.SetRow(user, rowIndex);
                columnIndex++;

                if (columnIndex == 4)
                {
                    columnIndex = 0;
                    rowIndex++;
                }
            }

            Content = employeeButtonsGrid;
        }


        #endregion

    }
}
