using System;
using System.Collections.Generic;
using System.Text;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis

// tO string?!?!?! String filesGrade?
{
    class EvaluationResults : ContentControl
    {


        #region Dependency Properties 

        /// <summary>
        /// The Evaluator's name
        /// </summary>
        public string Evaluator
        {
            get { return GetValue(EvaluatorProperty).ToString(); }
            set { SetValue(EvaluatorProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Evaluator"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EvaluatorProperty = DependencyProperty.Register(nameof(Evaluator), typeof(string), typeof(EvaluationResults));

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







        #region Constructors

        public EvaluationResults()
        {
            CreateGUI();
        }

        #endregion


        #region Private Methods 

        private void CreateGUI()
        {


            var dataTable = new DataTable();


            List<EvaluationResults> listItems = new List<EvaluationResults>();


            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpogsrgmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = "8.95", RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults{ Evaluator = "Sakis", Employee = "Mpomgrgpounas", Job = "mhxanikos", FinalGrade = "4", IG = "8.95", RG = "8.95", FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "xTakis", Employee = "Mpomposgsgunas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Msdvgsdfakis", Employee = "Mgnpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makbfxbis", Employee = "Mpowmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Maknb xcis", Employee = "Mpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Mabxkis", Employee = "Mpompsgggounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makfbis", Employee = "Mpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makixbs", Employee = "Mpomnpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpompougnas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "cxvMakis", Employee = "Mpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Madfvgdkis", Employee = "Mpgompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makihdfs", Employee = "Mpompgounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpomhpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makhfis", Employee = "Mpomhpggounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makisn", Employee = "Mpomphhgounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpompounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Mazkis", Employee = "Mpomhpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Macskis", Employee = "Mpomgbmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpompodhunas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Madfdgkis", Employee = "Mphhounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makifgs", Employee = "Mpomhpodhunas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Makgsis", Employee = "Mpompoudnas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResults { Evaluator = "Magedsgkis", Employee = "Mpomhpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });



            dataTable.Columns.Add("Evaluator", typeof(String));
            dataTable.Columns.Add("Employee", typeof(String));
            dataTable.Columns.Add("Job", typeof(String));
            dataTable.Columns.Add("IG", typeof(String));
            dataTable.Columns.Add("RG", typeof(String));
            dataTable.Columns.Add("FG", typeof(String));
            dataTable.Columns.Add("Final Grade", typeof(String));
            dataTable.Columns.Add("Report", typeof(Expander));
            dataTable.Columns.Add("Interview Comments", typeof(Expander));


            foreach (var listItem in listItems)
            {
                dataTable.Rows.Add(listItem);
            }

            var ScrollViewContainer = new ScrollViewer()
            {
                Content = dataTable
            };

            Content = ScrollViewContainer;

          
            //Binding??????

        }

        #endregion
    }
}

