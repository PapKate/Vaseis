using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{ 
    /// <summary>
    /// The manager's job position's data grid's header
    /// </summary>
    public class ManagerJobPositionsDataGridHeaderComponent : BaseJobPositionsDataGridHeaderComponent
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
        public ManagerJobPositionsDataGridHeaderComponent()
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
                Text = "Edit",
                ToolTip = new ToolTipComponent() { Text = "Edit salary" }
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
