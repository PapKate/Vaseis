using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    public class JobsDataButton : ContentControl
        {
            #region Protected Properties

            /// <summary>
            /// The stack panel containing a user's name and username
            /// </summary>
            protected StackPanel UserData { get; private set; }

            /// <summary>
            /// The user's username
            /// </summary>
            protected TextBlock UserUsernameText { get; private set; }

            /// <summary>
            /// The user's full name
            /// </summary>
            protected TextBlock UserFullNameText { get; private set; }

            /// <summary>
            /// The button representing a user
            /// </summary>
            protected Button UserButton { get; private set; }

            #endregion

            #region Dependency Properties

            #region Job Title

            /// <summary>
            /// The JOB'S Title
            /// </summary>
            public string JobTitle
            {
                get { return GetValue(JobTitleProperty).ToString(); }
                set { SetValue(JobTitleProperty, value); }
            }

            /// <summary>
            /// Identifies the <see cref="JobTitle"/> dependency property
            /// </summary>
            public static readonly DependencyProperty JobTitleProperty = DependencyProperty.Register(nameof(JobTitle), typeof(string), typeof(JobsDataButton));

          #endregion

          #region Department

          /// <summary>
          /// The user's full name
          /// </summary>
          public string Department
            {
                get { return GetValue(DepartmentProperty).ToString(); }
                set { SetValue(DepartmentProperty, value); }
            }

            /// <summary>
            /// Identifies the <see cref="Department"/> dependency property
            /// </summary>
            public static readonly DependencyProperty DepartmentProperty = DependencyProperty.Register(nameof(Department), typeof(string), typeof(JobsDataButton));

            #endregion

            #endregion

            #region Constructors

            public JobsDataButton()
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
                UserData = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                UserUsernameText = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 28,
                    FontWeight = FontWeights.Bold,
                };

                // Binds the text property of the text block to the Username property
                UserUsernameText.SetBinding(TextBlock.TextProperty, new Binding(nameof(JobTitle))
                {
                    Source = this
                });

                UserFullNameText = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,                 
                    FontSize = 28,
                    FontWeight = FontWeights.Normal,
                };

                // Binds the text property of the text block to the FullName property
                UserFullNameText.SetBinding(TextBlock.TextProperty, new Binding(nameof(Department))
                {
                    Source = this
                });

                UserData.Children.Add(UserFullNameText);

                UserData.Children.Add(this.UserUsernameText);

                UserButton = new Button()
                {
                    Style = MaterialDesignStyles.RaisedButton,
                    Height = double.NaN,
                    Margin = new Thickness(24),
                    Padding = new Thickness(8),
                    BorderThickness = new Thickness(0),
                    Content = UserData
                };

                UserButton.SetBinding(Button.BackgroundProperty, new Binding(nameof(Background))
                {
                    Source = this
                });

                ButtonAssist.SetCornerRadius(UserButton, new CornerRadius(8));

                Content = UserButton;

            }

            #endregion
    }
}
