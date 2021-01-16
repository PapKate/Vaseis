using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The my job positions data grid row 
    /// </summary>
    public class EvaluatorMyJobPositionsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        #region Protected Properties

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBox SalaryTextBox { get; private set; }

        /// <summary>
        /// The salary's text block
        /// </summary>
        protected TextBox DeadLineTextBox { get; private set; }

        /// <summary>
        /// The job picker
        /// </summary>
        protected ComboBox JobPositionPicker { get; private set; }

        /// <summary>
        /// The department picker
        /// </summary>
        protected ComboBox DepartmentPicker { get; private set; }

        /// <summary>
        /// The subject picker
        /// </summary>
        protected ComboBox SubjectPicker { get; private set; }

        /// <summary>
        /// The text boxes matching the text blocks
        /// </summary>
        protected Dictionary<TextBlock, TextBox> BlockAndBox { get; private set; }

        /// <summary>
        /// The pickers matching the text blocks
        /// </summary>
        protected Dictionary<TextBlock, ComboBox> BlockAndCombo { get; private set; }

        /// <summary>
        /// The text box for the method
        /// </summary>
        protected TextBox DataTextBox { get; private set; }

        /// <summary>
        /// The option picker for the method
        /// </summary>
        protected ComboBox OptionPicker { get; private set; }

        /// <summary>
        /// The edit button
        /// </summary>
        protected EditComponent EditComponent { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorMyJobPositionsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds a text box to the data grid row
        /// </summary>
        /// <param name="columnIndex">The data grid row's column index</param>
        /// <param name="hintText">The hint's text</param>
        protected TextBox CreateAndAddTextBox(int columnIndex, string hintText)
        {
            // Creates the salary text input field
            DataTextBox = new TextBox()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Collapsed
            };
            // Adds it to the grid
            RowDataGrid.Children.Add(DataTextBox);
            // Sets its hint text
            ControlsFactory.CreateHint(hintText, DataTextBox);
            // Sets grid column
            Grid.SetColumn(DataTextBox, columnIndex);

            // Returns the text box
            return DataTextBox;
        }

        /// <summary>
        /// Creates and adds a combo box to the data grid row
        /// </summary>
        /// <param name="columnIndex">The data grid row's column index</param>
        /// <param name="hintText">The hint's text</param>
        /// <param name="optionNames">A list of objects to pick from</param>
        protected ComboBox CreateAndAddPicker(int columnIndex, string hintText, List<object> optionNames)
        {
            var options = new List<ComboBoxItem>();
            // For each string in the list...
            foreach (var optionName in optionNames)
            {
                // Creates a new combo box item ...
                var comboBoxItem = new ComboBoxItem()
                {
                    Foreground = DarkGray.HexToBrush(),
                    FontFamily = Calibri,
                    FontSize = 28,
                    // with content the one string
                    Content = optionName
                };

                // Adds the combo box item to the list
                options.Add(comboBoxItem);
            }
            // Creates the combo box with items source the combo box items' list
            OptionPicker = new ComboBox()
            {
                Margin = new Thickness(24,0,24,0),
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 28,
                ItemsSource = options,
                Visibility = Visibility.Collapsed
            };

            ControlsFactory.CreateHint("Department", OptionPicker);

            RowDataGrid.Children.Add(OptionPicker);
            ControlsFactory.CreateHint(hintText, OptionPicker);
            Grid.SetColumn(OptionPicker, columnIndex);

            return OptionPicker;
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            var testList = new List<object> { "Cookies", "Tomato", "Development", "Chocolate", "Potato", "Agriculture", "Pastry" };

            // Creates the salary text input field
            SalaryTextBox = CreateAndAddTextBox(2, "Salary");

            // Creates the deadline's text input field
            DeadLineTextBox = new TextBox()
            {
                FontSize = 28,
                FontFamily = Calibri,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Collapsed
            };
            RowDataGrid.Children.Add(DeadLineTextBox);
            ControlsFactory.CreateHint("Deadline", DeadLineTextBox);
            Grid.SetColumn(DeadLineTextBox, 4);
            Grid.SetColumnSpan(DeadLineTextBox, 4);

            // Creates the job position's picker
            JobPositionPicker = CreateAndAddPicker(0, "Job position", testList);

            // Creates the department's picker
            DepartmentPicker = CreateAndAddPicker(1, "Department", testList);
            
            // Creates the subject's picker
            SubjectPicker = CreateAndAddPicker(3, "Subject", testList);

            BlockAndBox = new Dictionary<TextBlock, TextBox>()
            {
                { SalaryTextBlock, SalaryTextBox },
                { DeadlineTextBlock, DeadLineTextBox }
            };

            BlockAndCombo = new Dictionary<TextBlock, ComboBox>()
            {
                { JobPosistionTextBlock, JobPositionPicker},
                { DepartmentTextBlock, DepartmentPicker },
                { SubjectTextBlock, SubjectPicker },
            };

            // Creates the edit button
            EditComponent = new EditComponent
            {
                // The edit command
                EditCommand = new RelayCommand(() =>
                {
                    // For each text box and text block
                    foreach(var blockAndbox in BlockAndBox)
                    {
                        // Hides the text block
                        blockAndbox.Key.Visibility = Visibility.Collapsed;
                        // Shows the text box
                        blockAndbox.Value.Visibility = Visibility.Visible;
                        // Sets the text box's text as the block's text
                        blockAndbox.Value.Text = blockAndbox.Key.Text;
                    }

                    // For each picker and text block
                    foreach (var blockAndCombo in BlockAndCombo)
                    {
                        // Hides the text block
                        blockAndCombo.Key.Visibility = Visibility.Collapsed;
                        // Shows the picker
                        blockAndCombo.Value.Visibility = Visibility.Visible;
                        // Sets the picker's text as the block's text
                        blockAndCombo.Value.Text = blockAndCombo.Key.Text;
                    }
                }),

                // The save command
                SaveCommand = new RelayCommand(() =>
                {
                    // For each text box and text block
                    foreach (var blockAndbox in BlockAndBox)
                    {
                        // Shows the text block
                        blockAndbox.Key.Visibility = Visibility.Visible;
                        // Hides the text box
                        blockAndbox.Value.Visibility = Visibility.Collapsed;
                        // Sets the text block's text to the text box's text
                        blockAndbox.Key.Text = blockAndbox.Value.Text;
                    }

                    // For each picker and text block
                    foreach (var blockAndCombo in BlockAndCombo)
                    {
                        // Shows the text block
                        blockAndCombo.Key.Visibility = Visibility.Visible;
                        // Hides the picker
                        blockAndCombo.Value.Visibility = Visibility.Collapsed;
                        // Sets the text block's text to the picker's text
                        blockAndCombo.Key.Text = blockAndCombo.Value.Text;
                    }
                }),

                // The cancel command
                CancelCommand = new RelayCommand(() =>
                {
                    // For each text box and text block
                    foreach (var blockAndbox in BlockAndBox)
                    {
                        // Shows the text block
                        blockAndbox.Key.Visibility = Visibility.Visible;
                        // Hides the text box
                        blockAndbox.Value.Visibility = Visibility.Collapsed;
                    }

                    // For each picker and text block
                    foreach (var blockAndCombo in BlockAndCombo)
                    {
                        // Shows the text block
                        blockAndCombo.Key.Visibility = Visibility.Visible;
                        // Hides the picker
                        blockAndCombo.Value.Visibility = Visibility.Collapsed;
                    }
                }),

                // Creates and adds a tool tip
                ToolTip = new ToolTipComponent() { Text = "Edit job position" }
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
