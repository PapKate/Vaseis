﻿using MaterialDesignThemes.Wpf;
using static Vaseis.Styles;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class NewUserInputDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The new user  Username input 
        /// </summary>
        protected TextInputComponent UsernameInput { get; private set; }

        /// <summary>
        /// The new user  email input 
        /// </summary>
        protected TextInputComponent EmailInput { get; private set; }

        /// <summary>
        /// The new user  lastname input 
        /// </summary>
        protected TextInputComponent LastNameInput { get; private set; }

        /// <summary>
        /// The new user  firstname input 
        /// </summary>
        protected TextInputComponent FirstNameInput { get; private set; }

        /// <summary>
        /// The new user  jobposition input 
        /// </summary>
        protected TextInputComponent JobPositionInput { get; private set; }

        /// <summary>
        /// The picker component for company
        /// </summary>
        protected PickerComponent CompanyPicker { get; private set; }

        /// <summary>
        /// The user type picker component
        /// </summary>
        protected PickerComponent UserTypePicker { get; private set; }

        /// <summary>
        /// The department picker component
        /// </summary>
        protected PickerComponent DepartmentPicker { get; private set; }

        /// <summary>
        /// Temporary save report button
        /// </summary>
        protected Button CreateNewButton { get; private set; }

        #endregion

        #region Dependency Properties
        //The Ienumerable Porperties such as Companies, Departments etc, dont need OnPathChanged because the 
        //are used in pickerComponents which have it already implemented in pickerComponentClass

        #region Companies 

        public IEnumerable<string> OptionCompanies
        {
            get { return (IEnumerable<string>)GetValue(OptionCompaniesProperty); }
            set { SetValue(OptionCompaniesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionCompanies"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OptionCompaniesProperty = DependencyProperty.Register(nameof(OptionCompanies), typeof(IEnumerable<string>), typeof(NewUserInputDialogComponent));

        #endregion

        #region Companies 

        public IEnumerable<string> OptionDepartments
        {
            get { return (IEnumerable<string>)GetValue(OptionDepartmentsProperty); }
            set { SetValue(OptionDepartmentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionDepartments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OptionDepartmentsProperty = DependencyProperty.Register(nameof(OptionDepartments), typeof(IEnumerable<string>), typeof(NewUserInputDialogComponent));

        #endregion

        #region Companies 

        public IEnumerable<string> OptionUserTypes
        {
            get { return (IEnumerable<string>)GetValue(OptionUserTypesProperty); }
            set { SetValue(OptionUserTypesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionUserTypes"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OptionUserTypesProperty = DependencyProperty.Register(nameof(OptionUserTypes), typeof(IEnumerable<string>), typeof(NewUserInputDialogComponent));

        #endregion

        #endregion

        #region Constructors

        public NewUserInputDialogComponent()
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
            // Sets the dialog text to new user form
            DialogTitle.Text = "New user form";

            // Creates a username input component...
            UsernameInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "username",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(UsernameInput);

            // Creates a first name input component...
            FirstNameInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "First name",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(FirstNameInput);

            // Creates a last name input component...
            LastNameInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "Last name",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(LastNameInput);

            // Creates a email input component...
            EmailInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "Email",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(EmailInput);

            // Creates a job position input component...
            JobPositionInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "Job position",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(JobPositionInput);

            // Test list
            var newList = new List<string> { "Yeet", "Boom", "Potato" };

            // The picker for company
            CompanyPicker = new PickerComponent()
            {
                HintText = "Company",
                OptionNames = newList
            };
            // Adds the picker to the wrap panel
            InputWrapPanel.Children.Add(CompanyPicker);

            // The picker for department
            DepartmentPicker = new PickerComponent()
            {
                HintText = "Department",
                OptionNames = newList
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentPicker);

            // The picker for user type
            UserTypePicker = new PickerComponent()
            {
                HintText = "User type",
                OptionNames = newList
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(UserTypePicker);

            // Creates the create a new user button
            CreateNewButton = StyleHelpers.CreateDialogButton(HookersGreen, "Create user");
            // Adds it to the buttons' stack panel
            DialogButtonsStackPanel.Children.Add(CreateNewButton);
            
            // Sets the component's content to the dialog host
            Content = DialogHost;
        }


        #endregion
    }
}
