using System;
using System.Collections.Generic;
using System.Text;

namespace Vaseis.UI.Components.Employees
{
    class DepartmentButtonComponent : DepartmentDataButton
    {
        #region Public Properties

        /// <summary>
        /// The user
        /// </summary>
        public CompanyDataModel Department { get; }

        #endregion

        #region Constructors

        /// <param name="user">The user</param>
        public DepartmentButtonComponent(CompanyDataModel department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));

            DepartmentName = Department.DepartmentName.ToString();
            Background = Department.Color.HexToBrush();
            Height = 150;
        }

        #endregion
    }
    
    
}
