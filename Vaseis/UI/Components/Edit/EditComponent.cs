using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The edit section with edit, save and cancel button
    /// </summary>
    public class EditComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The edit button
        /// </summary>
        public Button EditButton { get; private set; }

        /// <summary>
        /// The save button
        /// </summary>
        public Button SaveButton { get; private set; }

        /// <summary>
        /// The cancel button
        /// </summary>
        public Button CancelButton { get; private set; }

        /// <summary>
        /// The container grid
        /// </summary>
        public Grid ButtonsGrid { get; private set; }

        #endregion

        #region Dependency Properties



        #endregion

        #region Constructors

        public EditComponent()
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
            ButtonsGrid = new Grid()
            {

            };
            // Adds two columns
            ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());
            ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Creates the save button
            SaveButton = ControlsFactory.CreateCheckButton();
            SaveButton.Click += SaveData;
            SaveButton.Visibility = Visibility.Collapsed;

            // Adds it to the grid
            ButtonsGrid.Children.Add(SaveButton);
            Grid.SetColumn(SaveButton, 1);

            // Creates the edit button
            EditButton = ControlsFactory.CreateEditButton();
            EditButton.Click += EditData;
            
            // Adds it to the grid
            ButtonsGrid.Children.Add(EditButton);
            Grid.SetColumn(EditButton, 1);

            // Creates the cancel button
            CancelButton = ControlsFactory.CreateCloseButton();
            CancelButton.Margin = new Thickness(0, 0, 24, 0);
            CancelButton.Click += CancelEdit;
            CancelButton.Visibility = Visibility.Collapsed;

            // Adds it to the grid
            ButtonsGrid.Children.Add(CancelButton);
            Grid.SetColumn(CancelButton, 0);

            // Sets the component's content as the buttons' grid
            Content = ButtonsGrid;
        }

        /// <summary>
        /// On click returns to edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveData(object sender, RoutedEventArgs e)
        {
            CancelButton.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Collapsed;
            EditButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// On click returns to edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEdit(object sender, RoutedEventArgs e)
        {
            CancelButton.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Collapsed;
            EditButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// On click shows save and cancel buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditData(object sender, RoutedEventArgs e)
        {
            CancelButton.Visibility = Visibility.Visible;
            SaveButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Collapsed;
           
        }


        #endregion

    }
}
