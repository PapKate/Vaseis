
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The job position request dialog
    /// </summary>
    public class JobPositionRequestDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The job position's title
        /// </summary>
        protected TextBlock JobPositionBlock { get; private set; }

        /// <summary>
        /// The department block
        /// </summary>
        protected TextBlock DepartmentBlock { get; private set; }
        
        /// <summary>
        /// The stack panel for the comments section
        /// </summary>
        protected StackPanel TextStackPanel { get; private set; }
        
        /// <summary>
        /// The "Why I want this position" text
        /// </summary>
        protected TextBlock TextTitleBlock { get; private set; }

        /// <summary>
        /// The text box's border
        /// </summary>
        protected Border TextBorder { get; private set; }

        /// <summary>
        /// The "why I want this job" input field
        /// </summary>
        protected TextBox ParagraphTextBox { get; private set; }

        /// <summary>
        /// The request's create Button
        /// </summary>
        protected Button CreateButton { get; private set; }

        /// <summary>
        /// The job positions' data grid row
        /// </summary>
        protected EmployeeJobPositionsDataGridRowComponent JobPositionDataGridRow { get; private set; }

        #endregion

        #region Dependency Properties

        #endregion

        #region RequestCommand

        /// <summary>
        /// The request evaluation command
        /// </summary>
        public ICommand RequestCommand
        {
            get { return (ICommand)GetValue(RequestCommandProperty); }
            set { SetValue(RequestCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="RequestCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty RequestCommandProperty = DependencyProperty.Register(nameof(RequestCommand), typeof(ICommand), typeof(JobPositionRequestDialogComponent));

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionRequestDialogComponent(EmployeeJobPositionsDataGridRowComponent jobPositionDataGridRow)
        {
            JobPositionDataGridRow = jobPositionDataGridRow ?? throw new ArgumentNullException(nameof(jobPositionDataGridRow));

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
            if (JobPositionDataGridRow != null)
            {
                // Add the text from the row to the input text in the dialog accordingly
                JobPositionBlock.Text = JobPositionDataGridRow.JobPositionName;
                DepartmentBlock.Text = JobPositionDataGridRow.DepartmentName;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Sets the dialog's title text
            DialogTitle.Text = "Request evaluation for job";

            // Creates a text block for job position
            JobPositionBlock = new TextBlock()
            {
                Foreground = DarkGray.HexToBrush(),
                FontSize = 28,
                FontFamily = Calibri,
                Margin = new Thickness(24)
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(JobPositionBlock);

            // Creates a text block for job position
            DepartmentBlock = new TextBlock()
            {
                Foreground = DarkGray.HexToBrush(),
                FontSize = 28,
                FontFamily = Calibri,
                Margin = new Thickness(24)
            };
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(DepartmentBlock);

            // Creates a stack panel for the paragraph area
            TextStackPanel = new StackPanel()
            {
                Margin = new Thickness(24, 0, 24, 0),
                Orientation = Orientation.Vertical,
                Width = 520
            };
            // Adds to the wrap panel the paragraph stack panel
            InputStackPanel.Children.Add(TextStackPanel);

            // The title block for paragraph
            TextTitleBlock = new TextBlock()
            {
                Text = "Why I want this position...",
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(0, 0, 0, 8)
            };
            // Adds the text block to the paragraph' stack panel...
            TextStackPanel.Children.Add(TextTitleBlock);

            // The border for the paragraph input area
            TextBorder = new Border()
            {
                BorderBrush = DarkGray.HexToBrush(),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5)
            };

            // The text input field for paragraph
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

            // Adds to the border the input field for the paragraph
            TextBorder.Child = ParagraphTextBox;

            // Adds tot he stack panel the border
            TextStackPanel.Children.Add(TextBorder);

            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(GreenBlue, "Send request");
            // On click call method
            CreateButton.Click += CloseDialogOnClick;
            // Bind the button's command to the request command
            CreateButton.SetBinding(Button.CommandProperty, new Binding(nameof(RequestCommand))
            { 
                Source = this
            });

            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);
        }

        /// <summary>
        /// Overrides the virtual method
        /// </summary>
        protected override void CloseDialogOnClick(RoutedEventArgs e)
        {
            base.CloseDialogOnClick(e);
        }

        #endregion
    }
}
