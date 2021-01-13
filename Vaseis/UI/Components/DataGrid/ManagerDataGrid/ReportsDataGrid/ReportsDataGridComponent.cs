using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Vaseis
{ 
    /// <summary>
    /// The reports' data grid
    /// </summary>
    public class ReportsDataGridComponent : ContentControl
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected BaseDataGridHeaderComponent DataGridHeader { get; private set; }

        /// <summary>
        /// The data grid's stack panel
        /// </summary>
        protected StackPanel InfoDataStackPanel { get; private set; }

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

        public ReportsDataGridComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Query the reports of the manager and add them as rows to the data grid
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
            InfoDataStackPanel = new StackPanel();

            // Creates and adds the header's row
            DataGridHeader = new ReportDataGridHeaderComponent()
            {
                Margin = new Thickness(-36, 0, 0, 0)
            };
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            //// Creates and adds a row to the data grid
            //var row = new ReportsDataGridRowComponent(PageGrid)
            //{
              
            //};

            //InfoDataStackPanel.Children.Add(row);

            //// Creates and adds a row to the data grid
            //var row2 = new ReportsDataGridRowComponent(PageGrid)
            //{
            //    EvaluatorName = "PapBoomBommLabros",
            //    EmployeeName = "PapKaterina",
            //    JobName = "Junior developer",
            //    DepartmentName = "Development",
            //};

            //InfoDataStackPanel.Children.Add(row2);

            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
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
                var newRow = new ReportsDataGridRowComponent(PageGrid);

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
