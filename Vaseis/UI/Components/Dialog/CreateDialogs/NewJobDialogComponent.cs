using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static Vaseis.Styles;

namespace Vaseis
{
    //For the admin in companies page -> Add Job to the parameter company
    public class NewJobDialogComponent : CreateDialogBaseComponent
    {
        #region Public Properties

        /// <summary>
        /// The company the Admin wants to add a job to
        /// </summary>
        public CompanyDataModel Company { get; }
        
        /// <summary>
        /// The company card
        /// </summary>
        public CompanyCardComponent CompanyCard { get; }

        #endregion

        #region Protected Properties 
        /// <summary>
        /// The job's Title
        /// </summary>
        protected TextInputComponent JobTitleInput { get;  set; } 

        /// <summary>
        /// The job's Department
        /// </summary>
        protected PickerComponent DeprtmentPicker { get; set;  }

        /// <summary>
        /// The job's Salary
        /// </summary>
        protected TextInputComponent SalaryInput { get;  set; }

        #endregion

        #region Dependency Properties

        #region Departments 

        public IEnumerable<string> DepartmentsOption
        {
            get { return (IEnumerable<string>)GetValue(DepartmentsOptionProperty); }
            set { SetValue(DepartmentsOptionProperty, value); }
        }


        /// <summary>
        /// Identifies the <see cref="OptionDepartments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentsOptionProperty = DependencyProperty.Register(nameof(DepartmentsOption), typeof(IEnumerable<string>), typeof(NewJobDialogComponent));

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="company">The company</param>
        /// <param name="companyCard">The company's representative card</param>
        public NewJobDialogComponent(CompanyDataModel company, CompanyCardComponent companyCard)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));
            CompanyCard = companyCard ?? throw new ArgumentNullException(nameof(companyCard));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a new job to a company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void CreateJobOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new job and returns the updated company
            var updatedCompany = await Services.GetDataStorage.AddNewJobAsync(Company.Id,
                                                                              JobTitleInput.Text,
                                                                              ControlsFactory.ParseSalaryToInt(SalaryInput.Text), 
                                                                              DeprtmentPicker.Text);
            // Sets the company's card's jobs as the update company's jobs
      //      CompanyCard.Jobs = updatedCompany.Jobs;
            // Closes the dialog
            CloseDialogOnClick(this, e);
        }

        #endregion

        #region Private Methods 

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary
        private void CreateGUI()
        {
            // Adds th dialog's title
            DialogTitle.Text = $"New job form for company:\n{Company.Name}";

            JobTitleInput = new TextInputComponent()
            {
                HintText = "Job Title",
                Width = 240,
                Margin = new Thickness(24)
            };
            // Adds it to the stack panel
            InputWrapPanel.Children.Add(JobTitleInput);

            // Create the salary text input component
            SalaryInput = new TextInputComponent()
            {
                HintText = "$alary",
                FontSize = 24,
                Width = 240,
                Margin = new Thickness(24)
            };
            // Adds it to the stack panel
            InputWrapPanel.Children.Add(SalaryInput);

            var departmentsNames = new List<string>();
            Company.Departments.ToList().ForEach(x => departmentsNames.Add(x.DepartmentName));
            // Creates the department's picker
            DeprtmentPicker = new PickerComponent()
            {
                HintText = "Department",
                CompleteFontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                OptionNames = departmentsNames
            };
            //// Binds the option names property to the department options
            //DeprtmentPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(DepartmentsOption))
            //{
            //    Source = this
            //});
            // Adds it to the stack panel
            InputWrapPanel.Children.Add(DeprtmentPicker);
            
            CreateButton.Click += CreateJobOnClick;
            // Sets the create button's background to dark blue
            CreateButton.Background = GreenBlue.HexToBrush();
        }

        #endregion

    }
}
