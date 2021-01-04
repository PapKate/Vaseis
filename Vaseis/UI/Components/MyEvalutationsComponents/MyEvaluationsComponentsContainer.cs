using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    class MyEvaluationsComponentsContainer
    {
        #region Constructors

        public MyEvaluationsComponentsContainer()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods 

        private void CreateGUI() 
        {

            var ScrollViewContainer = new ScrollViewer();

            var dataTable = new DataTable();


            //  var  EditButton = new CreateEditButton();
            //gia ka8e nea eggrafh 8a ginbetai generate kainourio edit & kainourio finalize button 
            //idios tropos, allos listener provider. But how?



            List<EvaluationResultListItem> listItems = new List<EvaluationResultListItem>
            {
                new EvaluationResultListItem { Employee = "Mpogsrgmpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb ", },
                new EvaluationResultListItem { Employee = "Mpomgrgpounas", Job = "mhxanikos", finalGrade = (float)4, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomposgsgunas", Job = "mhxanikos", finalGrade = (float)8.595, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mgnpompounas", Job = "mhxanikos", finalGrade = (float)0.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpowmpounas", Job = "mhxanikos", finalGrade = (float)3.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompsgggounas", Job = "mhxanikos", finalGrade = (float)1.095, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)3.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomnpounas", Job = "mhxanikos", finalGrade = (float)2.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompougnas", Job = "mhxanikos", finalGrade = (float)6.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.55, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpgompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompgounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomhpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomhpggounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomphhgounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomhpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomgbmpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompodhunas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mphhounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomhpodhunas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpompoudnas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " },
                new EvaluationResultListItem { Employee = "Mpomhpounas", Job = "mhxanikos", finalGrade = (float)8.95, IG = (float)8.95, RG = (float)7.95, FG = (float)4.95, InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " }
            };

            dataTable.Columns.Add("Employee", typeof(String));
            dataTable.Columns.Add("Job", typeof(String));
            dataTable.Columns.Add("IG", typeof(float));
            dataTable.Columns.Add("RG", typeof(float));
            dataTable.Columns.Add("FG", typeof(float));
            dataTable.Columns.Add("Final Grade", typeof(float));
            dataTable.Columns.Add("Interview Comments", typeof(Card));
            dataTable.Columns.Add("Edit", typeof(Button));
            dataTable.Columns.Add("Finalze", typeof(Button));


            foreach (var listItem in listItems)
            {
                dataTable.Rows.Add(listItem);
            }

            var button = ControlsFactory.CreateEditButton();


        }

        #endregion



    }
}
