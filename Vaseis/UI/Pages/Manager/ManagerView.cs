using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    public class ManagerView : BaseView
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManagerView(UserDataModel user) : base(user)
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
            // Creates and adds the manager's side menu
            CreateView(new ManagerSideMenuComponent(TabControl, User));
        }

        #endregion
    }
}
