using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    public class DepartmentDataButton : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The stack panel containing a departments's name 
        /// </summary>
        protected StackPanel DepartmentData { get; private set; }

        /// <summary>
        /// The department's name
        /// </summary>
        protected TextBlock DepartmentText { get; private set; }

        /// <summary>
        /// The button representing a department
        /// </summary>
        protected Button DepartmentButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region Username

        /// <summary>
        /// The user's username
        /// </summary>
        public string DepartmentName
        {
            get { return GetValue(DepartmentNameProperty).ToString(); }
            set { SetValue(DepartmentNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DepartmentName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DepartmentNameProperty = DependencyProperty.Register(nameof(DepartmentName), typeof(string), typeof(DepartmentDataButton));

        #endregion
     

        #endregion

        #region Constructors

        public DepartmentDataButton()
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
            DepartmentData = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            DepartmentText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
            };

            // Binds the text property of the text block to the Username property
            DepartmentText.SetBinding(TextBlock.TextProperty, new Binding(nameof(DepartmentName))
            {
                Source = this
            });


            DepartmentData.Children.Add(this.DepartmentText);

            DepartmentButton = new Button()
            {
                Style = MaterialDesignStyles.RaisedButton,
                Height = double.NaN,
                Margin = new Thickness(24),
                Padding = new Thickness(8),
                BorderThickness = new Thickness(0),
                Content = DepartmentData
            };

            DepartmentButton.SetBinding(Button.BackgroundProperty, new Binding(nameof(Background))
            {
                Source = this
            });

            ButtonAssist.SetCornerRadius(DepartmentButton, new CornerRadius(8));

            Content = DepartmentButton;

        }

        #endregion

    }
}
