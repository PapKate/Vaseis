using System;
using System.Collections.Generic;
using System.Text;

namespace Vaseis
{ 
    public class AdminView : BaseView
    {
        #region Protected Properties


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminView(UserDataModel user) : base(user)
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
            // Creates and adds the administrators's side menu
            CreateView(new AdminSideMenuComponent(TabControl, User));
        }

        #endregion
    }
}
