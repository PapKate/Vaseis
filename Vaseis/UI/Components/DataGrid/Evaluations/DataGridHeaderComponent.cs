using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;


namespace Vaseis
{
    public class DataGridHeaderComponent : BaseDataGridHeaderComponent
    {
        #region Protected Properties

        /// <summary>
        /// The evaluation's final grade
        /// </summary>
        protected TextBlock EvaluationGradeTextBlock { get; private set; }

        /// <summary>
        /// The report's grade
        /// </summary>
        protected TextBlock ReportGradeTextBlock { get; private set; }

        /// <summary>
        /// The file's grade
        /// </summary>
        protected TextBlock FilesGradeTextBlock { get; private set; }

        /// <summary>
        /// The interview's grade
        /// </summary>
        protected TextBlock InterviewGradeTextBlock { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataGridHeaderComponent()
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
            // Creates and adds the text blocks to the header with text and tool tip
            EvaluationGradeTextBlock = CreateHeaderTextBlock(4, "E.G.", "Evaluations grade");
            ReportGradeTextBlock = CreateHeaderTextBlock(5, "R.G.", "Report's grade");
            FilesGradeTextBlock = CreateHeaderTextBlock(6, "F.G.", "File's grade");
            InterviewGradeTextBlock = CreateHeaderTextBlock(7, "I.G.", "Interview's grade");

            // Sets the component's content as the header border
            Content = HeaderBorder;
        }

        #endregion

    }
}
