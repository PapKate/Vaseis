using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

namespace Vaseis
{
    public class BaseDataGridHeaderComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected Grid DataGridHeader { get; private set; }

        /// <summary>
        /// The evaluator's name
        /// </summary>
        protected TextBlock EvaluatorTextBlock { get; private set; }

        /// <summary>
        /// The employee's name
        /// </summary>
        protected TextBlock EmployeeTextBlock { get; private set; }

        /// <summary>
        /// The job's name
        /// </summary>
        protected TextBlock JobTextBlock { get; private set; }

        /// <summary>
        /// The department's name
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The header's text
        /// </summary>
        protected TextBlock HeaderTextBlock { get; private set; }

        /// <summary>
        /// The header's border
        /// </summary>
        protected Border HeaderBorder { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDataGridHeaderComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

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

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = ControlsFactory.CreateDataGridRowGrid();

            // Creates the header's border
            HeaderBorder = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 2),
                BorderBrush = DarkPink.HexToBrush(),
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(12)
            };
            // Sets the header's child as the header grid
            HeaderBorder.Child = DataGridHeader;

            // Creates the text blocks
            EvaluatorTextBlock = CreateHeaderTextBlock(0, "Evaluator", "Evaluator");
            EmployeeTextBlock = CreateHeaderTextBlock(1, "Employee", "Employee");
            JobTextBlock = CreateHeaderTextBlock(2, "Job position", "Job position");
            DepartmentTextBlock = CreateHeaderTextBlock(3, "Department", "Department");

            // Sets the component's content as the header border
            Content = HeaderBorder;
        }

        #endregion


    }
}
