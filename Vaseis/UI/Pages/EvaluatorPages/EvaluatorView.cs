using System;
using System.Collections.Generic;
using System.Text;

namespace Vaseis
{
    public class EvaluatorView : BaseView
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EvaluatorView(UserDataModel user) : base(user)
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
            // Creates and adds the evaluator's side menu
            CreateView(new EvaluatorSideMenuComponent(TabControl, User));
        }

        #endregion
    }
}
