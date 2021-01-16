using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The base class for the data grid's rows for evaluations
    /// </summary>
    public abstract class BaseDataGridRowComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The grid for a row
        /// </summary>
        protected Grid RowDataGrid { get; private set; }

        /// <summary>
        /// The evaluator's name
        /// </summary>
        protected TextBlock EvaluatorTextBlock { get; private set; }

        /// <summary>
        /// The evaluator's tool tip
        /// </summary>
        protected ToolTipComponent EvaluatorToolTip { get; private set; }

        /// <summary>
        /// The employee's name
        /// </summary>
        protected TextBlock EmployeeTextBlock { get; private set; }

        /// <summary>
        /// The employee's tool tip
        /// </summary>
        protected ToolTipComponent EmployeeToolTip { get; private set; }

        /// <summary>
        /// The job's name
        /// </summary>
        protected TextBlock JobTextBlock { get; private set; }

        /// <summary>
        /// The job's tool tip
        /// </summary>
        protected ToolTipComponent JobToolTip { get; private set; }

        /// <summary>
        /// The department's name
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The department's tool tip
        /// </summary>
        protected ToolTipComponent DepartmentToolTip { get; private set; }

        #endregion

        #region Dependency Properties

        #region Employee name

        /// <summary>
        /// The Employees's name
        /// </summary>
        public string EmployeeName
        {
            get { return (string)GetValue(EmployeeNameProperty); }
            set { SetValue(EmployeeNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmployeeName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeeNameProperty = DependencyProperty.Register(nameof(EmployeeName), typeof(string), typeof(BaseDataGridRowComponent));

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
        public static readonly DependencyProperty ShowDialogCommandProperty = DependencyProperty.Register(nameof(ShowDialogCommand), typeof(ICommand), typeof(BaseDataGridRowComponent));

        #endregion

        #region Evaluator name

        /// <summary>
        /// The evaluator's name
        /// </summary>
        public string EvaluatorName
        {
            get { return (string)GetValue(EvaluatorNameProperty); }
            set { SetValue(EvaluatorNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorNameProperty = DependencyProperty.Register(nameof(EvaluatorName), typeof(string), typeof(BaseDataGridRowComponent));

        #endregion

        #region Job name

        /// <summary>
        /// The job's name
        /// </summary>
        public string JobName
        {
            get { return (string)GetValue(JobNameProperty); }
            set { SetValue(JobNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="JobName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobNameProperty = DependencyProperty.Register(nameof(JobName), typeof(string), typeof(BaseDataGridRowComponent));

        #endregion

        #region Department name

        /// <summary>
        /// The department's name
        /// </summary>
        public string DepartmentName
        {
            get { return (string)GetValue(DepartmentNameProperty); }
            set { SetValue(DepartmentNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DepartmentName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentNameProperty = DependencyProperty.Register(nameof(DepartmentName), typeof(string), typeof(BaseDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDataGridRowComponent()
        {
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
                TextTrimming = TextTrimming.CharacterEllipsis,
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
            // Creates the data grid's row
            RowDataGrid = ControlsFactory.CreateDataGridRowGrid();

            #region RowData

            // Creates and adds the evaluator's text block to the row's stack panel
            EvaluatorTextBlock = CreateAndAddRowItem(0);
            // Binds the evaluator's text block to the evaluator's name
            EvaluatorTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluatorName))
            {
                Source = this
            });
            // Creates the tool tip
            EvaluatorToolTip = new ToolTipComponent();
            // Binds it's text property to the string
            EvaluatorToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(EvaluatorName))
            { 
                Source = this
            });
            // Adds it to the text block
            EvaluatorTextBlock.ToolTip = EvaluatorToolTip;

            // Creates and adds the employee's text block to the row's stack panel
            EmployeeTextBlock = CreateAndAddRowItem(1);
            // Binds the employee's text block to the employee's name
            EmployeeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EmployeeName))
            {
                Source = this
            });
            // Creates the tool tip
            EmployeeToolTip = new ToolTipComponent();
            // Binds it's text property to the string
            EmployeeToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(EmployeeName))
            {
                Source = this
            });
            // Adds it to the text block
            EmployeeTextBlock.ToolTip = EmployeeToolTip;

            // Creates and adds the job position's text block to the row's stack panel
            JobTextBlock = CreateAndAddRowItem(2);
            // Binds the job position's text block to the job's name
            JobTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(JobName))
            {
                Source = this
            });
            // Creates the tool tip
            JobToolTip = new ToolTipComponent();
            // Binds it's text property to the string
            JobToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(JobName))
            {
                Source = this
            });
            // Adds it to the text block
            JobTextBlock.ToolTip = JobToolTip;

            // Creates and adds the department's text block to the row's stack panel
            DepartmentTextBlock = CreateAndAddRowItem(3);
            // Binds the department's text block to the department's name
            DepartmentTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(DepartmentName))
            {
                Source = this
            });
            // Creates the tool tip
            DepartmentToolTip = new ToolTipComponent();
            // Binds it's text property to the string
            DepartmentToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(DepartmentName))
            {
                Source = this
            });
            // Adds it to the text block
            DepartmentTextBlock.ToolTip = DepartmentToolTip;

            #endregion
        }

        #endregion

    }
}
