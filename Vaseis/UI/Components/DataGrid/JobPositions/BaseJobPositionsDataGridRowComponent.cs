using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The base job position's data grid row
    /// </summary>
    public abstract class BaseJobPositionsDataGridRowComponent : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The grid for a row
        /// </summary>
        protected Grid RowDataGrid { get; private set; }

        /// <summary>
        /// The row's border
        /// </summary>
        protected Border RowBorder { get; private set; }

        /// <summary>
        /// The job position's text block
        /// </summary>
        protected TextBlock JobPosistionTextBlock { get; private set; }

        /// <summary>
        /// The job position's tool tip
        /// </summary>
        protected ToolTipComponent JobPositionToolTip { get; private set; }

        /// <summary>
        /// The department's text block
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The department's tool tip
        /// </summary>
        protected ToolTipComponent DepartmentToolTip { get; private set; }

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBlock SalaryTextBlock { get; private set; }

        /// <summary>
        /// The subject's text block
        /// </summary>
        protected TextBlock SubjectTextBlock { get; private set; }

        /// <summary>
        /// The subject's tool tip
        /// </summary>
        protected ToolTipComponent SubjectToolTip { get; private set; }

        /// <summary>
        /// The deadline's text block
        /// </summary>
        protected TextBlock DeadlineTextBlock { get; private set; }

        /// <summary>
        /// The number of job requests' text block
        /// </summary>
        protected TextBlock NumberOfJobRequestsTextBlock { get; private set; }

        #endregion

        #region Dependency Properties

        #region Job position

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string JobPositionText
        {
            get { return (string)GetValue(JobPositionTextProperty); }
            set { SetValue(JobPositionTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="JobPositionText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobPositionTextProperty = DependencyProperty.Register(nameof(JobPositionText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #region Department

        /// <summary>
        /// The department's name
        /// </summary>
        public string DepartmentText
        {
            get { return (string)GetValue(DepartmentTextProperty); }
            set { SetValue(DepartmentTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DepartmentText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentTextProperty = DependencyProperty.Register(nameof(DepartmentText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #region Salary

        /// <summary>
        /// The salary's name
        /// </summary>
        public string SalaryText
        {
            get { return (string)GetValue(SalaryTextTextProperty); }
            set { SetValue(SalaryTextTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SalaryText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SalaryTextTextProperty = DependencyProperty.Register(nameof(SalaryText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #region Subject

        /// <summary>
        /// The salary's name
        /// </summary>
        public string SubjectText
        {
            get { return (string)GetValue(SubjectTextProperty); }
            set { SetValue(SubjectTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SubjectText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SubjectTextProperty = DependencyProperty.Register(nameof(SubjectText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #region Deadline

        /// <summary>
        /// The deadline's dates
        /// </summary>
        public string DeadlineText
        {
            get { return (string)GetValue(DeadlineTextProperty); }
            set { SetValue(DeadlineTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DeadlineText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DeadlineTextProperty = DependencyProperty.Register(nameof(DeadlineText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #region NumberOfRequests

        /// <summary>
        /// The number of job position requests
        /// </summary>
        public string NumberOfRequestsText
        {
            get { return (string)GetValue(NumberOfRequestsTextProperty); }
            set { SetValue(NumberOfRequestsTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NumberOfRequestsText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NumberOfRequestsTextProperty = DependencyProperty.Register(nameof(NumberOfRequestsText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #region RemoveRow

        /// <summary>
        /// The open dialog command
        /// </summary>
        public ICommand ShowDialogCommand
        {
            get { return (ICommand)GetValue(ShowDialogCommandProperty); }
            set { SetValue(ShowDialogCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ShowDialogCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ShowDialogCommandProperty = DependencyProperty.Register(nameof(ShowDialogCommand), typeof(ICommand), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseJobPositionsDataGridRowComponent()
        {
            CreateGUI();
        }

        public BaseJobPositionsDataGridRowComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a <see cref="TextBlock"/> to the <see cref="RowDataGrid"/>
        /// </summary>
        /// <param name="rowIndex">The row's index</param>
        protected TextBlock CreateAndAddRowItem(int columnIndex)
        {
            // Creates the text block
            var textBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };

            // Adds it to the stack panel
            RowDataGrid.Children.Add(textBlock);
            Grid.SetColumn(textBlock, columnIndex);
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
            // Creates the row's grid
            RowDataGrid = ControlsFactory.CreateDataGridRowGrid();

            // Creates the row's border
            RowBorder = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
                Padding = new Thickness(12),

            };
            // Sets as the row's border child the row grid
            RowBorder.Child = RowDataGrid;

            #region RowData

            // Creates and adds the job position's text block to the row's grid
            JobPosistionTextBlock = CreateAndAddRowItem(0);
            // Binds the job position's text block to the job position's name
            JobPosistionTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(JobPositionText))
            {
                Source = this
            });
            // Creates a tool tip
            JobPositionToolTip = new ToolTipComponent();
            // Binds its text property to the text
            JobPositionToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(JobPositionText))
            { 
                Source = this
            });
            // Adds it to the text block
            JobPosistionTextBlock.ToolTip = JobPositionToolTip;

            // Creates and adds the department's text block to the row's grid
            DepartmentTextBlock = CreateAndAddRowItem(1);
            // Binds the department's text block to the department's name
            DepartmentTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(DepartmentText))
            {
                Source = this
            });
            // Creates a tool tip
            DepartmentToolTip = new ToolTipComponent();
            // Binds its text property to the text
            DepartmentToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(DepartmentText))
            {
                Source = this
            });
            // Adds it to the text block
            DepartmentTextBlock.ToolTip = DepartmentToolTip;

            // Creates and adds the salary's text block to the row's grid
            SalaryTextBlock = CreateAndAddRowItem(2);
            // Binds the salary's text block to the salary's name
            SalaryTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(SalaryText))
            {
                Source = this
            });

            // Creates and adds the subject's text block to the row's grid
            SubjectTextBlock = CreateAndAddRowItem(3);
            // Binds the subject's text block to the subject's name
            SubjectTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(SubjectText))
            {
                Source = this
            });
            // Creates a tool tip
            SubjectToolTip= new ToolTipComponent();
            // Binds its text property to the text
            SubjectToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(SubjectText))
            {
                Source = this
            });
            // Adds it to the text block
            SubjectTextBlock.ToolTip = SubjectToolTip;

            // Creates the No of requests text block
            DeadlineTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Adds it to the grid's header
            RowDataGrid.Children.Add(DeadlineTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(DeadlineTextBlock, 4);
            // Sets the column span
            Grid.SetColumnSpan(DeadlineTextBlock, 4);
            // Binds the subject's text block to the subject's name
            DeadlineTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(DeadlineText))
            {
                Source = this
            });

            // Creates and adds the number of requests text block to the row's grid
            NumberOfJobRequestsTextBlock = CreateAndAddRowItem(8);
            // Binds the  number of job position requests' text block to the  number of job position requests' text
            NumberOfJobRequestsTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(NumberOfRequestsText))
            {
                Source = this
            });

            #endregion

            Content = RowBorder;
        }

        #endregion


    }
}
