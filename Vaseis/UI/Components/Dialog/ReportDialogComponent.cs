using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The report's dialog
    /// </summary>
    public class ReportDialogComponent : DialogBaseComponent
    {
        #region Public Properties
        
        /// <summary>
        /// The evaluator's data grid row
        /// </summary>
        public EvaluatorDataGridRowComponent EvaluatorDataGridRow { get; }

        /// <summary>
        /// The manager's report data grid row
        /// </summary>
        public ReportsDataGridRowComponent ReportDataGridRow { get; }

        /// <summary>
        /// The report
        /// </summary>
        public ReportDataModel Report { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextBlock UserNameTextBlock { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextBlock JopPositionTextBlock { get; private set; }

        /// <summary>
        /// The department picker component
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The evaluator's picker
        /// </summary>
        protected PickerComponent EvaluatorPicker { get; private set; }

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

        #region Dependency Properties

        #region EvaluatorsList

        /// <summary>
        /// The paragraph's text
        /// </summary>
        public IEnumerable<string> EvaluatorsList
        {
            get { return (IEnumerable<string>)GetValue(EvaluatorsListProperty); }
            set { SetValue(EvaluatorsListProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorsList"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorsListProperty = DependencyProperty.Register(nameof(EvaluatorsList), typeof(IEnumerable<string>), typeof(ReportDialogComponent));

        #endregion

        #region FinalizedCommand

        /// <summary>
        /// The dialog's finalized command
        /// </summary>
        public ICommand FinalizedCommand
        {
            get { return (ICommand)GetValue(FinalizedCommandProperty); }
            set { SetValue(FinalizedCommandProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="FinalizedCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FinalizedCommandProperty = DependencyProperty.Register(nameof(FinalizedCommand), typeof(ICommand), typeof(ReportDialogComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for evaluator's evaluation
        /// </summary>
        public ReportDialogComponent(EvaluatorDataGridRowComponent evaluatorDataGridRow)
        {
            EvaluatorDataGridRow = evaluatorDataGridRow ?? throw new ArgumentNullException(nameof(evaluatorDataGridRow));

            CreateGUI();
        }

        /// <summary>
        /// Default constructor for manager's report
        /// </summary>
        public ReportDialogComponent(ReportsDataGridRowComponent reportDataGridRow, ReportDataModel report)
        {
            ReportDataGridRow = reportDataGridRow ?? throw new ArgumentNullException(nameof(reportDataGridRow));
            Report = report ?? throw new ArgumentNullException(nameof(report));

            CreateGUI();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets as selected item the combo box item with content the string
        /// </summary>
        /// <param name="itemName">The evaluator's username</param>
        public void SelectedEvaluator(string itemName)
            => EvaluatorPicker.SelectItem(itemName);

        #endregion

        #region Protected Methods

        /// <summary>
        /// Displays the data grid's values in the dialog
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
                UserNameTextBlock.Text = EvaluatorDataGridRow.EmployeeName;
                JopPositionTextBlock.Text = EvaluatorDataGridRow.JobPositionName;
            }

            // If the row is not null...
            if (ReportDataGridRow != null)
            {
                // Add the text from the row to the input text in the dialog accordingly
                ParagraphTextBox.Text = ReportDataGridRow.Report.ReportText;
                UserNameTextBlock.Text = ReportDataGridRow.EmployeeName;
                DepartmentTextBlock.Text = ReportDataGridRow.DepartmentName;
                JopPositionTextBlock.Text = ReportDataGridRow.JobPositionName;
                EvaluatorPicker.Text = ReportDataGridRow.EvaluatorName;
            }
        }

        /// <summary>
        /// Addition to the <see cref="TemporarySaveOnClick(object, RoutedEventArgs)"/>
        /// </summary>
        /// <param name="e"></param>
        protected virtual void TemporarySaveOnClick(RoutedEventArgs e)
        { 
        
        }

        /// <summary>
        /// Addition to the <see cref="FinalizedOnClick(object, RoutedEventArgs)"/>
        /// </summary>
        /// <param name="e"></param>
        protected virtual void FinalizedOnClick(RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Creates and adds a text block to the dialog
        /// </summary>
        protected TextBlock CreateAndAddTextBlock()
        {
            // Creates a new text block
            var textBlock = new TextBlock()
            {
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                MinWidth = 240,
                Margin = new Thickness(24),
                TextTrimming = TextTrimming.CharacterEllipsis,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Adds it to the input wrap panel
            InputWrapPanel.Children.Add(textBlock);

            // Returns the text block
            return textBlock;
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
            UserNameTextBlock = CreateAndAddTextBlock();

            // The input field for job position
            JopPositionTextBlock = CreateAndAddTextBlock();

            // The picker for department
            DepartmentTextBlock = CreateAndAddTextBlock();

            // If a report dialog is created...
            if(ReportDataGridRow != null)
            {
                // Creates the evaluators' picker
                EvaluatorPicker = new PickerComponent()
                {
                    OptionNames = EvaluatorsList,
                    HintText = "Evaluator",
                    Width = 240,
                    CompleteFontSize = 24,
                };
                // Binds the option names of the evaluator picker to the evaluator list
                EvaluatorPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(EvaluatorsList))
                {
                    Source = this
                });

                // Adds to the wrap panel
                InputWrapPanel.Children.Add(EvaluatorPicker);
            }
            
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
            // On click calls method
            FinalizeButton.Click += FinalizedOnClick;
            FinalizeButton.SetBinding(Button.CommandProperty, new Binding(nameof(FinalizedCommand))
            { 
                Source = this
            });
            // Sets the component's content to the dialog host
            Content = DialogHost;
        }

        /// <summary>
        /// Saves the new values in the data grid
        /// </summary>
        private async void TemporarySaveOnClick (object sender, RoutedEventArgs e)
        {
            // If the report row exists...
            if (ReportDataGridRow != null)
            {
                // Sets the report's data model values according to the matching input in the dialog
                Report.ReportText = ParagraphTextBox.Text;
                Report.UsersJobFilesPair.Evaluator.Username = EvaluatorPicker.Text;
                // If the paragraph text is NOT empty...
                if (ParagraphTextBox.Text != "")
                    // Sets the is written property of the report's data grid's row to true
                    Report.IsWritten = true;
                // Else...
                else
                    // Sets it to false
                    Report.IsWritten = false;
                // Updates the report data model in the data base
                await Services.GetDataStorage.UpdateReportAsync(Report, false);
                // Updates the reports data grid's row
                ReportDataGridRow.Update();
            }

            // For extra manipulation if wanted in a child class
            TemporarySaveOnClick(e);
            
            // Closes the dialog
            DialogHost.IsOpen = false;
        }

        /// <summary>
        /// Closes the dialog 
        /// Sends the report to the evaluator
        /// </summary>
        private async void FinalizedOnClick(object sender, RoutedEventArgs e)
        {
            if(ReportDataGridRow != null)
            {
                //Set the finalized value to true (finalized)
                Report.IsFinalized = true;
                //update the inputs to the memory
                TemporarySaveOnClick(sender, e);
                //update the finalized value to true
                await Services.GetDataStorage.UpdateReportAsync(Report, true);
                // Creates a new evaluation 
                await Services.GetDataStorage.AddEvaluatorEvaliation(Report);
                // Collapses the row until the next creation of the data grid's page
                ReportDataGridRow.Visibility = Visibility.Collapsed;
            }
            FinalizedOnClick(e);
            // Closes the dialog
            DialogHost.IsOpen = false;
        }

        #endregion
    }
}
