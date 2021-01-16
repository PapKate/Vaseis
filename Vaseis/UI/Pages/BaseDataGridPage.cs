using System;
using System.Windows.Controls;

namespace Vaseis
{
    public class BaseDataGridPage : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The manager
        /// </summary>
        public UserDataModel User { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        #endregion

        #region Constructors

        public BaseDataGridPage()
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
            // The page's grid
            PageGrid = new Grid();

            // Sets the component's content to the page's scroll viewer
            Content = PageGrid;
        }

        #endregion


    }
}
