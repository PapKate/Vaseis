using System;
using System.Collections.Generic;
using System.Text;

namespace Vaseis
{
    public class EmployeeView : BaseView
    {
        #region Protected Properties


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeView(UserDataModel user) : base(user)
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
            // Creates and adds the employee's side menu
            SideMenu = CreateView(new EmployeeSideMenuComponent(TabControl, User));
        }

        #endregion
    }
}
