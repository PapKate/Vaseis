using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's total job positions data grid row
    /// </summary>
    public class EvaluatorJobPositionsDataGridHeaderComponent : BaseJobPositionsDataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// The evaluator's text block
        /// </summary>
        protected TextBlock EvaluatorTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobPositionsDataGridHeaderComponent()
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
            // Creates the No of requests text block
            EvaluatorTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = "Evaluator",
                ToolTip = new ToolTipComponent() { Text = "Evaluator" }
            };
            // Adds it to the grid's header
            DataGridHeader.Children.Add(EvaluatorTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(EvaluatorTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(EvaluatorTextBlock, 2);
        }


        #endregion

    }
}
