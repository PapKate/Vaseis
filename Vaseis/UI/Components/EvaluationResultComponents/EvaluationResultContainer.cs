using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Vaseis
{
   public class EvaluationResultContainer : EvaluationResultListItem
    {
        #region Constructors

        public EvaluationResultContainer()
        {
            CreateGUI();
        }


        #region Private Methods 

        private void CreateGUI()
        {

            var dataTable = new DataTable();


            List<EvaluationResultListItem> listItems = new List<EvaluationResultListItem>();


            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpogsrgmpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Sakis", Employee = "Mpomgrgpounas", Job = "mhxanikos", finalGrade = (float)4, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "xTakis", Employee = "Mpomposgsgunas", Job = "mhxanikos", finalGrade = (float)8.595, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Msdvgsdfakis", Employee = "Mgnpompounas", Job = "mhxanikos", finalGrade = (float)0.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makbfxbis", Employee = "Mpowmpounas", Job = "mhxanikos", finalGrade = (float)3.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Maknb xcis", Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Mabxkis", Employee = "Mpompsgggounas", Job = "mhxanikos", finalGrade = (float)1.095, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makfbis", Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)3.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makixbs", Employee = "Mpomnpounas", Job = "mhxanikos", finalGrade = (float)2.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpompougnas", Job = "mhxanikos", finalGrade = (float)6.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "cxvMakis", Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.55, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Madfvgdkis", Employee = "Mpgompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makihdfs", Employee = "Mpompgounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpomhpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makhfis", Employee = "Mpomhpggounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makisn", Employee = "Mpomphhgounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Mazkis", Employee = "Mpomhpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Macskis", Employee = "Mpomgbmpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makis", Employee = "Mpompodhunas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Madfdgkis", Employee = "Mphhounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makifgs", Employee = "Mpomhpodhunas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Makgsis", Employee = "Mpompoudnas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            listItems.Add(new EvaluationResultListItem { Evaluator = "Magedsgkis", Employee = "Mpomhpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });



            dataTable.Columns.Add("Evaluator", typeof(String));
            dataTable.Columns.Add("Employee", typeof(String));
            dataTable.Columns.Add("Job", typeof(String));
            dataTable.Columns.Add("IG", typeof(float));
            dataTable.Columns.Add("RG", typeof(float));
            dataTable.Columns.Add("FG", typeof(float));
            dataTable.Columns.Add("Final Grade", typeof(float));
            dataTable.Columns.Add("Interview Comments", typeof(Card));


            foreach (var listItem in listItems)
            {
                dataTable.Rows.Add(listItem);
            }


            //ScrollViewContainer.
            //the fuck?
            var ScrollViewContainer = new ScrollViewer()
            {
                Content = dataTable
            };

            Content = ScrollViewContainer;


            //add all elements into the scroll view + ScrollView = Content !




        }



        #endregion


        #endregion



    }
}
