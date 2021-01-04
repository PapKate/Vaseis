using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    class MyEvaluationsItems { 

    #region Protected Properties

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

    public Button EditIcon { get; set; }

    public Button FinalizeIcon { get; set; }

        #endregion

    }
}
