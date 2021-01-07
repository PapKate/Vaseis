using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The create user dialog
    /// </summary>
    public abstract class DialogBaseComponent : ContentControl
    {
        /// <summary>
        /// The dialog host
        /// </summary>
        public DialogHost DialogHost { get; private set; }

        #region Protected Properties

        /// <summary>
        /// The outside grid
        /// </summary>
        protected Grid OutGrid { get; private set; }

        /// <summary>
        /// The grid containing the dialog text inputs
        /// </summary>
        protected Grid DialogGrid { get; private set; }

        /// <summary>
        /// The panel containing all input
        /// </summary>
        protected WrapPanel InputWrapPanel { get; private set; }

        /// <summary>
        /// The scroll viewer for the input wrap panel
        /// </summary>
        protected ScrollViewer InputScrollViewer { get; private set; }

        /// <summary>
        /// The dialog's title
        /// </summary>
        protected TextBlock DialogTitle { get; private set; }

        /// <summary>
        /// The stack panel containing the dialog buttons
        /// </summary>
        protected StackPanel DialogButtonsStackPanel { get; private set; }

        /// <summary>
        /// The close button
        /// </summary>
        protected Button CloseButton { get; private set; }

        #endregion

        #region Dependency Properties

        #endregion

        #region Protected Methods

        /// <summary>
        /// On click closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseDialogOnClick(object sender, RoutedEventArgs e)
        {
            // Sets the dialog host's property is open to false
            DialogHost.IsOpen = false;

            // And clears its content
            DialogHost.DialogContent = null;
        }

        #endregion

        #region Constructors

        public DialogBaseComponent()
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
            // The stack panel for the input fields
            InputWrapPanel = new WrapPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center
            };

            // The outer grid, fixed size
            OutGrid = new Grid()
            {
                Width = 628,
                ClipToBounds = false,
                Background = GhostWhite.HexToBrush(),
                Margin = new Thickness(8),
            };

            // The inner grid, child only margin
            DialogGrid = new Grid()
            {
                Margin = new Thickness(8),
                Background = White.HexToBrush(),
            };

            // Creates the close button
            CloseButton = ControlsFactory.CreateCloseButton();
            // Moves it 6 pixel to the right outside of the inner grid
            CloseButton.Margin = new Thickness(-12);
            // Positions the button to the right...
            CloseButton.HorizontalAlignment = HorizontalAlignment.Right;
            // and top of the inner grid
            CloseButton.VerticalAlignment = VerticalAlignment.Top;
            // When clicked close the dialog
            CloseButton.Click += CloseDialogOnClick;

            // Adds the close button to the inner grid
            DialogGrid.Children.Add(CloseButton);

            // Adds the inner grid to the outer grid
            OutGrid.Children.Add(DialogGrid);

            // Sets three rows for the dialog grid
            DialogGrid.RowDefinitions.Add(new RowDefinition());
            DialogGrid.RowDefinitions.Add(new RowDefinition());
            DialogGrid.RowDefinitions.Add(new RowDefinition());

            // The title of the dialog
            DialogTitle = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 36,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Width = 522,
                Margin = new Thickness(24),
                Foreground = DarkBlue.HexToBrush()
            };

            // Adds to the inner grid the title...
            DialogGrid.Children.Add(DialogTitle);
            // And sets it to the first row
            Grid.SetRow(DialogTitle, 0);


            // Creates the stack panel for the dialog's inner buttons
            DialogButtonsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(24)
            };

            // Adds to the inner grid the buttons' stack panel...
            DialogGrid.Children.Add(DialogButtonsStackPanel);
            // And sets it to the third row
            Grid.SetRow(DialogButtonsStackPanel, 2);

            InputScrollViewer = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Top,
                // With content the bio's text block
                Content = InputWrapPanel,
                CanContentScroll = true,
                MaxHeight = 680
            };

            // Adds to the inner grid the wrap panel
            DialogGrid.Children.Add(InputScrollViewer);
            // And sets it to the second row of the dialog grid
            Grid.SetRow(InputScrollViewer, 1);

            // Creates the dialog host
            DialogHost = new DialogHost()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                IsOpen = true,
                CloseOnClickAway = true,
                OverlayBackground = DarkGray.HexToBrush(),
            };

            // Sets the dialog host's content to the outer grid
            DialogHost.DialogContent = OutGrid;

            // Sets the component's content to the dialog host
            Content = DialogHost;
        }


        #endregion

    }
}
