using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class ManagerJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Protected Properties

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBox SalaryTextBox { get; private set; }

        /// <summary>
        /// The edit button
        /// </summary>
        protected EditComponent EditComponent { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerJobPositionsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the salary text input field
            SalaryTextBox = new TextBox()
            {
                Text = SalaryTextBlock.Text,
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Collapsed
            };
            // Ads it to the data grid's row
            RowDataGrid.Children.Add(SalaryTextBox);
            Grid.SetColumn(SalaryTextBox, 2);

            // Creates the edit button
            EditComponent = new EditComponent
            {
                // Sets the edit command as a new relay command that...
                EditCommand = new RelayCommand(() =>
                {
                    // Hides the salary's text block
                    SalaryTextBlock.Visibility = Visibility.Collapsed;
                    // Shows the salary's text box
                    SalaryTextBox.Visibility = Visibility.Visible;
                    // Sets the salary's text box's text to the salary's text block's text
                    SalaryTextBox.Text = SalaryTextBlock.Text;
                }),

                // Sets the edit command as a new relay command that...
                SaveCommand = new RelayCommand(() =>
                {
                    // Shows the salary's text block
                    SalaryTextBlock.Visibility = Visibility.Visible;
                    // Hides the salary's text box
                    SalaryTextBox.Visibility = Visibility.Collapsed;
                    // Sets the salary's text block's text to the salary's text box's text
                    SalaryTextBlock.Text = SalaryTextBox.Text;
                }),

                // Sets the edit command as a new relay command that...
                CancelCommand = new RelayCommand(() =>
                {
                    // Hides the salary's text block
                    SalaryTextBlock.Visibility = Visibility.Visible;
                    // Shows the salary's text box
                    SalaryTextBox.Visibility = Visibility.Collapsed;
                }),

                // Creates and adds a tool tip
                ToolTip = new ToolTipComponent() { Text = "Edit evaluation" }
            };

            // Add it to the grid
            RowDataGrid.Children.Add(EditComponent);
            // On the ninth column
            Grid.SetColumn(EditComponent, 9);
            Grid.SetColumnSpan(EditComponent, 2);
        }

        #endregion

    }
}
