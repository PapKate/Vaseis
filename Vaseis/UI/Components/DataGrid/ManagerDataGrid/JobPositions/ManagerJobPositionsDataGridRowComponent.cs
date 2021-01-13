using System;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    public class ManagerJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

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
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

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
            RowDataGrid.Children.Add(SalaryTextBox);
            Grid.SetColumn(SalaryTextBox, 2);

            // Creates the edit button
            EditComponent = new EditComponent
            {
                EditCommand = new RelayCommand(() =>
                {
                    SalaryTextBlock.Visibility = Visibility.Collapsed;
                    SalaryTextBox.Visibility = Visibility.Visible;
                    SalaryTextBox.Text = SalaryTextBlock.Text;
                }),

                SaveCommand = new RelayCommand(() =>
                {
                    SalaryTextBlock.Visibility = Visibility.Visible;
                    SalaryTextBox.Visibility = Visibility.Collapsed;
                    SalaryTextBlock.Text = SalaryTextBox.Text;
                }),

                CancelCommand = new RelayCommand(() =>
                {
                    SalaryTextBlock.Visibility = Visibility.Visible;
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
