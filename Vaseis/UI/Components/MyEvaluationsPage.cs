using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    class MyEvaluationsPage : ContentControl
    {

        #region Protected Properties

        public Button EditIcon { get; set; }

        public Button FinalizeIcon { get; set; }

        #endregion

        #region Dependency Properties
        
        /// <summary>
        /// The Employess's name
        /// </summary>
        public string Employee
        {
            get { return GetValue(EmployeeProperty).ToString(); }
            set { SetValue(EmployeeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Employee"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmployeeProperty = DependencyProperty.Register(nameof(Employee), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The Job's title
        /// </summary>
        public string Job
        {
            get { return GetValue(JobProperty).ToString(); }
            set { SetValue(JobProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Job"/> dependency property
        /// </summary>
        public static readonly DependencyProperty JobProperty = DependencyProperty.Register(nameof(Job), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The Final Grade
        /// </summary>
        public string FinalGrade
        {
            get { return GetValue(FinalGradeProperty).ToString(); }
            set { SetValue(FinalGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FinalGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FinalGradeProperty = DependencyProperty.Register(nameof(FinalGrade), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The InterviEW Grade
        /// </summary>
        public string IG
        {
            get { return GetValue(IGProperty).ToString(); }
            set { SetValue(IGProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="IG"/> dependency property
        /// </summary>
        public static readonly DependencyProperty IGProperty = DependencyProperty.Register(nameof(IG), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The report's Grade
        /// </summary>
        public string RG
        {
            get { return GetValue(RGProperty).ToString(); }
            set { SetValue(RGProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="RG"/> dependency property
        /// </summary>
        public static readonly DependencyProperty RGProperty = DependencyProperty.Register(nameof(RG), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The File's Grade
        /// </summary>
        public string FilesGrade
        {
            get { return GetValue(FilesGradeProperty).ToString(); }
            set { SetValue(FilesGradeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FilesGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FilesGradeProperty = DependencyProperty.Register(nameof(FilesGrade), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The Report
        /// </summary>
        public string Report
        {
            get { return GetValue(ReportProperty).ToString(); }
            set { SetValue(ReportProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ReportComments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ReportProperty = DependencyProperty.Register(nameof(Report), typeof(string), typeof(EvaluationResults));

        /// <summary>
        /// The Interview comments
        /// </summary>
        public string InterviewComments
        {
            get { return GetValue(InterviewCommentsProperty).ToString(); }
            set { SetValue(InterviewCommentsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="InterviewComments"/> dependency property
        /// </summary>
        public static readonly DependencyProperty InterviewCommentsProperty = DependencyProperty.Register(nameof(InterviewComments), typeof(string), typeof(EvaluationResults));


        #endregion


        #region Constructor

        public MyEvaluationsPage()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods 

        private void CreateGUI()
        {
            //giatiii?!?!?
             EditIcon =  ControlsFactory.CreateEditButton();

            var dataTable = new DataTable();


           var evaluationsRow = new List<EvaluatorMyEvaluationsPage>();


            dataTable.Columns.Add("Employee", typeof(String));
            dataTable.Columns.Add("Job", typeof(String));
            dataTable.Columns.Add("IG", typeof(String));
            dataTable.Columns.Add("RG", typeof(String));
            dataTable.Columns.Add("FG", typeof(String));
            dataTable.Columns.Add("Final Grade", typeof(String));
            dataTable.Columns.Add("Report", typeof(Expander));
            dataTable.Columns.Add("Interview Comments", typeof(Expander));
            dataTable.Columns.Add("Edit", typeof(Button));
            dataTable.Columns.Add("Finalize", typeof(Button));

            //create items kai add them 

            //Binding??

        }

        #endregion


    }

}

