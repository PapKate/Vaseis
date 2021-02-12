using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    public class NewUserDialogComponent : CreateDialogBaseComponent
    {
        #region Public Properties

        /// <summary>
        /// The company card
        /// </summary>
        public CompanyCardComponent CompanyCard { get; }

        /// <summary>
        /// The company card
        /// </summary>
        public CompanyDataModel Company { get; }

        /// <summary>
        /// The connected Admin
        /// </summary>
        public UserDataModel User { get; }

        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

        #endregion

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
        /// The password header Text
        /// </summary>
        protected TextBlock PasswordHeader { get; private set; }

        /// <summary>
        /// The new user password input 
        /// </summary>
        protected PasswordBox PasswordInput { get; private set; }

        /// <summary>
        /// The confirm password header Text
        /// </summary>
        protected TextBlock ConfirmPasswordHeader { get; private set; }

        /// <summary>
        /// The new user confirm password input 
        /// </summary>
        protected PasswordBox ConfirmPasswordInput { get; private set; }

        /// <summary>
        /// The new user  email input 
        /// </summary>
        protected TextInputComponent YearsOfExpInput { get; private set; }

        /// <summary>
        /// The new user  email input 
        /// </summary>
        protected TextInputComponent ProfilePicInput { get; private set; }

        /// <summary>
        /// The new user last name input 
        /// </summary>
        protected TextInputComponent LastNameInput { get; private set; }

        /// <summary>
        /// The new user first name input 
        /// </summary>
        protected TextInputComponent FirstNameInput { get; private set; }

        /// <summary>
        /// The new user job position picker 
        /// </summary>
        protected PickerComponent JobPositionPicker { get; private set; }

        /// <summary>
        /// The user type picker component
        /// </summary>
        protected ComboBox UserTypePicker { get; private set; }

        /// <summary>
        /// The department picker component
        /// </summary>
        protected PickerComponent DepartmentPicker { get; private set; }

        /// <summary>
        /// The input area
        /// </summary>
        protected ComboBoxItem OptionTitle { get; private set; }
        
        #endregion

        #region Dependency Properties

        //The Ienumerable Porperties such as Companies, Departments etc, dont need OnPathChanged because the 
        //are used in pickerComponents which have it already implemented in pickerComponentClass

        #region UserTypes 

        public IEnumerable<string> UserTypeOptions
        {
            get { return (IEnumerable<string>)GetValue(UserTypeOptionsProperty); }
            set { SetValue(UserTypeOptionsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="UserTypeOptions"/> dependency property
        /// </summary>
        public static readonly DependencyProperty UserTypeOptionsProperty = DependencyProperty.Register(nameof(UserTypeOptions), typeof(IEnumerable<string>), typeof(NewUserDialogComponent), new PropertyMetadata(OnUserTypesChanged));

        private static void OnUserTypesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as NewUserDialogComponent;

            sender.OnUserTypesChangedCore(e);
        }

        #endregion

        #region Departments 

        public IEnumerable<string> DepartmentOptions
        {
            get { return (IEnumerable<string>)GetValue(DepartmentOptionsProperty); }
            set { SetValue(DepartmentOptionsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DepartmentOptions"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentOptionsProperty = DependencyProperty.Register(nameof(DepartmentOptions), typeof(IEnumerable<string>), typeof(NewUserDialogComponent));

        #endregion

        #region Empty Departments 

        /// <summary>
        /// The departments with no manager
        /// </summary>
        public IEnumerable<string> EmptyDepartmentOptions
        {
            get { return (IEnumerable<string>)GetValue(EmptyDepartmentOptionsProperty); }
            set { SetValue(EmptyDepartmentOptionsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmptyDepartmentOptions"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmptyDepartmentOptionsProperty = DependencyProperty.Register(nameof(EmptyDepartmentOptions), typeof(IEnumerable<string>), typeof(NewUserDialogComponent));

        #endregion

        #region Jobs Positions 

        public IEnumerable<string> JobPositionOptions
        {
            get { return (IEnumerable<string>)GetValue(OptionJobPositionProperty); }
            set { SetValue(OptionJobPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="JobPositionOptions"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OptionJobPositionProperty = DependencyProperty.Register(nameof(JobPositionOptions), typeof(IEnumerable<string>), typeof(NewUserDialogComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="company">The company data model</param>
        /// <param name="companyCard">The representative card</param>
        /// <param name="pageGrid">The page's grid</param>
        public NewUserDialogComponent(UserDataModel user ,CompanyDataModel company, CompanyCardComponent companyCard, Grid pageGrid)
        {
            User = user ?? throw new ArgumentNullException(nameof(company));
            Company = company ?? throw new ArgumentNullException(nameof(company));
            CompanyCard = companyCard ?? throw new ArgumentNullException(nameof(companyCard));
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods 

        /// <summary>
        /// Creates and adds a new user to a company
        /// </summary>
        protected async void CreateNewUserOnClick(object sender, RoutedEventArgs e)
        {
            // By default empty
            var departmentName = "";
            // If a department was selected...
            if (DepartmentPicker != null)
                departmentName = DepartmentPicker.Text;
            // By default empty
            var jobPositionName = "";
            // If a job was selected...
            if (JobPositionPicker != null)
                jobPositionName = JobPositionPicker.Text;

            // If the password inputs do not match...
            if(PasswordInput.Password != ConfirmPasswordInput.Password)
            {
                // Creates a message dialog
                var errorMessage = new MessageDialogComponent()
                {
                    Message = "The two passwords do not match! Please try again.",
                    Title = "Error",
                    BrushColor = Red.HexToBrush()
                };
                // Adds it to the page's grid
                PageGrid.Children.Add(errorMessage);
            }
            else
            {
                // Creates a new user and returns the updated company
                var updatedCompany = await Services.GetDataStorage.AddNewUserAsync(Company.Id, UsernameInput.Text,
                                                            PasswordInput.Password,
                                                            FirstNameInput.Text, LastNameInput.Text,
                                                            EmailInput.Text, ControlsFactory.ParseStringToInt(YearsOfExpInput.Text), ProfilePicInput.Text,
                                                            jobPositionName, departmentName,
                                                            ControlsFactory.FindUserType(UserTypePicker.Text));
                // Sets the company's card's users as the update company's users
                CompanyCard.Employees = updatedCompany.Users;

                await Services.GetDataStorage.CreateNewLog(User.Username, "Entered a new User", $"Company: {Company.Name} User : {UsernameInput.Name}");

                // Closes the dialog
                CloseDialogOnClick(this, e);
            }
        }

        /// <summary>
        /// Handles the change of the <see cref="NewUserDialogComponent.UserTypeOptions"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnUserTypesChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Sets the dialog text to new user form
            DialogTitle.Text = $"New user form for company\n{Company.Name}";

            #region Inputs

            // Creates a username input component...
            UsernameInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "Username",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(UsernameInput);

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

            //Acts as HintText to the password cmponent since it cant have a hinttext from its own
            PasswordHeader = new TextBlock() { 
                Text = "Password",
                Margin = new Thickness(24,24,24,2),
                Width = 240,
                FontSize = 24,
                FontFamily = Calibri,
                Foreground = DarkPink.HexToBrush()
            };

            InputWrapPanel.Children.Add(PasswordHeader);

            //Acts as HintText to the password cmponent since it cant have a hinttext from its own
            ConfirmPasswordHeader = new TextBlock()
            {
                Text = "Confirm Password",
                Margin = new Thickness(24, 24, 24, 2),
                Width = 240,
                Foreground = DarkPink.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
            };

            InputWrapPanel.Children.Add(ConfirmPasswordHeader);

            // Creates a password input component...
            PasswordInput = new PasswordBox()
            {
                // With hint text the text 
                Margin = new Thickness(24, 2, 24, 24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(PasswordInput);

            // Creates a confirm password input component...
            ConfirmPasswordInput = new PasswordBox()
            {
                // With hint text the text 
                Margin = new Thickness(24,2,24,24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(ConfirmPasswordInput);

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

            // Creates a years of experience input component...
            YearsOfExpInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "Years of experience",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(YearsOfExpInput);

            // Creates a profile pic input component...
            ProfilePicInput = new TextInputComponent()
            {
                // With hint text the text 
                HintText = "Profile pic url",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(ProfilePicInput);

            #endregion

            // The picker for user type
            UserTypePicker = new ComboBox()
            {
                FontSize = 24,
                Width = 240,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                Margin = new Thickness(24)
            };
            ControlsFactory.CreateHint("User type", UserTypePicker);

            UserTypePicker.SelectionChanged += OptionsForUserType; 

            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(UserTypePicker);

            // Sets the create button color as hookers green
            CreateButton.Background = HookersGreen.HexToBrush();
            // On click calls method
            CreateButton.Click += CreateNewUserOnClick;
            
            // Sets the component's content to the dialog host
            Content = DialogHost;
        }

        /// <summary>
        /// Sets
        /// </summary>
        /// <param name="sender">The combo box</param>
        private void OptionsForUserType(object sender, SelectionChangedEventArgs e)
        {
            // Sets the value as the selected item's content
            var value = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();

            // If there is a job position picker in the dialog...
            if (JobPositionPicker != null)
                // Remove it from the wrap panel
                InputWrapPanel.Children.Remove(JobPositionPicker);

            // If there is a department picker...
            if (DepartmentPicker != null)
                // Remove it from the wrap panel
                InputWrapPanel.Children.Remove(DepartmentPicker);

            // If the employee is selected...
            if (value == "Employee")
            {
                // Creates a job position input component...
                JobPositionPicker = new PickerComponent()
                {
                    // With hint text the text 
                    HintText = "Job position",
                    CompleteFontSize = 24
                };
                // Adds it to the wrap panel
                InputWrapPanel.Children.Add(JobPositionPicker);

                // Binds the options names property of the picker to the job position options IEnumerable
                JobPositionPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(JobPositionOptions))
                {
                    Source = this
                });
            }
            // Else if an employee is not selected...
            else if(value != "Employee")
            {
                // Creates a new department picker
                DepartmentPicker = new PickerComponent()
                {
                    HintText = "Department",
                    CompleteFontSize = 24
                };
                // Adds it to the wrap panel
                InputWrapPanel.Children.Add(DepartmentPicker);
                // If the evaluator is selected...
                if(value == "Evaluator")
                {
                    // Binds the options names property of the picker to the department options IEnumerable
                    DepartmentPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(DepartmentOptions))
                    {
                        Source = this
                    });
                }
                else
                {
                    // Binds the options names property of the picker to the empty department options IEnumerable (no manager)
                    DepartmentPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(EmptyDepartmentOptions))
                    {
                        Source = this
                    });
                }
            }
        }

        /// <summary>
        /// Handles the change of the <see cref="OptionNames"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnUserTypesChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // The items source list
            var options = new List<ComboBoxItem>();

            // Get the new value
            var newValue = (IEnumerable<string>)e.NewValue;

            // If the new value is null...
            if (newValue == null)
            {
                // Creates a combo box item
                OptionTitle = new ComboBoxItem()
                {
                    Foreground = DarkGray.HexToBrush(),
                    FontFamily = Calibri,
                    FontSize = 28,
                    Margin = new Thickness(8, 0, 0, 0),
                    // with title "none"
                    Content = "no types"
                };

                // Adds it to the combo box items list
                options.Add(OptionTitle);
            }
            // Else...
            else
            {
                // For each string in the list...
                foreach (var optionName in newValue)
                {
                    // Creates a new combo box item ...
                    OptionTitle = new ComboBoxItem()
                    {
                        Foreground = DarkGray.HexToBrush(),
                        FontFamily = Calibri,
                        FontSize = 28,
                        FontWeight = FontWeights.Normal,
                        Margin = new Thickness(8, 0, 0, 0),
                        // with content the one string
                        Content = optionName
                    };

                    // Adds the combo box item to the list
                    options.Add(OptionTitle);
                }
            }

            UserTypePicker.ItemsSource = options;

            // Further handle the change
            OnUserTypesChanged(e);
        }

        #endregion
    }
}
