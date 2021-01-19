using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The my job positions data grid
    /// </summary>
    public class EvaluatorMyJobPositionsDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The evaluator
        /// </summary>
        public UserDataModel Evaluator { get; }
        
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorMyJobPositionsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion
        
        #region Dependency Properties

        #region NewRow

        /// <summary>
        /// The open dialog command
        /// </summary>
        public bool NewRow
        {
            get { return (bool)GetValue(NewRowProperty); }
            set { SetValue(NewRowProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NewRow"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NewRowProperty = DependencyProperty.Register(nameof(NewRow), typeof(bool), typeof(EvaluatorMyJobPositionsDataGridComponent), new PropertyMetadata(OnNewRowChanged));

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        private static void OnNewRowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EvaluatorMyJobPositionsDataGridComponent;

            sender.OnNewRowChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        public EvaluatorMyJobPositionsDataGridComponent(Grid pageGrid, UserDataModel evaluator)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));

            CreateGUI();
        }

        #endregion

        #region Protected Methods
        
        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected async override void OnInitialized()
        {
            base.OnInitialized();

            // Creates a list with the job positions' names
            var jobPositionsList = new List<string>();
            // Gets the company's job positions
            var companyJobPositions = await Services.GetDataStorage.GetCompanyJobPositions(Evaluator.Department.CompanyId);
            // For each job position...
            foreach(var companyJobPosition in companyJobPositions)
            {
                // Add their title to the list
                jobPositionsList.Add(companyJobPosition.Job.JobTitle);
            }

            // Creates a list with the departments' names
            var departmentsList = new List<string>();
            // Gets the company's departments
            var companyDepartments = await Services.GetDataStorage.GetCompanyDepartments(Evaluator.Department.CompanyId);
            // For each department...
            foreach (var companyDepartment in companyDepartments)
            {
                // Add their title to the list
                departmentsList.Add(companyDepartment.DepartmentName.ToString());
            }

            // Creates a list with the subjects' names
            var subjectsList = new List<string>();
            // Gets the subjects
            var subjects = await Services.GetDataStorage.GetSubjects();
            // For each subject...
            foreach (var subject in subjects)
            {
                // Add their title to the list
                subjectsList.Add(subject.Title);
            }

            // Query the job position requests by an employee and add them as rows to the data grid
            var jobPositions = await Services.GetDataStorage.GetEvaluatorJobPositions();

            // For each job position in the list...
            foreach (var jobPosition in jobPositions)
            {
                // Create a row of for the employee's job position data grid
                var row = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid, jobPosition)
                {
                    //JobPositionsList = jobPositionsList,
                    //DepartmentsList = departmentsList,
                    //SubjectsList = subjectsList
                };
                // Adds the row to the stack panel
                InfoDataStackPanel.Children.Add(row);
            }
        }

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnNewRowChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new EvaluatorMyJobPositionsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnNewRowChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                var newRow = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid);

                InfoDataStackPanel.Children.Add(newRow);
                // Creates a new evaluation dialog
                var jobPositionDialog = new JobPositionDialogComponent(newRow)
                {
                    // Sets the dialog is open to true
                    IsDialogOpen = true,
                    // Close button on click removes the new row from the data grid
                    CancelCommand = new RelayCommand(() => InfoDataStackPanel.Children.Remove(newRow))
                };
                // Adds it to the page grid
                PageGrid.Children.Add(jobPositionDialog);
                // Sets the new row value to false
                NewRow = false;
            }
        }

        #endregion

    }
}
