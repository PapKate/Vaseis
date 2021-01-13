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
    public class EvaluatorDataGridComponent : ContentControl
    {
        /// <summary>
        /// The page's grid container
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The header's grid
        /// </summary>
        protected EvaluatorMyEvaluationsDataGridHeaderComponent DataGridHeader { get; private set; }

        /// <summary>
        /// The data grid's stack panel
        /// </summary>
        protected StackPanel InfoDataStackPanel { get; private set; }

        public List<EvaluatorDataGridRowComponent> RowList { get; private set; }

        #endregion

        #region Dependency Properties

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
        public static readonly DependencyProperty NewRowProperty = DependencyProperty.Register(nameof(NewRow), typeof(bool), typeof(EvaluatorDataGridComponent), new PropertyMetadata(OnNewRowChanged));

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property
        /// </summary>
        private static void OnNewRowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EvaluatorDataGridComponent;

            sender.OnNewRowChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorDataGridComponent()
        {
            CreateGUI();
        }

        public EvaluatorDataGridComponent(Grid pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

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
            RowList = new List<EvaluatorDataGridRowComponent>();

            InfoDataStackPanel = new StackPanel();

            // Creates and adds the header's row
            DataGridHeader = new EvaluatorMyEvaluationsDataGridHeaderComponent(this);
            // Adds it to the stack panel
            InfoDataStackPanel.Children.Add(DataGridHeader);

            // Creates and adds a row to the data grid
            var row = new EvaluatorDataGridRowComponent(PageGrid)
            {
                EvaluatorName = "PapLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior developer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                InterviewComments = "oooofffff",
                
            };
            RowList.Add(row);
            InfoDataStackPanel.Children.Add(row);

            // Creates and adds a row to the data grid
            var row2 = new EvaluatorDataGridRowComponent(PageGrid)
            {
                EvaluatorName = "PapBoomBommLabros",
                EmployeeName = "PapKaterina",
                JobName = "Junior boomer",
                DepartmentName = "Development",
                EvaluationGrade = "7",
                InterviewGrade = "5",
                ReportGrade = "7",
                FilesGrade = "9",
                InterviewComments = "oooofffff axxxxx vahhhhhhn The ICommand interface is the code contract for commands that are written in .NET for Windows Runtime apps. These commands provide the commanding behavior for UI elements such as a Windows Runtime XAML Button and in particular an AppBarButton. If you're defining commands for Windows Runtime apps you use basically the same techniques you'd use for defining commands for a .NET app. Implement the command by defining a class that implements ICommand and specifically implement the Execute method."
                                + "XAML for Windows Runtime does not support x:Static, so don't attempt to use the x:Static markup extension if the command is used from Windows Runtime XAML. Also, the Windows Runtime does not have any predefined command libraries, so the XAML syntax shown here doesn't really apply for the case where you're implementing the interface and defining the command for Windows Runtime usage. "
            };
            RowList.Add(row2);
            InfoDataStackPanel.Children.Add(row2);

            // Sets the component's content to the info data grid
            Content = InfoDataStackPanel;
        }

        /// <summary>
        /// Handles the change of the <see cref="NewRow"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnNewRowChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                var newRow = new EvaluatorDataGridRowComponent(PageGrid);

                InfoDataStackPanel.Children.Add(newRow);
                // Creates a new evaluation dialog
                var EvaluationDialog = new EvaluationDialogComponent(newRow)
                {
                    // Sets the dialog is open to true
                    IsDialogOpen = true,
                    // Close button on click removes the new row from the data grid
                    CancelCommand = new RelayCommand(() => InfoDataStackPanel.Children.Remove(newRow))
                };
                // Adds it to the page grid
                PageGrid.Children.Add(EvaluationDialog);
                // Sets the new row value to false
                NewRow = false;
            }
        }

        #endregion

    }
    
}
