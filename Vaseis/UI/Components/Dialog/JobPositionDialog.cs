using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    public class JobPositionDialog : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The JobTitle Input text
        /// </summary>
        public TextInputComponent JobPositionTitleBlock { get; private set; }

        /// <summary>
        /// The JobPosition Salary Input
        /// </summary>
        public TextInputComponent JobPositionSalaryInput { get; private set; }

        /// <summary>
        /// The JobPostion Date of Announcement PickerComponent
        /// </summary>
        public DatePicker JobPositionAnnouncementDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion Date of submission PickerComponent
        /// </summary>
        public DatePicker JobPositionSubmissionDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion Date of startDate PickerComponent
        /// </summary>
        public DatePicker JobPositionStartDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion create Button
        /// </summary>
        public Button CreateButton{ get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionDialog()
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
            // Adds th dialog's title
            DialogTitle.Text = "Job Position";

            #region Input Data

            // Creates the job positions input
            JobPositionTitleBlock = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Job Position",
                Width = 240,
            };

            // Creates the job position's salary input 
            JobPositionSalaryInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Salary",
                Width = 240,
            };

            // Creates the date pickers
            JobPositionAnnouncementDatePicker = ControlsFactory.CreateDatePicker("Announcement Date");
            JobPositionSubmissionDatePicker = ControlsFactory.CreateDatePicker("Submission Date");
            JobPositionStartDatePicker = ControlsFactory.CreateDatePicker("Start Date");

            // Adds the input fields to the wrap panel
            InputWrapPanel.Children.Add(JobPositionTitleBlock);
            InputWrapPanel.Children.Add(JobPositionSalaryInput);
            InputWrapPanel.Children.Add(JobPositionAnnouncementDatePicker);
            InputWrapPanel.Children.Add(JobPositionSubmissionDatePicker);
            InputWrapPanel.Children.Add(JobPositionStartDatePicker);

            #endregion

            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(DarkPink, "Create");
            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);
        }
        #endregion

    }


}
