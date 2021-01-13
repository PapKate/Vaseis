using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    public class JobPositionDialogComponent : DialogBaseComponent
    {
        /// <summary>
        /// The evaluator's my job positions data grid row
        /// </summary>
        public EvaluatorMyJobPositionsDataGridRowComponent EvaluatorMyJobPositionsDataGridRow { get; }

        #region Protected Properties

        /// <summary>
        /// The JobTitle Input text
        /// </summary>
        protected PickerComponent JobPositionPicker { get; private set; }

        /// <summary>
        /// The department PickerComponent
        /// </summary>
        protected PickerComponent DepartmentPicker { get; private set; }

        /// <summary>
        /// The JobPosition Salary Input
        /// </summary>
        protected TextInputComponent SalaryInput { get; private set; }

        /// <summary>
        /// The JobPostion Date of Announcement PickerComponent
        /// </summary>
        protected DatePicker AnnouncementDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion Date of submission PickerComponent
        /// </summary>
        protected DatePicker SubmissionDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion Date of startDate PickerComponent
        /// </summary>
        protected PickerComponent SubjectPicker { get; private set; }

        /// <summary>
        /// The JobPostion create Button
        /// </summary>
        protected Button CreateButton{ get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionDialogComponent()
        {
            CreateGUI();
        }

        public JobPositionDialogComponent(EvaluatorMyJobPositionsDataGridRowComponent myJobPositionsDataGridRow)
        {
            EvaluatorMyJobPositionsDataGridRow = myJobPositionsDataGridRow ?? throw new ArgumentNullException(nameof(myJobPositionsDataGridRow));

            CreateGUI();
        }

        #endregion

        #region Private Methods 

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI() 
        {
            // Adds th dialog's title
            DialogTitle.Text = "Job position form";

            #region Input Data

            var testList = new List<string> { "Potato", "Zucchini", "Cucumber", "Pavlova", "Panna cotta", "Mascarpone", "Pastry", "Agriculture", "Tomato", "Cookies", "Pies" };

            // Creates the job name picker
            JobPositionPicker = new PickerComponent()
            {
                Margin = new Thickness(24),
                HintText = "Job Position",
                Width = 240,
                OptionNames = testList
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(JobPositionPicker);

            // Creates the department picker
            DepartmentPicker = new PickerComponent()
            {
                Margin = new Thickness(24),
                HintText = "Department",
                Width = 240,
                OptionNames = testList
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentPicker);

            // Creates the job position's salary input 
            SalaryInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Salary",
                Width = 240,
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(SalaryInput);

            // Creates the subject picker
            SubjectPicker = new PickerComponent()
            {
                Margin = new Thickness(24, 0, 24, 0),
                HintText = "Subject",
                Width = 240,
                OptionNames = testList
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(SubjectPicker);

            // Creates and adds the announcement date picker to the wrap panel
            AnnouncementDatePicker = ControlsFactory.CreateDatePicker("Announcement Date");
            InputWrapPanel.Children.Add(AnnouncementDatePicker);
            
            // Creates and adds the submission date picker to the wrap panel
            SubmissionDatePicker = ControlsFactory.CreateDatePicker("Submission Date");
            InputWrapPanel.Children.Add(SubmissionDatePicker);

            #endregion

            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(DarkPink, "Create");
            CreateButton.Click += CreateJobPositionOnClick;
            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);
        }

        /// <summary>
        /// Saves the new values in the data grid
        /// </summary>
        private void CreateJobPositionOnClick(object sender, RoutedEventArgs e)
        {
            // If the my job position row exists...
            if (EvaluatorMyJobPositionsDataGridRow != null)
            {
                // Sets the row's values according to the matching input in the dialog
                // Job name
                EvaluatorMyJobPositionsDataGridRow.JobPositionText = JobPositionPicker.Text;
                // Department
                EvaluatorMyJobPositionsDataGridRow.DepartmentText = DepartmentPicker.Text;
                // Salary
                EvaluatorMyJobPositionsDataGridRow.SalaryText = SalaryInput.Text;
                // Subject
                EvaluatorMyJobPositionsDataGridRow.SubjectText = SubjectPicker.Text;
                // Deadline
                EvaluatorMyJobPositionsDataGridRow.DeadlineText = $"{AnnouncementDatePicker.SelectedDate.Value.ToShortDateString()} - {SubmissionDatePicker.SelectedDate.Value.ToShortDateString()}";
            }
            // Closes the dialog
            DialogHost.IsOpen = false;
        }

        #endregion

    }


}
