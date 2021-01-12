using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    class CompaniesPage : ContentControl
    {
        #region Proetcted Properties

        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors
        public CompaniesPage()
        {
            CreateGUI();
        }

        #endregion


        /// <summary>
        /// Creates and adds the required GUI elements for the administrator's companies page
        /// </summary>
        #region Private Methods

        private void CreateGUI()
        {
            // The grid containing the companies
            var CompanyButtonsGrid = new Grid()
            {
                Margin = new Thickness(32),
            };

            // For four times...
            for (var i = 0; i <= 4 - 1; i++)
            {
                // Adds to the buttons' grid a column
                CompanyButtonsGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(400, GridUnitType.Pixel)
                });
            }

          //  Grid.SetRow



        }

        #endregion

    }
}
