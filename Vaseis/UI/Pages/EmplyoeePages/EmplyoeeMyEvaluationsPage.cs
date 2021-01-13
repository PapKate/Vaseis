using System.Windows.Controls;

namespace Vaseis
{
    public class EmplyoeeMyEvaluationsPage : ContentControl
    {
        #region Protected Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmplyoeeMyEvaluationsPage()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            var pageGrid = new Grid();

            var dataGrid2 = new EmployeeMyEvaluationsDataGridComponent()
            {
            };

            pageGrid.Children.Add(dataGrid2);




            Content = pageGrid;
        }

        #endregion
    }
}
