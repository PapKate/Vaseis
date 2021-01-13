using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;


namespace Vaseis
{
    public class EmployeeJobPositionsDataGridHeaderComponent : BaseJobPositionsDataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// The edit's text block
        /// </summary>
        protected TextBlock RequestTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobPositionsDataGridHeaderComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the No of requests text block
            RequestTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = "Request",
                ToolTip = new ToolTipComponent() { Text = "Request evaluation for job" }
            };
            // Adds it to the grid's header
            DataGridHeader.Children.Add(RequestTextBlock);
            // Sets the column where it starts
            Grid.SetColumn(RequestTextBlock, 9);
            // Sets the column span
            Grid.SetColumnSpan(RequestTextBlock, 2);
        }

        #endregion

    }
}
