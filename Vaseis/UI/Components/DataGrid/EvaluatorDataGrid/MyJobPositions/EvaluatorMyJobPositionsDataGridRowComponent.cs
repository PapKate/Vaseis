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
    /// The my job positions data grid row 
    /// </summary>
    public class EvaluatorMyJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The job position
        /// </summary>
        public JobPositionDataModel JobPosition { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBox SalaryTextBox { get; private set; }

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBox DeadLineTextBox { get; private set; }

        /// <summary>
        /// The text box for the method
        /// </summary>
        protected TextBox DataTextBox { get; private set; }

        /// <summary>
        /// The edit button
        /// </summary>
        protected Button EditButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorMyJobPositionsDataGridRowComponent(Grid pageGrid, JobPositionDataModel jobPosition) : base(pageGrid)
        {
            JobPosition = jobPosition ?? throw new ArgumentNullException(nameof(jobPosition));
            CreateGUI();
            Update();
        }

        /// <summary>
        /// New row constructor
        /// </summary>
        public EvaluatorMyJobPositionsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Updates the UI based on the values of the <see cref="JobPosition"/>
        /// </summary>
        public void Update()
        {
            SubjectName = ControlsFactory.CreateSubjectsString(JobPosition.Subjects);
            JobPositionName = JobPosition.Job.JobTitle;
            DepartmentName = JobPosition.Job.Department.DepartmentName.ToString();
            SalaryText = ControlsFactory.CreateSalaryFormat(JobPosition.Job.Salary);
            if (JobPosition.JobPositionRequests != null)
                NumberOfRequestsText = JobPosition.JobPositionRequests.Count().ToString();
            else
                NumberOfRequestsText = "0";
            DeadlineName = $"{JobPosition.AnnouncementDate.Value.ToShortDateString()} - {JobPosition.SubmissionDate.Value.ToShortDateString()}";
        }

        /// <summary>
        /// Creates and adds a text box to the data grid row
        /// </summary>
        /// <param name="columnIndex">The data grid row's column index</param>
        /// <param name="hintText">The hint's text</param>
        protected TextBox CreateAndAddTextBox(int columnIndex, string hintText)
        {
            // Creates the salary text input field
            DataTextBox = new TextBox()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Collapsed
            };
            // Adds it to the grid
            RowDataGrid.Children.Add(DataTextBox);
            // Sets its hint text
            ControlsFactory.CreateHint(hintText, DataTextBox);
            // Sets grid column
            Grid.SetColumn(DataTextBox, columnIndex);

            // Returns the text box
            return DataTextBox;
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the salary text input field
            SalaryTextBox = CreateAndAddTextBox(2, "Salary");

            // Creates the deadline's text input field
            DeadLineTextBox = new TextBox()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Collapsed
            };
            RowDataGrid.Children.Add(DeadLineTextBox);
            ControlsFactory.CreateHint("Deadline", DeadLineTextBox);
            Grid.SetColumn(DeadLineTextBox, 4);
            Grid.SetColumnSpan(DeadLineTextBox, 4);

            // Creates the edit button
            EditButton = ControlsFactory.CreateEditButton();
            // Adds it to the data grid's row
            RowDataGrid.Children.Add(EditButton);
            Grid.SetColumn(EditButton, 9);
            Grid.SetColumnSpan(EditButton, 2);

            // Binds the command property of the button with the show dialog command
            EditButton.SetBinding(Button.CommandProperty, new Binding(nameof(ShowDialogCommand))
            {
                Source = this
            });

        }

        #endregion

    }
}
