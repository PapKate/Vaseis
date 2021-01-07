
using MaterialDesignThemes.Wpf;

using System.Windows.Controls;

namespace Vaseis
{
    public class AdminSideMenuComponent : BaseSideMenuComponent
    {
        #region Protected Properties

        /// <summary>
        /// The companies button
        /// </summary>
        protected SideMenuButtonComponent CompaniesButton { get; private set; }

        /// <summary>
        /// The users button
        /// </summary>
        protected SideMenuButtonComponent UsersButton { get; private set; }

        /// <summary>
        /// The jobs button
        /// </summary>
        protected SideMenuButtonComponent Jobs { get; private set; }

        /// <summary>
        /// The subjects button
        /// </summary>
        protected SideMenuButtonComponent Subjects { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public AdminSideMenuComponent(TabControl tabControl) : base(tabControl)
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Create and add the my job requests button
            CompaniesButton = CreateAndAddSideMenuButton("Companies", PackIconKind.DomainPlus);

            // Create and add the my evaluations button
            UsersButton = CreateAndAddSideMenuButton("Users", PackIconKind.AccountMultipleAdd);

            // Create and add the job positions button
            Jobs = CreateAndAddSideMenuButton("Jobs", PackIconKind.FolderPlus);
        }


        #endregion
    }
}
