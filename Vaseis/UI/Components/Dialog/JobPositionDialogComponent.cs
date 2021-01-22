using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    /// <summary>
    /// The base for the job position dialogs
    /// </summary>
    public abstract class JobPositionDialogComponent : DialogBaseComponent
    {
        /// <summary>
        /// The evaluator's my job positions data grid row
        /// </summary>
        public EvaluatorMyJobPositionsDataGridRowComponent EvaluatorMyJobPositionsDataGridRow { get; }

        /// <summary>
        /// The JobTitle Input text
        /// </summary>
        public PickerComponent JobPositionPicker { get; private set; }

        #region Protected Properties

        /// <summary>
        /// The department PickerComponent
        /// </summary>
        protected PickerComponent DepartmentPicker { get; private set; }

        /// <summary>
        /// The JobPosition Salary Input
        /// </summary>
        public TextInputComponent SalaryInput { get; private set; }

        /// <summary>
        /// The JobPostion Date of Announcement PickerComponent
        /// </summary>
        public DatePicker AnnouncementDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion Date of submission PickerComponent
        /// </summary>
        public DatePicker SubmissionDatePicker { get; private set; }

        /// <summary>
        /// The JobPostion Date of startDate PickerComponent
        /// </summary>
        protected PickerComponent SubjectPicker { get; private set; }

        protected TogglesListComponent ToggleList { get; private set; }

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
        public static readonly DependencyProperty JobPositionsListProperty = DependencyProperty.Register(nameof(JobPositionsList), typeof(IEnumerable<string>), typeof(JobPositionDialogComponent));

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
        public static readonly DependencyProperty DepartmentsListProperty = DependencyProperty.Register(nameof(DepartmentsList), typeof(IEnumerable<string>), typeof(JobPositionDialogComponent));

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
        public static readonly DependencyProperty SubjectsListProperty = DependencyProperty.Register(nameof(SubjectsList), typeof(IEnumerable<string>), typeof(JobPositionDialogComponent));

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionDialogComponent(EvaluatorMyJobPositionsDataGridRowComponent myJobPositionsDataGridRow)
        {
            EvaluatorMyJobPositionsDataGridRow = myJobPositionsDataGridRow ?? throw new ArgumentNullException(nameof(myJobPositionsDataGridRow));

            CreateGUI();
        }

        /// <summary>
        /// New row constructor
        /// </summary>
        public JobPositionDialogComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the currently checked items of the list box
        /// </summary>
        public IEnumerable<CheckBox> CheckedItems()
            => ToggleList.CheckedItems();

        #endregion

        #region Private Methods 

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI() 
        {
            // Adds th dialog's title
            DialogTitle.Text = "Job position form";

            // Creates the job name picker
            JobPositionPicker = new PickerComponent()
            {
                CompleteFontSize = 24,
                Margin = new Thickness(24),
                HintText = "Job Position",
                Width = 240,
                
            };
            JobPositionPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(JobPositionsList))
            { 
                Source = this
            });
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(JobPositionPicker);

            // Creates the department picker
            DepartmentPicker = new PickerComponent()
            {
                CompleteFontSize = 24,
                Margin = new Thickness(24),
                HintText = "Department",
                Width = 240,
                Visibility = Visibility.Hidden
            };
            DepartmentPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(DepartmentsList))
            {
                Source = this
            });
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
                CompleteFontSize = 24,
                Margin = new Thickness(24, 0, 24, 0),
                HintText = "Subject",
                Width = 240,
            };
            SubjectPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(SubjectsList))
            {
                Source = this
            });
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(SubjectPicker);

            // Creates and adds the announcement date picker to the wrap panel
            AnnouncementDatePicker = ControlsFactory.CreateDatePicker("Announcement Date");
            InputWrapPanel.Children.Add(AnnouncementDatePicker);
            
            // Creates and adds the submission date picker to the wrap panel
            SubmissionDatePicker = ControlsFactory.CreateDatePicker("Submission Date");
            InputWrapPanel.Children.Add(SubmissionDatePicker);

            ToggleList = new TogglesListComponent();
            ToggleList.SetBinding(TogglesListComponent.ToggleNamesProperty, new Binding(nameof(SubjectsList))
            {
                Source = this
            });
            InputWrapPanel.Children.Add(ToggleList);

        }

        #endregion

    }


}
