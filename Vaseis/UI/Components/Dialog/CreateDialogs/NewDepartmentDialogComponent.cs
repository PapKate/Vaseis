using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The create a new department dialog
    /// </summary>
    public class NewDepartmentDialogComponent : CreateDialogBaseComponent
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
        /// The admin/manager connected
        /// </summary>
        public UserDataModel User { get; protected set; }

        #endregion

        #region Protected Properties

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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NewDepartmentDialogComponent(UserDataModel user, CompanyDataModel company, CompanyCardComponent companyCard)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Company = company ?? throw new ArgumentNullException(nameof(company));
            CompanyCard = companyCard ?? throw new ArgumentNullException(nameof(companyCard));

            CreateGUI();
        }

        #endregion

        #region  Protected Methods 

        /// <summary>
        /// Creates and adds a new department to a company
        /// </summary>
        protected async void CreateNewDepartment(object sender, RoutedEventArgs e)
        {
            // Creates a new department and returns the updated company
            var updatedCompany = await Services.GetDataStorage.AddNewDepartmentAsync(User, Company, DepartmentInput.Text, ColorInput.Text);
            // Sets the company's card's departments as the update company's departments
            CompanyCard.Departments = updatedCompany.Departments;

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
            DialogTitle.Text = $"New department form for company\n{Company.Name}";

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

            // Creates the color's input field
            ColorInput = new TextInputComponent()
            {
                Width = 240,
                Margin = new Thickness(24),
                HintText = "Hex color"
            };

            DepartmentStackPanel.Children.Add(ColorInput);

            CreateButton.Click += CreateNewDepartment;
        }

        #endregion

    }
}
