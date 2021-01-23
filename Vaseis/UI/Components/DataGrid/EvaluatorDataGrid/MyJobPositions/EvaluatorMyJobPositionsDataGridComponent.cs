using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageGrid">The page's grid</param>
        /// <param name="evaluator">The evaluator</param>
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
            var jobsList = new List<string>();
            // Gets the company's job positions
            var companyJobs = await Services.GetDataStorage.GetCompanyJobs(Evaluator.Department.CompanyId);
            // For each job position...
            foreach (var companyJob in companyJobs)
            {
                // Add their title to the list
                jobsList.Add(companyJob.JobTitle);
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
            var jobPositions = await Services.GetDataStorage.GetEvaluatorJobPositions(Evaluator.Id);

            // For each job position in the list...
            foreach (var jobPosition in jobPositions)
            {
                // Create a row of for the employee's job position data grid
                var row = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid, jobPosition);

                row.ShowDialogCommand = new RelayCommand(() =>
                {
                    var editPositionDialog = new EditJobPositionDialogComponent(row, jobPosition)
                    {
                        IsDialogOpen = true,
                        JobPositionsList = jobsList,
                        SubjectsList = subjectsList
                    };
                    editPositionDialog.SelectJobPosition(row.JobPositionName);
                    editPositionDialog.PreviouslyCheckedItems(ControlsFactory.SplitSubjectsString(row.SubjectName));

                    PageGrid.Children.Add(editPositionDialog);
                });
                
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
        private async void OnNewRowChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                // Creates a list with the job positions' names
                var jobsList = new List<string>();
                // Gets the company's job positions
                var companyJobs = await Services.GetDataStorage.GetCompanyJobs(Evaluator.Department.CompanyId);
                // For each job position...
                foreach (var companyJob in companyJobs)
                {
                    // Add their title to the list
                    jobsList.Add(companyJob.JobTitle);
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

                // Creates a new evaluation dialog
                var jobPositionDialog = new NewJobPositionDialogComponent(Evaluator)
                {
                    // Sets the dialog is open to true
                    IsDialogOpen = true,
                    JobPositionsList = jobsList,
                    SubjectsList = subjectsList,
                };
                // Close button on click removes the new row from the data grid
                jobPositionDialog.CreateCommand = new RelayCommand(async () =>
                {
                    // Finds the selected job in the dialog's picker
                    var job = companyJobs.Find(x => x.JobTitle == jobPositionDialog.JobPositionPicker.Text);

                    // Creates a new list of string
                    var selectedSubjectsTitles = new List<string>();
                    // Gets the selected check boxes and adds their content to the selected titles' list
                    jobPositionDialog.CheckedItems().ToList().ForEach(x => selectedSubjectsTitles.Add(x.Content.ToString()));

                    // Creates a new list of subject data models
                    var selectedSubjects = new List<SubjectDataModel>();
                    // For each title in the selected titles' list...
                    foreach (var title in selectedSubjectsTitles)
                    {
                        // Finds in the subjects the subjects with title the title and adds them to the selected list
                        selectedSubjects.Add(subjects.Find(x => x.Title == title));
                    }

                    // Creates a new job position in the data base
                    var jobPosition = await Services.GetDataStorage.AddEvaluatorJobPosition(Evaluator.Id, job, ControlsFactory.ParseSalaryToInt(jobPositionDialog.SalaryInput.Text),
                                                                                            jobPositionDialog.AnnouncementDatePicker.SelectedDate,
                                                                                            jobPositionDialog.SubmissionDatePicker.SelectedDate,
                                                                                            selectedSubjects);
                    // Creates a new row for the data grid
                    var newRow = new EvaluatorMyJobPositionsDataGridRowComponent(PageGrid, jobPosition);
                    // Creates the row's show dialog command
                    newRow.ShowDialogCommand = new RelayCommand(() =>
                    {
                        // Creates a new edit job position dialog
                        var editPositionDialog = new EditJobPositionDialogComponent(newRow, jobPosition)
                        {
                            // Sets it as open
                            IsDialogOpen = true,
                            // Sets its job positions
                            JobPositionsList = jobsList,
                            // Sets its subjects
                            SubjectsList = subjectsList
                        };
                        // Gets the job position from the row
                        editPositionDialog.SelectJobPosition(newRow.JobPositionName);
                        editPositionDialog.PreviouslyCheckedItems(ControlsFactory.SplitSubjectsString(newRow.SubjectName));
                        // Adds the dialog to the page's grid
                        PageGrid.Children.Add(editPositionDialog);
                    });
                    // Adds the new row to the stack panel
                    InfoDataStackPanel.Children.Add(newRow);
                });

                // Adds it to the page grid
                PageGrid.Children.Add(jobPositionDialog);
                // Sets the new row value to false
                NewRow = false;
            }
        }

        #endregion

    }
}
