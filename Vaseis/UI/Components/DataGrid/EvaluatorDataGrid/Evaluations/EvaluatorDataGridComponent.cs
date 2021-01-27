using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The data grid
    /// </summary>
    public class EvaluatorDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The connected Evaluator
        /// </summary>
        public UserDataModel Evaluator { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorMyEvaluationsDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorDataGridComponent(Grid pageGrid, UserDataModel evaluator)
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

            var companyJobs = await Services.GetDataStorage.GetCompanyJobs(Evaluator.Department.CompanyId);
            var jobTitles = new List<string>();
            foreach(var job in companyJobs)
            {
                jobTitles.Add(job.JobTitle);
            }

            // Creates and adds the header's row
            DataGridHeader = new EvaluatorMyEvaluationsDataGridHeaderComponent(this)
            {
                OptionNames = jobTitles
            };
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            // Query the job position requests by an employee and add them as rows to the data grid
            var evaluations = await Services.GetDataStorage.GetEvaluatorEvaluations(Evaluator.Id, false);

            // For each job position in the list...
            foreach (var evaluation in evaluations)
            {
                // Create a row of for the employee's job position data grid
                var row = new EvaluatorDataGridRowComponent(PageGrid, evaluation);

                // Adds the row to the stack panel
                InfoDataStackPanel.Children.Add(row);
                RowList.Add(row);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            RowList = new List<EvaluationBaseDataGridRowComponent>();
        }

        #endregion

    }
    
}
