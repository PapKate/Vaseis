using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's data grid header
    /// </summary>
    public class EvaluattionBaseDataGridHeaderComponent : DataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock RemainingEvaluationsTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluattionBaseDataGridHeaderComponent()
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
            // Adds the more details text to the header with a tool tip
            RemainingEvaluationsTextBlock = CreateHeaderTextBlock(8, "Remain", "Remaining open evaluations");
            // Adds a margin to the header (expander's fault)
            DataGridHeader.Margin = new Thickness(-36, 0, 0, 0);
        }

        #endregion
    }
}
