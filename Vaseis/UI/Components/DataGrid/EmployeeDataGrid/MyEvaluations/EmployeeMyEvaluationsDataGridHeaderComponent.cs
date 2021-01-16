using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The employee's evaluation header
    /// </summary>
    public class EmployeeMyEvaluationsDataGridHeaderComponent : DataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock Result { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeMyEvaluationsDataGridHeaderComponent()
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
            // Creates a new text block for the header for results column
            Result = CreateHeaderTextBlock(8, "Result", "Result");
        }


        #endregion

    }
}
