﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The create a new department dialog
    /// </summary>
    public class NewDepartmentDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The department's name input
        /// </summary>
        protected TextInputComponent DepartmentInput { get; private set; }

        /// <summary>
        /// The department's color input
        /// </summary>
        protected TextInputComponent ColorInput { get; private set; }

        /// <summary>
        /// The company's picker
        /// </summary>
        protected PickerComponent CompanyPicker { get; private set; }

        /// <summary>
        /// The create a new department button
        /// </summary>
        protected Button CreateButton { get; private set; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NewDepartmentDialogComponent()
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
            DepartmentInput = new TextInputComponent()
            { 
                Width = 240,
                Margin = new Thickness(24),
                HintText = "Department's name"
            };
            InputWrapPanel.Children.Add(DepartmentInput);

            CompanyPicker = new PickerComponent()
            {
                HintText = "Company",
                Width = 240,
                Margin = new Thickness(24, 0, 24, 0),
                OptionNames = new List<string> { "EnchantmentLab", "Batter", "CoffeeMesh", "Gklitsa & Co" }
            };
            InputWrapPanel.Children.Add(CompanyPicker);

            ColorInput = new TextInputComponent()
            {
                Width = 240,
                Margin = new Thickness(24),
                HintText = "Representative hex color"
            };
            InputWrapPanel.Children.Add(ColorInput);

            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(DarkPink, "Create");
            //CreateButton.Click += CreateDepartmentOnClick;
            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);

        }

        #endregion

    }
}