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

            DataGrid = new EvaluatorMyJobPositionsDataGridComponent(PageGrid)
            {

            };
            PageGrid.Children.Add(DataGrid);

            AddButton = ControlsFactory.CreateAddButton(DarkBlue);
            AddButton.Click += ShowJobPositionDialog;

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
            DataGrid.NewRow = true;
        }

        #endregion


    }
}
