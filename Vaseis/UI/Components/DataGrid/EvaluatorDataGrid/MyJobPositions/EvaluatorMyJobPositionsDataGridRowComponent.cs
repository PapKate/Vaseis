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
        /// The job picker
        /// </summary>
        protected ComboBox JobPositionPicker { get; private set; }

        /// <summary>
        /// The department picker
        /// </summary>
        protected ComboBox DepartmentPicker { get; private set; }

        /// <summary>
        /// The subject picker
        /// </summary>
        protected ComboBox SubjectPicker { get; private set; }

        /// <summary>
        /// The text boxes matching the text blocks
        /// </summary>
        protected Dictionary<TextBlock, TextBox> BlockAndBox { get; private set; }

        /// <summary>
        /// The pickers matching the text blocks
        /// </summary>
        protected Dictionary<TextBlock, ComboBox> BlockAndCombo { get; private set; }

        /// <summary>
        /// The text box for the method
        /// </summary>
        protected TextBox DataTextBox { get; private set; }

        /// <summary>
        /// The edit button
        /// </summary>
        protected EditComponent EditComponent { get; private set; }

        #endregion

        #region Dependency Properties

        #region JobPositionsList

        /// <summary>
        /// The list with the job positions' names
        /// </summary>
        public IEnumerable<string> JobPositionsList
        {
            get { return (IEnumerable<string>)GetValue(JobPositionsListProperty); }
            set { SetValue(JobPositionsListProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="JobPositionsList"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobPositionsListProperty = DependencyProperty.Register(nameof(JobPositionsList), typeof(IEnumerable<string>), typeof(EvaluatorMyJobPositionsDataGridRowComponent));

        #endregion

        #region DepartmentsList

        /// <summary>
        /// The list with the departments' names
        /// </summary>
        public IEnumerable<string> DepartmentsList
        {
            get { return (IEnumerable<string>)GetValue(DepartmentsListProperty); }
            set { SetValue(DepartmentsListProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DepartmentsList"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentsListProperty = DependencyProperty.Register(nameof(DepartmentsList), typeof(IEnumerable<string>), typeof(EvaluatorMyJobPositionsDataGridRowComponent));

        #endregion

        #region SubjectsList

        /// <summary>
        /// The list with the subjects' names
        /// </summary>
        public IEnumerable<string> SubjectsList
        {
            get { return (IEnumerable<string>)GetValue(SubjectsListProperty); }
            set { SetValue(SubjectsListProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SubjectsList"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SubjectsListProperty = DependencyProperty.Register(nameof(SubjectsList), typeof(IEnumerable<string>), typeof(EvaluatorMyJobPositionsDataGridRowComponent));

        #endregion

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
            SubjectText = JobPosition.Subjects.FirstOrDefault().Title;
            JobPositionText = JobPosition.Job.JobTitle;
            DepartmentText = JobPosition.Job.Department.DepartmentName.ToString();
            SalaryText = ControlsFactory.CreateSalaryFormat(JobPosition.Job.Salary);
            NumberOfRequestsText = JobPosition.JobPositionRequests.Count().ToString();
            DeadlineText = $"{JobPosition.AnnouncementDate.Value.ToShortDateString()} - {JobPosition.SubmissionDate.Value.ToShortDateString()}";
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

            var list = new List<string> { "boom", "bam" };

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

            JobPositionPicker = new ComboBox()
            {
                Width = 240,
                Margin = new Thickness(24),
                FontSize = 24,
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
            };
            JobPositionPicker.SetBinding(ComboBox.ItemsSourceProperty, new Binding(nameof(JobPositionsList))
            {
                Source = this
            });
            
            RowDataGrid.Children.Add(JobPositionPicker);
            Grid.SetColumn(JobPositionPicker, 0);


            BlockAndBox = new Dictionary<TextBlock, TextBox>()
            {
                { SalaryTextBlock, SalaryTextBox },
                { DeadlineTextBlock, DeadLineTextBox }
            };

            BlockAndCombo = new Dictionary<TextBlock, ComboBox>()
            {
                //{ JobPosistionTextBlock, JobPositionPicker},
                //{ DepartmentTextBlock, DepartmentPicker },
                //{ SubjectTextBlock, SubjectPicker },
            };

            // Creates the edit button
            EditComponent = new EditComponent
            {
                // The edit command
                EditCommand = new RelayCommand(() =>
                {
                    // For each text box and text block
                    foreach (var blockAndbox in BlockAndBox)
                    {
                        // Hides the text block
                        blockAndbox.Key.Visibility = Visibility.Collapsed;
                        // Shows the text box
                        blockAndbox.Value.Visibility = Visibility.Visible;
                        // Sets the text box's text as the block's text
                        blockAndbox.Value.Text = blockAndbox.Key.Text;
                    }

                    // For each picker and text block
                    foreach (var blockAndCombo in BlockAndCombo)
                    {
                        // Hides the text block
                        blockAndCombo.Key.Visibility = Visibility.Collapsed;
                        // Shows the picker
                        blockAndCombo.Value.Visibility = Visibility.Visible;
                        // Sets the picker's text as the block's text
                        blockAndCombo.Value.Text = blockAndCombo.Key.Text;
                    }
                }),

                // The save command
                SaveCommand = new RelayCommand(async () =>
                {
                // For each text box and text block
                foreach (var blockAndbox in BlockAndBox)
                {
                    // Shows the text block
                    blockAndbox.Key.Visibility = Visibility.Visible;
                    // Hides the text box
                    blockAndbox.Value.Visibility = Visibility.Collapsed;
                }

                // For each picker and text block
                foreach (var blockAndCombo in BlockAndCombo)
                {
                    // Shows the text block
                    blockAndCombo.Key.Visibility = Visibility.Visible;
                    // Hides the picker
                    blockAndCombo.Value.Visibility = Visibility.Collapsed;
                }

                    //var test1 = JobPositionPicker.Text;
                    //var test2 = ControlsFactory.GetDepartment(DepartmentText);
                    //var test3 = Int32.Parse(SalaryText);
                    //var test4 = ControlsFactory.GetAnnouncementDate(DeadlineText);
                    //var test5 = ControlsFactory.GetSubmissionDate(DeadlineText);


                    //await Services.GetDataStorage.UpdateJobPositionByEvaluator(JobPosition, 
                    //                                                               JobPositionText, 
                    //                                                               ControlsFactory.GetDepartment(DepartmentText), 
                    //                                                               Int32.Parse(SalaryText),
                    //                                                               ControlsFactory.GetAnnouncementDate(DeadlineText), 
                    //                                                               ControlsFactory.GetSubmissionDate(DeadlineText));
                }),

                // The cancel command
                CancelCommand = new RelayCommand(() =>
                {
                    // For each text box and text block
                    foreach (var blockAndbox in BlockAndBox)
                    {
                        // Shows the text block
                        blockAndbox.Key.Visibility = Visibility.Visible;
                        // Hides the text box
                        blockAndbox.Value.Visibility = Visibility.Collapsed;
                    }

                    // For each picker and text block
                    foreach (var blockAndCombo in BlockAndCombo)
                    {
                        // Shows the text block
                        blockAndCombo.Key.Visibility = Visibility.Visible;
                        // Hides the picker
                        blockAndCombo.Value.Visibility = Visibility.Collapsed;
                    }
                }),

                // Creates and adds a tool tip
                ToolTip = new ToolTipComponent() { Text = "Edit job position" }
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
