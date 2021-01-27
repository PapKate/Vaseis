using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vaseis
{
    /// <summary>
    /// The base data grid 
    /// </summary>
    public abstract class BaseDataGridComponent : ContentControl
    {

        /// <summary>
        /// A list with all the data grid's rows
        /// </summary>
        public List<EvaluationBaseDataGridRowComponent> RowList { get; set; }


        #region Protected Properties

        /// <summary>
        /// The data grid's scroll viewer
        /// </summary>
        protected ScrollViewer DataGridScrollViewer { get; private set; }

        /// <summary>
        /// The data grid's stack panel
        /// </summary>
        protected StackPanel InfoDataStackPanel { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDataGridComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected override sealed async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            await Task.Delay(10);

            OnInitialized();
        }

        protected virtual void OnInitialized() { }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the data grid's stack panel
            InfoDataStackPanel = new StackPanel();

            // Creates a scroll viewer and sets its content to the data grid's stack panel
            DataGridScrollViewer = new ScrollViewer()
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = InfoDataStackPanel
            };

            // Sets the component's content to the scroll viewer
            Content = DataGridScrollViewer;
        }

        #endregion
    }
}
