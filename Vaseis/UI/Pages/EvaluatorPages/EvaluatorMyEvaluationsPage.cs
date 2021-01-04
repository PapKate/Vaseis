using MaterialDesignThemes.Wpf;

using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// Represents the "my evaluations" page of the evaluator
    /// </summary>
    public class EvaluatorMyEvaluationsPage : EvaluationReportDialogComponent
    {
        #region Protected Properties

        /// <summary>
        /// The new evaluation dialog
        /// </summary>
        protected EvaluationReportDialogComponent EvaluationDialog { get; private set; }

        /// <summary>
        /// The add/open dialog button
        /// </summary>
        protected Button AddButton { get; private set; }

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        #endregion

        #region Constructors

        public EvaluatorMyEvaluationsPage()
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

            // Creates the add new user button
            AddButton = ControlsFactory.CreateAddButton(DarkBlue);
            // On click opens the new user dialog
            AddButton.Click += ShowDialogOnClick;
            // Adds the button to the page's grid
            PageGrid.Children.Add(AddButton);

            // Sets the component's content to the page's grid
            Content = PageGrid;
        }

        /// <summary>
        /// On click closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new evaluation dialog
            EvaluationDialog = new EvaluationReportDialogComponent();
            // Adds it to the page grid
            PageGrid.Children.Add(EvaluationDialog);

            // Sets the is open property of the dialog host to true
            EvaluationDialog.DialogHost.IsOpen = true;
        }

        #endregion

    }
}
