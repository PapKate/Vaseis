using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        #region Dependency Properties

        #region CreateRowCommand

        /// <summary>
        /// The open dialog command
        /// </summary>
        public ICommand CreateRowCommand
        {
            get { return (ICommand)GetValue(CreateRowCommandProperty); }
            set { SetValue(CreateRowCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CreateRowCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CreateRowCommandProperty = DependencyProperty.Register(nameof(CreateRowCommand), typeof(ICommand), typeof(EvaluatorDataGridComponent));

        #endregion

        #region NewRow

        /// <summary>
        /// The open dialog command
        /// </summary>
        public bool NewRow
        {
            get { return (bool)GetValue(NewRowProperty); }
            set { SetValue(NewRowProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NewRow"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NewRowProperty = DependencyProperty.Register(nameof(NewRow), typeof(bool), typeof(ReportsDataGridComponent), new PropertyMetadata(OnNewRowChanged));

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        private static void OnNewRowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ReportsDataGridComponent;

            sender.OnNewRowChangedCore(e);
        }

        #endregion

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

            var jobRequests = await Services.GetDbContext.JobPositionRequests.ToListAsync();

            // Query the reports of the manager and add them as rows to the data grid
            var reports = await Services.GetDataStorage.GetManagerReportsAsync(Manager.Id);

            foreach(var report in reports)
                InfoDataStackPanel.Children.Add(new ReportsDataGridRowComponent(PageGrid, report));
        }

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnNewRowChanged(DependencyPropertyChangedEventArgs e)
        {

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

        /// <summary>
        /// Handles the change of the <see cref="EditCommand"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnNewRowChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                var newRow = new ReportsDataGridRowComponent(PageGrid, Report);

                InfoDataStackPanel.Children.Add(newRow);
                // Creates a new evaluation dialog
                var reportDialog = new ReportDialogComponent(newRow)
                {
                    // Sets the dialog is open to true
                    IsDialogOpen = true,
                    // Close button on click removes the new row from the data grid
                    CancelCommand = new RelayCommand(() => InfoDataStackPanel.Children.Remove(newRow))
                };
                // Adds it to the page grid
                PageGrid.Children.Add(reportDialog);
                // Sets the new row value to false
                NewRow = false;
            }

            OnNewRowChanged(e);
        }


        #endregion

    }
}
