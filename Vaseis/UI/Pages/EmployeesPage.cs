using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

using static Vaseis.Styles;


namespace Vaseis
{
    /// <summary>
    /// The page for manager to browse through their company's employees
    /// </summary>
    public class EmployeesPage : ContentControl
    {
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
        /// 
        /// </summary>
        protected StackPanel HintStackPanel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected PackIcon SearchIcon { get; private set; }

        protected TextBlock HintTextBlock { get; private set; }

        protected EmployeeButtonsContainerComponent EmployeeButtonsContainer { get; private set; }

        #endregion


        #region Constructors

        public EmployeesPage()
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
            PageStackPanel = new StackPanel();

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

            PageStackPanel.Children.Add(SearchComandText);

            SearchBarBorder = new Border()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Width = 500,
                Height = 60,
                Background = White.HexToBrush(),
                CornerRadius = new CornerRadius(8)
            };

            PageStackPanel.Children.Add(SearchBarBorder);

            SearchBar = new TextBox()
            {
                Width = 468,
                Height = 44,
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = DarkGray.HexToBrush()
            };

            HintStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal
            };

            SearchIcon = StyleHelpers.MaterialIcon(DarkPink, PackIconKind.Magnify);
            SearchIcon.Height = 32;
            SearchIcon.Width = 32;

            HintTextBlock = new TextBlock()
            {
                Text = "Search...",
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 28,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal
            };

            HintStackPanel.Children.Add(SearchIcon);
            HintStackPanel.Children.Add(HintTextBlock);

            HintAssist.SetForeground(SearchBar, StyleHelpers.HexToBrush(Styles.DarkPink));
            HintAssist.SetHint(SearchBar, HintStackPanel);

            SearchBarBorder.Child = SearchBar;

            EmployeeButtonsContainer = new EmployeeButtonsContainerComponent()
            {
            };

            PageStackPanel.Children.Add(EmployeeButtonsContainer);

            ScrollViewer = new ScrollViewer()
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                Content = PageStackPanel,
                
            };

            

            Content = ScrollViewer;
        }

        #endregion
    }
}
