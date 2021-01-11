using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// 
    /// </summary>
    public class JobPositionsDataGridRowComponent : ContentControl
    {
        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

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
        /// The department's text block
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBlock SalaryTextBlock { get; private set; }

        /// <summary>
        /// The subject's text block
        /// </summary>
        protected TextBlock SubjectTextBlock { get; private set; }

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
        public static readonly DependencyProperty JobPositionTextProperty = DependencyProperty.Register(nameof(JobPositionText), typeof(string), typeof(JobPositionsDataGridRowComponent));

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
        public static readonly DependencyProperty DepartmentTextProperty = DependencyProperty.Register(nameof(DepartmentText), typeof(string), typeof(JobPositionsDataGridRowComponent));

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
        public static readonly DependencyProperty SalaryTextTextProperty = DependencyProperty.Register(nameof(SalaryText), typeof(string), typeof(JobPositionsDataGridRowComponent));

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
        public static readonly DependencyProperty SubjectTextProperty = DependencyProperty.Register(nameof(SubjectText), typeof(string), typeof(JobPositionsDataGridRowComponent));

        #endregion


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionsDataGridRowComponent()
        {
            CreateGUI();
        }

        public JobPositionsDataGridRowComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a <see cref="TextBlock"/> to the <see cref="RowStackPanel"/>
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
            RowDataGrid = ControlsFactory.CreateDataGridRowGrid();

            RowBorder = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
                Padding = new Thickness(12),

            };

            RowBorder.Child = RowDataGrid;

            #region RowData

            // Creates and adds the job position's text block to the row's stack panel
            JobPosistionTextBlock = CreateAndAddRowItem(0);
            // Binds the job position's text block to the job position's name
            JobPosistionTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(JobPositionText))
            {
                Source = this
            });

            // Creates and adds the department's text block to the row's stack panel
            DepartmentTextBlock = CreateAndAddRowItem(1);
            // Binds the department's text block to the department's name
            DepartmentTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(DepartmentText))
            {
                Source = this
            });

            // Creates and adds the salary's text block to the row's stack panel
            SalaryTextBlock = CreateAndAddRowItem(2);
            // Binds the salary's text block to the salary's name
            SalaryTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(SalaryText))
            {
                Source = this
            });

            // Creates and adds the subject's text block to the row's stack panel
            SubjectTextBlock = CreateAndAddRowItem(3);
            // Binds the subject's text block to the subject's name
            SubjectTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(SubjectText))
            {
                Source = this
            });

            #endregion

            Content = RowBorder;
        }

        #endregion


    }
}
