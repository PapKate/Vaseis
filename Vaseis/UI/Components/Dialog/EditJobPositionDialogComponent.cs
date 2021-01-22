using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The dialog for editing a job position 
    /// </summary>
    public class EditJobPositionDialogComponent : JobPositionDialogComponent
    {
        #region Public Properties

        public JobPositionDataModel JobPosition { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The save button
        /// </summary>
        protected Button SaveButton { get; private set; }

        /// <summary>
        /// The cancel button
        /// </summary>
        protected Button CancelButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EditJobPositionDialogComponent(EvaluatorMyJobPositionsDataGridRowComponent myJobPositionsDataGridRow, JobPositionDataModel jobPosition) : base(myJobPositionsDataGridRow)
        {
            JobPosition = jobPosition ?? throw new ArgumentNullException(nameof(jobPosition));
            CreateGUI();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the selected item as the string in the row
        /// </summary>
        /// <param name="itemName">The row's string for the job position</param>
        public void SelectJobPosition(string itemName)
            => JobPositionPicker.SelectItem(itemName);

        /// <summary>
        /// Gets the previously checked check boxes and sets them as checked again
        /// </summary>
        /// <param name="checkedNames">The previously checked contents of the check boxes</param>
        public void PreviouslyCheckedItems(IEnumerable<string> checkedNames)
            => ToggleList.PreviouslyCheckedItems(checkedNames);

        #endregion

        #region Protected Methods

        /// <summary>
        /// Displays the data grid's values in the dialog
        /// </summary>
        protected override void DialogVisibilityChanged(DependencyPropertyChangedEventArgs e)
        {
            // The virtual method
            base.DialogVisibilityChanged(e);
            // Sets the hint texts to empty
            SalaryInput.HintText = "";
            HintAssist.SetHint(AnnouncementDatePicker, "");
            HintAssist.SetHint(SubmissionDatePicker, "");
            // Sets the salary's input text as the text of the salary in the row
            SalaryInput.Text = EvaluatorMyJobPositionsDataGridRow.SalaryText;
            // Sets the announcement's input as the date time of the string in the row
            AnnouncementDatePicker.SelectedDate = ControlsFactory.GetAnnouncementDate(EvaluatorMyJobPositionsDataGridRow.DeadlineName);
            // Sets the submission's input as the date time of the string in the row
            SubmissionDatePicker.SelectedDate = ControlsFactory.GetSubmissionDate(EvaluatorMyJobPositionsDataGridRow.DeadlineName);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates a save button
            SaveButton = StyleHelpers.CreateDialogButton(Green, "Save edit");
            SaveButton.Margin = new Thickness(24);
            // Adds it to the dialog's stack panel for the buttons
            DialogButtonsStackPanel.Children.Add(SaveButton);

            SaveButton.Click += SaveEditOnClick;

            // Creates a cancel button
            CancelButton = StyleHelpers.CreateDialogButton(Red, "Cancel edit");
            CancelButton.Margin = new Thickness(24);
            // Adds it to the dialog's stack panel for the buttons
            DialogButtonsStackPanel.Children.Add(CancelButton);
            // Calls method on click to close the dialog and make no changes to the row
            CancelButton.Click += CloseDialogOnClick;
        }
       
        private async void SaveEditOnClick(object sender, RoutedEventArgs e)
        {
            // If the row is not null...
            if(EvaluatorMyJobPositionsDataGridRow != null)
            {
                // Gets the subjects
                var subjects = await Services.GetDataStorage.GetSubjects();
                
                // Creates a new list of string
                var selectedSubjectsTitles = new List<string>();
                // Gets the selected check boxes and adds their content to the selected titles' list
                CheckedItems().ToList().ForEach(x => selectedSubjectsTitles.Add(x.Content.ToString()));
                
                // Creates a new list of subject data models
                var selectedSubjects = new List<SubjectDataModel>();
                // For each title in the selected titles' list...
                foreach (var title in selectedSubjectsTitles)
                {
                    // Finds in the subjects the subjects with title the title and adds them to the selected list
                    selectedSubjects.Add(subjects.Find(x => x.Title == title));
                }
                
                // Updates the job position in the data base and sets it as the updated job position in memory (?)
                var upDatedJobPosition = await Services.GetDataStorage.UpdateJobPositionByEvaluatorAsync(JobPosition, JobPositionPicker.Text,
                                                                                ControlsFactory.ParseSalaryToInt(SalaryInput.Text),
                                                                                AnnouncementDatePicker.SelectedDate,
                                                                                SubmissionDatePicker.SelectedDate,
                                                                                selectedSubjects);
                // Sets the new updated values of the job position to the existing job position
                JobPosition.Job.JobTitle = upDatedJobPosition.Job.JobTitle;
                JobPosition.Job.Department.DepartmentName = upDatedJobPosition.Job.Department.DepartmentName;
                JobPosition.AnnouncementDate = upDatedJobPosition.AnnouncementDate;
                JobPosition.SubmissionDate = upDatedJobPosition.SubmissionDate;
                JobPosition.Job.Salary = upDatedJobPosition.Job.Salary;
                JobPosition.Subjects = upDatedJobPosition.Subjects;
                // Updates the row
                EvaluatorMyJobPositionsDataGridRow.Update();
            }

            DialogHost.IsOpen = false;
        }

        #endregion
    }
}
