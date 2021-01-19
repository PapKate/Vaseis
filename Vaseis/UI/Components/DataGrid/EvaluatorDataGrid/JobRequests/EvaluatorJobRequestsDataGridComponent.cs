using System;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The evaluator's job requests data grid
    /// </summary>
    public class EvaluatorJobRequestsDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The evaluator
        /// </summary>
        public UserDataModel Evaluator { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorJobRequestsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pageGrid">The page's grid</param>
        /// <param name="evaluator">The evaluator</param>
        public EvaluatorJobRequestsDataGridComponent(Grid pageGrid, UserDataModel evaluator)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected async override void OnInitialized()
        {
            base.OnInitialized();
            // Query the job position requests by an employee and add them as rows to the data grid
            var jobPositionRequests = await Services.GetDataStorage.GetEvaluatorJobPositionRequestsAsync(Evaluator.Id);

            // For each job position in the list...
            foreach (var jobPositionRequest in jobPositionRequests)
            {
                // Create a row of for the employee's job position data grid
                var row = new EvaluatorJobRequestsDataGridRowComponent(PageGrid, jobPositionRequest);
                // Adds the row to the stack panel
                InfoDataStackPanel.Children.Add(row);
            }
        }
        #endregion


        #region Private Methods

        // <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new EvaluatorJobRequestsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
        }

        #endregion
    }
}
