using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The dialog for creating a job position 
    /// </summary>
    public class NewJobPositionDialogComponent : JobPositionDialogComponent
    {
        #region Public Properties

        /// <summary>
        /// The evaluator
        /// </summary>
        public UserDataModel Evaluator { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The JobPostion create Button
        /// </summary>
        protected Button CreateButton { get; private set; }


        #endregion

        #region Dependency Properties

        #region CreateCommand

        /// <summary>
        /// The dialog's create command
        /// </summary>
        public ICommand CreateCommand
        {
            get { return (ICommand)GetValue(CreateCommandProperty); }
            set { SetValue(CreateCommandProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="CreateCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CreateCommandProperty = DependencyProperty.Register(nameof(CreateCommand), typeof(ICommand), typeof(NewJobPositionDialogComponent));

        #endregion


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NewJobPositionDialogComponent(UserDataModel evaluator)
        {
            Evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Saves the new values in the data grid
        /// </summary>
        protected void CreateJobPositionOnClick(object sender, RoutedEventArgs e)
        {
            // Closes the dialog
            DialogHost.IsOpen = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(DarkPink, "Create");
            CreateButton.SetBinding(Button.CommandProperty, new Binding(nameof(CreateCommand))
            { 
                Source = this
            });
            CreateButton.Click += CreateJobPositionOnClick;
            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);
        }

        #endregion
    }
}
