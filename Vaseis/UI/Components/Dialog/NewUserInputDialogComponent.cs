using MaterialDesignThemes.Wpf;
using static Vaseis.Styles;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Data;

namespace Vaseis
{
    public class NewUserInputDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The company in which the new user gets added
        /// </summary>
        protected CompanyDataModel Company { get; private set; }

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

        #region Departmetns 

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

        #region User Types 

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

        #region Jobs Positions 

        public IEnumerable<string> OptionJobPosition
        {
            get { return (IEnumerable<string>)GetValue(OptionJobPositionProperty); }
            set { SetValue(OptionJobPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionJobPosition"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OptionJobPositionProperty = DependencyProperty.Register(nameof(OptionJobPosition), typeof(IEnumerable<string>), typeof(NewUserInputDialogComponent));

        #endregion

        #endregion

        #region Constructors

        public NewUserInputDialogComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Protected Methods 

        protected async void CreateNewUserOnClick(object sender, RoutedEventArgs e)
        {
            await Services.GetDataStorage.NewUser(Company,UsernameInput.Text, FirstNameInput.Text,LastNameInput.Text,EmailInput.Text,JobPositionInput.Text,DepartmentPicker.Text,UserTypePicker.Text);

            CloseDialogOnClick(this, e);
               
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

            #region Inputs

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
                Width = 240,
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(JobPositionInput);

            #endregion


            // The picker for department
            DepartmentPicker = new PickerComponent()
            {
                HintText = "Department",
                FontSize = 24,
                OptionNames = OptionDepartments
            };     
            DepartmentPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(OptionDepartments))
            {
                Source = this
            });
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentPicker);

            // The picker for user type
            UserTypePicker = new PickerComponent()
            {
                HintText = "User type",
                FontSize = 24,
                OptionNames = OptionUserTypes
            };
            UserTypePicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(OptionUserTypes))
            {
                Source = this
            });

            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(UserTypePicker);

            // Creates the create a new user button
            CreateNewButton = StyleHelpers.CreateDialogButton(HookersGreen, "Create user");
            CreateNewButton.Click += CreateNewUserOnClick;
            // Adds it to the buttons' stack panel
            DialogButtonsStackPanel.Children.Add(CreateNewButton);
            
            // Sets the component's content to the dialog host
            Content = DialogHost;
        }


        #endregion
    }
}
