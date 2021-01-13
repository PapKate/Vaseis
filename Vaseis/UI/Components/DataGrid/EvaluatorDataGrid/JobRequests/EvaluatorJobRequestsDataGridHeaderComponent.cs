using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests data grid row
    /// </summary>
    public class EvaluatorJobRequestsDataGridHeaderComponent : BaseJobPositionsDataGridHeaderComponent
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
        public EvaluatorJobRequestsDataGridHeaderComponent()
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
            NumberOfRequestsTextBlock.ToolTip = new ToolTipComponent() { Text = "Request's number" };

            // Creates the No of requests text block
            EvaluatorTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = "Employee",
                ToolTip = new ToolTipComponent() { Text = "Employee" }
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
