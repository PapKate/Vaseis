using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Vaseis
{
    public class DepartmentContainerComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        ///  The grid container of all the user buttons
        /// </summary>
        protected UniformGrid UserButtonsGrid { get; private set; }

        /// <summary>
        /// The specific company
        /// </summary>
        protected CompanyDataModel Company { get; }

        #endregion

        #region Constructors

        public UserButtonsContainerComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var companyEmployees = await Services.GetDataStorage.GetDepartmentUsers(Company.Id);

            var emplyoees = companyEmployees.Users;

            foreach (var employee in emplyoees)
            {
                UserButtonsGrid.Children.Add(new UserButtonComponent(employee) { });
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // The grid containing the buttons
            UserButtonsGrid = new UniformGrid()
            {
                Margin = new Thickness(32),
            };

            // The component's content is the grid
            Content = UserButtonsGrid;
        }

        #endregion

    }
}
