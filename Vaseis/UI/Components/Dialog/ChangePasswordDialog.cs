using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
using System.Globalization;

namespace Vaseis
{
    public class ChangePasswordDialog : DialogBaseComponent 
    {

        #region Protected Properties

        /// <summary>
        /// The currentPassword
        /// </summary>
        protected string CurrentPasswordDependency{ get; private set; }

        /// <summary>
        /// Old passward Input
        /// </summary>
        protected PasswordBox CurrentPasswordInput { get; private set; }

        /// <summary>
        /// Old passward Input
        /// </summary>
        protected PasswordBox NewPasswordInput { get; private set; }

        /// <summary>
        /// Old passward Input
        /// </summary>
        protected PasswordBox TypeAgainNewPasswordInput { get; private set; }

        /// <summary>
        /// The button that sends the values when user is done
        /// </summary>
        protected Button OkButton { get; private set; }


        #endregion

        #region Dependency Property 

        /// <summary>
        /// This is the password we will get from the database to compare it to th one that the user will give us 
        /// </summary>
        public string CurrentPassword
        {
            get { return (string)GetValue(CurrentPasswordProperty); }
            set { SetValue(CurrentPasswordProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CurrentPassword"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPasswordProperty = DependencyProperty.Register(nameof(CurrentPassword), typeof(string), typeof(ChangePasswordDialog));

        #endregion

        #region Constructors

        public ChangePasswordDialog(UserDataModel user)
        {
            CreateGUI();
        }

        #endregion


        #region Protected Functions



        #endregion


        #region Private Methods
        /// <summary>
        /// Creates and adds the required GUI elements for the change password button
        ///</summary>
        private void CreateGUI()
        {
            //Sets the dialog's title
            DialogTitle.Text = "Change Password";

            //CurrentPasswordDependency

            // we shall compare the database's current password to the one that th euser will give us
            //in this input field

            var HintOldPasswordTitleBlock = new TextBlock()
            {
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 20,
                FontFamily = Calibri,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.Normal,
                TextTrimming = TextTrimming.CharacterEllipsis,
                IsHitTestVisible = false,
                Text = "Current Password"
            };

            CurrentPasswordInput = new PasswordBox()
            {
                // With hint text the name
                Margin = new Thickness(24),
                Width = 240

            };

            var HintNewPasswordTitleBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 20,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                TextTrimming = TextTrimming.CharacterEllipsis,
                IsHitTestVisible = false,
                Text = "New Password"
            };

            NewPasswordInput = new PasswordBox()
            {
                // With hint text the name
                Margin = new Thickness(24),
                Width = 240
            };

            var HintConfirmNewPasswordTitleBlock = new TextBlock()
            {
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 20,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                TextTrimming = TextTrimming.CharacterEllipsis,
                HorizontalAlignment = HorizontalAlignment.Center,
                IsHitTestVisible = false,
                Text = "Confirm Password"
            };

            TypeAgainNewPasswordInput = new PasswordBox()
            {
                // With hint text the name
                Margin = new Thickness(24),
                Width = 240
            };

            var cantChange = new TextBlock()
            {
                Margin = new Thickness(8, 0, 0, 0),
                Foreground = DarkPink.HexToBrush(),
                FontSize = 20,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                TextTrimming = TextTrimming.CharacterEllipsis,
                HorizontalAlignment = HorizontalAlignment.Center,
                IsHitTestVisible = false,
                Text = "Confirm Password"
            };

            //the ok Button

            OkButton = new Button()
            {
                Background = DarkBlue.HexToBrush(),
                Height = 40,
                Width = 164,
                Margin = new Thickness(28),
                Content = new TextBlock()
                {
                    Foreground = White.HexToBrush(),
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "OK"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };

                 //i use a stack panel so that the input fields are set in a column
            var ChangePasswordStackpanel = new StackPanel();

            ChangePasswordStackpanel.Children.Add(HintOldPasswordTitleBlock);
            ChangePasswordStackpanel.Children.Add(CurrentPasswordInput);
            ChangePasswordStackpanel.Children.Add(HintNewPasswordTitleBlock);
            ChangePasswordStackpanel.Children.Add(NewPasswordInput);
            ChangePasswordStackpanel.Children.Add(HintConfirmNewPasswordTitleBlock);
            ChangePasswordStackpanel.Children.Add(TypeAgainNewPasswordInput);


            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += CloseDialogOnClick;

            ChangePasswordStackpanel.Children.Add(OkButton);


            InputWrapPanel.Children.Add(ChangePasswordStackpanel);



            Content = DialogHost;


        }



        #endregion
    }
}
