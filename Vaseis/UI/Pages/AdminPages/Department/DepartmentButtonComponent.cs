using System;
using System.Collections.Generic;
using System.Text;
using Vaseis;

namespace VaseiS
{
   public class DepartmentButtonComponent : DepartmentDataButton
    {
        #region Public Properties

        /// <summary>
        /// The DEPARTMENT
        /// </summary>
        public DepartmentDataModel Department { get; }

        #endregion

        #region Constructors

        /// <param name="user">The user</param>
        public DepartmentButtonComponent(DepartmentDataModel department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
            DepartmentName = Department.DepartmentName.ToString();
            Background = Department.Color.HexToBrush();
            Height = 150;
        }

        #endregion
    }
    
    
}
