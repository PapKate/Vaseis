using MaterialDesignThemes.Wpf;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A dialog for a new company
    /// </summary>
    public class NewCompanyDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// List with the input fields names
        /// </summary>
        protected List<string> CompanyInputFields { get; private set; }

        /// <summary>
        /// Temporary save report button
        /// </summary>
        protected Button CreateNewButton { get; private set; }

        /// <summary>
        /// The date picker for the date created
        /// </summary>
        protected DatePicker DateCreatedPicker { get; private set; }

        /// <summary>
        /// The text input for the department
        /// </summary>
        protected TextInputComponent DepartmentTextBox { get; private set; }

        /// <summary>
        /// The add department button
        /// </summary>
        protected Button AddDepartmentButton { get; private set; }

        /// <summary>
        /// The new input box
        /// </summary>
        protected TextBox InputTextBox { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent CompanyName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent AFM { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent DOY { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent TelephoneNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent Country { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent City { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent StreetAddress { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent StreetNumber { get; private set; }

        #endregion

        #region Constructors

        public NewCompanyDialogComponent()
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
            // Sets the dialog's title
            DialogTitle.Text = "New company form";

            CompanyName = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Company name",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(CompanyName);

            AFM = new TextInputComponent()
            {
                // With hint text the name
                HintText = "AFM",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(AFM);

            DOY = new TextInputComponent()
            {
                // With hint text the name
                HintText = "DOY",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(DOY);

            TelephoneNumber = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Telephone number",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(TelephoneNumber);

            Country = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Country",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(Country);

            City = new TextInputComponent()
            {
                // With hint text the name
                HintText = "City",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(City);

            StreetAddress = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Street address name",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(StreetAddress);

            StreetNumber = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Street address number",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(StreetNumber);

            //kTODO: add the date picker to factor controls with parameter hint text
            // Creates a date picker - calendar field
            DateCreatedPicker = ControlsFactory.CreateDatePicker("Date created");
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DateCreatedPicker);

            // Creates a new text input component
            DepartmentTextBox = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Department",
                Margin = new Thickness(24),
                Width = 220
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentTextBox);

            // The add department
            AddDepartmentButton = new Button()
            {
                Content = new PackIcon()
                {
                    Kind = PackIconKind.Plus,
                    Width = 24,
                    Height = 24,
                    Foreground = White.HexToBrush(),
                },
                Width = 28,
                Height = 28,
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
                Margin = new Thickness(-16, 0, 0, 0)
            };

            // Sets a corner radius for the button
            ButtonAssist.SetCornerRadius(AddDepartmentButton, new CornerRadius(8));
            // On click calls method
            AddDepartmentButton.Click += CreateDepartmentInputField;
            // Adds it tot he wrap panel
            InputWrapPanel.Children.Add(AddDepartmentButton);

            // Creates the create a new user button
            CreateNewButton = StyleHelpers.CreateDialogButton(HookersGreen, "Create company");
            // Adds it to the buttons' stack panel

            DialogButtonsStackPanel.Children.Add(CreateNewButton);

            // Sets the component's content to the dialog host
            Content = DialogHost;
        }

        /// <summary>
        /// The user's input text on department text box
        /// </summary>
        private string inputText;

        /// <summary>
        /// Creates a department input field
        /// </summary>
        private void CreateDepartmentInputField(object sender, RoutedEventArgs e)
        {
            inputText = DepartmentTextBox.InputTextBox.Text;
            CreateInputField(inputText);
        }


        /// <summary>
        /// Creates a new input field
        /// </summary>
        /// <param name="inputHint">The hint text</param>
        private void CreateInputField(string inputText)
        {
            // Creates a new text input component
            InputTextBox = new TextBox()
            {
                // With hint text the name
                Text = inputText,
                Margin = new Thickness(24),
                Width = 240,
                FontSize = 20,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            // Adds a hint
            ControlsFactory.CreateHint("Department", InputTextBox);

            // Sets the first department's input text to null
            DepartmentTextBox.InputTextBox.Text = "";

            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(InputTextBox);
        }


        #endregion
    }
}
