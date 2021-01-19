using MaterialDesignThemes.Wpf;

using System;
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
        /// Formats a currency string to an integer
        /// </summary>
        /// <param name="value">The salary</param>
        /// <returns></returns>
        public static int ParseSalaryToInt(string value)
        {
            // Parses the currency to an integer
            var newValue = int.Parse(value, NumberStyles.Currency);
            // Returns the integer
            return newValue;
        }

        /// <summary>
        /// Convert String to Null able int
        /// </summary>
        /// <param name="thisOne"></param>
        /// <returns></returns>
        public static int? GradeToNullableInt(string thisOne) 
        {
            var sDouble = Convert.ToDouble(thisOne);

            var f = sDouble * 100;
            var fuck = (int)f;

            return fuck;
        }


        /// <summary>
        /// Finds the department enum by its string name
        /// </summary>
        public static Department GetDepartment(string departmentName)
        {
            // Gets an array of all the values the department enum has
            var departments = Enum.GetValues(typeof(Department));
            // By default the found department is the first department of the enum
            var departmentWithName = Department.Accounting;
            // For each department in the enum
            foreach(var department in departments)
            {
                // If the department is the same as the given...
                if (department.ToString() == departmentName)
                {
                    // Sets the found department as this one
                    departmentWithName = (Department)department;
                    // Break out of the for each
                    break;
                }
            }
            // Returns the found department enum
            return departmentWithName;
        }

        /// <summary>
        /// Gets the deadline's string and returns the announcement date
        /// </summary>
        /// <param name="deadlineString">format: date - date</param>
        public static DateTime GetAnnouncementDate(string deadlineString)
        {
            // Gets the first date of the string 
            var announcementString = deadlineString.Split('-')[0];
            // Parses it to date time
            var announcementDate = DateTime.Parse(announcementString);
            // Returns the date time
            return announcementDate;
        }

        /// <summary>
        /// Gets the deadline's string and returns the submission date
        /// </summary>
        /// <param name="deadlineString">format: date - date</param>
        public static DateTime GetSubmissionDate(string deadlineString)
        {
            // Gets the first date of the string 
            var submissionString = deadlineString.Split('-')[1];
            // Parses it to date time
            var submissionDate = DateTime.Parse(submissionString);
            // Returns the date time
            return submissionDate;
        }

        /// <summary>
        /// Turn the grade from 1000 to 10 max
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static double GetGrade(int? grade)
        {
            // If not null return the new value else 0
            var parsedGrade = grade * 0.01 ?? default(int);
            // returns the grade scaled to 10
            return parsedGrade;
        }

        /// <summary>
        /// Calculates the final evaluation grade
        /// </summary>
        /// <param name="filesGrade">The files grade</param>
        /// <param name="interviewGrade">The interview's grade</param>
        /// <param name="reportGrade">The report's grade</param>
        public static int CreateFinalGrade(int? filesGrade, int? interviewGrade, int? reportGrade)
        {
            var finalGrade = (int)(filesGrade*0.2 + interviewGrade*0.4 + reportGrade*0.4);

            // Returns the evaluation's grade
            return finalGrade;
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
        /// Creates and returns a <see cref="Button"/> personalized as an edit button
        /// </summary>
        /// <returns></returns>
        public static Button CreateAddButton()
        {
            var button = CreateControlButton(PackIconKind.Add, GreenBlue);
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