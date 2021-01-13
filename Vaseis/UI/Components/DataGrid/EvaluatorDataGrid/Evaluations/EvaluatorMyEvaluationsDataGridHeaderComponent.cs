using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The my evaluations' data grid header
    /// </summary>
    public class EvaluatorMyEvaluationsDataGridHeaderComponent : EvaluattionBaseDataGridHeaderComponent
    {
        #region Public Properties

        public EvaluatorDataGridComponent MyEvaluationsDataGrid { get; }

        #endregion


        #region Protected Properties

        /// <summary>
        /// The job position's picker
        /// </summary>
        protected ComboBox JobPositionPicker { get; private set; }
        
        /// <summary>
        /// A list of all options
        /// </summary>
        protected List<ComboBoxItem> OptionItems { get; private set; }

        /// <summary>
        /// The input area
        /// </summary>
        protected ComboBoxItem OptionTitle { get; private set; }

        /// <summary>
        /// The input area
        /// </summary>
        protected ComboBoxItem JobPositionItem { get; private set; }

        #endregion

        #region Dependency Properties

        #region ValueChanged

        /// <summary>
        /// A bool set to true if value changed 
        /// </summary>
        public bool ValueChanged
        {
            get { return (bool)GetValue(ValueChangedProperty); }
            set { SetValue(ValueChangedProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ValueChanged"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ValueChangedProperty = DependencyProperty.Register(nameof(ValueChanged), typeof(bool), typeof(EvaluatorMyEvaluationsDataGridHeaderComponent));

        #endregion

        #region ValueChanged

        /// <summary>
        /// A bool set to true if value changed 
        /// </summary>
        public RoutedEvent ChangedCommand
        {
            get { return (RoutedEvent)GetValue(ChangedCommandProperty); }
            set { SetValue(ChangedCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ChangedCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ChangedCommandProperty = DependencyProperty.Register(nameof(ChangedCommand), typeof(RoutedEvent), typeof(EvaluatorMyEvaluationsDataGridHeaderComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorMyEvaluationsDataGridHeaderComponent()
        {
            CreateGUI();
        }

        public EvaluatorMyEvaluationsDataGridHeaderComponent(EvaluatorDataGridComponent myEvaluationsDataGrid)
        {
            MyEvaluationsDataGrid = myEvaluationsDataGrid ?? throw new ArgumentNullException(nameof(myEvaluationsDataGrid));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            var optionNames = new List<string> { "Job position", "Tomato", "Junior developer", "Cooker" };

            OptionItems = new List<ComboBoxItem>();

            // For each string in the list...
            foreach (var optionName in optionNames)
            {
                // Creates a new combo box item ...
                OptionTitle = new ComboBoxItem()
                {
                    Foreground = DarkGray.HexToBrush(),
                    FontFamily = Calibri,
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    Margin = new Thickness(8, 0, 0, 0),
                    // with content the one string
                    Content = optionName
                };

                // Adds the combo box item to the list
                OptionItems.Add(OptionTitle);
            }

            // Creates a new combo box item ...
            JobPositionItem = new ComboBoxItem()
            {
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(8, 0, 0, 0),
                Content = "Job position"
            };

            // Adds the combo box item to the list
            OptionItems.Add(JobPositionItem);

            // Creates the job position combo box
            JobPositionPicker = new ComboBox()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                ToolTip = new ToolTipComponent() { Text = "Job position" },
                ItemsSource = OptionItems,
            };
            // Add it to the header's grid
            DataGridHeader.Children.Add(JobPositionPicker);
            Grid.SetColumn(JobPositionPicker, 2);

            JobPositionPicker.SelectionChanged += SelectionChangedOnClick;


            // The default item is the job position
            JobPositionPicker.SelectedItem = JobPositionItem;
            // Sets the job position's text block's visibility to hidden
            JobTextBlock.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The combo box</param>
        private void SelectionChangedOnClick(object sender, SelectionChangedEventArgs e)
        {
            var value = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;

            if(value != null && value != "Job position")
            {
                foreach (var listItem in MyEvaluationsDataGrid.RowList)
                {
                    if (listItem.JobName != value)
                        listItem.Visibility = Visibility.Collapsed;
                }
            }
            if(value != null && value == "Job position")
            {
                foreach (var listItem in MyEvaluationsDataGrid.RowList)
                {
                        listItem.Visibility = Visibility.Visible;
                }
            }
        }


        #endregion


    }
}
