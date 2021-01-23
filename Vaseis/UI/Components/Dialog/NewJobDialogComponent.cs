using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        #region Protected Properties 
        /// <summary>
        /// The job's Title
        /// </summary>
        protected TextInputComponent JobTitle { get;  set; } 

        /// <summary>
        /// The job's Department
        /// </summary>
        protected PickerComponent Deprtment { get; set;  }

        /// <summary>
        /// The job's Salary
        /// </summary>
        protected TextInputComponent Salary { get;  set; }

        #endregion


        #region Dependency Properties

        #region Departmetns 

        public IEnumerable<string> DepartmentsOption
        {
            get { return (IEnumerable<string>)GetValue(DepartmentsOptionProperty); }
            set { SetValue(DepartmentsOptionProperty, value); }
        }


        /// <summary>
        /// Identifies the <see cref="OptionDepartments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentsOptionProperty = DependencyProperty.Register(nameof(DepartmentsOption), typeof(IEnumerable<string>), typeof(NewJobDialogComponent));

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// I use the company parameter to specify some characteristics suck as Company id etc
        /// </summary>
        public NewJobDialogComponent(CompanyDataModel company)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));

            CreateGUI();
        }


        #endregion

        #region Protected Methods

        protected async void CreateJobOnClick(object sender, RoutedEventArgs e)
        {

            var salary = Int32.Parse(Salary.Text);

            await Services.GetDataStorage.AddNewJob(Company,salary, Deprtment.Text);

            CloseDialogOnClick(this, e);

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

             JobTitle = new TextInputComponent()
            {
                HintText = "Job Title",
                FontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0)
            };

            Salary = new TextInputComponent()
            {
                HintText = "$alary",
                FontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0)
            };

             Deprtment = new PickerComponent()
            {
                HintText = "Department",
                FontSize = 24,
                Width = 240,
                Foreground = DarkGray.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(4, 0, 4, 0),
                OptionNames = DepartmentsOption
             };
            Deprtment.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(DepartmentsOption))
            {
                Source = this
            });

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
            OkButton.Click += CreateJobOnClick;

            JobStackPanel.Children.Add(OkButton);


            InputWrapPanel.Children.Add(JobStackPanel);


            #endregion

        }
    }
}
