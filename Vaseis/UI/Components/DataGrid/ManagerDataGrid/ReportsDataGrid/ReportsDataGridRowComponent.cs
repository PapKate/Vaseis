using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;


namespace Vaseis
{
    public class ReportsDataGridRowComponent : BaseDataGridRowComponent
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The report
        /// </summary>
        public ReportDataModel Report { get; }

        #region Protected Properties

        /// <summary>
        /// The expander for the report 
        /// </summary>
        protected Expander ReportExpander { get; private set; }

        /// <summary>
        /// The report's title text
        /// </summary>
        protected TextBlock ReportTitleTextBlock { get; private set; }

        /// <summary>
        /// The report
        /// </summary>
        protected TextBlock ReportTextBlock { get; private set; }

        /// <summary>
        /// The expander for the report 
        /// </summary>
        protected Expander RequestReasonExpander { get; private set; }

        /// <summary>
        /// The report's title text
        /// </summary>
        protected TextBlock RequestReasonTitleTextBlock { get; private set; }

        /// <summary>
        /// The report
        /// </summary>
        protected TextBlock RequestReasonTextBlock { get; private set; }

        /// <summary>
        /// The report's status text block
        /// </summary>
        protected TextBlock StatusTextBlock { get; private set; }

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock MoreDetailsTextBlock { get; private set; }

        /// <summary>
        /// The stack panel for the expanded row
        /// </summary>
        protected StackPanel ExtraStackPanel { get; private set; }

        /// <summary>
        /// The expander for the extra info
        /// </summary>
        protected Expander DetailsExpander { get; private set; }

        /// <summary>
        /// The edit button
        /// </summary>
        protected Button EditButton { get; private set; }

        /// <summary>
        /// The finalize and send button
        /// </summary>
        protected Button FinalizeButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region Report

