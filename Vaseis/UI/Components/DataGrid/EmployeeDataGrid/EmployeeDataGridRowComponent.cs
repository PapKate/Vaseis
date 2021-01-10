using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A row for the employee's data grid
    /// </summary>
    public class EmployeeDataGridRowComponent : DataGridRowComponent
    {
        #region Protected Properties

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock ResultTextBlock { get; private set; }

        #endregion

        #region Dependency Properties

        #region Result

        /// <summary>
        /// The result text
        /// </summary>
        public string Result
        {
            get { return (string)GetValue(ResultTextProperty); }
            set { SetValue(ResultTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Result"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ResultTextProperty = DependencyProperty.Register(nameof(Result), typeof(string), typeof(EmployeeDataGridRowComponent), new PropertyMetadata(OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EmployeeDataGridRowComponent;

            sender.OnTextChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeDataGridRowComponent()
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
            var border = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
                Padding = new Thickness(12),
                
            };

            border.Child = RowDataGrid;

            // Creates the result text block
            ResultTextBlock = new TextBlock()
            {
                FontFamily = Calibri,
                FontSize = 28,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Adds it to the data grid
            RowDataGrid.Children.Add(ResultTextBlock);
            // On its eighth row
            Grid.SetColumn(ResultTextBlock, 8);

            // Binds the result text to the result text block
            ResultTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Result))
            {
                Source = this
            });

            Content = border;
        }

        /// <summary>
        /// Handles the change of the <see cref="Result"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnTextChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (string)e.NewValue;
            // If the new value is null...
            if (newValue == null)
            {
                ResultTextBlock.Text = "-";
            }
            // Else...
            else
            {
                // Sets the result's text as the new value
                ResultTextBlock.Text = newValue;
                
                // If the new value is Fail...
                if (newValue == "Fail")
                    // Sets the result's foreground to red
                    ResultTextBlock.Foreground = Red.HexToBrush();
                
                // If the new value is Pass...
                if (newValue == "Pass")
                { 
                    // Sets the result's foreground to green
                    ResultTextBlock.Foreground = Green.HexToBrush();
                    // Creates a tick button
                    var acquireButton = ControlsFactory.CreateCheckButton();
                    // Creates a tool tip for it
                    acquireButton.ToolTip = new ToolTipComponent() { Text = "Acquire job position" };
                    // Adds it to the row's grid
                    RowDataGrid.Children.Add(acquireButton);
                    // On the ninth column
                    Grid.SetColumn(acquireButton, 9);
                }
            }
        }

        #endregion

    }
}
