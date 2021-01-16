using System;
using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Windows.Data;

namespace Vaseis
{
    public class EvaluatorJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Protected Properties

        /// <summary>
        /// The evaluator's text block
        /// </summary>
        protected TextBlock EvaluatorTextBlock { get; private set; }

        /// <summary>
        /// The evaluator's tool tip
        /// </summary>
        protected ToolTipComponent EvaluatorToolTip { get; private set; }

        #endregion

        #region Dependency Properties

        #region Evaluator

        /// <summary>
        /// The evaluator's name
        /// </summary>
        public string EvaluatorText
        {
            get { return (string)GetValue(EvaluatorTextProperty); }
            set { SetValue(EvaluatorTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="EvaluatorText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorTextProperty = DependencyProperty.Register(nameof(EvaluatorText), typeof(string), typeof(BaseJobPositionsDataGridRowComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobPositionsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the evaluators text block
            EvaluatorTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Adds it to the grid's header
            RowDataGrid.Children.Add(EvaluatorTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(EvaluatorTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(EvaluatorTextBlock, 2);
            // Binds the evaluator's text block to the evaluator's name
            EvaluatorTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(EvaluatorText))
            {
                Source = this
            });
            // Creates a tool tip
            EvaluatorToolTip = new ToolTipComponent();
            // Binds its text property to the text
            EvaluatorToolTip.SetBinding(ToolTipComponent.TextProperty, new Binding(nameof(EvaluatorText))
            {
                Source = this
            });
            // Adds it to the text block
            EvaluatorTextBlock.ToolTip = EvaluatorToolTip;

        }

        #endregion
    }
}
