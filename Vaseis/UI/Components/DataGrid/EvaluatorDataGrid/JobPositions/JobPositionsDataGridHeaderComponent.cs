using System.Windows.Controls;
using System.Windows;
using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The job position's data grid's header
    /// </summary>
    public class JobPositionsDataGridHeaderComponent : ContentControl
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

        /// <summary>
        /// The job position's text block
        /// </summary>
        protected TextBlock JobPositionTextBlock { get; private set; }

        /// <summary>
        /// The job position's text block
        /// </summary>
        protected TextBlock DepartmentTextBlock { get; private set; }

        /// <summary>
        /// The job position's text block
        /// </summary>
        protected TextBlock SalaryTextBlock { get; private set; }

        /// <summary>
        /// The job position's text block
        /// </summary>
        protected TextBlock SubjectTextBlock { get; private set; }


        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public JobPositionsDataGridHeaderComponent()
        {
            CreateGUI();
        }

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
            JobPositionTextBlock = CreateHeaderTextBlock(0, "Job position", "Job position");
            DepartmentTextBlock = CreateHeaderTextBlock(1, "Department", "Department");
            SalaryTextBlock = CreateHeaderTextBlock(2, "Salary", "Salary");
            SubjectTextBlock = CreateHeaderTextBlock(3, "Subject", "Subject");

            // Sets the component's content as the header border
            Content = HeaderBorder;
        }


        #endregion


    }
}
