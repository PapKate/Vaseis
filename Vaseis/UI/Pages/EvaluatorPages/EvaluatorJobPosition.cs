using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    public class EvaluatorJobPosition : ContentControl
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorJobPosition()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            var pageGrid = new Grid();
            var jobPositionDialogue = new JobPositionDialog()
            {
                IsDialogOpen = true
            };
            pageGrid.Children.Add(jobPositionDialogue);
            Content = pageGrid;
        
        
        
        
        }

        #endregion
    }
}
