using System.Windows.Controls;
using System.Windows;

using static Vaseis.Styles;

using System.Windows.Media.Effects;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace Vaseis
{
    /// <summary>
    /// The side menu
    /// </summary>
    public class SideMenuComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The sideMenu container
        /// </summary>
        protected StackPanel SideMenuContainer { get; private set; }

        /// <summary>
        /// The side menu's border
        /// </summary>
        protected Border SideMenuBorder { get; private set; }


        #endregion

        #region Constructors

        public SideMenuComponent()
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
            SideMenuBorder = new Border()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                
                //BorderBrush = DarkGray.HexToBrush(),
                //BorderThickness = new Thickness(0, 0, 1, 0)
                Effect = new DropShadowEffect
                {
                    Color = DarkGray.HexToColor(),
                    Direction = 320,
                    ShadowDepth = 0,
                    Opacity = 1
                }
            };

            SideMenuContainer = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = White.HexToBrush(),

            };

            SideMenuBorder.Child = SideMenuContainer;

            var userMenuData = CreateUserMenuData();

            foreach(var user in userMenuData)
            {
                if(user.UserType == UserType.Evaluator)
                {
                    foreach(var buttonData in user.UserTitleAndIconPage)
                    {
                        var userPageButton = new SideMenuButtonComponent()
                        {
                            PageTitle = buttonData.Key,
                            PageIcon = buttonData.Value
                        };

                        SideMenuContainer.Children.Add(userPageButton);
                    }
                }
            }


            Content = SideMenuBorder;
        }

        /// <summary>
        /// Creates a list with the required icons and titles for side menu buttons
        /// according to the user's type
        /// </summary>
        private List<SideMenuUserData> CreateUserMenuData()
        {
            var userMenuDataList = new List<SideMenuUserData>();

            var employeeButtonsData = new Dictionary<string, PackIconKind>
            {
                { "Profile", PackIconKind.AccountCircle },
                { "Company", PackIconKind.Domain },
                { "Job requests", PackIconKind.ClipboardArrowUp },
                { "My evaluations", PackIconKind.ClipboardAccount },
                { "My job positions", PackIconKind.BriefcaseAccount },
                { "Job positions", PackIconKind.FolderSearch },
            };

            var employeeMenuData = new SideMenuUserData
            {
                UserType = UserType.Employee,
                UserTitleAndIconPage = employeeButtonsData
            };

            userMenuDataList.Add(employeeMenuData);

            var managerButtonsData = new Dictionary<string, PackIconKind>
            {
                { "Profile", PackIconKind.AccountCircle },
                { "Company", PackIconKind.Domain },
                { "Reports", PackIconKind.ClipboardFlow }, 
                { "Evaluation results", PackIconKind.ClipboardList },
                { "Employees", PackIconKind.AccountGroup },
            };

            var managerMenuData = new SideMenuUserData
            {
                UserType = UserType.Manager,
                UserTitleAndIconPage = managerButtonsData                  
            };

            userMenuDataList.Add(managerMenuData);

            var evaluatorButtonsData = new Dictionary<string, PackIconKind>
            {
                { "Profile", PackIconKind.AccountCircle },
                { "Company", PackIconKind.Domain },
                { "Job requests", PackIconKind.ClipboardArrowDown },
                { "My evaluations", PackIconKind.ClipboardEdit },
                { "My job positions", PackIconKind.FolderEdit },
                { "Job positions", PackIconKind.FolderSearch },
            };

            var evaluatorMenuData = new SideMenuUserData
            {
                UserType = UserType.Evaluator,
                UserTitleAndIconPage = evaluatorButtonsData
            };

            userMenuDataList.Add(evaluatorMenuData);

            var adminButtonsData = new Dictionary<string, PackIconKind>
            {
                { "Profile", PackIconKind.AccountCircle },
                { "Companies", PackIconKind.Domain },
                { "Users", PackIconKind.AccountMultipleAdd },
                { "Jobs", PackIconKind.FolderPlus },
                { "Subjects", PackIconKind.TranscribeClose },
            };

            var adminMenuData = new SideMenuUserData
            {
                UserType = UserType.Administrator,
                UserTitleAndIconPage = adminButtonsData
            };

            userMenuDataList.Add(adminMenuData);

            return userMenuDataList;
        } 

        #endregion
    }
}
