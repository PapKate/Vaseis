using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    public class LogPage : ContentControl
    {
        #region Public Properties 
        #endregion

        #region Protected Properties

        /// <summary>
        /// the page's stackPanel
        /// </summary>
        protected StackPanel PageStackPanel { get; private set; }


        /// <summary>
        /// the page's scrollviewer
        /// </summary>
        protected ScrollViewer PageScrollViewer { get; private set; }

        #endregion

        #region Dependency Properties

        #endregion

        #region Constructor

        public LogPage()
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods 

        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var logs = await Services.GetDataStorage.GetLogHistory();

            foreach (var log in logs) 
            {
                var logRowComponent = new LogDataGridRowComponent()
                {
                    Username = log.Username,
                    Action = log.Action,
                    Details = log.Details,
                    DateTime = log.When.ToString()
                };

                PageStackPanel.Children.Add(logRowComponent);
            }

        }

        #endregion

        #region Private Methods 

        private void CreateGUI()
        {

            PageStackPanel = new StackPanel();

            PageScrollViewer = new ScrollViewer()
            {
                Content = PageStackPanel
            };

            Content = PageScrollViewer;
        }
        #endregion
    }
}
