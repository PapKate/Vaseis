using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The evaluator's my job positions' page
    /// </summary>
    public class EvaluatorMyJobPositionsPage : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The add job position button
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The evaluator's my job positions data grid
        /// </summary>
        protected EvaluatorMyJobPositionsDataGridComponent DataGrid { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorMyJobPositionsPage()
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
            // The page's grid
            PageGrid = new Grid()
            {
            };

            // Creates the data grid
            DataGrid = new EvaluatorMyJobPositionsDataGridComponent(PageGrid)
            {

            };
            // Adds it to the page
            PageGrid.Children.Add(DataGrid);

            // Creates the add button
            AddButton = ControlsFactory.CreateAddButton(DarkBlue);
            // On click calls the method
            AddButton.Click += ShowJobPositionDialog;
            // Adds the button to the page's grid
            PageGrid.Children.Add(AddButton);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        /// <summary>
        /// On click returns to edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowJobPositionDialog(object sender, RoutedEventArgs e)
        {
            // Sets the data grid's new row property to true
            DataGrid.NewRow = true;
        }

        #endregion


    }
}
