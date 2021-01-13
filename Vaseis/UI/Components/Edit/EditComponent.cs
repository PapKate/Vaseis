using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
        protected Button EditButton { get; private set; }

        /// <summary>
        /// The save button
        /// </summary>
        protected Button SaveButton { get; private set; }

        /// <summary>
        /// The cancel button
        /// </summary>
        protected Button CancelButton { get; private set; }

        /// <summary>
        /// The container grid
        /// </summary>
        protected Grid ButtonsGrid { get; private set; }

        #endregion

        #region Dependency Properties

        #region EditCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EditCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(nameof(EditCommand), typeof(ICommand), typeof(EditComponent));

        #endregion

        #region CancelCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CancelCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand), typeof(EditComponent));

        #endregion

        #region SaveCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SaveCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SaveCommandProperty = DependencyProperty.Register(nameof(SaveCommand), typeof(ICommand), typeof(EditComponent));

        #endregion

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
            SaveButton.SetBinding(Button.CommandProperty, new Binding(nameof(SaveCommand))
            {
                Source = this
            });

            // Adds it to the grid
            ButtonsGrid.Children.Add(SaveButton);
            Grid.SetColumn(SaveButton, 1);

            // Creates the edit button
            EditButton = ControlsFactory.CreateEditButton();
            EditButton.Click += EditData;
            EditButton.SetBinding(Button.CommandProperty, new Binding(nameof(EditCommand))
            { 
                Source = this
            });
         
            // Adds it to the grid
            ButtonsGrid.Children.Add(EditButton);
            Grid.SetColumn(EditButton, 1);

            // Creates the cancel button
            CancelButton = ControlsFactory.CreateCloseButton();
            CancelButton.Margin = new Thickness(0, 0, 24, 0);
            CancelButton.Click += CancelEdit;
            CancelButton.Visibility = Visibility.Collapsed;
            CancelButton.SetBinding(Button.CommandProperty, new Binding(nameof(CancelCommand))
            {
                Source = this
            });

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
