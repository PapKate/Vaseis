using System.Data;
using System.Windows.Controls;

namespace Vaseis

// tO string?!?!?! String filesGrade?
{
    class EvaluationResults : ContentControl
    {

        #region Protected Properties

        public TextBlock EvaluatorTextBlock { get; set; }

        public TextBlock EmployeeTextBlock { get; set; }

        public TextBlock JobTextBlock { get; set; }

        public TextBlock FinalGradeTextBlock { get; set; }

        public TextBlock IGTextBlock { get; set; }

        public TextBlock RGTextBlock { get; set; }

        public TextBlock FilesTextBlock { get; set; }

        public Expander Details { get; set; }

        public Expander Report { get; set; }

        public Expander InterviewCommentsBlock { get; set; }

        public Button EditIcon { get; set; }

        public Button FinalizeIcon { get; set; }

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
            var pageGrid = new Grid()
            {
                Background = Styles.DarkPink.HexToBrush()
            };

            //var evaluationHeader = new StackPanel()
            //{
            //    Orientation = Orientation.Horizontal,

            //};

            //var dataTable = new DataTable();


            //List<EvaluationResults> listItems = new List<EvaluationResults>();

            //listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpogsrgmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = "8.95", RG = "7.95", FilesGrade = "7.95", Report = "afhafgiusagbsg", InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            //listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpogsrgmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = "8.95", RG = "7.95", FilesGrade = "7.95", Report = "afhafgiusagbsg", InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            //listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpogsrgmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = "8.95", RG = "7.95", FilesGrade = "7.95", Report = "afhafgiusagbsg", InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });
            //listItems.Add(new EvaluationResults { Evaluator = "Makis", Employee = "Mpogsrgmpounas", Job = "mhxanikos", FinalGrade = "8.95", IG = "8.95", RG = "7.95", FilesGrade = "7.95", Report = "afhafgiusagbsg", InterviewComments = "jslvgs vfsfvbsfvxfbdnbdgbdzh,gszrgbzgb g ;osdurgoszdghzs rgszr;og hzsgvz;go  gsodyhig edsgesrpiergif  og rgwgwa;ogwa;ouwsgws;gw;ogwao;gtkhwrfvb " });

            //dataTable.Columns.Add("Evaluator", typeof(string));
            //dataTable.Columns.Add("Employee", typeof(string));
            //dataTable.Columns.Add("Job", typeof(string));
            //dataTable.Columns.Add("IG", typeof(string));
            //dataTable.Columns.Add("RG", typeof(string));
            //dataTable.Columns.Add("FG", typeof(string));
            //dataTable.Columns.Add("Final Grade", typeof(string));
            //dataTable.Columns.Add("Report", typeof(Expander));
            //dataTable.Columns.Add("Interview Comments", typeof(Expander));
            //dataTable.Columns.Add("Edit", typeof(Button));
            //dataTable.Columns.Add("Finalize", typeof(Button));

            //foreach (var listItem in listItems)
            //{
            //    dataTable.Rows.Add(listItem);
            //}


            //var evaluationsDataTable = new DataTable();

            //evaluationsDataTable.Columns.Add("Evaluator", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("Employee", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("Job", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("IG", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("RG", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("FG", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("Final Grade", typeof(TextBlock));
            //evaluationsDataTable.Columns.Add("Report", typeof(Expander));
            //evaluationsDataTable.Columns.Add("Interview Comments", typeof(Expander));
            //evaluationsDataTable.Columns.Add("Details", typeof(Expander));
            //evaluationsDataTable.Columns.Add("Edit", typeof(Button));
            //evaluationsDataTable.Columns.Add("Finalize", typeof(Button));


            //var hmm = new TextBlock()
            //{
            //    Text = "hmmmmmm"
            //};

            //var hmmm = new Expander() {
            //Header = "HFGBSOVGBFSF",      
            //Foreground = Styles.DarkPink.HexToBrush()
            //};
            
            //hmmm.Content = "vsgbvdtjhnzdxnjzdehszehedhjhjndv bs";

            //evaluationsDataTable.Rows.Add(hmm, hmm, hmmm, hmmm,hmmm );

            ////pageGrid.Children.Add(evaluationsDataTable);

            //var datagrid = new DataGrid()
            //{
               
            //    //ItemsSource = evaluationsDataTable.
            //};

            //pageGrid.Children.Add(datagrid);


            //var ScrollViewContainer = new ScrollViewer()
            //{
            //    Content = pageGrid
            //};

            //Content = ScrollViewContainer;

        }

        #endregion
    }
}

