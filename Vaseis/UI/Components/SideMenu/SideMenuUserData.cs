using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Text;

namespace Vaseis
{
    public class SideMenuUserData
    {
        /// <summary>
        /// The user's type
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Contains all the titles and icons for the user's side menu
        /// </summary>
        public Dictionary<string, PackIconKind> UserTitleAndIconPage { get; set; }
    }
}
