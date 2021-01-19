using System;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The job position's data grid
    /// </summary>
    public class EvaluatorJobPositionsDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The evluator
        /// </summary>
        public UserDataModel Evaluator { get; }

        #endregion


        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorJobPositionsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        public EvaluatorJobPositionsDataGridComponent(Grid pageGrid, UserDataModel evaluator)
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
            // Query the job positions assigned to an evaluator and add them as rows to the data grid
            var jobPositions = await Services.GetDataStorage.GetCompanyJobPositions(Evaluator.Department.CompanyId);

            // For each job position
            foreach (var jobPosition in jobPositions)
                // Creates and adds a row to the data grid's stack panel
                InfoDataStackPanel.Children.Add(new EvaluatorJobPositionsDataGridRowComponent(PageGrid, jobPosition));
        }
        #endregion

        #region Private Methods

        // <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new EvaluatorJobPositionsDataGridHeaderComponent();
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }
        #endregion


    }
}
