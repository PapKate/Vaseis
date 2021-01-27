using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The manager's data grid for job positions
    /// </summary>
    public class ManagerJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
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
        /// The edit button
        /// </summary>
        protected EditComponent EditComponent { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerJobPositionsDataGridRowComponent(Grid pageGrid, JobPositionDataModel jobPosition) : base(pageGrid)
        {
            JobPosition = jobPosition ?? throw new ArgumentNullException(nameof(jobPosition));

            CreateGUI();

            Update();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates the UI based on the values of the <see cref="JobPosition"/>
        /// </summary>
        public void Update()
        {
            var subjectList = new List<SubjectDataModel>();
            JobPosition.JobsAndSubjects.ToList().ForEach(x => subjectList.Add(x.Subject));
            SubjectName = ControlsFactory.CreateSubjectsString(subjectList);
            JobPositionName = JobPosition.Job.JobTitle;
            DepartmentName = JobPosition.Job.Department.DepartmentName.ToString();
            SalaryText = ControlsFactory.CreateSalaryFormat(JobPosition.Job.Salary);
            DeadlineName = $"{JobPosition.AnnouncementDate.Value.ToShortDateString()} - {JobPosition.SubmissionDate.Value.ToShortDateString()}";
            NumberOfRequestsText = JobPosition.JobPositionRequests.Count().ToString();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the salary text input field
            SalaryTextBox = new TextBox()
            {
                Text = SalaryTextBlock.Text,
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Collapsed
            };
            // Ads it to the data grid's row
            RowDataGrid.Children.Add(SalaryTextBox);
            Grid.SetColumn(SalaryTextBox, 2);

            // Creates the edit button
            EditComponent = new EditComponent
            {
                // Sets the edit command as a new relay command that...
                EditCommand = new RelayCommand(() =>
                {
                    // Hides the salary's text block
                    SalaryTextBlock.Visibility = Visibility.Collapsed;
                    // Shows the salary's text box
                    SalaryTextBox.Visibility = Visibility.Visible;
                    // Sets the salary's text box's text to the salary's text block's text
                    SalaryTextBox.Text = SalaryTextBlock.Text;
                }),

                // Sets the edit command as a new relay command that...
                SaveCommand = new RelayCommand(async () =>
                {
                    // Shows the salary's text block
                    SalaryTextBlock.Visibility = Visibility.Visible;
                    // Hides the salary's text box
                    SalaryTextBox.Visibility = Visibility.Collapsed;
                    // Sets the salary's text block's text to the salary's text box's text
                    SalaryTextBlock.Text = SalaryTextBox.Text;
                    await Services.GetDataStorage.UpdateJobPositionByManager(JobPosition.Job, ControlsFactory.ParseSalaryToInt(SalaryTextBox.Text));
                }),

                // Sets the edit command as a new relay command that...
                CancelCommand = new RelayCommand(() =>
                {
                    // Hides the salary's text block
                    SalaryTextBlock.Visibility = Visibility.Visible;
                    // Shows the salary's text box
                    SalaryTextBox.Visibility = Visibility.Collapsed;
                }),

                // Creates and adds a tool tip
                ToolTip = new ToolTipComponent() { Text = "Edit evaluation" }
            };

            // Add it to the grid
            RowDataGrid.Children.Add(EditComponent);
            // On the ninth column
            Grid.SetColumn(EditComponent, 9);
            Grid.SetColumnSpan(EditComponent, 2);
        }

        #endregion

    }
}
