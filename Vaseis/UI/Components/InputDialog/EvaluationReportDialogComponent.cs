using MaterialDesignThemes.Wpf;
using static Vaseis.Styles;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// The evaluation report's dialog
    /// </summary>
    public class EvaluationReportDialogComponent : DialogBaseComponent
    {
        /// <summary>
        /// The dialog host
        /// </summary>
        public DialogHost EvaluationReportDialogHost { get; private set; }

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
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent ReportGradeInput { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent QualificationsGradeInput { get; private set; }

        /// <summary>
        /// The text input component for the username
        /// </summary>
        protected TextInputComponent InterviewGradeInput { get; private set; }

        /// <summary>
        /// The stack panel for the comments section
        /// </summary>
        protected StackPanel CommentsStackPanel { get; private set; }

        /// <summary>
        /// Interview Comments text
        /// </summary>
        protected TextBlock CommentsTextBlock { get; private set; }

        /// <summary>
        /// The comments text box's border
        /// </summary>
        protected Border CommentsBorder { get; private set; }

        /// <summary>
        /// The comments' input text area
        /// </summary>
        protected TextBox CommentsTextBox { get; private set; }

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

        #endregion

        #region Constructors

        public EvaluationReportDialogComponent()
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
            // The title of the dialog
            DialogTitle.Text = "EvaluationReport";

            #region Input Data

            // The input field for user
            UserNameInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Employee's username",
                Width = 240,
            };

            // The input field for job position
            JopPositionInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Job position",
                Width = 240,
            };

            // The input field for report's grade
            ReportGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Report's grade",
                Width = 240,
            };

            // The input field for qualifications grade
            QualificationsGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Qualification's grade",
                Width = 240,
            };

            // The input field for user
            InterviewGradeInput = new TextInputComponent()
            {
                Margin = new Thickness(24),
                HintText = "Interview's grade",
                Width = 240,
            };

            // Adds the input field to the input wrap panel
            InputWrapPanel.Children.Add(UserNameInput);
            InputWrapPanel.Children.Add(JopPositionInput);
            InputWrapPanel.Children.Add(ReportGradeInput);
            InputWrapPanel.Children.Add(QualificationsGradeInput);
            InputWrapPanel.Children.Add(InterviewGradeInput);

            #endregion

            // Creates a stack panel for the comments area
            CommentsStackPanel = new StackPanel()
            {
                Margin = new Thickness(24, 0, 24, 0),
                Orientation = Orientation.Vertical,
                Width = 520
            };

            // Adds to the wrap panel the comments stack panel
            InputWrapPanel.Children.Add(CommentsStackPanel);

            // The title block for comments
            CommentsTextBlock = new TextBlock()
            {
                Text = "Interview comments",
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(0, 0, 0, 8)
            };

            // Adds the text block to the comments' stack panel...
            CommentsStackPanel.Children.Add(CommentsTextBlock);
            

            // The border for the comments inut area
            CommentsBorder = new Border()
            {
                BorderBrush = DarkGray.HexToBrush(),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5)
            };

            // The text input field for comments
            CommentsTextBox = new TextBox()
            {
                MinLines = 6,
                FontFamily = Calibri,
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
            };

            // Adds to the border the input field for the comments
            CommentsBorder.Child = CommentsTextBox;

            // Adds tot he stack panel the border
            CommentsStackPanel.Children.Add(CommentsBorder);

            // Creates the save button
            SaveButton = StyleHelpers.CreateDialogButton(LightBlue, "Temporary save");
            // Adds margin to the save button
            SaveButton.Margin = new Thickness(0, 0, 12, 0);
            // Adds the save button to the buttons' stack panel
            DialogButtonsStackPanel.Children.Add(SaveButton);

            // Creates the finalize and send button...
            FinalizeButton = StyleHelpers.CreateDialogButton(HookersGreen, "Finalize and send");
            // And adds margin to it
            FinalizeButton.Margin = new Thickness(12, 0, 0, 0);
            // Adds to the buttons' stack panel the finalize and send button
            DialogButtonsStackPanel.Children.Add(FinalizeButton);


            // Sets the component's content to the dialog host
            Content = DialogHost;
        }


        /// <summary>
        /// On click closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Sets the dialog host's property is open to false
            DialogHost.IsOpen = false;
        }

        #endregion

    }
}
