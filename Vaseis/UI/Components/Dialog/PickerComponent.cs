using MaterialDesignThemes.Wpf;

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The combo box picker component
    /// </summary>
    public class PickerComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The input to enter
        /// </summary>
        protected TextBlock HintTitleBlock { get; private set; }

        /// <summary>
        /// The input area
        /// </summary>
        protected ComboBoxItem OptionTitle { get; private set; }

        /// <summary>
        /// The picker for company
        /// </summary>
        protected ComboBox OptionPicker { get; private set; }

        #endregion

        #region Dependency Properties

        #region FontSize

        /// <summary>
        /// The required font size for all elements
        /// </summary>
        public int CompleteFontSize
        {
            get { return (int)GetValue(CompleteFontSizeProperty); }
            set { SetValue(CompleteFontSizeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CompleteFontSize"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CompleteFontSizeProperty = DependencyProperty.Register(nameof(CompleteFontSize), typeof(int), typeof(PickerComponent));

        #endregion

        #region Text

        /// <summary>
        /// The required input text helper
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(PickerComponent));

        #endregion

        #region HintText

        /// <summary>
        /// The required input text helper
        /// </summary>
        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="HintText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(nameof(HintText), typeof(string), typeof(PickerComponent));

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
        public static readonly DependencyProperty OptionNamesProperty = DependencyProperty.Register(nameof(OptionNames), typeof(IEnumerable<string>), typeof(PickerComponent), new PropertyMetadata(OnOptionsNameChanged));

        
        private static void OnOptionsNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as PickerComponent;

            sender.OnDataNameChangedCore(e);
        }

        #endregion

        #endregion


        #region Constructors

        public PickerComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Searches through the items in the comboBox for the item with the same content's string as the given string
        /// </summary>
        /// <param name="itemName">The item we want to match with a combo box item</param>
        public void SelectItem(string itemName)
        {
            // Set's the hint text to empty (else there is a delay)
            HintAssist.SetHint(OptionPicker, "");
            // Sets the selected item of the combo box as the first item with content the given string
            OptionPicker.SelectedItem = OptionPicker.Items.OfType<ComboBoxItem>().First(x => x.Content.ToString() == itemName);
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

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the combo box with items source the combo box items' list
            OptionPicker = new ComboBox()
            {
                Width = 240,
                MaxDropDownHeight = 200,
                Margin = new Thickness(24),
                FontSize = 24,
                Foreground = DarkGray.HexToBrush(),
                FontFamily = Calibri,
                
            };

            OptionPicker.SetBinding(ComboBox.TextProperty, new Binding(nameof(Text))
            { 
                Source = this
            });

            // The hint text
            HintTitleBlock = new TextBlock()
            {
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontFamily = Calibri,
                TextTrimming = TextTrimming.CharacterEllipsis,
                IsHitTestVisible = false,
            };
            HintTitleBlock.SetBinding(TextBlock.FontSizeProperty, new Binding(nameof(CompleteFontSize))
            {
                Source = this
            });

            // Binds the hint text block's text property to the hint text property
            HintTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(HintText))
            {
                Source = this
            });

            // Sets the hint's text color to dark pink
            HintAssist.SetForeground(OptionPicker, DarkPink.HexToBrush());
            // Sets the hint on the option picker combo box
            HintAssist.SetHint(OptionPicker, HintTitleBlock);

            // Sets the component's content as the option picker
            Content = OptionPicker;
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
            // If the new value is null...
            if (newValue == null)
            {
                // Creates a combo box item
                OptionTitle = new ComboBoxItem()
                {
                    Foreground = DarkGray.HexToBrush(),
                    FontFamily = Calibri,
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    Margin = new Thickness(8, 0, 0, 0),
                    // with title "none"
                    Content = "none"
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
                        FontWeight = FontWeights.Normal,
                        Margin = new Thickness(8, 0, 0, 0),
                        // with content the one string
                        Content = optionName
                    };
                    OptionTitle.SetBinding(ComboBoxItem.FontSizeProperty, new Binding(nameof(CompleteFontSize))
                    {
                        Source = this
                    });
                    // Adds the combo box item to the list
                    options.Add(OptionTitle);
                }
            }

            OptionPicker.ItemsSource = options;

            // Further handle the change
            OnOptionsNameChanged(e);
        }

        #endregion

    }
}
