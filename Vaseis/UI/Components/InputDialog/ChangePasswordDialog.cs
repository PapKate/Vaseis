using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    public class ChangePasswordDialog : DialogBaseComponent
    {

        #region Protected Properties

        /// <summary>
        /// Old passward Input
        /// </summary>
        protected TextInputComponent OldPasswordInput { get; private set; }

        /// <summary>
        /// Old passward Input
        /// </summary>
        protected TextInputComponent NewPasswordInput { get; private set; }

        /// <summary>
        /// Old passward Input
        /// </summary>
        protected TextInputComponent TypeAgainNewPasswordInput { get; private set; }

        /// <summary>
        /// The button that sends the values when user is done
        /// </summary>
        protected Button OkButton { get; private set; }

        #endregion

        #region Constructors

        public ChangePasswordDialog()
        {
            CreateGUI();
        }

        #endregion



        #region Private Methods
        /// <summary>
        /// Creates and adds the required GUI elements for the change password button
        ///</summary>
        private void CreateGUI()
        {
            //Sets the dialog's title
            DialogTitle.Text = "Change Password";



            OldPasswordInput = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Old password",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
          //  InputWrapPanel.Children.Add(OldPasswordInput);

            NewPasswordInput = new TextInputComponent()
            {
                // With hint text the name
                HintText = "New password",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
           // InputWrapPanel.Children.Add(NewPasswordInput);

            TypeAgainNewPasswordInput = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Verify new password",
                Margin = new Thickness(24),
                Width = 240
            };
            // And adds it to the dialog's input wrap panel
           /// InputWrapPanel.Children.Add(TypeAgainNewPasswordInput);

            //i use a stack panel so that the input fields are set in a column
            var ChangePasswordStackpanel = new StackPanel();

            ChangePasswordStackpanel.Children.Add(OldPasswordInput);
            ChangePasswordStackpanel.Children.Add(NewPasswordInput);
            ChangePasswordStackpanel.Children.Add(TypeAgainNewPasswordInput);


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
