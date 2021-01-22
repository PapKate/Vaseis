using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;
using System.Collections.Generic;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using System.Linq;

namespace Vaseis
{
    /// <summary>
    /// A list with toggles
    /// </summary>
    public class TogglesListComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The scroll viewer for the toggles
        /// </summary>
        protected ListBox TogglesListBox { get; private set; }

        /// <summary>
        /// The list's button
        /// </summary>
        protected Button ListButton { get; private set; }

        /// <summary>
        /// The list's grid
        /// </summary>
        protected Grid ListGrid { get; private set; }

        /// <summary>
        /// A check box
        /// </summary>
        protected CheckBox Toggle { get; private set; }

        public List<string> ToggleContents { get; set; }

        protected List<CheckBox> ToggleCheckBoxes { get; private set; }

        #endregion

        #region Dependency Properties

        #region ToggleList

        /// <summary>
        /// The required options for content box items' content
        /// </summary>
        public IEnumerable<string> ToggleNames
        {
            get { return (IEnumerable<string>)GetValue(ToggleNamesProperty); }
            set { SetValue(ToggleNamesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ToggleNames"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ToggleNamesProperty = DependencyProperty.Register(nameof(ToggleNames), typeof(IEnumerable<string>), typeof(TogglesListComponent), new PropertyMetadata(OnToggleListChanged));


        private static void OnToggleListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as TogglesListComponent;

            sender.OnToggleListChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TogglesListComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Searches through the items in the list box for the items that have as content the given strings...
        /// And sets them as checked
        /// </summary>
        /// <param name="checkedNames">The names of the previously checked items</param>
        public void PreviouslyCheckedItems(IEnumerable<string> checkedNames)
        {
            // Gets all the check boxes that contain the checked names
            var previouslyChecked = TogglesListBox.Items.OfType<CheckBox>().Where(x => checkedNames.Contains(x.Content.ToString())).ToList();
            // Sets their is checked property to true
            previouslyChecked.ForEach(x => x.IsChecked = true);
        }

        /// <summary>
        /// Gets the currently checked items of the list box
        /// </summary>
        public IEnumerable<CheckBox> CheckedItems()
        {
            var checkedItems = TogglesListBox.Items.OfType<CheckBox>().Where(x => x.IsChecked == true);

            return checkedItems;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="ToggleNames"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnOptionsNameChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Changes the toggle's scroll viewer accordingly
        /// </summary>
        protected void ChangeTogglesVisibilityOnClick(object sender, RoutedEventArgs e)
        {
            // If the toggles are not visible...
            if (TogglesListBox.Visibility == Visibility.Collapsed)
                // Set's the scroll viewer's visibility to visible
                TogglesListBox.Visibility = Visibility.Visible;
            // Else...
            else
                // Collapses the scroll viewer
                TogglesListBox.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// If the toggle is checked adds its content to a list of strings
        /// </summary>
        protected void OnToggleChecked(object sender, RoutedEventArgs e)
        {
            var toggle = sender as CheckBox;
            ToggleContents.Add(toggle.Content.ToString());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            ToggleContents = new List<string>();
            ToggleCheckBoxes = new List<CheckBox>();

            // Creates a grid
            ListGrid = new Grid() { Margin = new Thickness(24) };
            // A row for the button
            ListGrid.RowDefinitions.Add(new RowDefinition());
            // A row for the list of toggles
            ListGrid.RowDefinitions.Add(new RowDefinition());

            // Creates a button 
            ListButton = new Button()
            {
                Style = MaterialDesignStyles.FlatButton,
                Foreground = DarkPink.HexToBrush(),
                FontFamily = Calibri,
                FontSize = 24,
                Width = 240,
                Height = 44,
                BorderThickness = new Thickness(0, 0, 0, 2),
                BorderBrush = DarkPink.HexToBrush(),
                Content = "Subjects"
            };
            // Adds the button to the grid
            ListGrid.Children.Add(ListButton);
            //On click changes the toggles scroll viewer's visibility
            ListButton.Click += ChangeTogglesVisibilityOnClick;
            ButtonAssist.SetCornerRadius(ListButton, new CornerRadius(0));

            TogglesListBox = new ListBox()
            {
                MaxHeight = 200,
                Width = 240,
                Background = White.HexToBrush(),
                Visibility = Visibility.Collapsed,
                Effect = ControlsFactory.CreateShadow()
            };
            RippleAssist.SetIsDisabled(TogglesListBox, true);

            ListGrid.Children.Add(TogglesListBox);
            Grid.SetRow(TogglesListBox, 1);

            Content = ListGrid;
        }

        /// <summary>
        /// Handles the change of the <see cref="ToggleNames"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnToggleListChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<string>)e.NewValue;

            var items = new List<CheckBox>();

            // If the new value is null...
            if (newValue == null)
            {
                // Creates a combo box item
                Toggle = new CheckBox()
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
                items.Add(Toggle);
            }
            // Else...
            else
            {
                // For each string in the list...
                foreach (var toggleName in ToggleNames)
                {
                    // Creates a new check box...
                    Toggle = new CheckBox()
                    {
                        Foreground = DarkGray.HexToBrush(),
                        FontFamily = Calibri,
                        FontSize = 24,
                        FontWeight = FontWeights.Normal,
                        Margin = new Thickness(8, 0, 0, 0),
                        // with content the one string
                        Content = toggleName
                    };
                    Toggle.Checked += OnToggleChecked;

                    // Adds the combo box item to the list
                    items.Add(Toggle);
                }
            }
            TogglesListBox.ItemsSource = items;

            // Further handle the change
            OnOptionsNameChanged(e);
        }


        #endregion
    }
}
