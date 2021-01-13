
using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
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

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionRequestDialogComponent()
        {
            CreateGUI();
        }

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
                JobPositionBlock.Text = JobPositionDataGridRow.JobPositionText;
                DepartmentBlock.Text = JobPositionDataGridRow.DepartmentText;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            DialogTitle.Text = "Request evaluation for job";

            JobPositionBlock = new TextBlock()
            {
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                FontSize = 28,
                FontFamily = Calibri,
                Margin = new Thickness(24)
            };
            InputWrapPanel.Children.Add(JobPositionBlock);

            DepartmentBlock = new TextBlock()
            {
                Foreground = DarkGray.HexToBrush(),
                FontSize = 28,
                FontFamily = Calibri,
                Margin = new Thickness(24)
            };
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
            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);
        }

        #endregion
    }
}
