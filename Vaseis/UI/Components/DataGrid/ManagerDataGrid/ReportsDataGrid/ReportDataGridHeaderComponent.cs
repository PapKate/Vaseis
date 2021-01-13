using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The report's data grid header
    /// </summary>
    public class ReportDataGridHeaderComponent : BaseDataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// The report's status text block
        /// </summary>
        protected TextBlock StatusTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReportDataGridHeaderComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the report's status text block
            StatusTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = "Status",
                ToolTip = new ToolTipComponent() { Text = "Report's status" }
            };
            // Adds it to the grid's header
            DataGridHeader.Children.Add(StatusTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(StatusTextBlock, 5);
            // Sets the column span
            Grid.SetColumnSpan(StatusTextBlock, 3);
        }

        #endregion


    }
}
