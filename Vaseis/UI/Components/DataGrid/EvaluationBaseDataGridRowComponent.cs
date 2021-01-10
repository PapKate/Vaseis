using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The manager's data grid's row component
    /// </summary>
    public abstract class EvaluationBaseDataGridRowComponent : DataGridRowComponent 
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The interview's info area
        /// </summary>
        protected StackPanel InterviewAreaStackPanel { get; private set; }

        /// <summary>
        /// The interview's title text
        /// </summary>
        protected TextBlock InterviewTitleTextBlock { get; private set; }

        /// <summary>
        /// The interview's comments
        /// </summary>
        protected TextBlock InterviewCommentsTextBlock { get; private set; }

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
        /// The expander for the interview comments
        /// </summary>
        protected Expander InterviewExpander { get; private set; }

        /// <summary>
        /// The expander for the report 
        /// </summary>
        protected Expander ReportExpander { get; private set; }

        /// <summary>
        /// The expander for the extra info
        /// </summary>
        protected Expander DetailsExpander { get; private set; }

        /// <summary>
        /// The detail's grin in the expander
        /// </summary>
        protected StackPanel DetailsStackPanel { get; private set; }

        #endregion

        #region Dependency Properties

        #region Interview comments

        /// <summary>
        /// The interview's comments
        /// </summary>
        public string InterviewComments
        {
            get { return (string)GetValue(InterviewCommentsProperty); }
            set { SetValue(InterviewCommentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="InterviewComments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty InterviewCommentsProperty = DependencyProperty.Register(nameof(InterviewComments), typeof(string), typeof(EvaluationBaseDataGridRowComponent));

        #endregion

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
        public static readonly DependencyProperty ReportProperty = DependencyProperty.Register(nameof(Report), typeof(string), typeof(EvaluationBaseDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluationBaseDataGridRowComponent()
        {

        }

        public EvaluationBaseDataGridRowComponent(Grid pageGrid)
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

            // Creates the details' expander
            DetailsExpander = new Expander()
            {
                // With header the grid
                Header = RowDataGrid,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
            };

            // Creates a new stack panel for the details
            DetailsStackPanel = new StackPanel();

            #region Interview expanded

            // Creates the interview's title text block
            InterviewTitleTextBlock = new TextBlock()
            {
                Text = "Interview comments",
                FontSize = 30,
                FontFamily = Calibri,
                Foreground = DarkPink.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(64, 0, 0, 0)
            };

            // Creates and adds the interview's text block to the row's stack panel
            InterviewCommentsTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(64, 0, 0, 0)
            };
            // Binds the interview's text block to the interview's comments
            InterviewCommentsTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(InterviewComments))
            {
                Source = this
            });

            // Creates an expander for the interview comments
            InterviewExpander = new Expander()
            {
                // With header the interview title
                Header = InterviewTitleTextBlock,
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush()
            };
            // Sets its content as the interview comments
            InterviewExpander.Content = InterviewCommentsTextBlock;

            // Adds the interview's expander in the details' stack panel
            DetailsStackPanel.Children.Add(InterviewExpander);

            #endregion

            #region Report expanded

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

            // Adds the expander to the details' stack panel
            DetailsStackPanel.Children.Add(ReportExpander);

            #endregion

            // Sets the details' expander's content as the details' stack panel
            DetailsExpander.Content = DetailsStackPanel;

            // Sets the component's content as the details' expander
            Content = DetailsExpander;
        }

        #endregion
    }
}
