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
        /// More details text
        /// </summary>
        protected TextBlock MoreDetailsTextBlock { get; private set; }

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
        /// The interview's comments
        /// </summary>
        public string Report
        {
            get { return (string)GetValue(ReportProperty); }
            set { SetValue(ReportProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Report"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ReportProperty = DependencyProperty.Register(nameof(Report), typeof(string), typeof(ReportsDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReportsDataGridRowComponent()
        {

        }

        public ReportsDataGridRowComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
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
            ReportTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Report))
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

            // Sets the details' expander's content as the details' stack panel
            DetailsExpander.Content = ReportExpander;

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

        #endregion
    }
}
