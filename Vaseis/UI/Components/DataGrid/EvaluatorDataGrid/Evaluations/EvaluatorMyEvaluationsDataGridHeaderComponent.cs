using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EvaluatorMyEvaluationsDataGridHeaderComponent : DataGridHeaderComponent
    {
        #region Public Properties

        public BaseDataGridComponent MyEvaluationsDataGrid { get; }

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

        #region ChangedCommand

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

        #region Options

        /// <summary>
        /// The required options for content box items' content
        /// </summary>
        public IEnumerable<string> OptionNames
        {
            get { return (IEnumerable<string>)GetValue(OptionNamesProperty); }
            set { SetValue(OptionNamesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionNames"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OptionNamesProperty = DependencyProperty.Register(nameof(OptionNames), typeof(IEnumerable<string>), typeof(EvaluatorMyEvaluationsDataGridHeaderComponent), new PropertyMetadata(OnOptionsNameChanged));


        private static void OnOptionsNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EvaluatorMyEvaluationsDataGridHeaderComponent;

            sender.OnDataNameChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorMyEvaluationsDataGridHeaderComponent(BaseDataGridComponent myEvaluationsDataGrid)
        {
            MyEvaluationsDataGrid = myEvaluationsDataGrid ?? throw new ArgumentNullException(nameof(myEvaluationsDataGrid));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="OptionNames"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnOptionsNameChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion
        
        #region Private Methods

        private void CreateGUI()
        {
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
        /// Sets the visibilities in each and every row according to the selected item of the combo box
        /// </summary>
        /// <param name="sender">The combo box</param>
        private void SelectionChangedOnClick(object sender, SelectionChangedEventArgs e)
        {
            // Sets the value as the selected item's content
            var value = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();
            // If the value is not null and is not the job position option...
            if(value != null && value != "Job position")
            {
                // For each row in the data grid...
                foreach (var listItem in MyEvaluationsDataGrid.RowList)
                {
                    // If the row's job name is not equal to the value...
                    if (listItem.JobPositionName != value)
                        // Collapse the row
                        listItem.Visibility = Visibility.Collapsed;
                    // Else...
                    else
                        // Set the row as visible
                        listItem.Visibility = Visibility.Visible;
                }
            }
            // If the value is not null and is the job position option...
            if (value != null && value == "Job position")
            {
                // For each row of the data grid...
                foreach (var listItem in MyEvaluationsDataGrid.RowList)
                {
                    // Sets them visible
                    listItem.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Handles the change of the <see cref="OptionNames"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnDataNameChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // The items source list
            var options = new List<ComboBoxItem>();

            // Get the new value
            var newValue = (IEnumerable<string>)e.NewValue;

            // Creates a new combo box item ...
            JobPositionItem = new ComboBoxItem()
            {
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 28,
                Margin = new Thickness(8, 0, 0, 0),
                Content = "Job position"
            };
            // Adds the combo box item to the list
            options.Add(JobPositionItem);

            // If the new value is null...
            if (newValue == null)
            {
                // Creates a combo box item
                OptionTitle = new ComboBoxItem()
                {
                    Foreground = DarkGray.HexToBrush(),
                    FontFamily = Calibri,
                    FontSize = 28,
                    FontWeight = FontWeights.Normal,
                    Margin = new Thickness(8, 0, 0, 0),
                    // with title "none"
                    Content = "empty"
                };

                // Adds it to the combo box items list
                options.Add(OptionTitle);
            }
            // Else...
            else
            {
                // For each string in the list...
                foreach (var optionName in OptionNames)
                {
                    // Creates a new combo box item ...
                    OptionTitle = new ComboBoxItem()
                    {
                        Foreground = DarkGray.HexToBrush(),
                        FontFamily = Calibri,
                        FontSize = 28,
                        FontWeight = FontWeights.Normal,
                        Margin = new Thickness(8, 0, 0, 0),
                        // with content the one string
                        Content = optionName
                    };
                    
                    // Adds the combo box item to the list
                    options.Add(OptionTitle);
                }
            }

            JobPositionPicker.ItemsSource = options;
            JobPositionPicker.SelectedItem = JobPositionPicker.Items.OfType<ComboBoxItem>().First(x => x.Content.ToString() == "Job position");

            // Further handle the change
            OnOptionsNameChanged(e);
        }

        #endregion


    }
}
