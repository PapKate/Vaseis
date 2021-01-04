using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class EvaluationResultListItem : ContentControl
    {
        #region Protected Properties

        public String Evaluator { get; set; }

        public String Employee { get; set; }

        public String Job { get; set; }

        public float finalGrade { get; set; }

        ///<summary>
        ///Interview grade
        /// </summary>
        public float IG { get; set; }

        ///<summary>
        ///Reports grade
        /// </summary>
        public float RG { get; set; }

        ///<summary>
        ///Files grade
        /// </summary>
        public float FG { get; set; }

        public String InterviewComments { get; set; }

        #endregion

        #region Constructors

        public EvaluationResultListItem()
        {
        }

        #endregion
    }

}