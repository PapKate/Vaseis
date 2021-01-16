using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    //For the admin in companies page -> Add Job to the parameter company
    public class NewJobDialogComponent : DialogBaseComponent
    {
        #region Public Properties

        /// <summary>
        /// The company the Admin wants to add a job to
        /// </summary>
        public CompanyDataModel Company { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// I use the company parameter to specify some characteristics suck as Company id etc
        /// </summary>
        public NewJobDialogComponent()
        {
            CreateGUI();
        }

        public NewJobDialogComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }


        #endregion

        #region Private Methods 

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary
        private void CreateGUI()
        {
            //just using two variables to unite two strings 

            var textHelper = Company.Name;
            var textHelper2 = "Create job for the company " + textHelper;

            // Adds th dialog's title
            DialogTitle.Text = textHelper2;

            var JobTitle = new TextInputComponent()
            {
                HintText = "Job Title",
                FontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0)
            };

            var Salary = new TextInputComponent()
            {
                HintText = "$alary",
                FontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0)
            };

            var Deprtment = new PickerComponent()
            {
                HintText = "Department",
                FontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0),
                OptionNames = new List<string> { "Κόλαση", "Καθαρτήριο", "Παράδεισος" }
            };

            var JobStackPanel = new StackPanel();
            JobStackPanel.Children.Add(JobTitle);
            JobStackPanel.Children.Add(Salary);
            JobStackPanel.Children.Add(Deprtment);


            //the ok Button

            var OkButton = new Button()
            {
                Background = DarkBlue.HexToBrush(),
                Height = 40,
                Width = 164,
                Margin = new Thickness(28),
                Content = new TextBlock()
                {
                    Foreground = White.HexToBrush(),
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "OK"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += CloseDialogOnClick;

            JobStackPanel.Children.Add(OkButton);


            InputWrapPanel.Children.Add(JobStackPanel);


            #endregion

        }
    }
}
