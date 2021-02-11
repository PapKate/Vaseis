using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A dialog for a new company
    /// </summary>
    public class NewCompanyDialogComponent : CreateDialogBaseComponent
    {
        #region Public Properties

        /// <summary>
        /// The created company data model
        /// </summary>
        public CompanyDataModel Company { get; private set; }

        /// <summary>
        /// The connected Admin
        /// </summary>
        public UserDataModel User { get; private set; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// List with the input fields names
        /// </summary>
        protected List<string> CompanyInputFields { get; private set; }

        /// <summary>
        /// The date picker for the date created
        /// </summary>
        protected DatePicker DateCreatedPicker { get; private set; }

        /// <summary>
        /// The text input for the department
        /// </summary>
        protected TextInputComponent DepartmentTextBox { get; private set; }

        /// <summary>
        /// The text input for the department's color
        /// </summary>
        protected TextInputComponent DepartmentColorTextBox { get; private set; }

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
        protected TextInputComponent About { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent CompanyPicture { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextInputComponent StreetNumber { get; private set; }
        
        /// <summary>
        /// The department names
        /// </summary>
        protected Dictionary<string, string> DepartmentData { get; private set; }

        #endregion

        #region Constructors

        public NewCompanyDialogComponent(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a new company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void CreateCompanyAsync(object sender, RoutedEventArgs e)
        {
            // If the department's text blocks for name and color are null... do nothing
            if (string.IsNullOrEmpty(DepartmentTextBox.Text) || string.IsNullOrEmpty(DepartmentColorTextBox.Text)) { }
            // Else...
            else 
                // Add them to the dictionary
                DepartmentData.Add(DepartmentTextBox.Text, DepartmentColorTextBox.Text);
            // Creates the company
            Company = await Services.GetDataStorage.CreateCompanyAsync(User, CompanyName.Text, DOY.Text, AFM.Text, 
                                                                              About.Text, TelephoneNumber.Text, 
                                                                              City.Text, Country.Text, StreetNumber.Text, 
                                                                              StreetAddress.Text, CompanyPicture.Text,
                                                                              DepartmentData);

          //  await Services.GetDataStorage.CreateNewLog(User.Username, "Added a new Company", $"Company : {CompanyName.Text}");


            // Closes the dialog
            CloseDialogOnClick(this, e);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            DepartmentData = new Dictionary<string, string>();

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

            //Some words about the company
            About = new TextInputComponent()
            {
                // With hint text the name
                HintText = "About",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(About);

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

            CompanyPicture = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Company's picture url",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(CompanyPicture);

            // Creates a new text input component
            DepartmentTextBox = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Department",
                Margin = new Thickness(24),
                Width = 240
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentTextBox);

            // Creates a new text input component
            DepartmentColorTextBox = new TextInputComponent()
            {
                // With hint text the name
                HintText = "D's hex color",
                Margin = new Thickness(24),
                Width = 220
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentColorTextBox);

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
            CreateButton.Background = DarkBlue.HexToBrush();
            // Adds it to the buttons' stack panel
            CreateButton.Click += CreateCompanyAsync;
        }

        /// <summary>
        /// The user's input text on department text box
        /// </summary>
        private string departmentInputText;
        /// <summary>
        /// The user's input text on department color text box
        /// </summary>
        private string departmentColorInputText;

        /// <summary>
        /// Creates a department input field
        /// </summary>
        private void CreateDepartmentInputField(object sender, RoutedEventArgs e)
        {
            departmentInputText = DepartmentTextBox.InputTextBox.Text;
            departmentColorInputText = DepartmentColorTextBox.InputTextBox.Text;
            if (string.IsNullOrEmpty(departmentInputText) || string.IsNullOrEmpty(departmentColorInputText)) { }
            else
                DepartmentData.Add( departmentInputText, departmentColorInputText);
            CreateInputField(departmentInputText, "Department");
            CreateInputField(departmentColorInputText, "Department hex color");

        }

        /// <summary>
        /// Creates a new input field
        /// </summary>
        /// <param name="inputHint">The hint text</param>
        private void CreateInputField(string inputText, string hintText)
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
            ControlsFactory.CreateHint(hintText, InputTextBox);

            // Sets the first department's input text to null
            DepartmentTextBox.InputTextBox.Text = "";
            DepartmentColorTextBox.InputTextBox.Text = "";

            // And adds it to the dialog's input wrap panel
            InputWrapPanel.Children.Add(InputTextBox);
        }

        #endregion
    }
}
