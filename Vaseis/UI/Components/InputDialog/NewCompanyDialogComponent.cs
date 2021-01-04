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

            // Creates a list with all the required text input field name's
            CompanyInputFields = new List<string>()
            {
                "Company name",
                "AFM",
                "DOY",
                "DateCreated",
                "Telephone number",
                "Country",
                "City",
                "Street address name",
                "Street address number",
            };

            // For each name in the list...
            foreach (var inputField in CompanyInputFields)
            {
                // Creates a new text input component
                var inputTextBox = new TextInputComponent()
                {
                    // With hint text the name
                    HintText = inputField,
                    Margin = new Thickness(24),
                    Width = 240
                };

                // And adds it to the dialog's input wrap panel
                InputWrapPanel.Children.Add(inputTextBox);
            }
            //kTODO: add the date picker to factor controls with parameter hint text
            // Creates a date picker - calendar field
            var datePicker = new DatePicker()
            {
                Width = 240,
                Margin = new Thickness(24),
                Foreground = DarkGray.HexToBrush(),
                FontSize = 20
            };
            // Adds a hint to the date picker
            HintAssist.SetHint(datePicker, "Date created");
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(datePicker);

            // Creates the create a new user button
            CreateNewButton = StyleHelpers.CreateDialogButton(HookersGreen, "Create company");
            // Adds it to the buttons' stack panel

            DialogButtonsStackPanel.Children.Add(CreateNewButton);

            // Sets the component's content to the dialog host
            Content = DialogHost;
        }
        #endregion
    }
}
