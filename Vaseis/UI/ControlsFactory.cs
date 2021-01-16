﻿using MaterialDesignThemes.Wpf;

using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// Provides helpers for creating predefined controls
    /// </summary>
    public static class ControlsFactory
    {
        /// <summary>
        /// Creates a shadow for a GUI element
        /// </summary>
        public static DropShadowEffect CreateShadow()
        {
            return new DropShadowEffect
            {
                Color = DarkGray.HexToColor(),
                Direction = 320,
                ShadowDepth = 0,
                Opacity = 0.4
            };
        }

        /// <summary>
        /// Formats an integer to the correct currency representation
        /// </summary>
        /// <param name="value">The value we want to get in currency format</param>
        /// <returns></returns>
        public static string CreateSalaryFormat(int value)
        {
            return value.ToString("C", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates the data grid's rows
        /// </summary>
        public static Grid CreateDataGridRowGrid()
        {
            var rowGrid = new Grid()
            {
                Height = 52,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            for (var i = 0; i <= 4 - 1; i++)
            {
                rowGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(240, GridUnitType.Pixel)
                });
            }

            for (var i = 0; i <= 4 - 1; i++)
            {
                rowGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(80, GridUnitType.Pixel)
                });
            }

            rowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(140, GridUnitType.Pixel)
            });

            for (var i = 0; i <= 2 - 1; i++)
            {
                rowGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(70, GridUnitType.Pixel)
                });
            }

            return rowGrid;
        }

        /// <summary>
        /// Creates a hint
        /// </summary>
        /// <param name="hintText">The hint's text</param>
        /// <param name="element">The element to which the hint is attached to</param>
        public static void CreateHint(string hintText, DependencyObject element)
        {
            // Creates the hint text
            var hintTitleBlock = new TextBlock()
            {
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                TextTrimming = TextTrimming.CharacterEllipsis,
                IsHitTestVisible = false,
                Text = hintText
            };

            // Sets the text's color to dark pink
            HintAssist.SetForeground(element, DarkPink.HexToBrush());
            // Sets the hint to the input text box
            HintAssist.SetHint(element, hintTitleBlock);
        }

        /// <summary>
        /// Creates a date picker
        /// </summary>
        public static DatePicker CreateDatePicker(string hintText)
        {
            //kTODO: add the date picker to factor controls with parameter hint text
            // Creates a date picker - calendar field
            var datePicker = new DatePicker()
            {
                Width = 240,
                Margin = new Thickness(24),
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24
            };
            // Adds a hint to the date picker
            ControlsFactory.CreateHint(hintText, datePicker);

            return datePicker;
        }


        /// <summary>
        /// Creates an add button for the pages
        /// </summary>
        /// <param name="background">The hexadecimal value representing a color</param>
        public static Button CreateAddButton(string background)
        {
            // Creates the add button
            var addButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Background = background.HexToBrush(),
                Height = 52,
                Width = 120,
                Margin = new Thickness(0, 0, 0, 32),
                Content = new TextBlock()
                {
                    Foreground = Styles.White.HexToBrush(),
                    FontSize = 28,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Styles.Calibri,
                    Text = "Add"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(addButton, new CornerRadius(8));
            
            // Returns the button
            return addButton;
        }

        #region Control Buttons

        /// <summary>
        /// Creates a square button with a pack icon and specified color
        /// </summary>
        /// <param name="packIconKind"></param>
        /// <returns></returns>
        public static Button CreateControlButton(PackIconKind packIconKind, string backgroundColor)
        {
            var button = new Button()
            {
                Content = new PackIcon()
                {
                    Kind = packIconKind,
                    Width = 36,
                    Height = 36,
                    Foreground = White.HexToBrush(),
                },
                Width = 40,
                Height = 40,
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
                Background = backgroundColor.HexToBrush()
            };

            ButtonAssist.SetCornerRadius(button, new CornerRadius(8));

            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as an edit button
        /// </summary>
        /// <returns></returns>
        public static Button CreateEditButton()
        {
            var button = CreateControlButton(PackIconKind.Edit, DarkPink);

            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a close button
        /// </summary>
        /// <returns></returns>
        public static Button CreateCloseButton()
        {
            var button = CreateControlButton(PackIconKind.Close, Red);

            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a check button
        /// </summary>
        /// <returns></returns>
        public static Button CreateCheckButton()
        {
            var button = CreateControlButton(PackIconKind.Check, Green);
      
            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a back button
        /// </summary>
        /// <returns></returns>
        public static Button CreateBackButton()
        {
            var button = CreateControlButton(PackIconKind.ArrowLeftBold, HookersGreen);
            
            return button;
        }

        /// <summary>
        /// Creates and returns a <see cref="Button"/> personalized as a finalize button
        /// </summary>
        /// <returns></returns>
        public static Button CreateFinalizeButton()
        {
            var button = CreateControlButton(PackIconKind.ArrowUpBold, HookersGreen);
            
            return button;
        }

        #endregion

    }
}