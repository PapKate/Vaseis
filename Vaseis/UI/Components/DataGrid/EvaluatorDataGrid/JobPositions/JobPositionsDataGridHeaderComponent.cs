using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    public class JobPositionsDataGridHeaderComponent
    {
        #region Protected Properties
        
        /// <summary>
        /// The header's grid
        /// </summary>
        protected Grid DataGridHeader { get; private set; }

        /// <summary>
        /// The header's text
        /// </summary>
        protected TextBlock HeaderTextBlock { get; private set; }

        /// <summary>
        /// The header's border
        /// </summary>
        protected Border HeaderBorder { get; private set; }

        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates the header text blocks
        /// </summary>
        /// <param name="columnIndex">The column index of the header' grid</param>
        /// <param name="text">The header block's text</param>
        /// <param name="toolTipText">The tool tip's text</param>
        /// <returns></returns>
        protected TextBlock CreateHeaderTextBlock(int columnIndex, string text, string toolTipText)
        {
            // Creates the text block
            HeaderTextBlock = new TextBlock()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Text = text,
                ToolTip = new ToolTipComponent() { Text = toolTipText }
            };

            // Adds it to the stack panel
            DataGridHeader.Children.Add(HeaderTextBlock);
            Grid.SetColumn(HeaderTextBlock, columnIndex);
            // Returns the text block
            return HeaderTextBlock;
        }

        #endregion

        #region Private Methods

        #endregion


    }
}
