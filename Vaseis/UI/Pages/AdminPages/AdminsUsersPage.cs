using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Vaseis
{
    public class AdminsUsersPage : ContentControl
    {
        #region Protected Properties
        /// <summary>
        /// The page's StackPanel
        /// </summary>
        protected StackPanel PageStackPanel { get; private set; }

        /// <summary>
        /// The page;s ScrollViewer
        /// </summary>
        protected ScrollViewer PageScrollViewer { get; private set; }


        protected TextBlock CompanyTextBlock { get; private set; }


        #endregion

        #region Dependency Properties


        #endregion

        #region Constructors

        public AdminsUsersPage()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            PageStackPanel = new StackPanel();

            var IntroBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 52,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkPink.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                Text = "Employees per Company",
                Margin = new Thickness(44)
            };

            PageStackPanel.Children.Add(IntroBlock);

            //foreach (var company in Companies) { };

            CompanyTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                Text = "Company Name",
                Margin = new Thickness(48)
            };

            PageStackPanel.Children.Add(CompanyTextBlock);

           
            var hmmm = new UserButtonsContainerComponent();
            var scroll = new ScrollViewer() {

                MaxHeight = 1200,
                Content = hmmm,
            };

            var hmmExpander = new Expander()
            {     
                Header = "Employees",
                Width = 1500,
                BorderThickness = new Thickness(0, 0, 0, 8),
                Content = scroll,
            };

            PageStackPanel.Children.Add(hmmExpander);

            CompanyTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                Text = "Company Name 2",

            };

            PageStackPanel.Children.Add(CompanyTextBlock);

            var hmm = new UserButtonsContainerComponent();


     
            PageStackPanel.Children.Add(hmm);

            PageScrollViewer = new ScrollViewer();
            PageScrollViewer.Content = PageStackPanel;

            Content = PageScrollViewer;

        }

    }
        #endregion
    }

