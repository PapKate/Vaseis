using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The create a new department dialog
    /// </summary>
    public class NewDepartmentDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The company the Admin wants to add a department to
        /// </summary>
        public CompanyDataModel Company { get; }

        /// <summary>
        /// The department's name input
        /// </summary>
        protected TextInputComponent DepartmentInput { get; private set; }

        /// <summary>
        /// The department's stack panel
        /// </summary>
        public StackPanel DepartmentStackPanel { get; private set; }

        /// <summary>
        /// The department's color input
        /// </summary>
        protected TextInputComponent ColorInput { get; private set; }

        /// <summary>
        /// The company's picker
        /// </summary>
        protected PickerComponent CompanyPicker { get; private set; }

        /// <summary>
        /// The create a new department button
        /// </summary>
        protected Button CreateButton { get; private set; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NewDepartmentDialogComponent(CompanyDataModel company)
        {
            CreateGUI();
        }

        #endregion

        #region  Protected Methods 

        protected async void CreateNewDepartment(object sender, RoutedEventArgs e)
        {
            await Services.GetDataStorage.AddNewDepartment(Company, DepartmentInput.Text, ColorInput.Text);

            CloseDialogOnClick(this, e);

        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {


            DialogTitle.Text = "Create Department";

            // Creates the department's input field
           DepartmentInput = new TextInputComponent()
            { 
                Width = 240,
                Margin = new Thickness(24),
                HintText = "Department's name"
            };


            DepartmentStackPanel = new StackPanel();

            DepartmentStackPanel.Children.Add(DepartmentInput);
          // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentStackPanel);

            // Creates the company's combo box
            CompanyPicker = new PickerComponent()
            {
                HintText = "Company",
                FontSize = 24,
                Width = 240,
                Margin = new Thickness(24, 0, 24, 0),
                OptionNames = new List<string> { "EnchantmentLab", "Batter", "CoffeeMesh", "Gklitsa & Co" }
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(CompanyPicker);



            // Creates the color's input field
            ColorInput = new TextInputComponent()
            {
                Width = 240,
                Margin = new Thickness(24),
                HintText = "Representative hex color"
            };

            DepartmentStackPanel.Children.Add(ColorInput);

            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(DarkPink, "Create");
            CreateButton.Margin = new Thickness(32);
            // Adds it to the dialog's button's stack panel

            CreateButton.Click += CreateNewDepartment;
            //DialogButtonsStackPanel.Children.Add(CreateButton);

            DepartmentStackPanel.Children.Add(CreateButton);

            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentStackPanel);

        }

        #endregion

    }
}
