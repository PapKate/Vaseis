using MaterialDesignThemes.Wpf;
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
        /// A list that contains all input field's hint texts
        /// </summary>
        protected List<string> UserInputFields { get; private set; }

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
            
            // Creates a list with all the input fields
            UserInputFields = new List<string>()
            {
                "Username",
                "Email",
                "First name",
                "Last name",
                "Job position",
            };

            // For each name in the list...
            foreach(var inputField in UserInputFields)
            {
                // Creates a text input component...
                var inputTextBox = new TextInputComponent()
                {
                    // With hint text the text 
                    HintText = inputField,
                    Margin = new Thickness(24),
                    Width = 240
                };

                // Adds it to the input wrap panel of the dialog grid
                InputWrapPanel.Children.Add(inputTextBox);
            }

            // Test list
            var newList = new List<string> { "Yeet", "Boom", "Potato" };

            // The picker for company
            CompanyPicker = new PickerComponent()
            {
                HintText = "Company",
                OptionNames = newList
            };
            
            //newList.Add("Test");

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
