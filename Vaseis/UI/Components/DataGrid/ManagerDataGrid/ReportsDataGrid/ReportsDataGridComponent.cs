﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The reports' data grid
    /// </summary>
    public class ReportsDataGridComponent : BaseDataGridComponent
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Manager { get; }

        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The report
        /// </summary>
        public ReportDataModel Report { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected BaseDataGridHeaderComponent DataGridHeader { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReportsDataGridComponent()
        {
            CreateGUI();
        }

        public ReportsDataGridComponent(Grid pageGrid, UserDataModel manager)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));

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

            var evaluators = await Services.GetDataStorage.GetEvaluatorsAsync(Manager);
            var evaluatorsList = new List<string>();
            // For each evaluator in the evaluator data model test
            foreach (var evaluator in evaluators)
                // Adds to the evaluatorsList the evaluator's username
                evaluatorsList.Add(evaluator.Username);

            // Query the reports of the manager and add them as rows to the data grid
            var reports = await Services.GetDataStorage.GetManagerReportsAsync(Manager.Id);

            // For each report...
            foreach (var report in reports)
            {
                // Create a new row for the data grid
                var row = new ReportsDataGridRowComponent(PageGrid, report);

                row.ShowDialogCommand = new RelayCommand(() =>
                {
                    // Creates an evaluation dialog
                    var reportDialog = new ReportDialogComponent(row, report)
                    {
                        // And opens it
                        IsDialogOpen = true,
                        EvaluatorsList = evaluatorsList,
                        FinalizedCommand = new RelayCommand(async () =>
                        {
                            await Task.Delay(2000);
                            // Creates a new finalized dialog
                            var finalizedDialog = new MessageDialogComponent()
                            {
                                Message = "Your report has been successfully sent to the evaluator",
                                Title = "Success",
                                BrushColor = HookersGreen.HexToBrush(),
                                IsDialogOpen = true,
                            };
                            // Adds it to the page's grid
                            PageGrid.Children.Add(finalizedDialog);
                        })
                    };
                    reportDialog.SelectedEvaluator(row.EvaluatorName);
                    // Adds it to the page's grid
                    PageGrid.Children.Add(reportDialog);
                });

                // Add it to the stack panel
                InfoDataStackPanel.Children.Add(row);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates and adds the header's row
            DataGridHeader = new ReportDataGridHeaderComponent()
            {
                Margin = new Thickness(-36, 0, 0, 0)
            };
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);
        }

        #endregion

    }
}
