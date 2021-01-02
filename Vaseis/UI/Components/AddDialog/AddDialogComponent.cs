using MaterialDesignThemes.Wpf;

using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Windows.Data;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// Pop up dialog for adding data
    /// </summary>
    public class AddDialogComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The page's grid container
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The add button that fires the dialog
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The dialog host
        /// </summary>
        protected DialogHost EvaluationReportDialog { get; private set; }

        /// <summary>
        /// The border that contains the dialog grid
        /// </summary>
        protected Border DialogBorder { get; private set; }

        /// <summary>
        /// The grid containing the dialog text inputs
        /// </summary>
        protected Grid DialogGrid { get; private set; }

        /// <summary>
        /// The panel containing all input
        /// </summary>
        protected WrapPanel InputWrapPanel { get; private set; }

        /// <summary>
        /// The dialog's title
        /// </summary>
        protected TextBlock DialogTitle { get; private set; }

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

        public AddDialogComponent()
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
            DialogBorder = new Border()
            {
                BorderThickness = new Thickness(4),
                Background = LightBlue.HexToBrush()
            };

            DialogGrid = new Grid()
            { 
                Width = 580,
                Height = 700,
                Background = White.HexToBrush(),
                
            };

            DialogBorder.Child = DialogGrid;

            EvaluationReportDialog = new DialogHost()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                IsOpen = false,
                CloseOnClickAway = true,
                OverlayBackground = DarkGray.HexToBrush()
                
            };
            
            EvaluationReportDialog.DialogContent = DialogBorder;

            InputWrapPanel = new WrapPanel()
            {
                Margin = new Thickness(0, 80, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            DialogGrid.Children.Add(InputWrapPanel);

            DialogTitle = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = "Evaluation Report",
                FontSize = 36,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(24)
            };
            
            DialogGrid.Children.Add(DialogTitle);

            #region Input Data

            UserNameInput = new TextInputComponent()
            {
                HintText = "Employee's username",
                Width = 240,
                Height = 36
            };

            JopPositionInput = new TextInputComponent()
            {
                HintText = "Job position",
                Width = 240,
                Height = 36
            };

            ReportGradeInput = new TextInputComponent()
            {
                HintText = "Report's grade",
                Width = 240,
                Height = 36
            };

            QualificationsGradeInput = new TextInputComponent()
            {
                HintText = "Qualification's grade",
                Width = 240,
                Height = 36
            };

            InterviewGradeInput = new TextInputComponent()
            {
                HintText = "Interview's grade",
                Width = 240,
                Height = 36
            };

            InputWrapPanel.Children.Add(UserNameInput);
            InputWrapPanel.Children.Add(JopPositionInput);
            InputWrapPanel.Children.Add(ReportGradeInput);
            InputWrapPanel.Children.Add(QualificationsGradeInput);
            InputWrapPanel.Children.Add(InterviewGradeInput);

            #endregion

            CommentsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 540,
                Margin = new Thickness(24, 24, 0, 0)

            };
            
            InputWrapPanel.Children.Add(CommentsStackPanel);

            CommentsTextBlock = new TextBlock()
            {
                Text = "Interview comments",
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
            };

            CommentsStackPanel.Children.Add(CommentsTextBlock);

            var commentsBorder = new Border()
            {
                BorderThickness = new Thickness(1),
                BorderBrush = DarkPink.HexToBrush(),
                CornerRadius = new CornerRadius(5),
                Width = 532,
                Height = 180,
            };

            CommentsTextBox = new TextBox()
            {
                Margin = new Thickness(4),
                FontFamily = Calibri,
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
            };


            commentsBorder.Child = CommentsTextBox;

            CommentsStackPanel.Children.Add(commentsBorder);

            SaveButton = StyleHelpers.CreateDialogButton(LightBlue, "Temporary save");

            InputWrapPanel.Children.Add(SaveButton);

            AddButton = ControlsFactory.CreateAddButton(DarkBlue);

            AddButton.Click += ShowDialogOnClick;

            var grid = new Grid()
            {

            };

            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            grid.Children.Add(AddButton);
            grid.Children.Add(EvaluationReportDialog);
            //grid.Children.Add(DialogGrid);

            Content = grid;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDialogOnClick(object sender, RoutedEventArgs e)
        {
            EvaluationReportDialog.IsOpen = true;
        }

        #endregion

    }
}
