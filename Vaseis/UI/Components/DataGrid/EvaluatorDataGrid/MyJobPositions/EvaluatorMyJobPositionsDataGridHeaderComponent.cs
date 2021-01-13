using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The my job positions data grid header
    /// </summary>
    public class EvaluatorMyJobPositionsDataGridHeaderComponent : BaseJobPositionsDataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// The edit's text block
        /// </summary>
        protected TextBlock EditTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorMyJobPositionsDataGridHeaderComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the No of requests text block
            EditTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = "Edit job",
                ToolTip = new ToolTipComponent() { Text = "Edit job position" }
            };
            // Adds it to the grid's header
            DataGridHeader.Children.Add(EditTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(EditTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(EditTextBlock, 2);
        }

        #endregion

    }
}
