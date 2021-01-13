using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{
    public class EmployeeJobRequestsDataGridHeaderComponent : BaseJobPositionsDataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// The edit's text block
        /// </summary>
        protected TextBlock CancelRequestTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobRequestsDataGridHeaderComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the No of requests text block
            CancelRequestTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = "Cancel",
                ToolTip = new ToolTipComponent() { Text = "Cancel request evaluation for job" }
            };
            // Adds it to the grid's header
            DataGridHeader.Children.Add(CancelRequestTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(CancelRequestTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(CancelRequestTextBlock, 2);
        }

        #endregion

    }
}
