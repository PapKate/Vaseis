using System;
using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Windows.Data;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests data grid row
    /// </summary>
    public class EvaluatorJobRequestsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Protected Properties

        /// <summary>
        /// The employee's text block
        /// </summary>
        protected TextBlock EmployeeTextBlock { get; private set; }

        #endregion

        #region Dependency Properties

        #region Evaluator

        /// <summary>
        /// The evaluator's name
        /// </summary>
        public string EmployeeText
        {
            get { return (string)GetValue(EmployeeTextProperty); }
            set { SetValue(EmployeeTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EmployeeText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeeTextProperty = DependencyProperty.Register(nameof(EmployeeText), typeof(string), typeof(EvaluatorJobRequestsDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobRequestsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the evaluators text block
            EmployeeTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Adds it to the grid's header
            RowDataGrid.Children.Add(EmployeeTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(EmployeeTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(EmployeeTextBlock, 2);
            // Binds the evaluator's text block to the evaluator's name
            EmployeeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EmployeeText))
            {
                Source = this
            });
        }

        #endregion
    }
}