        /// <summary>
        /// The report's comments
        /// </summary>
        public string ReportParagraph
        {
            get { return (string)GetValue(ReportParagraphProperty); }
            set { SetValue(ReportParagraphProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ReportParagraph"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ReportParagraphProperty = DependencyProperty.Register(nameof(ReportParagraph), typeof(string), typeof(ReportsDataGridRowComponent));

        #endregion

        #region ReasonForRequest

        /// <summary>
        /// The employee's comments for the request
        /// </summary>
        public string ReasonForRequest
        {
            get { return (string)GetValue(ReasonForRequestProperty); }
            set { SetValue(ReasonForRequestProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ReasonForRequest"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ReasonForRequestProperty = DependencyProperty.Register(nameof(ReasonForRequest), typeof(string), typeof(ReportsDataGridRowComponent));

        #endregion

        #region ReportStatus

        /// <summary>
        /// The interview's comments
        /// </summary>
        public bool IsWritten
        {
            get { return (bool)GetValue(ReportStatusProperty); }
            set { SetValue(ReportStatusProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="IsWritten"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ReportStatusProperty = DependencyProperty.Register(nameof(IsWritten), typeof(bool), typeof(ReportsDataGridRowComponent), new PropertyMetadata(OnStatusChanged));

        /// <summary>
        /// Handles the change of the <see cref="IsWritten"/> property
        /// </summary>
        private static void OnStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ReportsDataGridRowComponent;

            sender.OnStatusChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        public ReportsDataGridRowComponent(Grid pageGrid, ReportDataModel report)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Report = report ?? throw new ArgumentNullException(nameof(report));
            CreateGUI();

            Update();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates the UI based on the values of the <see cref="Report"/>
        /// </summary>
        public void Update()
        {
            EvaluatorName = Report.UsersJobFilesPair.Evaluator.Username;
            EmployeeName = Report.UsersJobFilesPair.Employee.Username;
            JobName = Report.JobPositionRequest.JobPosition.Job.JobTitle;
            ReportParagraph = Report.ReportText;
            ReasonForRequest = Report.JobPositionRequest.RequestsReason;
            DepartmentName = Report.JobPositionRequest.JobPosition.Job.Department.DepartmentName.ToString();
            IsWritten = Report.IsWritten;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="IsWritten"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnStatusChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the report's status text block
            StatusTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "Empty"
            };
            // Adds it to the grid's header
            RowDataGrid.Children.Add(StatusTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(StatusTextBlock, 5);
            // Sets the column span
            Grid.SetColumnSpan(StatusTextBlock, 3);
            
            //Creates the more details text
            MoreDetailsTextBlock = new TextBlock()
            {
                Text = "Details",
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            // Adds it to the grid
            RowDataGrid.Children.Add(MoreDetailsTextBlock);
            // On the eighth column
            Grid.SetColumn(MoreDetailsTextBlock, 8);

            // Creates the edit button
            EditButton = ControlsFactory.CreateEditButton();
            // Creates and adds a tool tip
            EditButton.ToolTip = new ToolTipComponent() { Text = "Edit evaluation" };

            EditButton.Click += ShowRowDialog;

            // Add it to the grid
            RowDataGrid.Children.Add(EditButton);
            // On the ninth column
            Grid.SetColumn(EditButton, 9);

            // Creates the finalize and send button
            FinalizeButton = ControlsFactory.CreateFinalizeButton();
            // Creates and adds a tool tip
            FinalizeButton.ToolTip = new ToolTipComponent() { Text = "Finalize and send evaluation" };
            // Add it to the grid
            RowDataGrid.Children.Add(FinalizeButton);
            // On the tenth column
            Grid.SetColumn(FinalizeButton, 10);
            // When clicked shows the finalized dialog
            FinalizeButton.Click += ShowFinalizedDialogOnClick;

            // Creates the details' expander
            DetailsExpander = new Expander()
            {
                // With header the grid
                Header = RowDataGrid,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
            };

            #region RequestReason Expanded

            // Creates the report's title text block
            RequestReasonTitleTextBlock = new TextBlock()
            {
                Text = "Employee's reason for applying",
                FontSize = 30,
                FontFamily = Calibri,
                Foreground = DarkPink.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(64, 0, 0, 0)
            };

            // Creates and adds the report's text block to the row's stack panel
            RequestReasonTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(64, 0, 0, 0)
            };
            // Binds the report's text block to the report's text block's text 
            RequestReasonTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(ReasonForRequest))
            {
                Source = this
            });

            // Creates an expander for the report
            RequestReasonExpander = new Expander()
            {
                Header = RequestReasonTitleTextBlock,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush()
            };
            // Sets its content as the report text
            RequestReasonExpander.Content = RequestReasonTextBlock;

            #endregion

            #region Report Expanded

            // Creates the report's title text block
            ReportTitleTextBlock = new TextBlock()
            {
                Text = "Report",
                FontSize = 30,
                FontFamily = Calibri,
                Foreground = DarkPink.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(64, 0, 0, 0)
            };

            // Creates and adds the report's text block to the row's stack panel
            ReportTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(64, 0, 0, 0)
            };
            // Binds the report's text block to the report's text block's text 
            ReportTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(ReportParagraph))
            {
                Source = this
            });

            // Creates an expander for the report
            ReportExpander = new Expander()
            {
                Header = ReportTitleTextBlock,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush()
            };
            // Sets its content as the report text
            ReportExpander.Content = ReportTextBlock;

            #endregion

            // Creates the extra's stack panel
            ExtraStackPanel = new StackPanel();
            // Adds the request's reason's expander to it
            ExtraStackPanel.Children.Add(RequestReasonExpander);
            // Adds the report's expander to it
            ExtraStackPanel.Children.Add(ReportExpander);
            

            // Sets the details' expander's content as the details' stack panel
            DetailsExpander.Content = ExtraStackPanel;

            // Sets the component's content as the details' expander
            Content = DetailsExpander;
        }

        /// <summary>
        /// On click closes the dialog
        /// </summary>
        private void ShowRowDialog(object sender, RoutedEventArgs e)
        {
            // Creates an evaluation dialog
            var reportDialog = new ReportDialogComponent(this)
            {
                // And opens it
                IsDialogOpen = true
            };
            // Adds it to the page's grid
            PageGrid.Children.Add(reportDialog);
        }

        /// <summary>
        /// Opens a dialog notifying the evaluator the evaluation has been sent to a manager
        /// </summary>
        private void ShowFinalizedDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new finalized dialog
            var finalizedDialog = new MessageDialogComponent()
            {
                Message = "Your report has been successfully sent to an evaluator",
                Title = "Success",
                BrushColor = HookersGreen.HexToBrush(),
                IsDialogOpen = true
            };
            // Adds it to the page's grid
            PageGrid.Children.Add(finalizedDialog);
        }

        /// <summary>
        /// Handles the change of the <see cref="EditCommand"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnStatusChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;

            if (newValue == true)
            {
                StatusTextBlock.Text = "Written";
            }
            else
                StatusTextBlock.Text = "Empty";

            // For a child's further modification
            OnStatusChanged(e);

            newValue = false;
        }
        #endregion
    }
}
