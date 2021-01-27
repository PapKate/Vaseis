using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The page for manager to browse through their company's employees
    /// </summary>
    public class ManagerEmployeesPage : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel Manager { get; }

        /// <summary>
        /// The tab control
        /// </summary>
        public TabControl TabControl { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The page's scrollbar
        /// </summary>
        protected ScrollViewer ScrollViewer { get; private set; }

        /// <summary>
        /// The page's stack panel
        /// </summary>
        protected StackPanel PageStackPanel { get; private set; }

        /// <summary>
        /// The search employee command text
        /// </summary>
        protected TextBlock SearchComandText { get; private set; }

        /// <summary>
        /// The border containing the search command text
        /// </summary>
        protected Border SearchBarBorder { get; private set; }

        /// <summary>
        /// The search bar
        /// </summary>
        protected TextBox SearchBar { get; private set; }

        /// <summary>
        /// The stack panel containing the hint icon and text
        /// </summary>
        protected StackPanel HintStackPanel { get; private set; }

        /// <summary>
        /// The hint icon
        /// </summary>
        protected PackIcon SearchIcon { get; private set; }

        /// <summary>
        /// The hint text
        /// </summary>
        protected TextBlock HintTextBlock { get; private set; }

        /// <summary>
        /// The employee buttons grid
        /// </summary>
        protected UniformGrid EmployeeButtonsContainer { get; private set; }

        /// <summary>
        /// The key binding for the enter key
        /// </summary>
        protected KeyBinding OnEnterKeyPressed { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="manager">The manager</param>
        public ManagerEmployeesPage(UserDataModel manager, TabControl tabControl)
        {
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));
            TabControl = tabControl ?? throw new System.ArgumentNullException(nameof(tabControl));
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the initialization of the page
        /// </summary>
        /// <param name="e">Event args</param>
        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Gets all the employees of the manager's company
            var employees = await Services.GetDataStorage.GetCompanyEmployees(Manager.Department.CompanyId);

            // For every employee...
            foreach(var employee in employees)
                // Create and add the user button
                EmployeeButtonsContainer.Children.Add(new UserButtonComponent(employee, TabControl));

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // The page's stack panel
            PageStackPanel = new StackPanel();

            // The search command text block
            SearchComandText = new TextBlock()
            {
                Text = "Enter an employee's username or full name",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 64, 0, 32),
                Foreground = DarkBlue.HexToBrush(),
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                FontStyle = FontStyles.Normal,
                FontSize = 40
            };
            // Adds the search text block to the page's stack panel
            PageStackPanel.Children.Add(SearchComandText);

            // Creates a border for the search input field
            SearchBarBorder = new Border()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Width = 500,
                Height = 60,
                Background = White.HexToBrush(),
                CornerRadius = new CornerRadius(8)
            };
            // Adds the border to the stack panel
            PageStackPanel.Children.Add(SearchBarBorder);

            // Creates the search input field
            SearchBar = new TextBox()
            {
                Width = 468,
                Height = 44,
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = DarkGray.HexToBrush()
            };


            // The input fields hint stack panel
            HintStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal
            };
            
            // Creates an icon for the hint
            SearchIcon = StyleHelpers.MaterialIcon(DarkPink, PackIconKind.Magnify);
            SearchIcon.Height = 32;
            SearchIcon.Width = 32;

            // Creates the hint's text
            HintTextBlock = new TextBlock()
            {
                Text = "Search...",
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 28,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal
            };
            // Adds to the hint stack panel the icon
            HintStackPanel.Children.Add(SearchIcon);
            // Adds to the hint stack panel the text
            HintStackPanel.Children.Add(HintTextBlock);

            // Sets the text color of the hint to dark pink
            HintAssist.SetForeground(SearchBar, DarkPink.HexToBrush());
            // Sets the hint to the search bar input field
            HintAssist.SetHint(SearchBar, HintStackPanel);

            // Sets the border's content to the search bar input field
            SearchBarBorder.Child = SearchBar;

            // Creates the employees buttons with the container
            EmployeeButtonsContainer = new UniformGrid() { Columns = 4 };
            // Adds the container to the page's stack panel
            PageStackPanel.Children.Add(EmployeeButtonsContainer);

            // Creates a new key binding
            OnEnterKeyPressed = new KeyBinding
            {
                // The key is enter
                Key = Key.Enter,
                // Sets the command for when the enter key is pressed
                Command = new RelayCommand(() =>
                {
                    // For each button in the container...
                    foreach(var child in EmployeeButtonsContainer.Children )
                    {
                        // Parser from object to user button the child
                        var button = child as UserButtonComponent;
                        // Splits the search bar's input 
                        // whenever there is a space creates a string
                        var search = SearchBar.Text.Split(" ");
                        // If the text is null or empty...
                        if (String.IsNullOrEmpty(SearchBar.Text))
                            // Sets every button to visible
                            button.Visibility = Visibility.Visible;
                        // Else if the text matches a button's username
                        else if (button.Title == SearchBar.Text)
                            // Sets that button as visible
                            button.Visibility = Visibility.Visible;
                        // If there are spaces in the text...
                        else if (search.Length > 1)
                        {
                            // If there is a possible combination that matches the button's full name...
                            if (button.User.FullName == search[0] + " " + search[1]
                              || button.User.FullName == search[1] + " " + search[0])
                            {
                                // Sets that button as visible
                                button.Visibility = Visibility.Visible;
                            }
                            // Else...
                            else
                                // Collapses the button
                                button.Visibility = Visibility.Collapsed;
                        }
                        // Else...
                        else
                            // Collapses the button
                            button.Visibility = Visibility.Collapsed;
                    }
                })
            };
            // Adds it to the search bar's input bindings
            SearchBar.InputBindings.Add(OnEnterKeyPressed);

            // Creates a scroll viewer and sets its content to the page's stack panel
            ScrollViewer = new ScrollViewer()
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                Content = PageStackPanel,
            };

            // Sets the component's content to the scroll viewer
            Content = ScrollViewer;
        }

        #endregion
    }
}
