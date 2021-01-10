using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class ReportDialogComponent : DialogBaseComponent
    {
        /// <summary>
        /// The evaluator's data grid row
        /// </summary>
        public EvaluatorDataGridRowComponent EvaluatorDataGridRow { get; }

        /// <summary>
        /// The manager's report data grid row
        /// </summary>
        public ReportsDataGridRowComponent ReportDataGridRow { get; }

        #region Protected Properties

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent UserNameInput { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent JopPositionInput { get; private set; }

        /// <summary>
        /// The department picker component
        /// </summary>
        protected PickerComponent DepartmentPicker { get; private set; }

        /// <summary>
        /// The stack panel for the comments section
        /// </summary>
        protected StackPanel TextStackPanel { get; private set; }

        /// <summary>
        /// Interview Comments text
        /// </summary>
        protected TextBlock TextTitleBlock { get; private set; }

        /// <summary>
        /// The comments text box's border
        /// </summary>
        protected Border TextBorder { get; private set; }

        /// <summary>
        /// The comments' input text area
        /// </summary>
        protected TextBox ParagraphTextBox { get; private set; }

        /// <summary>
        /// Finalize and send report button
        /// </summary>
        protected Button FinalizeButton { get; private set; }

        /// <summary>
        /// Temporary save report button
        /// </summary>
        protected Button SaveButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReportDialogComponent()
        {
            CreateGUI();
        }

        public ReportDialogComponent(EvaluatorDataGridRowComponent evaluatorDataGridRow)
        {
            EvaluatorDataGridRow = evaluatorDataGridRow ?? throw new ArgumentNullException(nameof(evaluatorDataGridRow));

            CreateGUI();
        }

        public ReportDialogComponent(ReportsDataGridRowComponent reportDataGridRow)
        {
            ReportDataGridRow = reportDataGridRow ?? throw new ArgumentNullException(nameof(reportDataGridRow));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Displays the data grid's values in the report
        /// </summary>
        protected override void DialogVisibilityChanged(DependencyPropertyChangedEventArgs e)
        {
            // The virtual method
            base.DialogVisibilityChanged(e);
            // If the row is not null...
            if (EvaluatorDataGridRow != null)
            {
                // Add the text from the row to the input text in the dialog accordingly
                ParagraphTextBox.Text = EvaluatorDataGridRow.InterviewComments;
                UserNameInput.Text = EvaluatorDataGridRow.EmployeeName;
                JopPositionInput.Text = EvaluatorDataGridRow.JobName;
            }
        }

        /// <summary>
        /// Addition to the <see cref="TemporarySaveOnClick(object, RoutedEventArgs)"/>
        /// </summary>
        /// <param name="e"></param>
        protected virtual void TemporarySaveOnClick(RoutedEventArgs e)
        { 
        
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // The title of the dialog
            DialogTitle.Text = "Employee report";

            // The input field for user
            UserNameInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Employee's username",
                Width = 240,
                
            };
            // Adds the input field to the input wrap panel
            InputWrapPanel.Children.Add(UserNameInput);

            // The input field for job position
            JopPositionInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Job position",
                Width = 240,
            };
            // Adds the input field to the input wrap panel
            InputWrapPanel.Children.Add(JopPositionInput);

            // The picker for department
            DepartmentPicker = new PickerComponent()
            {
                HintText = "Department",
                OptionNames = new List<string> { "Yeet", "Boom", "Potato", "Bazooka", "Development" }
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentPicker);

            // Creates a stack panel for the comments area
            TextStackPanel = new StackPanel()
            {
                Margin = new Thickness(24, 0, 24, 0),
                Orientation = Orientation.Vertical,
                Width = 520
            };

            // Adds to the wrap panel the comments stack panel
            InputStackPanel.Children.Add(TextStackPanel);

            // The title block for comments
            TextTitleBlock = new TextBlock()
            {
                Text = "Report",
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(0, 0, 0, 8)
            };

            // Adds the text block to the comments' stack panel...
            TextStackPanel.Children.Add(TextTitleBlock);


            // The border for the comments input area
            TextBorder = new Border()
            {
                BorderBrush = DarkGray.HexToBrush(),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5)
            };

            // The text input field for comments
            ParagraphTextBox = new TextBox()
            {
                MinLines = 6,
                FontFamily = Calibri,
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                Padding = new Thickness(4),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                MinHeight = 200,
                MaxHeight = 300
            };

            // Adds to the border the input field for the comments
            TextBorder.Child = ParagraphTextBox;

            // Adds tot he stack panel the border
            TextStackPanel.Children.Add(TextBorder);

            // Creates the save button
            SaveButton = StyleHelpers.CreateDialogButton(LightBlue, "Temporary save");
            // Adds margin to the save button
            SaveButton.Margin = new Thickness(0, 0, 12, 0);
            // Adds the save button to the buttons' stack panel
            DialogButtonsStackPanel.Children.Add(SaveButton);

            SaveButton.Click += TemporarySaveOnClick;

            // Creates the finalize and send button...
            FinalizeButton = StyleHelpers.CreateDialogButton(HookersGreen, "Finalize and send");
            // And adds margin to it
            FinalizeButton.Margin = new Thickness(12, 0, 0, 0);
            // Adds to the buttons' stack panel the finalize and send button
            DialogButtonsStackPanel.Children.Add(FinalizeButton);

            FinalizeButton.Click += ReportFinalizedOnClick;

            // Sets the component's content to the dialog host
            Content = DialogHost;
        }

        /// <summary>
        /// Saves the new values in the data grid
        /// </summary>
        private void TemporarySaveOnClick (object sender, RoutedEventArgs e)
        {
            // If the evaluation row exists...
            if (EvaluatorDataGridRow != null)
            {
                // Sets the row's values according to the matching input in the dialog
                EvaluatorDataGridRow.InterviewComments = ParagraphTextBox.Text;
                EvaluatorDataGridRow.EmployeeName = UserNameInput.Text;
                EvaluatorDataGridRow.JobName = JopPositionInput.Text;
                EvaluatorDataGridRow.DepartmentName = DepartmentPicker.Text;
                DialogHost.IsOpen = false;
            }
            // If the report row exists...
            if (ReportDataGridRow != null)
            {
                // Sets the row's values according to the matching input in the dialog
                ReportDataGridRow.Report = ParagraphTextBox.Text;
                ReportDataGridRow.EmployeeName = UserNameInput.Text;
                ReportDataGridRow.JobName = JopPositionInput.Text;
                ReportDataGridRow.DepartmentName = DepartmentPicker.Text;
                DialogHost.IsOpen = false;
            }
            TemporarySaveOnClick(e);
        }

        /// <summary>
        /// Closes the dialog 
        /// Sends the report to the evaluator
        /// </summary>
        private void ReportFinalizedOnClick(object sender, RoutedEventArgs e)
        {
            // Closes the dialog
            DialogHost.IsOpen = false;
        }

        #endregion

    }
}
