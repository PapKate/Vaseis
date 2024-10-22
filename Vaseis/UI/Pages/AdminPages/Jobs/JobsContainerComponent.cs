﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Vaseis
{
   public class JobsContainerComponent : ContentControl
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

        public JobsContainerComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var companyDepartments = await Services.GetDataStorage.GetDepartmentUsers(Company.Id);

            foreach (var department in companyDepartments)
            {
                var jobs = department.Jobs;

                foreach (var job in jobs)
                {
                    UserButtonsGrid.Children.Add(new JobButtonComponent(job));
                }
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
                Margin = new Thickness(24),
                Columns = 2
            };

            // The component's content is the grid
            Content = UserButtonsGrid;
        }

        #endregion

    }

}

