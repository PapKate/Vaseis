using System;
using System.Windows;

namespace Vaseis
{
    public class DepartmentButtonComponent : DataButtonComponent
   {
        #region Public Properties

        /// <summary>
        /// The DEPARTMENT
        /// </summary>
        public DepartmentDataModel Department { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="department">The department</param>
        public DepartmentButtonComponent(DepartmentDataModel department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
            Title = Department.DepartmentName;
            
            Background = Department.Color.HexToBrush();
            Height = 150;

            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Collapses the text's text block
            TextTextBlock.Visibility = Visibility.Collapsed;
        }

        #endregion

    }
}
